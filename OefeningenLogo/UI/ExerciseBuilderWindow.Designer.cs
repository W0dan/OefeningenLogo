namespace OefeningenLogo.UI
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
            this.SuspendLayout();
            // 
            // ExerciseListview
            // 
            this.ExerciseListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseListview.Location = new System.Drawing.Point(12, 12);
            this.ExerciseListview.Name = "ExerciseListview";
            this.ExerciseListview.Size = new System.Drawing.Size(827, 507);
            this.ExerciseListview.TabIndex = 0;
            this.ExerciseListview.UseCompatibleStateImageBehavior = false;
            this.ExerciseListview.View = System.Windows.Forms.View.List;
            // 
            // AddExerciseButton
            // 
            this.AddExerciseButton.Location = new System.Drawing.Point(673, 525);
            this.AddExerciseButton.Name = "AddExerciseButton";
            this.AddExerciseButton.Size = new System.Drawing.Size(166, 23);
            this.AddExerciseButton.TabIndex = 1;
            this.AddExerciseButton.Text = "&Oefening toevoegen";
            this.AddExerciseButton.UseVisualStyleBackColor = true;
            this.AddExerciseButton.Click += new System.EventHandler(this.AddExerciseButton_Click);
            // 
            // ExerciseBuilderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 560);
            this.Controls.Add(this.AddExerciseButton);
            this.Controls.Add(this.ExerciseListview);
            this.Name = "ExerciseBuilderWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oefeningen maker";
            this.Load += new System.EventHandler(this.ExerciseBuilderWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ExerciseListview;
        private System.Windows.Forms.Button AddExerciseButton;

    }
}