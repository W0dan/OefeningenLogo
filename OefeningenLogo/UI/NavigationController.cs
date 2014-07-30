using System.Windows.Forms;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.AddConstraint;
using OefeningenLogo.UI.AddNumber;
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
        private readonly IAddConstraintController _addConstraintController;
        private readonly IAddNumberController _addNumberController;

        public NavigationController(IExerciseSheetsController exerciseSheetController
            , ICreateExerciseSheetController exerciseBuilderController
            , ICreateExerciseController createExerciseController
            , IAddConstraintController addConstraintController
            , IAddNumberController addNumberController)
        {
            _exerciseSheetController = exerciseSheetController;
            _exerciseBuilderController = exerciseBuilderController;
            _createExerciseController = createExerciseController;
            _addConstraintController = addConstraintController;
            _addNumberController = addNumberController;

            _exerciseSheetController.WantToAddExerciseSheet += ExerciseSheetControllerWantsToAddExerciseSheet;
            _exerciseBuilderController.WantToCreateExercise += ExerciseBuilderControllerWantsToCreateExercise;
            _createExerciseController.WantToAddConstraint += CreateExerciseControllerWantsToAddConstraint;
            _createExerciseController.WantToAddNumber += CreateExerciseControllerWantsToAddNumber;
        }

        INumberDefinition CreateExerciseControllerWantsToAddNumber(IWindow parentWindow)
        {
            return _addNumberController.ShowWindow(parentWindow);
        }

        private IConstraint CreateExerciseControllerWantsToAddConstraint(IWindow parentWindow)
        {
            return _addConstraintController.ShowWindow(parentWindow);
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