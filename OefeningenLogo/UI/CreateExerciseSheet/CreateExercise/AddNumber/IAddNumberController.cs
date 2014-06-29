using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddNumber
{
    public interface IAddNumberController : IController
    {
        INumberDefinition ShowWindow(IWindow window);
    }
}