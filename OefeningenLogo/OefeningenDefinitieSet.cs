using System;
using System.Collections.Generic;
using System.Linq;

namespace OefeningenLogo
{
    public interface IOefeningenDefinitieSet
    {
        List<string> GetOefeningen(int aantal);
    }

    public class OefeningenDefinitieSet : IOefeningenDefinitieSet
    {
        private readonly Random _random = new Random();
        private GetalSetDefinitie _getalSetDefinitie;
        private List<string> _oefeningen;

        public OefeningenDefinitieSet()
        {
            _getalSetDefinitie = null;
            _oefeningen = new List<string>();
        }

        public OefeningenDefinitieSet(List<string> oefeningen, GetalSetDefinitie getalsetDef)
        {
            _getalSetDefinitie = getalsetDef;
            _oefeningen = oefeningen;
        }

        public IEnumerable<string> Oefeningen
        {
            get { return _oefeningen.ToList(); }
        }

        public IEnumerable<GetalDefinitie> GetalDefinities
        {
            get { return _getalSetDefinitie.GetalDefinities; }
        }

        public GetalSetDefinitie GetalSetDefinitie
        {
            get { return _getalSetDefinitie; }
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
            return _getalSetDefinitie.GetaldefinitieToevoegen(getalDefinitie);
        }

        private string GetOefening()
        {
            var oefening = _oefeningen[_random.Next(0, _oefeningen.Count)];

            var getalset = _getalSetDefinitie.Generate(_random);
            var getallen = getalset.GetGetallen();

            return string.Format(oefening, getallen);
        }

        public void GetalSetInstellen(string line)
        {
            _getalSetDefinitie = new GetalSetDefinitie(line);
        }
    }
}