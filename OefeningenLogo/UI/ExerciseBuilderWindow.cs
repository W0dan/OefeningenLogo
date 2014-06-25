using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.Extensions;

namespace OefeningenLogo.UI
{
    public partial class ExerciseBuilderWindow : Form, IExerciseBuilderWindow
    {
        public event Action AddExerciseButtonClicked;
        public event Action Loaded;

        public ExerciseBuilderWindow()
        {
            InitializeComponent();
        }

        private void AddExerciseButton_Click(object sender, EventArgs e)
        {
            this.RaiseEvent(() => AddExerciseButtonClicked());
        }

        private void ExerciseBuilderWindow_Load(object sender, EventArgs e)
        {
            this.RaiseEvent(() => Loaded());
        }

        public void ReloadExercises(IEnumerable<IAmADefinitionOfAnExercise> exercises)
        {
            ExerciseListview.Items.Clear();

            foreach (var exercise in exercises)
            {
                ExerciseListview.Items.Add(exercise.ToString());
            }
        }
    }
}
