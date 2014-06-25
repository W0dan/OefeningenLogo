namespace OefeningenLogo.Oefeningen
{
    public class ExerciseTemplate : IAmATemplateForAnExercise
    {
        private readonly string _template;

        public ExerciseTemplate(string template)
        {
            _template = template;
        }

        public string Template
        {
            get { return _template; }
        }
    }
}