namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise
{
    partial class CreateExerciseWindow
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
            this.TemplateTextbox = new System.Windows.Forms.TextBox();
            this.TemplateLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NumbersListview = new System.Windows.Forms.ListView();
            this.NumbersLabel = new System.Windows.Forms.Label();
            this.ConstraintsLabel = new System.Windows.Forms.Label();
            this.ConstraintsListview = new System.Windows.Forms.ListView();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddNumberButton = new System.Windows.Forms.Button();
            this.AddConstraintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TemplateTextbox
            // 
            this.TemplateTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TemplateTextbox.Location = new System.Drawing.Point(66, 38);
            this.TemplateTextbox.Name = "TemplateTextbox";
            this.TemplateTextbox.Size = new System.Drawing.Size(490, 20);
            this.TemplateTextbox.TabIndex = 1;
            this.TemplateTextbox.TextChanged += new System.EventHandler(this.TemplateTextbox_TextChanged);
            // 
            // TemplateLabel
            // 
            this.TemplateLabel.AutoSize = true;
            this.TemplateLabel.Location = new System.Drawing.Point(12, 38);
            this.TemplateLabel.Name = "TemplateLabel";
            this.TemplateLabel.Size = new System.Drawing.Size(51, 13);
            this.TemplateLabel.TabIndex = 7;
            this.TemplateLabel.Text = "Sjabloon:";
            // 
            // NameTextbox
            // 
            this.NameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextbox.Location = new System.Drawing.Point(66, 12);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(490, 20);
            this.NameTextbox.TabIndex = 0;
            this.NameTextbox.TextChanged += new System.EventHandler(this.NameTextbox_TextChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Naam:";
            // 
            // NumbersListview
            // 
            this.NumbersListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumbersListview.Location = new System.Drawing.Point(12, 86);
            this.NumbersListview.MultiSelect = false;
            this.NumbersListview.Name = "NumbersListview";
            this.NumbersListview.Size = new System.Drawing.Size(544, 93);
            this.NumbersListview.TabIndex = 2;
            this.NumbersListview.UseCompatibleStateImageBehavior = false;
            this.NumbersListview.View = System.Windows.Forms.View.List;
            // 
            // NumbersLabel
            // 
            this.NumbersLabel.AutoSize = true;
            this.NumbersLabel.Location = new System.Drawing.Point(15, 70);
            this.NumbersLabel.Name = "NumbersLabel";
            this.NumbersLabel.Size = new System.Drawing.Size(49, 13);
            this.NumbersLabel.TabIndex = 8;
            this.NumbersLabel.Text = "Getallen:";
            // 
            // ConstraintsLabel
            // 
            this.ConstraintsLabel.AutoSize = true;
            this.ConstraintsLabel.Location = new System.Drawing.Point(15, 225);
            this.ConstraintsLabel.Name = "ConstraintsLabel";
            this.ConstraintsLabel.Size = new System.Drawing.Size(43, 13);
            this.ConstraintsLabel.TabIndex = 9;
            this.ConstraintsLabel.Text = "Regels:";
            // 
            // ConstraintsListview
            // 
            this.ConstraintsListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConstraintsListview.Location = new System.Drawing.Point(12, 241);
            this.ConstraintsListview.Name = "ConstraintsListview";
            this.ConstraintsListview.Size = new System.Drawing.Size(544, 93);
            this.ConstraintsListview.TabIndex = 3;
            this.ConstraintsListview.UseCompatibleStateImageBehavior = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(454, 384);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(102, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "&Annuleren";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(346, 384);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "&Bewaren";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddNumberButton
            // 
            this.AddNumberButton.Location = new System.Drawing.Point(454, 185);
            this.AddNumberButton.Name = "AddNumberButton";
            this.AddNumberButton.Size = new System.Drawing.Size(102, 23);
            this.AddNumberButton.TabIndex = 10;
            this.AddNumberButton.Text = "Getal toevoegen";
            this.AddNumberButton.UseVisualStyleBackColor = true;
            this.AddNumberButton.Click += new System.EventHandler(this.AddNumberButton_Click);
            // 
            // AddConstraintButton
            // 
            this.AddConstraintButton.Location = new System.Drawing.Point(454, 340);
            this.AddConstraintButton.Name = "AddConstraintButton";
            this.AddConstraintButton.Size = new System.Drawing.Size(102, 23);
            this.AddConstraintButton.TabIndex = 11;
            this.AddConstraintButton.Text = "Regel toevoegen";
            this.AddConstraintButton.UseVisualStyleBackColor = true;
            this.AddConstraintButton.Click += new System.EventHandler(this.AddConstraintButton_Click);
            // 
            // CreateExerciseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 416);
            this.Controls.Add(this.AddConstraintButton);
            this.Controls.Add(this.AddNumberButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConstraintsLabel);
            this.Controls.Add(this.ConstraintsListview);
            this.Controls.Add(this.NumbersLabel);
            this.Controls.Add(this.NumbersListview);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.TemplateLabel);
            this.Controls.Add(this.TemplateTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "CreateExerciseWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oefening ontwerpen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TemplateTextbox;
        private System.Windows.Forms.Label TemplateLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ListView NumbersListview;
        private System.Windows.Forms.Label NumbersLabel;
        private System.Windows.Forms.Label ConstraintsLabel;
        private System.Windows.Forms.ListView ConstraintsListview;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddNumberButton;
        private System.Windows.Forms.Button AddConstraintButton;
    }
}