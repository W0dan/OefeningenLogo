using System.Collections.Generic;
using System.Data;
using System.Linq;
using OefeningenLogo.Service;

namespace OefeningenLogo.Oefeningen
{
    public class ExerciseDefinition : IExerciseDefinition
    {
        private readonly string _name;
        private readonly IExerciseTemplate _exerciseTemplate;
        private readonly List<INumberDefinition> _numberDefinitions = new List<INumberDefinition>();
        private readonly List<IConstraint> _constraints = new List<IConstraint>();

        public ExerciseDefinition(string name, IExerciseTemplate exerciseTemplate)
        {
            _name = name;
            _exerciseTemplate = exerciseTemplate;
        }

        public string Name { get { return _name; } }
        public string Template { get { return _exerciseTemplate.Template; } }

        public void AddNumberDefinition(INumberDefinition numberDefinition)
        {
            _numberDefinitions.Add(numberDefinition);
        }

        public void AddConstraint(IConstraint constraint)
        {
            _constraints.Add(constraint);
        }

        public IEnumerable<INumberDefinition> Numbers
        {
            get { return _numberDefinitions; }
        }

        public string CreateExercise(IProvideRandomNumbers randomNumberGenerator)
        {
            var numbers = _numberDefinitions.Select(n => n.GetNumber(randomNumberGenerator)).ToArray();
            var invalidConstraintCount = 0;
            while (!ConstraintsAreValid(numbers))
            {
                if (invalidConstraintCount > 100)
                    throw new CannotSatisfyConstraintException("Het is onmogelijk om getallen te maken waarvoor de regel klopt (in 100 pogingen)");

                numbers = _numberDefinitions.Select(n => n.GetNumber(randomNumberGenerator)).ToArray();
                invalidConstraintCount++;
            }

            return string.Format(
                _exerciseTemplate.Template,
                numbers.Select(n => (object)n).ToArray()
                );
        }

        private bool ConstraintsAreValid(decimal[] numbers)
        {
            return _constraints.All(constraint => constraint.IsValid(numbers));
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", _name, _exerciseTemplate.Template);
        }
    }
}