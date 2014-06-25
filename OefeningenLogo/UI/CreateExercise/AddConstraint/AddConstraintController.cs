using OefeningenLogo.Backend;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.CreateExercise.AddConstraint
{
    public class AddConstraintController
    {
        private readonly AddConstraintWindow _window;
        private readonly IRepository _repository;
        private IAmAConstraint _constraint;

        private AddConstraintController(AddConstraintWindow window, IRepository repository)
        {
            _window = window;
            _repository = repository;
        }

        public static IAmAConstraint ShowWindow(ICreateExerciseWindow parent, IRepository repository)
        {
            var window = new AddConstraintWindow();
            var result = new AddConstraintController(window, repository);
            window.ShowDialog(parent);
            return result._constraint;
        }
    }
}