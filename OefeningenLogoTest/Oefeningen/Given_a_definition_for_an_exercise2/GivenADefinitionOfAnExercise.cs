﻿using Moq;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogoTest.Oefeningen.Given_a_definition_for_an_exercise2
{
    public class GivenADefinitionOfAnExercise
    {
        public GivenADefinitionOfAnExercise()
        {
            var mock = new Mock<IAmATemplateForAnExercise>();
            mock
                .Setup(m => m.Template)
                .Returns(Template);

            ExerciseDefinition = new ExerciseDefinition("", mock.Object);
        }

        public string Template
        {
            get { return "{0} * 2 = ."; }
        }

        public IAmADefinitionOfAnExercise ExerciseDefinition { get; private set; }
    }
}