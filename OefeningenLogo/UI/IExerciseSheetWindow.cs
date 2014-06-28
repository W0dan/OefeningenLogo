using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI
{
    public interface IExerciseSheetWindow : IWindow
    {
        void ReloadExerciseSheets(IEnumerable<IExerciseSheet> exerciseSheets);
        event Action AddExerciseSheetButtonClicked;
        event Action Loaded;
        event Action<string> ExerciseSheetSelected;
    }
}