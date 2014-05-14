using System;
using System.Collections.Generic;
using System.IO;

namespace OefeningenLogo
{
    public enum TypeOefeningen
    {
        Type1,
        Type2,
        Andere,
        Type3
    }

    public class OefeningenGenerator
    {
        private readonly string _pdfPath;
        private readonly string _logoPath;

        public OefeningenGenerator(string pdfPath, string logoPath)
        {
            _pdfPath = pdfPath;
            _logoPath = logoPath;
        }

        public void MaakOefeningenLogo(DateTime startdatum, DateTime einddatum, OefeningenDefinitieSet oefeningenDefinitieSet)
        {
            einddatum = einddatum.AddDays(1);
            for (var datum = startdatum; datum < einddatum; datum = datum.AddDays(1))
                MaakOefeningenblad(datum, oefeningenDefinitieSet);
        }

        private void MaakOefeningenblad(DateTime datum, OefeningenDefinitieSet oefeningenDefinitieSet)
        {
            var oefeningenBlad = new PdfGenerator(datum, _pdfPath);

            var oefeningen = oefeningenDefinitieSet.GetOefeningen(25);
            foreach (var oefening in oefeningen)
            {
                oefeningenBlad.AddLine(oefening);
            }
            oefeningenBlad.Write();
        }

        public OefeningenDefinitieSet GetOefening(string typeOefening)
        {
            var typeOefeningen = new OefeningenDefinitieSet();
            var filename = Path.Combine(_logoPath, typeOefening + ".dat");
            using (var fs = File.OpenRead(filename))
            using (var sr = new StreamReader(fs))
            {
                var readModus = ReadModus.None;
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line == "[getal]")
                    {
                        readModus = ReadModus.Getal;
                        continue;
                    }
                    if (line == "[oefening]")
                    {
                        readModus = ReadModus.Oefening;
                        continue;
                    }
                    if (line == "[getalset]")
                    {
                        readModus = ReadModus.GetalSet;
                        continue;
                    }

                    switch (readModus)
                    {
                        case ReadModus.None:
                            break;
                        case ReadModus.Getal:
                            typeOefeningen.GetaldefinitieToevoegen(line);
                            break;
                        case ReadModus.Oefening:
                            typeOefeningen.OefeningToevoegen(line);
                            break;
                        case ReadModus.GetalSet:
                            typeOefeningen.GetalSetInstellen(line);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return typeOefeningen;
        }

        public OefeningenDefinitieSet GetOefening(TypeOefeningen typeOefeningen)
        {
            switch (typeOefeningen)
            {
                case TypeOefeningen.Type1:
                    return GetOefeningenType1();
                case TypeOefeningen.Type2:
                    return GetOefeningenType2();
                case TypeOefeningen.Type3:
                    return GetOefeningenType3();
                case TypeOefeningen.Andere:
                    return new OefeningenDefinitieSet(new List<GetalDefinitie>(), new List<string>());
                default:
                    throw new ArgumentOutOfRangeException("typeOefeningen");
            }
        }

        private OefeningenDefinitieSet GetOefeningenType3()
        {
            var typeOefeningen = new List<string>
                                     {
                                         "{0} + {1} =    .",
                                         "    .    + {1} = {2}",
                                         "{0} +    .    = {2}",
                                     };
            var getallen = new List<GetalDefinitie>
                               {
                                   new GetalDefinitie("{0}", 0, 1000),
                                   new GetalDefinitie("{1}", 0, 1000),
                                   new GetalDefinitie("{2}", true),
                               };

            var getalsetDef = new GetalSetDefinitie(getallen, "{0} + {1}");

            return new OefeningenDefinitieSet(getallen, typeOefeningen, getalsetDef);
        }

        private static OefeningenDefinitieSet GetOefeningenType1()
        {
            var typeOefeningen = new List<string>
                              {
                                  "net voor {0} komt  .",
                                  "net na {0} komt  .",
                                  "{0} komt net voor  .",
                                  "{0} komt net na  .",
                                  "net voor  .  komt {0}",
                                  "net na  .  komt {0}",
                                  "  .  komt net voor {0}",
                                  "  .  komt net na {0}",
                              };
            return new OefeningenDefinitieSet(new List<GetalDefinitie> { new GetalDefinitie("{0}", 0, 1000) }, typeOefeningen);
        }

        private static OefeningenDefinitieSet GetOefeningenType2()
        {
            var typeOefeningen = new List<string>
                              {
                                  "Het kleinste even getal groter dan {0} =  .",
                                  "Het kleinste oneven getal groter dan {0} =  .",
                                  "Het grootste even getal kleiner dan {0} =  .",
                                  "Het grootste oneven getal kleiner dan {0} =  .",
                              };
            return new OefeningenDefinitieSet(new List<GetalDefinitie> { new GetalDefinitie("{0}", 0, 1000) }, typeOefeningen);
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