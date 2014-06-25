using System.Collections.Generic;

namespace OefeningenLogo.Oefeningen
{
    public class ExerciseGenerator
    {
        public IEnumerable<string> Generate()
        {
            var exercises = new List<string>();
            var randomNumberGenerator = new RandomNumberGenerator();

            for (var i = 0; i < 25; i++)
            {
                exercises.Add(CreateExercise(randomNumberGenerator));
            }

            return exercises;
        }

        private static string CreateExercise(RandomNumberGenerator randomNumberGenerator)
        {
            var ed = new ExerciseDefinition("", new ExerciseTemplate("{0} + {1} = "));
            ed.AddNumberDefinition(new NumberDefinition("", 0, 100));
            ed.AddNumberDefinition(new NumberDefinition("", 0, 100));
            return ed.CreateExercise(randomNumberGenerator);
        }
    }
}