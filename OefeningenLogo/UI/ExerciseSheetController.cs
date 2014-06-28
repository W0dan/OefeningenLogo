using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI
{
    public class ExerciseSheetController : IRootController
    {
        private readonly IExerciseSheetWindow _window;
        private readonly IExerciseBuilderController _exerciseBuilderController;

        public ExerciseSheetController(IExerciseSheetWindow window, IExerciseBuilderController exerciseBuilderController)
        {
            _window = window;
            _exerciseBuilderController = exerciseBuilderController;
            _window.Loaded += Loaded;
            _window.AddExerciseSheetButtonClicked += AddExerciseSheetButtonClicked;
        }

        void AddExerciseSheetButtonClicked()
        {
            _exerciseBuilderController.ShowWindow(_window);
        }

        void Loaded()
        {
            _window.ReloadExerciseSheets(new List<ExerciseSheet>());
        }

        public Form Window
        {
            get { return (Form)_window; }
        }
    }
}