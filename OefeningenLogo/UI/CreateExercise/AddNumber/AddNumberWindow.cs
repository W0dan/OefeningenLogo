using System;
using System.Windows.Forms;
using OefeningenLogo.UI.Extensions;

namespace OefeningenLogo.UI.CreateExercise.AddNumber
{
    public partial class AddNumberWindow : Form, IAddNumberWindow
    {
        public event Action SaveButtonClicked;
        public event Action CancelButtonClicked;
        public event Action<string> NameChanged;
        public event Action<string> MinvalueChanged;
        public event Action<string> MaxvalueChanged;
        public event Action<string> DecimalsChanged;

        public AddNumberWindow()
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

        private void MinvalueTextbox_TextChanged(object sender, EventArgs e)
        {
            MinvalueChanged.Raise(MinvalueTextbox.Text);
        }

        private void MaxvalueTextbox_TextChanged(object sender, EventArgs e)
        {
            MaxvalueChanged.Raise(MaxvalueTextbox.Text);
        }

        private void DecimalsTextbox_TextChanged(object sender, EventArgs e)
        {
            DecimalsChanged.Raise(DecimalsTextbox.Text);
        }

        public void DecimalsValid(bool valid)
        {
            DecimalsTextbox.SetValidState(valid);
        }

        public void MinvalueValid(bool valid)
        {
            MinvalueTextbox.SetValidState(valid);
        }

        public void NameValid(bool valid)
        {
            NameTextbox.SetValidState(valid);
        }

        public void MaxvalueValid(bool valid)
        {
            MaxvalueTextbox.SetValidState(valid);
        }

        public void ValidationIssuesPresent()
        {
            MessageBox.Show("Niet alle velden zijn goed ingevuld !");
        }

    }
}
