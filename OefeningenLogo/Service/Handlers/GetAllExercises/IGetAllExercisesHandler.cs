using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetAllExercises
{
    public interface IGetAllExercisesHandler : IHandler
    {
        IEnumerable<IExerciseDefinition> GetAllExercises();
    }
}