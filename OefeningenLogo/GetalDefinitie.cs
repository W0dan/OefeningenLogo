using System;

namespace OefeningenLogo
{
    public class GetalDefinitie
    {
        private readonly string _name;
        private readonly bool _isResult;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly uint _cijfersNaDeKomma;

        public GetalDefinitie(string name, bool isResult)
        {
            _name = name;
            _isResult = isResult;
        }

        public GetalDefinitie(string name, int minValue, int maxValue)
            : this(name, minValue, maxValue, 0)
        {
        }

        public GetalDefinitie(string name, int minValue, int maxValue, uint cijfersNaDeKomma)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _name = name;
            _cijfersNaDeKomma = cijfersNaDeKomma;
        }

        public string Name
        {
            get { return _name; }
        }

        public decimal GetGetal(Random random)
        {
            if (_cijfersNaDeKomma == 0)
                return random.Next(_minValue, _maxValue);
            
            var minValue = _minValue*(int) Math.Pow(10, _cijfersNaDeKomma);
            var maxValue = _maxValue*(int) Math.Pow(10, _cijfersNaDeKomma);
            return random.Next(minValue, maxValue)/(decimal) Math.Pow(10, _cijfersNaDeKomma);
        }

        public string GetGetal()
        {
            if (_cijfersNaDeKomma == 0)
                return string.Format("random.Next({0}, {1}) ", _minValue, _maxValue);

            var minValue = _minValue * (int)Math.Pow(10, _cijfersNaDeKomma);
            var maxValue = _maxValue * (int)Math.Pow(10, _cijfersNaDeKomma);
            return string.Format("random.Next({0}, {1})/{2}M", minValue, maxValue, (decimal)Math.Pow(10, _cijfersNaDeKomma));
        }

        public bool IsResult
        {
            get { return _isResult; }
        }

        public string ToString(string separator)
        {
            return _name + separator + _minValue + separator + _maxValue + separator + _cijfersNaDeKomma;
        }

        public override string ToString()
        {
            return ToString(" ");
        }
    }
}