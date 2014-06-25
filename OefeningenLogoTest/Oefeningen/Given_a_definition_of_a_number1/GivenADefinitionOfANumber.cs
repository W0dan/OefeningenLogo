using OefeningenLogo.Oefeningen;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_of_a_number1
{
    public class GivenADefinitionOfANumber
    {
        public GivenADefinitionOfANumber()
        {
            NumberDefinition = new NumberDefinition("", MinValue, MaxValue);
        }

        protected int MaxValue
        {
            get { return 10; }
        }

        public int MinValue
        {
            get { return 0; }
        }

        public IAmADefinitionOfANumber NumberDefinition { get; set; }
    }
}