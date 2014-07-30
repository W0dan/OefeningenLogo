using System;
using OefeningenLogo.Service;

namespace OefeningenLogo.Oefeningen
{
    public class NumberDefinition : INumberDefinition
    {
        public string Name { get; private set; }
        public int Decimals { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public NumberDefinition(string name, int minValue, int maxValue, int decimals = 0)
        {
            Name = name;
            Decimals = decimals;
            MinValue = minValue;
            MaxValue = maxValue;
        }


        public decimal GetNumber(IProvideRandomNumbers randomNumberGenerator)
        {
            var generatedNumber = randomNumberGenerator.GetRandomNumber(MinValue, MaxValue);

            return generatedNumber / (decimal)Math.Pow(10, Decimals);
        }

        public override string ToString()
        {
            var decimals = "";
            if (Decimals > 0)
            {
                decimals = "," + new String('0', Decimals);
            }

            return string.Format("{0}: {1}{3}-{2}{3}", Name, MinValue, MaxValue, decimals);
        }
    }
}