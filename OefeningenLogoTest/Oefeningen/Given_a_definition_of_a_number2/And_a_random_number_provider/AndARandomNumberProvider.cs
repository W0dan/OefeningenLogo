using Moq;
using OefeningenLogo.Oefeningen;
using OefeningenLogoTest.Extensions;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_of_a_number2.And_a_random_number_provider
{
    public class AndARandomNumberProvider : GivenADefinitionOfANumber
    {
        private readonly int[] _randomNumbers = new[] { 52, 77, 35 };

        public AndARandomNumberProvider()
        {
            var mock = new Mock<IProvideRandomNumbers>();

            mock
                .Setup(m => m.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsInOrder(_randomNumbers);

            RandomNumberProvider = mock.Object;
        }

        public int ExpectedRandomNumber
        {
            get
            {
                return _randomNumbers[0];
            }
        }

        public IProvideRandomNumbers RandomNumberProvider { get; private set; }
    }
}