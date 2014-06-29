using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddConstraint
{
    public class AddConstraintController:IController, IAddConstraintController
    {
        private readonly IAddConstraintWindow _window;
        private readonly IRepository _repository;
        private IConstraint _constraint;

        public AddConstraintController(IAddConstraintWindow window, IRepository repository)
        {
            _window = window;
            _repository = repository;
        }

        public IConstraint ShowWindow(IWindow parent)
        {
            _window.Loaded += Loaded;
            
            _window.ShowDialog(parent);

            _window.Loaded -= Loaded;

            return _constraint;
        }

        void Loaded()
        {
            Reload();
        }

        private void Reload()
        {
            var constraints = _repository.GetAllConstraints();
            _window.ReloadConstraints(constraints);
        }
    }
}