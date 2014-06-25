using System;
using System.Windows.Forms;
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.RaiseEvent(() => CancelButtonClicked());
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.RaiseEvent(() => SaveButtonClicked());
        }

        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {
            this.RaiseEvent(() => NameChanged(NameTextbox.Text));
        }

        private void TemplateTextbox_TextChanged(object sender, EventArgs e)
        {
            this.RaiseEvent(() => TemplateChanged(TemplateTextbox.Text));
        }

        private void AddNumberButton_Click(object sender, EventArgs e)
        {
            this.RaiseEvent(() => AddNumberButtonClicked());
        }

        private void AddConstraintButton_Click(object sender, EventArgs e)
        {
            this.RaiseEvent(() => AddConstraintButtonClicked());
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
