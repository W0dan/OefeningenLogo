using System.Collections.Generic;
using System.Linq;

namespace OefeningenLogo
{
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