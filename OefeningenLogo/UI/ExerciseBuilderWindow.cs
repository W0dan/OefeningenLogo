using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI.CreateExercise.AddNumber;
using OefeningenLogo.UI.Extensions;

namespace OefeningenLogo.UI
{
    public partial class ExerciseBuilderWindow : Form, IExerciseBuilderWindow
    {
        public event Action Loaded;
        public event Action AddExerciseButtonClicked;
        public event Action<string> ExerciseSelected;
        public event Action<string> ExerciseUnselected;

        public ExerciseBuilderWindow()
        {
            InitializeComponent();
        }

        private void AddExerciseButton_Click(object sender, EventArgs e)
        {
            AddExerciseButtonClicked.Raise();
        }

        private void ExerciseBuilderWindow_Load(object sender, EventArgs e)
        {
            Loaded.Raise();
        }

        private void ExerciseListview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hit = ExerciseListview.HitTest(e.Location);

            if (hit.Item == null)
                return;

            ExerciseSelected.Raise((string)hit.Item.Tag);
        }

        private void ExerciseSheetListview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hit = ExerciseSheetListview.HitTest(e.Location);

            if (hit.Item == null)
                return;

            ExerciseUnselected.Raise((string)hit.Item.Tag);
        }

        public void Clear()
        {
            ExerciseListview.Items.Clear();
        }
        
        public void ShowDialog(IWindow parent)
        {
            base.ShowDialog(parent);
        }

        public void ReloadExercises(IEnumerable<IExerciseDefinition> exercises)
        {
            ExerciseListview.Items.Clear();

            foreach (var exercise in exercises)
            {
                var item = new ListViewItem(exercise.ToString()) { Tag = exercise.Name };
                ExerciseListview.Items.Add(item);
            }
        }

        public void RemoveExercise(string exerciseName)
        {
            var exerciseToDelete = ExerciseSheetListview.GetItems()
                .AsQueryable().OfType<ListViewItem>()
                .Single(i => (string)i.Tag == exerciseName);

            ExerciseSheetListview.Items.Remove(exerciseToDelete);
        }

        public void AddExercise(string exerciseName)
        {
            var exerciseToAdd = (ListViewItem)ExerciseListview.GetItems()
                .Single(i => (string)i.Tag == exerciseName)
                .Clone();

            ExerciseSheetListview.Items.Add(exerciseToAdd);
        }
    }
}
