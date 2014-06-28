using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.CSharp;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo
{
    public partial class MaakOefeningen : Form
    {
        private int _andereOefeningenCounter = 1;
        private OefeningenDefinitieSet _selectedOefeningenDefinitieSet;
        private bool _comboboxChanging;
        private const string LogoPath = @"c:\temp\logo\";

        public MaakOefeningen()
        {
            InitializeComponent();
        }

        private void MaakOefeningen_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(LogoPath);
            var di = new DirectoryInfo(LogoPath);
            foreach (var fileInfo in di.GetFiles("*.dat"))
            {
                TypeOefeningCombobox.Items.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length - 4));
            }

            TypeOefeningCombobox.Items.Add("nieuw");
            TypeOefeningCombobox.SelectedItem = TypeOefeningCombobox.Items[0];
        }

        private void TypeOefeningCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboboxChanging = true;

            AndereOefeningenTextbox.Visible = false;

            _selectedOefeningenDefinitieSet = GetTypeOefeningen();

            OefeningenTextbox.Text = "";
            foreach (var oefening in _selectedOefeningenDefinitieSet.Oefeningen)
            {
                OefeningenTextbox.Text += oefening + "\r\n";
            }
            GetalDefinitiesListbox.Items.Clear();
            foreach (var getaldefinitie in _selectedOefeningenDefinitieSet.GetalDefinities)
            {
                GetalDefinitiesListbox.Items.Add(getaldefinitie);
            }
            VerbandTextbox.Text = _selectedOefeningenDefinitieSet.GetalSetDefinitie.TokenString;

            _comboboxChanging = false;
        }

        private OefeningenDefinitieSet GetTypeOefeningen()
        {
            if ((string)TypeOefeningCombobox.SelectedItem != "nieuw")
                return new OefeningenProvider(LogoPath).GetOefening((string)TypeOefeningCombobox.SelectedItem);

            AndereOefeningenTextbox.Text = "Nieuwe oefeningen " + _andereOefeningenCounter;
            AndereOefeningenTextbox.Visible = true;
            return new OefeningenProvider(LogoPath).GetNieuweOefening(VerbandTextbox.Text);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var startdatum = StartDatumDateTimePicker.Value;
            var einddatum = EindDatumDateTimePicker.Value;
            try
            {
                var pdfPath = Path.Combine(LogoPath, DateTime.Now.ToString("yyyyMMdd"));
                var pdfGenerator = new PdfGenerator(pdfPath);
                var oefeningenGenerator = new OefeningenGenerator(pdfGenerator);

                oefeningenGenerator.MaakOefeningenLogo(startdatum, einddatum, _selectedOefeningenDefinitieSet);

                try
                {
                    oefeningenGenerator.Test(startdatum, einddatum, _selectedOefeningenDefinitieSet);
                }
                catch (Exception)
                {
                    //mute exception
                }

                var options = string.Format(@"/select, ""{0}\oefeningen_{1:yyyyMMdd}.pdf""", pdfPath, startdatum);
                Process.Start("explorer.exe", options);

                if ((string)TypeOefeningCombobox.SelectedItem != "nieuw")
                    return;

                var nieuweOefening = AndereOefeningenTextbox.Text;
                var filename = Path.Combine(LogoPath, nieuweOefening + ".dat");

                var oefeningenProvider = new OefeningenProvider(LogoPath);
                oefeningenProvider.SaveOefening(filename, _selectedOefeningenDefinitieSet);
                _andereOefeningenCounter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er zit een foutje in de oefeningen:\r\n" + ex.Message, "fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OefeningenTextbox_TextChanged(object sender, EventArgs e)
        {
            if (_comboboxChanging)
                return;

            var oefeningen = OefeningenTextbox.Text.Split(new[] { "\r\n" }, StringSplitOptions.None)
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToList();
            _selectedOefeningenDefinitieSet.SetOefeningen(oefeningen);
        }

        private void GetalDefToevoegenButton_Click(object sender, EventArgs e)
        {
            var g = "|" + LaagsteTextbox.Text + "|" + HoogsteTextbox.Text + "|" + CijfersNaDeKommaTextbox.Text;
            var getalDefinitie = _selectedOefeningenDefinitieSet.GetaldefinitieToevoegen(g);
            GetalDefinitiesListbox.Items.Add(getalDefinitie);
        }

        private void VerbandTextbox_TextChanged(object sender, EventArgs e)
        {
            _selectedOefeningenDefinitieSet.GetalSetDefinitie.SetTokenString(VerbandTextbox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eg = new ExerciseGenerator();

            var result = eg.Generate();

            foreach (var item in result)
            {
                Debug.WriteLine(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string xmlFilename = @"C:\Temp\logo\exercises.xml";

            using (var fs = File.OpenRead(xmlFilename))
            {
                using (var sr = new StreamReader(fs))
                {
                    var xml = sr.ReadToEnd();
                    var doc = XDocument.Parse(xml);

                    var allConstraintsXml = from c in doc.Descendants("constraints").First().Descendants("constraint")
                                         select c;

                    var allConstraints = new Dictionary<string, IConstraint>();
                    foreach (var constraintXml in allConstraintsXml)
                    {
                        var name = constraintXml.Attribute("name").Value;
                        var value = constraintXml.Attribute("value").Value;

                        allConstraints.Add(name, BuildConstraint(value));
                    }

                    var exercisesXml = from ex in doc.Descendants("exercise")
                                       select ex;

                    foreach (var exerciseXml in exercisesXml)
                    {
                        var exercise = new ExerciseDefinition(exerciseXml.Attribute("name").Value, new ExerciseTemplate(exerciseXml.Attribute("template").Value));

                        var numbersXml = from n in exerciseXml.Descendants("numbers").First().Descendants("number")
                                         select n;

                        foreach (var number in numbersXml)
                        {
                            var minValue = int.Parse(number.Attribute("minvalue").Value);
                            var maxValue = int.Parse(number.Attribute("maxvalue").Value);
                            var decimals = int.Parse(number.Attribute("decimals").Value);
                            exercise.AddNumberDefinition(new NumberDefinition("", minValue, maxValue, decimals));
                        }

                        var constraintsRoot = exerciseXml.Descendants("constraints").FirstOrDefault();
                        if (constraintsRoot != null)
                        {
                            var constraintsXml = from c in constraintsRoot.Descendants("constraint")
                                                 select c;

                            foreach (var constraint in constraintsXml)
                            {
                                var constraintName = constraint.Attribute("type").Value;

                                exercise.AddConstraint(allConstraints[constraintName]);
                            }
                        }
                    }

                }
            }
        }

        private IConstraint BuildConstraint(string value)
        {
            var definition =
                string.Format(@"public class Constraint : OefeningenLogo.Oefeningen.IAmAConstraint
{{
    public bool IsValid(params decimal[] numbers)
    {{
        return {0};
    }}
}}", value);

            var csCompiler = new CSharpCodeProvider();
            var compilerParameters = new CompilerParameters
                                         {
                                             GenerateInMemory = true,
                                             GenerateExecutable = false
                                         };
            var location = Assembly.GetExecutingAssembly().Location;
            compilerParameters.ReferencedAssemblies.Add(location);
            var results = csCompiler.CompileAssemblyFromSource(compilerParameters, new[] { definition });

            IConstraint constraint = null;

            if (results.Errors.Count == 0)
            {
                var assembly = results.CompiledAssembly;
                constraint = assembly.CreateInstance("Constraint") as IConstraint;
            }

            return constraint;
        }
    }
}
