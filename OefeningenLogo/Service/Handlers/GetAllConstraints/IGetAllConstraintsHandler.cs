using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetAllConstraints
{
    public interface IGetAllConstraintsHandler : IHandler
    {
        IDictionary<string, IConstraint> GetAllConstraints();
    }
}