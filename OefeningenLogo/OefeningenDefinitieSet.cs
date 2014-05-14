using System;
using System.Collections.Generic;
using System.Linq;

namespace OefeningenLogo
{
    public class OefeningenDefinitieSet
    {
        private readonly Random _random = new Random();
        private GetalSetDefinitie _getalSetDefinitie;
        private readonly List<GetalDefinitie> _getalDefinities;
        private List<string> _oefeningen;

        public OefeningenDefinitieSet()
        {
            _getalDefinities = new List<GetalDefinitie>();
            _getalSetDefinitie = null;
            _oefeningen = new List<string>();
        }

        public OefeningenDefinitieSet(List<GetalDefinitie> getalDefinities, List<string> oefeningen, GetalSetDefinitie getalsetDef = null)
        {
            _getalDefinities = getalDefinities;
            _getalSetDefinitie = getalsetDef;
            _oefeningen = oefeningen;
        }

        public IEnumerable<string> Oefeningen
        {
            get { return _oefeningen.ToList(); }
        }

        public IEnumerable<GetalDefinitie> GetalDefinities
        {
            get { return _getalDefinities.ToList(); }
        }

        public void SetOefeningen(List<string> oefeningen)
        {
            _oefeningen = oefeningen;
        }

        public List<string> GetOefeningen(int aantal)
        {
            var result = new List<string>();

            for (var i = 0; i < aantal; i++)
            {
                result.Add((i + 1).ToString("0") + ".  " + GetOefening());
            }

            return result;
        }

        public void OefeningToevoegen(string line)
        {
            _oefeningen.Add(line);
        }

        public GetalDefinitie GetaldefinitieToevoegen(string getalDefinitie)
        {
            var getalComponenten = getalDefinitie.Split('|');

            var name = getalComponenten[0];

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
            if (_getalSetDefinitie != null)
                _getalSetDefinitie.AddGetal(g);
            return g;
        }

        private GetalDefinitie GetaldefinitieToevoegen(string name, int minValue, int maxValue, uint cijfersNaDeKomma)
        {
            var g = new GetalDefinitie(name, minValue, maxValue, cijfersNaDeKomma);
            _getalDefinities.Add(g);
            if (_getalSetDefinitie != null)
                _getalSetDefinitie.AddGetal(g);
            return g;
        }

        private string GetOefening()
        {
            var oefening = _oefeningen[_random.Next(0, _oefeningen.Count)];

            var getallen = _getalDefinities
                .Select(getalDefinitie => (object)getalDefinitie.GetGetal(_random))
                .ToArray();

            //TODO bovenstaande in comment en onderstaande uit comment om met getalsets te werken
            //var getalset = _getalSetDefinitie.Generate(_random);
            //var getallen = getalset.GetGetallen();

            return string.Format(oefening, getallen);
        }

        public void GetalSetInstellen(string line)
        {
            _getalSetDefinitie = new GetalSetDefinitie(_getalDefinities, line);
        }
    }
}