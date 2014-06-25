using Xunit;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_of_a_number1.And_a_random_number_provider
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
        public void It_returns_the_generated_number()
        {
            Assert.Equal(_data.ExpectedRandomNumber.ToString("0"), _result.ToString("0"));
        }
    }
}