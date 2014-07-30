using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service.Handlers.GetExercise;

namespace OefeningenLogo.Service.Handlers.CreateExerciseSheet
{
    public class CreateExerciseSheetHandler : ICreateExerciseSheetHandler
    {
        private readonly IRepository _repository;
        private readonly IGetExerciseHandler _getExerciseHandler;
        private readonly IProvideRandomNumbers _randomNumberGenerator;

        public CreateExerciseSheetHandler(IRepository repository, IGetExerciseHandler getExerciseHandler, IProvideRandomNumbers randomNumberGenerator)
        {
            _repository = repository;
            _getExerciseHandler = getExerciseHandler;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public void CreateExerciseSheet(string name)
        {
            var sheet = _repository.GetExerciseSheet(name);

            var exercises = new Dictionary<int, IExerciseDefinition>();
            var i = 0;
            foreach (var exerciseName in sheet.Exercises)
            {
                var exercise = _getExerciseHandler.GetExercise(exerciseName);

                exercises.Add(i, exercise);
                i++;
            }

            CreatePdf(exercises);
        }

        private void CreatePdf(Dictionary<int, IExerciseDefinition> exercises)
        {
            var pdfGen = new PdfGenerator(ConfigSettings.RootPath);

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
    }
}