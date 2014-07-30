using System.Xml.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service
{
    public interface IRepository
    {
        void SaveExercise(IExerciseDefinition exercise);
        void SaveConstraint(IConstraint constraint);
        IExerciseSheet GetExerciseSheet(string name);
        XDocument Load();
        void Save();
    }
}