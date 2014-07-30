using System.Collections.Generic;
using System.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetAllSheets
{
    public class GetAllSheetsHandler: IGetAllSheetsHandler
    {
        private readonly IRepository _repository;

        public GetAllSheetsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IExerciseSheet> GetAllSheets()
        {
            var doc = _repository.Load();

            var sheets = new List<IExerciseSheet>();

            var sheetsXml = from s in doc.Descendants("sheets").Single()
                                .Descendants("sheet")
                            select s;

            foreach (var sheetXml in sheetsXml)
            {
                var sheet = new ExerciseSheet(sheetXml.Attribute("name").Value);

                var exercisesXml = from ex in sheetXml.Descendants("exercise")
                                   select ex;

                foreach (var exerciseXml in exercisesXml)
                {
                    sheet.AddExercise(exerciseXml.Attribute("type").Value);
                }

                sheets.Add(sheet);
            }

            return sheets;
        }
    }
}