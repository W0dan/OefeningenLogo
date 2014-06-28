using System.Windows.Forms;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExercise.AddConstraint
{
    public partial class AddConstraintWindow : Form,IAddConstraintWindow
    {
        public AddConstraintWindow()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWindow parent)
        {
            base.ShowDialog(parent);
        }
    }
}
