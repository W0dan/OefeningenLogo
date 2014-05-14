using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

            _comboboxChanging = false;
        }

        private OefeningenDefinitieSet GetTypeOefeningen()
        {
            if ((string)TypeOefeningCombobox.SelectedItem != "nieuw")
                return new OefeningenProvider(LogoPath).GetOefening((string)TypeOefeningCombobox.SelectedItem);

            AndereOefeningenTextbox.Text = "Nieuwe oefeningen " + _andereOefeningenCounter;
            AndereOefeningenTextbox.Visible = true;
            return new OefeningenProvider(LogoPath).GetNieuweOefening();
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
    }
}
