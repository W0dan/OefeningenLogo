using System;
using System.Collections.Generic;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.AddConstraint
{
    public interface IAddConstraintWindow : IWindow
    {
        event Action Loaded;
        void ReloadConstraints(IDictionary<string, IConstraint> constraints);
    }
}