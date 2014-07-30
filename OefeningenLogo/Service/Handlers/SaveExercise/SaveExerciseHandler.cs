using System.Linq;
using System.Xml.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.SaveExercise
{
    public class SaveExerciseHandler : ISaveExerciseHandler
    {
        private readonly IRepository _repository;

        public SaveExerciseHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void SaveExercise(IExerciseDefinition exercise)
        {
            var doc=_repository.Load();

            var exerciseExists = !(doc.Descendants("exercises").Single().Descendants("exercise")
                                       .SingleOrDefault(e => e.Attribute("name").Value == exercise.Name) == null);

            if (exerciseExists)
                throw new ValidationException("Oefening bestaat reeds");

            var exerciseXml = new XElement("exercise");
            exerciseXml.Add(new XAttribute("name", exercise.Name));
            exerciseXml.Add(new XAttribute("template", exercise.Template));
            var numbersXml = new XElement("numbers");
            exerciseXml.Add(numbersXml);
            foreach (var number in exercise.Numbers)
            {
                var numberXml = new XElement("number");
                numberXml.Add(new XAttribute("name", number.Name));
                numberXml.Add(new XAttribute("minvalue", number.MinValue));
                numberXml.Add(new XAttribute("maxvalue", number.MaxValue));
                numberXml.Add(new XAttribute("decimals", number.Decimals));

                numbersXml.Add(numberXml);
            }

            doc.Element("exercisebuilder")
                .Element("exercises")
                .Add(exerciseXml);

            _repository.Save();
        }
    }
}