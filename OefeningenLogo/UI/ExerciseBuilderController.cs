using OefeningenLogo.Backend;
using OefeningenLogo.UI.CreateExercise;

namespace OefeningenLogo.UI
{
    public class ExerciseBuilderController : IExerciseBuilderController
    {
        private readonly IExerciseBuilderWindow _window;
        private readonly IRepository _repository;

        public ExerciseBuilderController(IExerciseBuilderWindow window)
        {
            _repository = new Repository();
            _window = window;
            _window.Loaded += Loaded;
            _window.AddExerciseButtonClicked += AddExerciseButtonClicked;
        }

        private void Loaded()
        {
            Reload();
        }

        private void AddExerciseButtonClicked()
        {
            CreateExerciseController.ShowWindow(_window, _repository);

            Reload();
        }

        private void Reload()
        {
            var exercises = _repository.GetAllExercises();
            _window.ReloadExercises(exercises);
        }
    }
}