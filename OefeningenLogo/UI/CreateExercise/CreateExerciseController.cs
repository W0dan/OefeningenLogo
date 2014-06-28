using System.Collections.Generic;
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
        private readonly IAddNumberController _addNumberController;
        private readonly IAddConstraintController _addConstraintController;
        private string _exerciseName;
        private string _exerciseTemplate;
        private List<INumberDefinition> _numbers = new List<INumberDefinition>();
        private List<IConstraint> _constraints = new List<IConstraint>();
        private bool _templateValid;
        private bool _nameValid;

        public CreateExerciseController(ICreateExerciseWindow window, IRepository repository, IAddNumberController addNumberController, IAddConstraintController addConstraintController)
        {

            _window = window;
            _repository = repository;
            _addNumberController = addNumberController;
            _addConstraintController = addConstraintController;
        }

        public void ShowWindow(IWindow parent)
        {
            _nameValid = false;
            _templateValid = false;
            _numbers = new List<INumberDefinition>();
            _constraints = new List<IConstraint>();

            _window.SaveButtonClicked += SaveButtonClicked;
            _window.CancelButtonClicked += CancelButtonClicked;
            _window.AddNumberButtonClicked += AddNumberButtonClicked;
            _window.AddConstraintButtonClicked += AddConstraintButtonClicked;
            _window.NameChanged += NameChanged;
            _window.TemplateChanged += TemplateChanged;

            _window.ShowDialog(parent);

            _window.SaveButtonClicked -= SaveButtonClicked;
            _window.CancelButtonClicked -= CancelButtonClicked;
            _window.AddNumberButtonClicked -= AddNumberButtonClicked;
            _window.AddConstraintButtonClicked -= AddConstraintButtonClicked;
            _window.NameChanged -= NameChanged;
            _window.TemplateChanged -= TemplateChanged;

            _window.Clear();
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
            var constraint = _addConstraintController.ShowWindow(_window);

            if (constraint == null)
                return;

            _constraints.Add(constraint);
            _window.AddNumber(constraint.ToString());
        }

        private void AddNumberButtonClicked()
        {
            var number = _addNumberController.ShowWindow(_window);

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

            var exercise = new ExerciseDefinition(_exerciseName, new ExerciseTemplate(_exerciseTemplate));

            foreach (var number in _numbers)
            {
                exercise.AddNumberDefinition(number);
            }

            foreach (var constraint in _constraints)
            {
                exercise.AddConstraint(constraint);
            }

            _repository.SaveExercise(exercise);

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