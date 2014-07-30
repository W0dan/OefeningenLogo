using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service.Handlers.GetAllConstraints;

namespace OefeningenLogo.UI.AddConstraint
{
    public class AddConstraintController:IController, IAddConstraintController
    {
        private readonly IAddConstraintWindow _window;
        private readonly IGetAllConstraintsHandler _getAllConstraintsHandler;
        private IConstraint _constraint;

        public AddConstraintController(IAddConstraintWindow window, IGetAllConstraintsHandler getAllConstraintsHandler )
        {
            _window = window;
            _getAllConstraintsHandler = getAllConstraintsHandler;
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
            var constraints = _getAllConstraintsHandler.GetAllConstraints();
            _window.ReloadConstraints(constraints);
        }
    }
}