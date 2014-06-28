using System.Collections.Generic;
using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise;

namespace OefeningenLogo.UI
{
    public class ExerciseBuilderController : IExerciseBuilderController
    {
        private readonly IExerciseBuilderWindow _window;
        private readonly IRepository _repository;
        private readonly ICreateExerciseController _createExerciseController;
        private List<string> _exercises;
        private ExerciseSheet _sheet;

        public ExerciseBuilderController(IExerciseBuilderWindow window, IRepository repository, ICreateExerciseController createExerciseController)
        {
            _window = window;
            _repository = repository;
            _createExerciseController = createExerciseController;
        }

        public IExerciseSheet ShowWindow(IExerciseSheetWindow parent)
        {
            _exercises = new List<string>();
            _sheet = null;

            _window.Loaded += Loaded;
            _window.AddExerciseButtonClicked += AddExerciseButtonClicked;
            _window.ExerciseSelected += ExerciseSelected;
            _window.ExerciseUnselected += ExerciseUnselected;

            _window.ShowDialog(parent);

            _window.Loaded -= Loaded;
            _window.AddExerciseButtonClicked -= AddExerciseButtonClicked;
            _window.ExerciseSelected -= ExerciseSelected;
            _window.ExerciseUnselected -= ExerciseUnselected;

            _window.Clear();

            return _sheet;
        }

        void ExerciseUnselected(string exerciseName)
        {
            _window.RemoveExercise(exerciseName);
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
            _createExerciseController.ShowWindow(_window);

            Reload();
        }

        private void Reload()
        {
            var exercises = _repository.GetAllExercises();
            _window.ReloadExercises(exercises);
        }
    }
}