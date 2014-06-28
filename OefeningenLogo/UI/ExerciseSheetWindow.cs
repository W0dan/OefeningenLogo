using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddNumber;
using OefeningenLogo.UI.Extensions;

namespace OefeningenLogo.UI
{
    public partial class ExerciseSheetWindow : Form, IExerciseSheetWindow
    {
        public event Action AddExerciseSheetButtonClicked;
        public event Action Loaded;

        public ExerciseSheetWindow()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWindow parent)
        {
            base.ShowDialog(parent);
        }

        private void CreateNewExerciseSheetButton_Click(object sender, EventArgs e)
        {
            AddExerciseSheetButtonClicked.Raise();
        }

        private void ExerciseSheetWindow_Load(object sender, EventArgs e)
        {
            Loaded.Raise();
        }

        public void ReloadExerciseSheets(IEnumerable<ExerciseSheet> exerciseSheets)
        {
            foreach (var exerciseSheet in exerciseSheets)
            {
                ExerciseSheetListview.Items.Add(exerciseSheet.ToString());
            }
        }
    }
}
