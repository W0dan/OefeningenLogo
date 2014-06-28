using System;
using System.Drawing;
using System.Windows.Forms;
using OefeningenLogo.UI.CreateExercise.AddNumber;
using OefeningenLogo.UI.Extensions;

namespace OefeningenLogo.UI.CreateExercise
{
    public partial class CreateExerciseWindow : Form, ICreateExerciseWindow
    {
        public event Action SaveButtonClicked;
        public event Action CancelButtonClicked;
        public event Action AddNumberButtonClicked;
        public event Action AddConstraintButtonClicked;
        public event Action<string> NameChanged;
        public event Action<string> TemplateChanged;

        public CreateExerciseWindow()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWindow parent)
        {
            base.ShowDialog(parent);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelButtonClicked.Raise();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButtonClicked.Raise();
        }

        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {
            NameChanged.Raise(NameTextbox.Text);
        }

        private void TemplateTextbox_TextChanged(object sender, EventArgs e)
        {
            TemplateChanged.Raise(TemplateTextbox.Text);
        }

        private void AddNumberButton_Click(object sender, EventArgs e)
        {
            AddNumberButtonClicked.Raise();
        }

        private void AddConstraintButton_Click(object sender, EventArgs e)
        {
            AddConstraintButtonClicked.Raise();
        }

        public void Clear()
        {
            NameTextbox.Text = string.Empty;
            NameTextbox.BackColor = Color.White;
            TemplateTextbox.Text = string.Empty;
            TemplateTextbox.BackColor = Color.White;
            NumbersListview.Items.Clear();
            ConstraintsListview.Items.Clear();
        }

        public void AddNumber(string number)
        {
            NumbersListview.Items.Add(number);
        }

        public void NameValid(bool valid)
        {
            NameTextbox.SetValidState(valid);
        }

        public void TemplateValid(bool valid)
        {
            TemplateTextbox.SetValidState(valid);
        }

        public void ValidationIssuesPresent()
        {
            MessageBox.Show("Niet alle velden zijn goed ingevuld !");
        }
    }
}
