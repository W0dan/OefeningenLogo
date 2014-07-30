using Moq;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.Service;
using Xunit;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise2.And_one_definition_of_a_number
{
    public class When_CreateExercise_is_called : IUseFixture<AndOneDefinitionOfANumber>
    {
        private string _result;
        private AndOneDefinitionOfANumber _data;

        public void SetFixture(AndOneDefinitionOfANumber data)
        {
            _data = data;

            _result = data.ExerciseDefinition.CreateExercise(It.IsAny<IProvideRandomNumbers>());
        }

        [Fact]
        public void It_creates_an_exercise()
        {
            Assert.Equal(string.Format(_data.Template, _data.Number), _result);
        }
    }
}