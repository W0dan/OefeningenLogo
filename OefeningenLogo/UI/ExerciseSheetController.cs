using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI
{
    public class ExerciseSheetController : IRootController
    {
        private readonly IExerciseSheetWindow _window;
        private readonly IRepository _repository;
        private readonly IExerciseBuilderController _exerciseBuilderController;

        public ExerciseSheetController(IExerciseSheetWindow window, IRepository repository, IExerciseBuilderController exerciseBuilderController)
        {
            _window = window;
            _repository = repository;
            _exerciseBuilderController = exerciseBuilderController;

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
            var rnd = new RandomNumberGenerator();

            pdfGen.InitializePage(DateTime.Now);

            for (var i = 0; i < 25; i++)
            {
                var currentEx = rnd.GetRandomNumber(0, exercises.Count);
                
                pdfGen.AddLine(exercises[currentEx].CreateExercise(rnd));
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