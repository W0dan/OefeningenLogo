namespace OefeningenLogo.Oefeningen
{
    public interface IAmAConstraint
    {
        bool IsValid(params decimal[] numbers);
    }
}