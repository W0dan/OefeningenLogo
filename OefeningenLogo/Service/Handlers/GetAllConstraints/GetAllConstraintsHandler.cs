using System.Collections.Generic;
using System.Linq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.Service.Handlers.GetAllConstraints
{
    public class GetAllConstraintsHandler : IGetAllConstraintsHandler
    {
        private readonly IRepository _repository;

        public GetAllConstraintsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public IDictionary<string, IConstraint> GetAllConstraints()
        {
            var doc = _repository.Load();

            var constraints = new Dictionary<string, IConstraint>();

            var allConstraintsXml =
                from c in doc.Descendants("constraints").First().Descendants("constraint")
                select c;

            foreach (var constraintXml in allConstraintsXml)
            {
                var name = constraintXml.Attribute("name").Value;
                var value = constraintXml.Attribute("value").Value;
                var description = constraintXml.Attribute("description").Value;

                constraints.Add(name, ConstraintBuilder.BuildConstraint(value, description));
            }

            return constraints;
        }
    }
}