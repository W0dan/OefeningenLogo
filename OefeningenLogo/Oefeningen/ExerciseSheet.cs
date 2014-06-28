using System.Collections.Generic;
using System.Xml.Linq;

namespace OefeningenLogo.Oefeningen
{
    public class ExerciseSheet : IExerciseSheet
    {
        private readonly string _name;
        private readonly List<IExerciseDefinition> _exercises = new List<IExerciseDefinition>();

        public ExerciseSheet(string name)
        {
            _name = name;
        }

        public void AddExercise(IExerciseDefinition exercise)
        {
            _exercises.Add(exercise);
        }
    }
}