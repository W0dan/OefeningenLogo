using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExerciseSheet;

namespace OefeningenLogo.UI
{
    public class ExerciseSheetController : IRootController
    {
        private readonly IExerciseSheetWindow _window;
        private readonly IRepository _repository;
        private readonly IExerciseBuilderController _exerciseBuilderController;
        private readonly IProvideRandomNumbers _randomNumberGenerator;

        public ExerciseSheetController(IExerciseSheetWindow window, IRepository repository, IExerciseBuilderController exerciseBuilderController, IProvideRandomNumbers randomNumberGenerator)
        {
            _window = window;
            _repository = repository;
            _exerciseBuilderController = exerciseBuilderController;
            _randomNumberGenerator = randomNumberGenerator;

            _window.AddExerciseSheetButtonClicked += AddExerciseSheetButtonClicked;
            _window.Loaded += Loaded;
            _window.ExerciseSheetSelected += ExerciseSheetSelected;

        }

        void ExerciseSheetSelected(string name)
        {
            var sheet = _repository.GetExerciseSheet(name);

            var exercises = new Dictionary<int, IExerciseDefinition>();
            var i = 0;
            foreach (var exerciseName in sheet.Exercises)
            {
                var exercise = _repository.GetExercise(exerciseName);

                exercises.Add(i, exercise);
                i++;
            }

            CreatePdf(exercises);
        }

        private void CreatePdf(Dictionary<int, IExerciseDefinition> exercises)
        {
            var pdfGen = new PdfGenerator(@"c:\temp");

            pdfGen.InitializePage(DateTime.Now);

            for (var i = 0; i < 25; i++)
            {
                var currentEx = _randomNumberGenerator.GetRandomNumber(0, exercises.Count);
                try
                {
                    pdfGen.AddLine(string.Format("{0:00}. {1}", i + 1, exercises[currentEx].CreateExercise(_randomNumberGenerator)));
                }
                catch (Exception e)
                {
                    pdfGen.AddLine(string.Format("fout bij oefening {0}: {1}", exercises[currentEx].Name, e.Message));
                }
            }

            pdfGen.Write();
        }

        void AddExerciseSheetButtonClicked()
        {
            _exerciseBuilderController.ShowWindow(_window);
        }

        void Loaded()
        {
            var sheets = _repository.GetAllSheets();
            _window.ReloadExerciseSheets(sheets);
        }

        public Form Window
        {
            get { return (Form)_window; }
        }
    }
}