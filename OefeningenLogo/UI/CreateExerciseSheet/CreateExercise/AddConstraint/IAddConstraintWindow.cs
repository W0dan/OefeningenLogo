using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddNumber;

namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddConstraint
{
    public interface IAddConstraintWindow : IWindow
    {
        event Action Loaded;
        void ReloadConstraints(IDictionary<string, IConstraint> constraints);
    }
}