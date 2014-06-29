using System;
using OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise
{
    public interface ICreateExerciseWindow : IWindow
    {
        void Close();
        void AddNumber(string number);
        void NameValid(bool valid);
        void TemplateValid(bool valid);
        void ValidationIssuesPresent();
        void Message(string message);
        event Action SaveButtonClicked;
        event Action CancelButtonClicked;
        event Action AddNumberButtonClicked;
        event Action AddConstraintButtonClicked;
        event Action<string> NameChanged;
        event Action<string> TemplateChanged;
        void Clear();
    }
}