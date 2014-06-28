using System.Collections.Generic;

namespace OefeningenLogo.Oefeningen
{
    public interface IExerciseSheet
    {
        string Name { get; }
        IEnumerable<string> Exercises { get; }
    }
}