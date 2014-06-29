using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExerciseSheet
{
    public interface IExerciseBuilderController : IController
    {
        IExerciseSheet ShowWindow(IExerciseSheetWindow parent);
    }
}