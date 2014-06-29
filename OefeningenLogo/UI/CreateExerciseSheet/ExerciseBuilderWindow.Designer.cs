namespace OefeningenLogo.UI.CreateExerciseSheet
{
    partial class ExerciseBuilderWindow
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
            this.ExerciseListview = new System.Windows.Forms.ListView();
            this.AddExerciseButton = new System.Windows.Forms.Button();
            this.ExerciseSheetListview = new System.Windows.Forms.ListView();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.AlleOefeningenLabel = new System.Windows.Forms.Label();
            this.GeselecteerdeOefeningenLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExerciseListview
            // 
            this.ExerciseListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseListview.Location = new System.Drawing.Point(12, 69);
            this.ExerciseListview.Name = "ExerciseListview";
            this.ExerciseListview.Size = new System.Drawing.Size(849, 140);
            this.ExerciseListview.TabIndex = 0;
            this.ExerciseListview.UseCompatibleStateImageBehavior = false;
            this.ExerciseListview.View = System.Windows.Forms.View.List;
            this.ExerciseListview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExerciseListview_MouseDoubleClick);
            // 
            // AddExerciseButton
            // 
            this.AddExerciseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddExerciseButton.Location = new System.Drawing.Point(695, 215);
            this.AddExerciseButton.Name = "AddExerciseButton";
            this.AddExerciseButton.Size = new System.Drawing.Size(166, 23);
            this.AddExerciseButton.TabIndex = 1;
            this.AddExerciseButton.Text = "&Ontwerp nieuwe oefening";
            this.AddExerciseButton.UseVisualStyleBackColor = true;
            this.AddExerciseButton.Click += new System.EventHandler(this.AddExerciseButton_Click);
            // 
            // ExerciseSheetListview
            // 
            this.ExerciseSheetListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseSheetListview.Location = new System.Drawing.Point(12, 263);
            this.ExerciseSheetListview.Name = "ExerciseSheetListview";
            this.ExerciseSheetListview.Size = new System.Drawing.Size(849, 138);
            this.ExerciseSheetListview.TabIndex = 2;
            this.ExerciseSheetListview.UseCompatibleStateImageBehavior = false;
            this.ExerciseSheetListview.View = System.Windows.Forms.View.List;
            this.ExerciseSheetListview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExerciseSheetListview_MouseDoubleClick);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "Naam:";
            // 
            // NameTextbox
            // 
            this.NameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextbox.Location = new System.Drawing.Point(66, 12);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(795, 20);
            this.NameTextbox.TabIndex = 7;
            // 
            // AlleOefeningenLabel
            // 
            this.AlleOefeningenLabel.AutoSize = true;
            this.AlleOefeningenLabel.Location = new System.Drawing.Point(15, 53);
            this.AlleOefeningenLabel.Name = "AlleOefeningenLabel";
            this.AlleOefeningenLabel.Size = new System.Drawing.Size(80, 13);
            this.AlleOefeningenLabel.TabIndex = 9;
            this.AlleOefeningenLabel.Text = "Alle oefeningen";
            // 
            // GeselecteerdeOefeningenLabel
            // 
            this.GeselecteerdeOefeningenLabel.AutoSize = true;
            this.GeselecteerdeOefeningenLabel.Location = new System.Drawing.Point(15, 247);
            this.GeselecteerdeOefeningenLabel.Name = "GeselecteerdeOefeningenLabel";
            this.GeselecteerdeOefeningenLabel.Size = new System.Drawing.Size(132, 13);
            this.GeselecteerdeOefeningenLabel.TabIndex = 10;
            this.GeselecteerdeOefeningenLabel.Text = "Geselecteerde oefeningen";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(651, 407);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "&Bewaren";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(759, 407);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(102, 23);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "&Annuleren";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ExerciseBuilderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 440);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.GeselecteerdeOefeningenLabel);
            this.Controls.Add(this.AlleOefeningenLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.ExerciseSheetListview);
            this.Controls.Add(this.AddExerciseButton);
            this.Controls.Add(this.ExerciseListview);
            this.Name = "ExerciseBuilderWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oefeningenblad ontwerpen";
            this.Load += new System.EventHandler(this.ExerciseBuilderWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ExerciseListview;
        private System.Windows.Forms.Button AddExerciseButton;
        private System.Windows.Forms.ListView ExerciseSheetListview;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label AlleOefeningenLabel;
        private System.Windows.Forms.Label GeselecteerdeOefeningenLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;

    }
}