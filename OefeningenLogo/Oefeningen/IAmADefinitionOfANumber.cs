namespace OefeningenLogo.Oefeningen
{
    public interface IAmADefinitionOfANumber
    {
        decimal GetNumber(IProvideRandomNumbers randomNumberGenerator);
        string Name { get; }
        int MinValue { get; }
        int MaxValue { get; }
        int Decimals { get; }
    }
}