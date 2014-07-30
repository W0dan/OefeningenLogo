using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetExercise
{
    public interface IGetExerciseHandler : IHandler
    {
        IExerciseDefinition GetExercise(string name);
    }
}