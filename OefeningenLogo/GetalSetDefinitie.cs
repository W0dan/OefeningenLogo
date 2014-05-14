using System;
using System.Collections.Generic;
using System.Linq;

namespace OefeningenLogo
{
    public class GetalSetDefinitie
    {
        private readonly string _tokenstring;
        private readonly List<GetalDefinitie> _getallen;

        public GetalSetDefinitie(IEnumerable<GetalDefinitie> getallen, string tokenstring)
        {
            _getallen = getallen.ToList();
            _tokenstring = tokenstring;
        }

        public void AddGetal(GetalDefinitie getal)
        {
            _getallen.Add(getal);
        }

        public GetalSet Generate(Random random)
        {
            var getalSet = new GetalSet();
            var code = _tokenstring;

            foreach (var getalDefinitie in _getallen)
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
    }

    public class GetalSet
    {
        private readonly List<decimal> _getallen;

        public GetalSet()
        {
            _getallen = new List<decimal>();
        }

        public void AddGetal(decimal getal)
        {
            _getallen.Add(getal);
        }

        public object[] GetGetallen()
        {
            return _getallen.Select(g => (object)g).ToArray();
        }
    }
}