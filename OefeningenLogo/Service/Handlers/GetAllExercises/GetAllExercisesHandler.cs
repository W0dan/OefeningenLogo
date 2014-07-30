using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service.Handlers.GetAllConstraints;

namespace OefeningenLogo.Service.Handlers.GetAllExercises
{
    public class GetAllExercisesHandler : IGetAllExercisesHandler
    {
        private readonly IRepository _repository;
        private readonly IGetAllConstraintsHandler _getAllConstraintsHandler;

        public GetAllExercisesHandler(IRepository repository, IGetAllConstraintsHandler getAllConstraintsHandler)
        {
            _repository = repository;
            _getAllConstraintsHandler = getAllConstraintsHandler;
        }

        public IEnumerable<IExerciseDefinition> GetAllExercises()
        {
            var doc = _repository.Load();

            var exercises = new List<IExerciseDefinition>();

            var allConstraints = _getAllConstraintsHandler.GetAllConstraints();

            var exercisesXml = from ex in doc.Descendants("exercises")
                                   .Single().Descendants("exercise")
                               select ex;

            foreach (var exerciseXml in exercisesXml)
            {
                var exercise = GetExercise(exerciseXml, allConstraints);

                exercises.Add(exercise);
            }

            return exercises;
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
    }
}