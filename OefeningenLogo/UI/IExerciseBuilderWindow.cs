using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI
{
    public interface IExerciseBuilderWindow : IWin32Window
    {
        void ReloadExercises(IEnumerable<IAmADefinitionOfAnExercise> exercises);
        event Action AddExerciseButtonClicked;
        event Action Loaded;
    }
}