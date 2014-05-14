using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OefeningenLogo
{
    public partial class MaakOefeningen : Form
    {
        private OefeningenGenerator _oefeningenGenerator;

        private int _andereOefeningenCounter = 1;
        private string _pdfPath;
        private OefeningenDefinitieSet _typeOefeningen;
        private bool _comboboxChanging;
        private const string LogoPath = @"c:\temp\logo\";

        public MaakOefeningen()
        {
            InitializeComponent();
        }

        private void MaakOefeningen_Load(object sender, EventArgs e)
        {
            _pdfPath = Path.Combine(LogoPath, DateTime.Now.ToString("yyyyMMdd"));
            _oefeningenGenerator = new OefeningenGenerator(_pdfPath, LogoPath);

            TypeOefeningCombobox.Items.Add(TypeOefeningen.Type1);
            TypeOefeningCombobox.Items.Add(TypeOefeningen.Type2);
            TypeOefeningCombobox.Items.Add(TypeOefeningen.Type3);

            Directory.CreateDirectory(LogoPath);
            var di = new DirectoryInfo(LogoPath);
            foreach (var fileInfo in di.GetFiles("*.dat"))
            {
                TypeOefeningCombobox.Items.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length - 4));
            }

            TypeOefeningCombobox.Items.Add(TypeOefeningen.Andere);
            TypeOefeningCombobox.SelectedItem = TypeOefeningCombobox.Items[0];
        }

        private void TypeOefeningCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboboxChanging = true;

            AndereOefeningenTextbox.Visible = false;

            _typeOefeningen = GetTypeOefeningen();

            OefeningenTextbox.Text = "";
            foreach (var oefening in _typeOefeningen.Oefeningen)
            {
                OefeningenTextbox.Text += oefening + "\r\n";
            }
            GetalDefinitiesListbox.Items.Clear();
            foreach (var getaldefinitie in _typeOefeningen.GetalDefinities)
            {
                GetalDefinitiesListbox.Items.Add(getaldefinitie);
            }

            _comboboxChanging = false;
        }

        private OefeningenDefinitieSet GetTypeOefeningen()
        {
            if (!(TypeOefeningCombobox.SelectedItem is TypeOefeningen))
                return _oefeningenGenerator.GetOefening((string)TypeOefeningCombobox.SelectedItem);

            var typeOefening = (TypeOefeningen)TypeOefeningCombobox.SelectedItem;
            if (typeOefening == TypeOefeningen.Andere)
            {
                AndereOefeningenTextbox.Text = "Andere oefeningen " + _andereOefeningenCounter;
                AndereOefeningenTextbox.Visible = true;
            }
            return _oefeningenGenerator.GetOefening(typeOefening);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var startdatum = StartDatumDateTimePicker.Value;
            var einddatum = EindDatumDateTimePicker.Value;
            try
            {
                _oefeningenGenerator.MaakOefeningenLogo(startdatum, einddatum, _typeOefeningen);

                var options = string.Format(@"/select, ""{0}\oefeningen_{1:yyyyMMdd}.pdf""", _pdfPath, startdatum);
                Process.Start("explorer.exe", options);

                if (!(TypeOefeningCombobox.SelectedItem is TypeOefeningen) ||
                    (TypeOefeningen)TypeOefeningCombobox.SelectedItem != TypeOefeningen.Andere)
                    return;

                var andereOefeningen = AndereOefeningenTextbox.Text;
                var filename = Path.Combine(LogoPath, andereOefeningen + ".dat");
                using (var fs = File.Open(filename, FileMode.Create, FileAccess.Write))
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("[getal]");
                    foreach (var getalDefinitie in _typeOefeningen.GetalDefinities)
                    {
                        sw.WriteLine(getalDefinitie.ToString("|"));
                    }
                    sw.WriteLine("[oefening]");
                    foreach (var oefening in _typeOefeningen.Oefeningen)
                    {
                        sw.WriteLine(oefening);
                    }
                }
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
            _typeOefeningen.SetOefeningen(oefeningen);
        }

        private void GetalDefToevoegenButton_Click(object sender, EventArgs e)
        {
            var g = "|" + LaagsteTextbox.Text + "|" + HoogsteTextbox.Text + "|" + CijfersNaDeKommaTextbox.Text;
            var getalDefinitie = _typeOefeningen.GetaldefinitieToevoegen(g);
            GetalDefinitiesListbox.Items.Add(getalDefinitie);
        }
    }
}
