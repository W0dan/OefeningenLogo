using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExerciseSheet
{
    public interface ICreateExerciseSheetWindow : IWindow
    {
        void ReloadExercises(IEnumerable<IExerciseDefinition> exercises);
        void AddExercise(string exerciseName);
        void RemoveExercise(string exerciseName);
        void Clear();
        void Close();
        event Action Loaded;
        event Action AddExerciseButtonClicked;
        event Action<string> ExerciseSelected;
        event Action<string> ExerciseUnselected;
        event Action CancelButtonClicked;
        event Action SaveButtonClicked;
    }
}