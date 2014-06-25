using System.Collections.Generic;

namespace OefeningenLogo.Oefeningen
{
    public interface IAmADefinitionOfAnExercise
    {
        string CreateExercise(IProvideRandomNumbers randomNumberGenerator);
        void AddNumberDefinition(IAmADefinitionOfANumber numberDefinition);
        void AddConstraint(IAmAConstraint constraint);
        IEnumerable<IAmADefinitionOfANumber> Numbers { get; }
        string Name { get; }
        string Template { get; }
    }
}