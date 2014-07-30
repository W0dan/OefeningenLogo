using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.SaveExercise
{
    public interface ISaveExerciseHandler : IHandler
    {
        void SaveExercise(IExerciseDefinition exercise);
    }
}