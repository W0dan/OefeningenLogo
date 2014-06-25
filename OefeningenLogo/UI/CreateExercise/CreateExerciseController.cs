using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddConstraint;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExercise
{
    public class CreateExerciseController : ICreateExerciseController
    {
        private readonly ICreateExerciseWindow _window;
        private readonly IRepository _repository;
        private string _exerciseName;
        private string _exerciseTemplate;
        private readonly List<IAmADefinitionOfANumber> _numbers = new List<IAmADefinitionOfANumber>();
        private readonly List<IAmAConstraint> _constraints = new List<IAmAConstraint>();
        private IAmADefinitionOfAnExercise _exercise;
        private bool _templateValid;
        private bool _nameValid;

        public static IAmADefinitionOfAnExercise ShowWindow(IWin32Window parent, IRepository repository)
        {
            var window = new CreateExerciseWindow();
            var result = new CreateExerciseController(window, repository);
            window.ShowDialog(parent);
            return result._exercise;
        }

        private CreateExerciseController(ICreateExerciseWindow window, IRepository repository)
        {
            _window = window;
            _repository = repository;
            _window.SaveButtonClicked += SaveButtonClicked;
            _window.CancelButtonClicked += CancelButtonClicked;
            _window.AddNumberButtonClicked += AddNumberButtonClicked;
            _window.AddConstraintButtonClicked += AddConstraintButtonClicked;
            _window.NameChanged += NameChanged;
            _window.TemplateChanged += TemplateChanged;
        }

        private void TemplateChanged(string template)
        {
            _templateValid = true;
            if (string.IsNullOrWhiteSpace(template))
                _templateValid = false;
            
            _window.TemplateValid(_templateValid);

            _exerciseTemplate = template;
        }

        private void NameChanged(string name)
        {
            _nameValid = true;
            if (string.IsNullOrWhiteSpace(name))
                _nameValid = false;

            _window.NameValid(_nameValid);

            _exerciseName = name;
        }

        private void AddConstraintButtonClicked()
        {
            var constraint = AddConstraintController.ShowWindow(_window, _repository);

            if (constraint == null)
                return;

            _constraints.Add(constraint);
            _window.AddNumber(constraint.ToString());
        }

        private void AddNumberButtonClicked()
        {
            var number = AddNumberController.ShowWindow(_window);

            if (number == null)
                return;

            _numbers.Add(number);
            _window.AddNumber(number.ToString());
        }

        private void CancelButtonClicked()
        {
            CloseWindow();
        }

        private void SaveButtonClicked()
        {
            if (!IsValid())
                return;

            _exercise = new ExerciseDefinition(_exerciseName, new ExerciseTemplate(_exerciseTemplate));

            foreach (var number in _numbers)
            {
                _exercise.AddNumberDefinition(number);
            }

            foreach (var constraint in _constraints)
            {
                _exercise.AddConstraint(constraint);
            }

            _repository.SaveExercise(_exercise);

            CloseWindow();
        }

        private bool IsValid()
        {
            if ((!_nameValid || !_templateValid))
            {
                _window.NameValid(_nameValid);
                _window.TemplateValid(_templateValid);
                _window.ValidationIssuesPresent();
                return false;
            }
            return true;
        }

        private void CloseWindow()
        {
            _window.Close();
        }
    }
}