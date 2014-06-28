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

            var sheetsXml = from s in _doc.Descendants("sheets")
                                .Single().Descendants("sheet")
                            select s;

            foreach (var sheetXml in sheetsXml)
            {
                var sheet = new ExerciseSheet(sheetXml.Attribute("name").Value);

                var exercisesXml = from ex in sheetXml.Descendants("exercise")
                                   select ex;

                foreach (var exerciseXml in exercisesXml)
                {
                    // ?????????????????????????
                    //sheet.AddExercise();
                }

                sheets.Add(sheet);
            }

            return sheets;
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
                var exercise = new ExerciseDefinition(exerciseXml.Attribute("name").Value,
                                                      new ExerciseTemplate(exerciseXml.Attribute("template").Value));
                exercises.Add(exercise);

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

                constraints.Add(name, ConstraintBuilder.BuildConstraint(value));
            }

            return constraints;
        }

    }
}
