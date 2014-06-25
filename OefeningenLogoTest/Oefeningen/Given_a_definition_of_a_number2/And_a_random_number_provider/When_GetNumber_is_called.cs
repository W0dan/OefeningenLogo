using Xunit;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_of_a_number2.And_a_random_number_provider
{
    public class When_GetNumber_is_called : IUseFixture<AndARandomNumberProvider>
    {
        private AndARandomNumberProvider _data;
        private decimal _result;

        public void SetFixture(AndARandomNumberProvider data)
        {
            _data = data;

            _result = _data.NumberDefinition.GetNumber(data.RandomNumberProvider);
        }

        [Fact]
        public void The_returned_number_is_smaller_than_or_equal_to_MaxNumber()
        {
            Assert.True(_result <= _data.MaxValue);
        }

        [Fact]
        public void It_returns_the_generated_number()
        {
            Assert.Equal(((decimal)_data.ExpectedRandomNumber / 10).ToString("0.0"), _result.ToString("0.0"));
        }
    }
}