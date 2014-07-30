using Moq;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise2.And_one_definition_of_a_number
{
    public class AndOneDefinitionOfANumber : GivenADefinitionOfAnExercise
    {
        public AndOneDefinitionOfANumber()
        {
            var mock = new Mock<INumberDefinition>();
            mock
                .Setup(m => m.GetNumber(It.IsAny<IProvideRandomNumbers>()))
                .Returns(Number);

            ExerciseDefinition.AddNumberDefinition(mock.Object);
        }

        public decimal Number
        {
            get { return 5; }
        }
    }
}