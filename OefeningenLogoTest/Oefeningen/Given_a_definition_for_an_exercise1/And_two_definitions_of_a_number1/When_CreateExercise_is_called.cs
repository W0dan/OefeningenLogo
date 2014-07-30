using Moq;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service;
using Xunit;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise1.And_two_definitions_of_a_number1
{
    public class When_CreateExercise_is_called : IUseFixture<AndTwoDefinitionsOfANumber>
    {
        private string _result;
        private AndTwoDefinitionsOfANumber _data;

        public void SetFixture(AndTwoDefinitionsOfANumber data)
        {
            _data = data;

            _result = data.ExerciseDefinition.CreateExercise(It.IsAny<IProvideRandomNumbers>());
        }

        [Fact]
        public void It_creates_an_exercise()
        {
            Assert.Equal(string.Format(_data.Template, _data.Number1, _data.Number2), _result);
        }
    }
}