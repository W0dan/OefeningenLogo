using System.Collections.Generic;

namespace OefeningenLogo.Oefeningen
{
    public class ExerciseSheet : IExerciseSheet
    {
        private readonly string _name;
        private readonly List<string> _exercises = new List<string>();

        public ExerciseSheet(string name)
        {
            _name = name;
        }

        public string Name { get { return _name; } }

        public void AddExercise(string exercise)
        {
            _exercises.Add(exercise);
        }

        public IEnumerable<string> Exercises{get { return _exercises; }} 
    }
}