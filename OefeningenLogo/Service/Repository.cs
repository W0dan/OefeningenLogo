using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service
{
    public class Repository : IRepository
    {
        private readonly string XmlFilename;

        private XDocument _doc;

        public Repository()
        {
            XmlFilename = ConfigSettings.ExerciseFile;
        }

        public XDocument Load()
        {
            if (_doc == null)
                _doc = XDocument.Load(XmlFilename);

            return _doc;
        }

        private void Save()
        {
            if (_doc != null)
                _doc.Save(XmlFilename);
        }

        public void SaveExercise(IExerciseDefinition exercise)
        {
            Load();

            var exerciseExists = !(_doc.Descendants("exercises").Single().Descendants("exercise")
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

            _doc.Element("exercisebuilder")
                .Element("exercises")
                .Add(exerciseXml);

            Save();
        }

        public void SaveConstraint(IConstraint constraint)
        {

        }

        public IEnumerable<IExerciseSheet> GetAllSheets()
        {
            Load();

            var sheets = new List<IExerciseSheet>();

            var sheetsXml = from s in _doc.Descendants("sheets").Single()
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

        public IExerciseSheet GetExerciseSheet(string name)
        {
            Load();

            var sheet = new ExerciseSheet(name);

            var sheetXml = (from s in _doc.Descendants("sheets").Single()
                               .Descendants("sheet")
                           where s.Attribute("name").Value == name
                           select s).Single();

            foreach (var exerciseXml in sheetXml.Descendants("exercise"))
            {
                var exerciseName = exerciseXml.Attribute("type").Value;

                sheet.AddExercise(exerciseName);
            }

            return sheet;
        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
