using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI
{
    public interface IExerciseBuilderController : IController
    {
        IExerciseSheet ShowWindow(IExerciseSheetWindow parent);
    }
}