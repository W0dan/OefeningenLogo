using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetExercise
{
    public class GetExerciseQuery : IGetExerciseQuery
    {
        public IExerciseDefinition GetExercise(XElement exerciseXml, IDictionary<string, IConstraint> allConstraints)
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
    }
}