using System;

namespace OefeningenLogo.Service
{
    public class RandomNumberGenerator : IProvideRandomNumbers
    {
        static readonly Random Random = new Random();

        public int GetRandomNumber(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }
    }
}