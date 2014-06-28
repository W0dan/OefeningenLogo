using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Backend
{
    public interface IRepository
    {
        void SaveExercise(IExerciseDefinition exercise);
        void SaveConstraint(IConstraint constraint);
        IEnumerable<IExerciseDefinition> GetAllExercises();
        IDictionary<string, IConstraint> GetAllConstraints();
    }
}