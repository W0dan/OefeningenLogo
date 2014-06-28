using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI
{
    public interface IExerciseBuilderWindow : IWindow
    {
        void ReloadExercises(IEnumerable<IExerciseDefinition> exercises);
        void AddExercise(string exerciseName);
        void RemoveExercise(string exerciseName);
        void Clear();
        event Action Loaded;
        event Action AddExerciseButtonClicked;
        event Action<string> ExerciseSelected;
        event Action<string> ExerciseUnselected;
    }
}