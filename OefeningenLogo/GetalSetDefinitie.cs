using System;
using System.Collections.Generic;

namespace OefeningenLogo
{
    public class GetalSetDefinitie
    {
        private string _tokenstring;
        private readonly List<GetalDefinitie> _getalDefinities;

        public GetalSetDefinitie(string tokenstring)
        {
            _getalDefinities = new List<GetalDefinitie>();
            _tokenstring = tokenstring;
        }

        public GetalDefinitie GetaldefinitieToevoegen(string getalDefinitie)
        {
            var getalComponenten = getalDefinitie.Split('|');

            var name = getalComponenten[0];

            if (getalDefinitie.Contains("result"))
                return new GetalDefinitie(name, true);

            int minValue;
            int maxValue;
            uint cijfersNaDeKomma;

            if (int.TryParse(getalComponenten[1], out minValue)
                && int.TryParse(getalComponenten[2], out maxValue)
                && uint.TryParse(getalComponenten[3], out cijfersNaDeKomma))
            {
                return string.IsNullOrWhiteSpace(name)
                    ? GetaldefinitieToevoegen(minValue, maxValue, cijfersNaDeKomma)
                    : GetaldefinitieToevoegen(name, minValue, maxValue, cijfersNaDeKomma);
            }

            return null;
        }

        public GetalDefinitie GetaldefinitieToevoegen(int minValue, int maxValue, uint cijfersNaDeKomma)
        {
            var g = new GetalDefinitie("{" + (_getalDefinities.Count).ToString("0") + "}", minValue, maxValue, cijfersNaDeKomma);
            _getalDefinities.Add(g);
            return g;
        }

        private GetalDefinitie GetaldefinitieToevoegen(string name, int minValue, int maxValue, uint cijfersNaDeKomma)
        {
            var g = new GetalDefinitie(name, minValue, maxValue, cijfersNaDeKomma);
            _getalDefinities.Add(g);
            return g;
        }

        public void GetaldefinitieToevoegen(GetalDefinitie getal)
        {
            _getalDefinities.Add(getal);
        }

        public IEnumerable<GetalDefinitie> GetalDefinities
        {
            get { return _getalDefinities; }
        }

        public void SetTokenString(string tokenString)
        {
            _tokenstring = tokenString;
        }

        public string TokenString
        {
            get { return _tokenstring; }
        }

        public GetalSet Generate(Random random)
        {
            var getalSet = new GetalSet();
            var code = _tokenstring;

            foreach (var getalDefinitie in _getalDefinities)
            {
                if (getalDefinitie.IsResult)
                    continue;

                var getal = getalDefinitie.GetGetal(random);
                getalSet.AddGetal(getal);

                code = code.Replace(getalDefinitie.Name, getal.ToString() + "M");
            }

            var result = ExpressionExecutor.Execute(code);
            getalSet.AddGetal(result.Value);

            return getalSet;
        }

        public List<decimal> Generate(int aantal)
        {
            var code = _tokenstring;

            foreach (var getalDefinitie in _getalDefinities)
            {
                if (getalDefinitie.IsResult)
                    continue;

                var getal = getalDefinitie.GetGetal();

                code = code.Replace(getalDefinitie.Name, getal);
            }

            var result = ExpressionExecutor.Execute(code, aantal);

            return result;
        }
    }
}