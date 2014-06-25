using System;
using System.Collections.Generic;
using System.IO;

namespace OefeningenLogo
{
    public class OefeningenProvider
    {
        private readonly string _logoPath;

        public OefeningenProvider(string logoPath)
        {
            _logoPath = logoPath;
        }

        public OefeningenDefinitieSet GetNieuweOefening(string tokenString)
        {
            return new OefeningenDefinitieSet(new List<string>(), new GetalSetDefinitie(tokenString));
        }

        public OefeningenDefinitieSet GetOefening(string typeOefening)
        {
            var filename = Path.Combine(_logoPath, typeOefening + ".dat");
            using (var fs = File.OpenRead(filename))
                return GetOefening(fs);

        }

        public void SaveOefening(string filename, OefeningenDefinitieSet set)
        {
            using (var fs = File.Open(filename, FileMode.Create, FileAccess.Write))
            using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine("[getalset]");
                sw.WriteLine(set.GetalSetDefinitie.TokenString);
                sw.WriteLine("[getal]");
                foreach (var getalDefinitie in set.GetalDefinities)
                {
                    sw.WriteLine(getalDefinitie.ToString("|"));
                }
                sw.WriteLine("[oefening]");
                foreach (var oefening in set.Oefeningen)
                {
                    sw.WriteLine(oefening);
                }
            }
        }

        private static OefeningenDefinitieSet GetOefening(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var typeOefeningen = new OefeningenDefinitieSet();
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
                return typeOefeningen;
            }
        }
    }
}