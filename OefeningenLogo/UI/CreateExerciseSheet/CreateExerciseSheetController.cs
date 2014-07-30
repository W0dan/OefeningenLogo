using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service.Handlers.GetAllExercises;
using OefeningenLogo.Service.Handlers.SaveExerciseSheet;
using OefeningenLogo.UI._Extensions;

namespace OefeningenLogo.UI.CreateExerciseSheet
{
    public class CreateExerciseSheetController : ICreateExerciseSheetController
    {
        private readonly ICreateExerciseSheetWindow _window;
        private readonly IGetAllExercisesHandler _getAllExercisesHandler;
        private readonly ISaveExerciseSheetHandler _saveExerciseSheetHandler;
        private List<string> _exercises;
        private ExerciseSheet _sheet;

        public event Action<IWindow> WantToCreateExercise;

        public CreateExerciseSheetController(ICreateExerciseSheetWindow window, IGetAllExercisesHandler getAllExercisesHandler, ISaveExerciseSheetHandler saveExerciseSheetHandler)
        {
            _window = window;
            _getAllExercisesHandler = getAllExercisesHandler;
            _saveExerciseSheetHandler = saveExerciseSheetHandler;
        }

        public IExerciseSheet ShowWindow(IWindow parent)
        {
            _exercises = new List<string>();

            _sheet = null;

            _window.Loaded += Loaded;
            _window.AddExerciseButtonClicked += AddExerciseButtonClicked;
            _window.ExerciseSelected += ExerciseSelected;
            _window.ExerciseUnselected += ExerciseUnselected;
            _window.SaveButtonClicked += SaveButtonClicked;
            _window.CancelButtonClicked += CancelButtonClicked;

            _window.ShowDialog(parent);

            _window.Loaded -= Loaded;
            _window.AddExerciseButtonClicked -= AddExerciseButtonClicked;
            _window.ExerciseSelected -= ExerciseSelected;
            _window.ExerciseUnselected -= ExerciseUnselected;
            _window.SaveButtonClicked -= SaveButtonClicked;
            _window.CancelButtonClicked -= CancelButtonClicked;

            _window.Clear();

            return _sheet;
        }

        void CancelButtonClicked()
        {
            _window.Close();
        }

        void SaveButtonClicked()
        {
            foreach (var exercise in _exercises)
            {
                _sheet.AddExercise(exercise);
            }

            _saveExerciseSheetHandler.SaveExerciseSheet(_sheet);
        }

        void ExerciseUnselected(string exerciseName)
        {
            _window.RemoveExercise(exerciseName);
            _exercises.Remove(exerciseName);
        }

        void ExerciseSelected(string exerciseName)
        {
            _exercises.Add(exerciseName);
            _window.AddExercise(exerciseName);
        }

        private void Loaded()
        {
            Reload();
        }

        private void AddExerciseButtonClicked()
        {
            WantToCreateExercise.Raise(_window);

            Reload();
        }

        private void Reload()
        {
            var exercises = _getAllExercisesHandler.GetAllExercises();
            _window.ReloadExercises(exercises);
        }
    }
}