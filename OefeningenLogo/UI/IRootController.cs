using System.Windows.Forms;

namespace OefeningenLogo.UI
{
    public interface IRootController : IController
    {
        Form Window { get; }
    }
}