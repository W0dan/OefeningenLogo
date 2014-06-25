using System;

namespace OefeningenLogo
{
    public class OefeningenGenerator
    {
        private readonly IGeneratePdfs _pdfGenerator;

        public OefeningenGenerator(IGeneratePdfs pdfGenerator)
        {
            _pdfGenerator = pdfGenerator;
        }

        public void MaakOefeningenLogo(DateTime startdatum, DateTime einddatum, IOefeningenDefinitieSet oefeningenDefinitieSet)
        {
            einddatum = einddatum.AddDays(1);
            for (var datum = startdatum; datum < einddatum; datum = datum.AddDays(1))
                MaakOefeningenblad(datum, oefeningenDefinitieSet);
        }

        private void MaakOefeningenblad(DateTime datum, IOefeningenDefinitieSet oefeningenDefinitieSet)
        {
            _pdfGenerator.InitializePage(datum);

            var oefeningen = oefeningenDefinitieSet.GetOefeningen(25);
            foreach (var oefening in oefeningen)
            {
                _pdfGenerator.AddLine(oefening);
            }
            _pdfGenerator.Write();
        }

        public void Test(DateTime startdatum, DateTime einddatum, OefeningenDefinitieSet oefeningenDefinitieSet)
        {
            var oefeningen = oefeningenDefinitieSet.Test(25);
        }
    }

    public enum ReadModus
    {
        None,
        Getal,
        Oefening,
        GetalSet
    }
}