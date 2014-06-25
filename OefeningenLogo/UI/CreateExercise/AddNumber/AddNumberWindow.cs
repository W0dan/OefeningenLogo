using System;
using System.Drawing;
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

        private void MinvalueTextbox_TextChanged(object sender, EventArgs e)
        {
            this.RaiseEvent(() => MinvalueChanged(MinvalueTextbox.Text));
        }

        private void MaxvalueTextbox_TextChanged(object sender, EventArgs e)
        {
            this.RaiseEvent(() => MaxvalueChanged(MaxvalueTextbox.Text));
        }

        private void DecimalsTextbox_TextChanged(object sender, EventArgs e)
        {
            this.RaiseEvent(() => DecimalsChanged(DecimalsTextbox.Text));
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
