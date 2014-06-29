namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddConstraint
{
    partial class AddConstraintWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AllConstraintsLabel = new System.Windows.Forms.Label();
            this.AllConstraintsListview = new System.Windows.Forms.ListView();
            this.SelectedConstraintsListview = new System.Windows.Forms.ListView();
            this.SelectedConstraintsLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllConstraintsLabel
            // 
            this.AllConstraintsLabel.AutoSize = true;
            this.AllConstraintsLabel.Location = new System.Drawing.Point(12, 9);
            this.AllConstraintsLabel.Name = "AllConstraintsLabel";
            this.AllConstraintsLabel.Size = new System.Drawing.Size(55, 13);
            this.AllConstraintsLabel.TabIndex = 0;
            this.AllConstraintsLabel.Text = "Alle regels";
            // 
            // AllConstraintsListview
            // 
            this.AllConstraintsListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllConstraintsListview.Location = new System.Drawing.Point(15, 25);
            this.AllConstraintsListview.Name = "AllConstraintsListview";
            this.AllConstraintsListview.Size = new System.Drawing.Size(387, 105);
            this.AllConstraintsListview.TabIndex = 1;
            this.AllConstraintsListview.UseCompatibleStateImageBehavior = false;
            this.AllConstraintsListview.View = System.Windows.Forms.View.List;
            // 
            // SelectedConstraintsListview
            // 
            this.SelectedConstraintsListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedConstraintsListview.Location = new System.Drawing.Point(15, 158);
            this.SelectedConstraintsListview.Name = "SelectedConstraintsListview";
            this.SelectedConstraintsListview.Size = new System.Drawing.Size(387, 105);
            this.SelectedConstraintsListview.TabIndex = 3;
            this.SelectedConstraintsListview.UseCompatibleStateImageBehavior = false;
            this.SelectedConstraintsListview.View = System.Windows.Forms.View.List;
            // 
            // SelectedConstraintsLabel
            // 
            this.SelectedConstraintsLabel.AutoSize = true;
            this.SelectedConstraintsLabel.Location = new System.Drawing.Point(12, 142);
            this.SelectedConstraintsLabel.Name = "SelectedConstraintsLabel";
            this.SelectedConstraintsLabel.Size = new System.Drawing.Size(107, 13);
            this.SelectedConstraintsLabel.TabIndex = 2;
            this.SelectedConstraintsLabel.Text = "Geselecteerde regels";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(191, 269);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "&Bewaren";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(299, 269);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(102, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "&Annuleren";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // AddConstraintWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 299);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectedConstraintsListview);
            this.Controls.Add(this.SelectedConstraintsLabel);
            this.Controls.Add(this.AllConstraintsListview);
            this.Controls.Add(this.AllConstraintsLabel);
            this.Name = "AddConstraintWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regel toevoegen";
            this.Load += new System.EventHandler(this.AddConstraintWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AllConstraintsLabel;
        private System.Windows.Forms.ListView AllConstraintsListview;
        private System.Windows.Forms.ListView SelectedConstraintsListview;
        private System.Windows.Forms.Label SelectedConstraintsLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}