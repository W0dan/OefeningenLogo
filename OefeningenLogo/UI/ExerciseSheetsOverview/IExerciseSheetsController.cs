using System;
using System.Windows.Forms;

namespace OefeningenLogo.UI.ExerciseSheetsOverview
{
    public interface IExerciseSheetsController : IController
    {
        event Action<IWindow> WantToAddExerciseSheet;

        Form Window { get; }
    }
}