using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetAllSheets
{
    public interface IGetAllSheetsHandler : IHandler
    {
        IEnumerable<IExerciseSheet> GetAllSheets();
    }
}