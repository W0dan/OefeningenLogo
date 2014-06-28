using OefeningenLogo.Oefeningen;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_of_a_number2
{
    public class GivenADefinitionOfANumber
    {
        public GivenADefinitionOfANumber()
        {
            NumberDefinition = new NumberDefinition("", MinValue, MaxValue, Decimals);
        }

        protected int Decimals
        {
            get { return 1; }
        }

        public int MaxValue
        {
            get { return 10; }
        }

        public int MinValue
        {
            get { return 0; }
        }

        public INumberDefinition NumberDefinition { get; set; }
    }
}