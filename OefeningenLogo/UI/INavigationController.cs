using System.Windows.Forms;

namespace OefeningenLogo.UI
{
    public interface INavigationController : IController
    {
        Form GetStartupWindow();
    }
}