using System;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExercise
{
    public interface ICreateExerciseController : IController
    {
        event Func<IWindow, INumberDefinition> WantToAddNumber;
        event Func<IWindow, IConstraint> WantToAddConstraint;

        void ShowWindow(IWindow window);
    }
}