using System.Collections.Generic;

namespace OefeningenLogo.Oefeningen
{
    public interface IExerciseDefinition
    {
        string CreateExercise(IProvideRandomNumbers randomNumberGenerator);
        void AddNumberDefinition(INumberDefinition numberDefinition);
        void AddConstraint(IConstraint constraint);
        IEnumerable<INumberDefinition> Numbers { get; }
        string Name { get; }
        string Template { get; }
    }
}