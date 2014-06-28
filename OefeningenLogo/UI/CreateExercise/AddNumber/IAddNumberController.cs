using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExercise.AddNumber
{
    public interface IAddNumberController : IController
    {
        INumberDefinition ShowWindow(IWindow window);
    }
}