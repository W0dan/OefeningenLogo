namespace OefeningenLogo.UI
{
    partial class ExerciseSheetWindow
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
            this.ExerciseSheetListview = new System.Windows.Forms.ListView();
            this.CreateNewExerciseSheetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExerciseSheetListview
            // 
            this.ExerciseSheetListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExerciseSheetListview.Location = new System.Drawing.Point(12, 12);
            this.ExerciseSheetListview.Name = "ExerciseSheetListview";
            this.ExerciseSheetListview.Size = new System.Drawing.Size(713, 532);
            this.ExerciseSheetListview.TabIndex = 0;
            this.ExerciseSheetListview.UseCompatibleStateImageBehavior = false;
            this.ExerciseSheetListview.View = System.Windows.Forms.View.List;
            this.ExerciseSheetListview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExerciseSheetListview_MouseDoubleClick);
            // 
            // CreateNewExerciseSheetButton
            // 
            this.CreateNewExerciseSheetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateNewExerciseSheetButton.Location = new System.Drawing.Point(485, 550);
            this.CreateNewExerciseSheetButton.Name = "CreateNewExerciseSheetButton";
            this.CreateNewExerciseSheetButton.Size = new System.Drawing.Size(240, 23);
            this.CreateNewExerciseSheetButton.TabIndex = 1;
            this.CreateNewExerciseSheetButton.Text = "&Ontwerp nieuw oefeningenblad";
            this.CreateNewExerciseSheetButton.UseVisualStyleBackColor = true;
            this.CreateNewExerciseSheetButton.Click += new System.EventHandler(this.CreateNewExerciseSheetButton_Click);
            // 
            // ExerciseSheetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 585);
            this.Controls.Add(this.CreateNewExerciseSheetButton);
            this.Controls.Add(this.ExerciseSheetListview);
            this.Name = "ExerciseSheetWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oefeningen maken";
            this.Load += new System.EventHandler(this.ExerciseSheetWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ExerciseSheetListview;
        private System.Windows.Forms.Button CreateNewExerciseSheetButton;
    }
}