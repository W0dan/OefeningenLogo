using Moq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise1.And_two_definitions_of_a_number2.And_a_constraint
{
    public class AndAConstraint : AndTwoDefinitionsOfANumber
    {
        public AndAConstraint()
        {
            var mock = new Mock<IAmAConstraint>();

            mock
                .Setup(m => m.IsValid(It.Is<decimal[]>(ar => ar[0] <= ar[1])))
                .Returns(true);

            ExerciseDefinition.AddConstraint(mock.Object);
        }
    }
}