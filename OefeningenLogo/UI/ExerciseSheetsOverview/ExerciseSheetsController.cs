using System;
using System.Windows.Forms;
using OefeningenLogo.Service.Handlers.CreateExerciseSheet;
using OefeningenLogo.Service.Handlers.GetAllSheets;
using OefeningenLogo.UI._Extensions;

namespace OefeningenLogo.UI.ExerciseSheetsOverview
{
    public class ExerciseSheetsController : IExerciseSheetsController
    {
        private readonly IExerciseSheetsWindow _window;
        private readonly ICreateExerciseSheetHandler _createExerciseSheetHandler;
        private readonly IGetAllSheetsHandler _getAllSheetsHandler;

        public event Action<IWindow> WantToAddExerciseSheet;

        public ExerciseSheetsController(IExerciseSheetsWindow window, ICreateExerciseSheetHandler createExerciseSheetHandler, IGetAllSheetsHandler getAllSheetsHandler)
        {
            _window = window;
            _createExerciseSheetHandler = createExerciseSheetHandler;
            _getAllSheetsHandler = getAllSheetsHandler;

            _window.AddExerciseSheetButtonClicked += AddExerciseSheetButtonClicked;
            _window.Loaded += Loaded;
            _window.ExerciseSheetSelected += ExerciseSheetSelected;

        }

        void ExerciseSheetSelected(string name)
        {
            for (var i = 0; i < 5; i++)
            {
                _createExerciseSheetHandler.CreateExerciseSheet(name);
            }
        }

        void AddExerciseSheetButtonClicked()
        {
            WantToAddExerciseSheet.Raise(_window);
        }

        void Loaded()
        {
            var sheets = _getAllSheetsHandler.GetAllSheets();
            _window.ReloadExerciseSheets(sheets);
        }

        public Form Window
        {
            get { return (Form)_window; }
        }
    }
}