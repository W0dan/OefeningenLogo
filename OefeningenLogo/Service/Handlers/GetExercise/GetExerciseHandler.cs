using System.Linq;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service.Handlers.GetAllConstraints;

namespace OefeningenLogo.Service.Handlers.GetExercise
{
    public class GetExerciseHandler : IGetExerciseHandler
    {
        private readonly IRepository _repository;
        private readonly IGetAllConstraintsHandler _getAllConstraintsHandler;
        private readonly IGetExerciseQuery _getExerciseQuery;

        public GetExerciseHandler(IRepository repository, IGetAllConstraintsHandler getAllConstraintsHandler, IGetExerciseQuery getExerciseQuery)
        {
            _repository = repository;
            _getAllConstraintsHandler = getAllConstraintsHandler;
            _getExerciseQuery = getExerciseQuery;
        }

        public IExerciseDefinition GetExercise(string name)
        {
            var doc = _repository.Load();

            var allConstraints = _getAllConstraintsHandler.GetAllConstraints();

            var exerciseXml = (from e in doc.Descendants("exercises").Single()
                                   .Descendants("exercise")
                               where e.Attribute("name").Value == name
                               select e).Single();

            return _getExerciseQuery.GetExercise(exerciseXml, allConstraints);
        }
    }
}