using System;
using OefeningenLogo.UI.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExercise
{
    public interface ICreateExerciseWindow : IWindow
    {
        void Close();
        void AddNumber(string number);
        void NameValid(bool valid);
        void TemplateValid(bool valid);
        void ValidationIssuesPresent();
        event Action SaveButtonClicked;
        event Action CancelButtonClicked;
        event Action AddNumberButtonClicked;
        event Action AddConstraintButtonClicked;
        event Action<string> NameChanged;
        event Action<string> TemplateChanged;
        void Clear();
    }
}