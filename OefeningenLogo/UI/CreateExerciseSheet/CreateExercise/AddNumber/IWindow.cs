using System.Windows.Forms;

namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddNumber
{
    public interface IWindow : IWin32Window
    {
        void ShowDialog(IWindow parent);
    }
}