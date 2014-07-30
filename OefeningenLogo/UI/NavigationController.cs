using System.Windows.Forms;
using OefeningenLogo.UI.CreateExercise;
using OefeningenLogo.UI.CreateExerciseSheet;
using OefeningenLogo.UI.ExerciseSheetsOverview;

namespace OefeningenLogo.UI
{
    public class NavigationController : INavigationController
    {
        private readonly IExerciseSheetsController _exerciseSheetController;
        private readonly ICreateExerciseSheetController _exerciseBuilderController;
        private readonly ICreateExerciseController _createExerciseController;

        public NavigationController(IExerciseSheetsController exerciseSheetController, ICreateExerciseSheetController exerciseBuilderController, ICreateExerciseController createExerciseController)
        {
            _exerciseSheetController = exerciseSheetController;
            _exerciseBuilderController = exerciseBuilderController;
            _createExerciseController = createExerciseController;

            _exerciseSheetController.WantToAddExerciseSheet += ExerciseSheetControllerWantsToAddExerciseSheet;
            _exerciseBuilderController.WantToCreateExercise += ExerciseBuilderControllerWantsToCreateExercise;
        }

        void ExerciseBuilderControllerWantsToCreateExercise(IWindow parentWindow)
        {
            _createExerciseController.ShowWindow(parentWindow);
        }

        void ExerciseSheetControllerWantsToAddExerciseSheet(IWindow parentWindow)
        {
            _exerciseBuilderController.ShowWindow(parentWindow);
        }

        public Form GetStartupWindow()
        {
            return _exerciseSheetController.Window;
        }
    }
}