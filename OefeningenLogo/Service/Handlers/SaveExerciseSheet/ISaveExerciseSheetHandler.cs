using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.SaveExerciseSheet
{
    public interface ISaveExerciseSheetHandler : IHandler
    {
        void SaveExerciseSheet(IExerciseSheet exerciseSheet);
    }
}