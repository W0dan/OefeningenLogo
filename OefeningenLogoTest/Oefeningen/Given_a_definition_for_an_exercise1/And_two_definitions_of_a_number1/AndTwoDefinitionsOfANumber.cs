using Moq;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise1.And_two_definitions_of_a_number1
{
    public class AndTwoDefinitionsOfANumber : GivenADefinitionOfAnExercise
    {
        public AndTwoDefinitionsOfANumber()
        {
            ExerciseDefinition.AddNumberDefinition(GetNumberDefinition(Number1));
            ExerciseDefinition.AddNumberDefinition(GetNumberDefinition(Number2));
        }

        public decimal Number1
        {
            get
            {
                return 7;
            }
        }

        public decimal Number2
        {
            get
            {
                return 8;
            }
        }

        private INumberDefinition GetNumberDefinition(decimal number)
        {
            var mock = new Mock<INumberDefinition>();
            mock
                .Setup(m => m.GetNumber(It.IsAny<IProvideRandomNumbers>()))
                .Returns(number);
            return mock.Object;
        }
    }
}