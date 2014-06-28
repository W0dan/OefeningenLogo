namespace OefeningenLogo.Oefeningen
{
    public interface IConstraint
    {
        bool IsValid(params decimal[] numbers);
    }
}