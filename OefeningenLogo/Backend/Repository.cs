using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.CSharp;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Backend
{
    public class Repository : IRepository
    {
        public void SaveExercise(IAmADefinitionOfAnExercise exercise)
        {
            XmlHelper.SaveXml(doc => SaveExercise(doc, exercise));
        }

        private void SaveExercise(XContainer doc, IAmADefinitionOfAnExercise exercise)
        {
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

            doc.Element("exercises").Add(exerciseXml);
        }

        public void SaveConstraint(IAmAConstraint constraint)
        {

        }

        public IEnumerable<IAmADefinitionOfAnExercise> GetAllExercises()
        {
            var exercises = new List<IAmADefinitionOfAnExercise>();

            XmlHelper.ReadXml(doc => GetAllExercises(doc, exercises));

            return exercises;
        }

        private void GetAllExercises(XContainer doc, ICollection<IAmADefinitionOfAnExercise> exercises)
        {
            var allConstraints = new Dictionary<string, IAmAConstraint>();
            GetAllConstraints(doc, allConstraints);

            var exercisesXml = from ex in doc.Descendants("exercise")
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
        }

        public IDictionary<string, IAmAConstraint> GetAllConstraints()
        {
            var constraints = new Dictionary<string, IAmAConstraint>();

            XmlHelper.ReadXml(doc => GetAllConstraints(doc, constraints));

            return constraints;
        }

        private void GetAllConstraints(XContainer doc, IDictionary<string, IAmAConstraint> constraints)
        {
            var allConstraintsXml =
                from c in doc.Descendants("constraints").First().Descendants("constraint")
                select c;

            foreach (var constraintXml in allConstraintsXml)
            {
                var name = constraintXml.Attribute("name").Value;
                var value = constraintXml.Attribute("value").Value;

                constraints.Add(name, BuildConstraint(value));
            }
        }

        private IAmAConstraint BuildConstraint(string value)
        {
            var definition =
                string.Format(@"public class Constraint : OefeningenLogo.Oefeningen.IAmAConstraint
{{
    public bool IsValid(params decimal[] numbers)
    {{
        return {0};
    }}
}}", value);

            var csCompiler = new CSharpCodeProvider();
            var compilerParameters = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };
            var location = Assembly.GetExecutingAssembly().Location;
            compilerParameters.ReferencedAssemblies.Add(location);
            var results = csCompiler.CompileAssemblyFromSource(compilerParameters, new[] { definition });

            IAmAConstraint constraint = null;

            if (results.Errors.Count == 0)
            {
                var assembly = results.CompiledAssembly;
                constraint = assembly.CreateInstance("Constraint") as IAmAConstraint;
            }

            return constraint;
        }
    }
}
