using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OefeningenLogo.Oefeningen;
using OefeningenLogo.UI._Extensions;

namespace OefeningenLogo.UI.AddConstraint
{
    public partial class AddConstraintWindow : Form, IAddConstraintWindow
    {
        public event Action Loaded;

        public AddConstraintWindow()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWindow parent)
        {
            base.ShowDialog(parent);
        }

        private void AddConstraintWindow_Load(object sender, EventArgs e)
        {
            Loaded.Raise();
        }

        public void ReloadConstraints(IDictionary<string, IConstraint> constraints)
        {
            AllConstraintsListview.Items.Clear();

            foreach (var constraint in constraints)
            {
                var item = new ListViewItem(constraint.Value.ToString()) {Tag = constraint.Key};
                AllConstraintsListview.Items.Add(item);
            }
        }
    }
}
