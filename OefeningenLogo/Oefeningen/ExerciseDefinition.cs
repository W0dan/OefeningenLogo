using System.Collections.Generic;
using System.Linq;

namespace OefeningenLogo.Oefeningen
{
    public class ExerciseDefinition : IAmADefinitionOfAnExercise
    {
        private readonly string _name;
        private readonly IAmATemplateForAnExercise _exerciseTemplate;
        private readonly List<IAmADefinitionOfANumber> _numberDefinitions = new List<IAmADefinitionOfANumber>();
        private readonly List<IAmAConstraint> _constraints = new List<IAmAConstraint>();

        public ExerciseDefinition(string name, IAmATemplateForAnExercise exerciseTemplate)
        {
            _name = name;
            _exerciseTemplate = exerciseTemplate;
        }

        public string Name { get { return _name; } }
        public string Template { get { return _exerciseTemplate.Template; } }

        public void AddNumberDefinition(IAmADefinitionOfANumber numberDefinition)
        {
            _numberDefinitions.Add(numberDefinition);
        }

        public void AddConstraint(IAmAConstraint constraint)
        {
            _constraints.Add(constraint);
        }

        public IEnumerable<IAmADefinitionOfANumber> Numbers
        {
            get { return _numberDefinitions; }
        }

        public string CreateExercise(IProvideRandomNumbers randomNumberGenerator)
        {
            var numbers = _numberDefinitions.Select(n => n.GetNumber(randomNumberGenerator)).ToArray();
            while (!ConstraintsAreValid(numbers))
            {
                numbers = _numberDefinitions.Select(n => n.GetNumber(randomNumberGenerator)).ToArray();
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