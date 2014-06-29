using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Backend
{
    public class Repository : IRepository
    {
        const string XmlFilename = @"C:\Temp\logo\exercises.xml";

        private XDocument _doc;

        private void Load()
        {
            if (_doc == null)
                _doc = XDocument.Load(XmlFilename);
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

        public IExerciseDefinition GetExercise(string name)
        {
            Load();

            var allConstraints = GetAllConstraints();

            var exerciseXml = (from e in _doc.Descendants("exercises").Single()
                                   .Descendants("exercise")
                               where e.Attribute("name").Value == name
                               select e).Single();

            return GetExercise(exerciseXml, allConstraints);
        }

        private static IExerciseDefinition GetExercise(XElement exerciseXml, IDictionary<string, IConstraint> allConstraints)
        {
            var exercise = new ExerciseDefinition(exerciseXml.Attribute("name").Value,
                                                  new ExerciseTemplate(exerciseXml.Attribute("template").Value));

            var numbersXml = from n in exerciseXml.Descendants("numbers").First().Descendants("number")
                             select n;

            foreach (var number in numbersXml)
            {
                var minValue = int.Parse(number.Attribute("minvalue").Value);
                var maxValue = int.Parse(number.Attribute("maxvalue").Value);
                var decimals = int.Parse(number.Attribute("decimals").Value);
                exercise.AddNumberDefinition(new NumberDefinition("", minValue, maxValue, decimals));
            }

            var constraintsRoot = exerciseXml.Descendants("constraints").FirstOrDefault();
            if (constraintsRoot != null)
            {
                var constraintsXml = from c in constraintsRoot.Descendants("constraint")
                                     select c;

                foreach (var constraint in constraintsXml)
                {
                    var constraintName = constraint.Attribute("type").Value;

                    exercise.AddConstraint(allConstraints[constraintName]);
                }
            }

            return exercise;
        }

        public IEnumerable<IExerciseDefinition> GetAllExercises()
        {
            Load();

            var exercises = new List<IExerciseDefinition>();

            var allConstraints = GetAllConstraints();

            var exercisesXml = from ex in _doc.Descendants("exercises")
                                   .Single().Descendants("exercise")
                               select ex;

            foreach (var exerciseXml in exercisesXml)
            {
                var exercise = GetExercise(exerciseXml, allConstraints);

                exercises.Add(exercise);
            }

            return exercises;
        }

        public IDictionary<string, IConstraint> GetAllConstraints()
        {
            Load();

            var constraints = new Dictionary<string, IConstraint>();

            var allConstraintsXml =
                from c in _doc.Descendants("constraints").First().Descendants("constraint")
                select c;

            foreach (var constraintXml in allConstraintsXml)
            {
                var name = constraintXml.Attribute("name").Value;
                var value = constraintXml.Attribute("value").Value;
                var description = constraintXml.Attribute("description").Value;

                constraints.Add(name, ConstraintBuilder.BuildConstraint(value, description));
            }

            return constraints;
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
