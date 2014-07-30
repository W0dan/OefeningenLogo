using System;
using System.Drawing;
using System.IO;
using PdfCraft.API;
using PdfCraft.Fonts;

namespace OefeningenLogo.Service
{
    public class PdfGenerator : IGeneratePdfs
    {
        private Document _doc;
        private Page _page;
        private TextBox _text;
        private DateTime _datum;
        private readonly string _pdfPath;

        public PdfGenerator(string pdfPath)
        {
            _pdfPath = pdfPath;
        }

        public void InitializePage(DateTime datum)
        {
            _doc = new Document();
            _page = _doc.AddPage();

            var headertext = _doc.CreateTextBox(new Rectangle(0, 0, 50, 50));
            headertext.Position = new Point(400, 20);
            headertext.SetFont(new FontProperties("Helvetica", 10));
            _datum = datum;
            headertext.AddText("Afgedrukt op " + _datum.ToString("dd MMMM yyyy"));
            headertext.AddText("Ingevuld op           " + _datum.ToString("MMMM yyyy"));
            _page.AddTextBox(headertext);


            _text = _doc.CreateTextBox(new Rectangle(0, 0, 160, 50));

            _text.SetColor(Color.Black);
            _text.Position = new Point(40, 20);
        }

        public void AddLine(string line)
        {
            _text.SetFont(new FontProperties("Helvetica", 15), true);
            _text.AddText(line + "\n");
            _text.SetFont(new FontProperties("Helvetica", 5), true);
            _text.AddText("\n");
        }

        public void Write()
        {
            _page.AddTextBox(_text);

            var pdf = _doc.Generate();

            Directory.CreateDirectory(_pdfPath);

            const string pathTemplate = @"{0}\oefeningen_{1:yyyyMMdd}_{2}.pdf";
            var nummer = 1;
            var path = string.Format(pathTemplate,_pdfPath,_datum,nummer); //_pdfPath + @"\oefeningen_" + _datum.ToString("yyyyMMdd") + ".pdf";
            while(File.Exists(path))
            {
                nummer++;
                path = string.Format(pathTemplate, _pdfPath, _datum, nummer); //_pdfPath + @"\oefeningen_" + _datum.ToString("yyyyMMdd") + ".pdf";
            }

            using (var fs = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(pdf, 0, pdf.Length);
            }
        }
    }
}