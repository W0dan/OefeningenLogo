using System.Windows.Forms;

namespace OefeningenLogo.UI
{
    public interface IWindow : IWin32Window
    {
        void ShowDialog(IWindow parent);
    }
}