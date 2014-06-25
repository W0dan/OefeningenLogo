using System.Collections.Generic;
using Moq;
using OefeningenLogo.Oefeningen;
using OefeningenLogoTest.Extensions;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise1.And_two_definitions_of_a_number2
{
    public class AndTwoDefinitionsOfANumber : GivenADefinitionOfAnExercise
    {
        private readonly decimal[] _number1Numbers = new[] { 8M, 3M };
        private readonly decimal[] _number2Numbers = new[] { 7M, 5M };

        public AndTwoDefinitionsOfANumber()
        {
            ExerciseDefinition.AddNumberDefinition(GetNumberDefinition(_number1Numbers));
            ExerciseDefinition.AddNumberDefinition(GetNumberDefinition(_number2Numbers));
        }

        public decimal LastReturnedNumber1
        {
            get { return _number1Numbers[_number1Numbers.Length - 1]; }
        }

        public decimal LastReturnedNumber2
        {
            get { return _number2Numbers[_number2Numbers.Length - 1]; }
        }

        private IAmADefinitionOfANumber GetNumberDefinition(IList<decimal> numbersArray)
        {
            var mock = new Mock<IAmADefinitionOfANumber>();
            mock
                .Setup(m => m.GetNumber(It.IsAny<IProvideRandomNumbers>()))
                .ReturnsInOrder(numbersArray[0], numbersArray[1]);
            return mock.Object;
        }
    }
}