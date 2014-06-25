using Moq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_of_a_number1.And_a_random_number_provider
{
    public class AndARandomNumberProvider : GivenADefinitionOfANumber
    {
        private readonly int[] _randomNumbers;
        private int _rnPointer = -1;

        public AndARandomNumberProvider()
        {
            _randomNumbers = new[] {5, 7, 3};
            var mock = new Mock<IProvideRandomNumbers>();

            mock
                .Setup(m => m.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(GetRandomNumber);

            RandomNumberProvider = mock.Object;
        }

        public int ExpectedRandomNumber
        {
            get
            {
                return _randomNumbers[0];
            }
        }

        public int GetRandomNumber()
        {
            _rnPointer++;
            return _randomNumbers[_rnPointer];
        }

        public IProvideRandomNumbers RandomNumberProvider { get; private set; }
    }
}