using Moq;
using OefeningenLogo.Oefeningen;
using Xunit;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise1.And_two_definitions_of_a_number2.And_a_constraint
{
    public class When_CreateExercise_is_called : IUseFixture<AndAConstraint>
    {
        private string _result;
        private AndAConstraint _data;

        public void SetFixture(AndAConstraint data)
        {
            _data = data;

            _result = data.ExerciseDefinition.CreateExercise(It.IsAny<IProvideRandomNumbers>());
        }

        [Fact]
        public void It_creates_an_exercise()
        {
            Assert.Equal(string.Format(_data.Template, _data.LastReturnedNumber1, _data.LastReturnedNumber2), _result);
        }
    }
}