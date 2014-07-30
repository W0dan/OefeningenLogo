using OefeningenLogo.Service;

namespace OefeningenLogo.Oefeningen
{
    public interface INumberDefinition
    {
        decimal GetNumber(IProvideRandomNumbers randomNumberGenerator);
        string Name { get; }
        int MinValue { get; }
        int MaxValue { get; }
        int Decimals { get; }
    }
}