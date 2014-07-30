using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.ExerciseSheetsOverview
{
    public interface IExerciseSheetsWindow : IWindow
    {
        void ReloadExerciseSheets(IEnumerable<IExerciseSheet> exerciseSheets);
        event Action AddExerciseSheetButtonClicked;
        event Action Loaded;
        event Action<string> ExerciseSheetSelected;
    }
}