using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI
{
    public interface IExerciseSheetWindow : IWindow
    {
        void ReloadExerciseSheets(IEnumerable<ExerciseSheet> exerciseSheets);
        event Action AddExerciseSheetButtonClicked;
        event Action Loaded;
    }
}