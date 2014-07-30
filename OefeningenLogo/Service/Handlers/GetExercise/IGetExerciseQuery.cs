using System.Collections.Generic;
using System.Xml.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetExercise
{
    public interface IGetExerciseQuery : IQuery
    {
        IExerciseDefinition GetExercise(XElement exerciseXml, IDictionary<string, IConstraint> allConstraints);
    }
}