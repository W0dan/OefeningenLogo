using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.AddNumber
{
    public interface IAddNumberController : IController
    {
        INumberDefinition ShowWindow(IWindow window);
    }
}