using System;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExerciseSheet
{
    public interface ICreateExerciseSheetController : IController
    {
        event Action<IWindow> WantToCreateExercise;

        IExerciseSheet ShowWindow(IWindow parent);
    }
}