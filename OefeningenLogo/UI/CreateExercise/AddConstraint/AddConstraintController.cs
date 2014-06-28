using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExercise.AddConstraint
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
            _window.ShowDialog(parent);
            return _constraint;
        }
    }
}