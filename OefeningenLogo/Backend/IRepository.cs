using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Backend
{
    public interface IRepository
    {
        void SaveExercise(IAmADefinitionOfAnExercise exercise);
        void SaveConstraint(IAmAConstraint constraint);
        IEnumerable<IAmADefinitionOfAnExercise> GetAllExercises();
        IDictionary<string, IAmAConstraint> GetAllConstraints();
    }
}