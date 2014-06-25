using System;
using System.Windows.Forms;

namespace OefeningenLogo.UI.CreateExercise.AddNumber
{
    public interface IAddNumberWindow : IWin32Window
    {
        void Close();
        void DecimalsValid(bool valid);
        void MaxvalueValid(bool valid);
        void MinvalueValid(bool valid);
        void NameValid(bool valid);
        void ValidationIssuesPresent();
        event Action SaveButtonClicked;
        event Action CancelButtonClicked;
        event Action<string> NameChanged;
        event Action<string> MinvalueChanged;
        event Action<string> MaxvalueChanged;
        event Action<string> DecimalsChanged;
    }
}