namespace OefeningenLogo.UI.CreateExerciseSheet.CreateExercise.AddNumber
{
    partial class AddNumberWindow
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.MinvalueTextbox = new System.Windows.Forms.TextBox();
            this.MinvalueLabel = new System.Windows.Forms.Label();
            this.MaxvalueTextbox = new System.Windows.Forms.TextBox();
            this.MaxvalueLabel = new System.Windows.Forms.Label();
            this.DecimalsTextbox = new System.Windows.Forms.TextBox();
            this.DecimalsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(131, 117);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(102, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "&Bewaren";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(239, 117);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(102, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "&Annuleren";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "Naam:";
            // 
            // NameTextbox
            // 
            this.NameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextbox.Location = new System.Drawing.Point(123, 6);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(218, 20);
            this.NameTextbox.TabIndex = 9;
            this.NameTextbox.TextChanged += new System.EventHandler(this.NameTextbox_TextChanged);
            // 
            // MinvalueTextbox
            // 
            this.MinvalueTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinvalueTextbox.Location = new System.Drawing.Point(123, 32);
            this.MinvalueTextbox.Name = "MinvalueTextbox";
            this.MinvalueTextbox.Size = new System.Drawing.Size(218, 20);
            this.MinvalueTextbox.TabIndex = 11;
            this.MinvalueTextbox.TextChanged += new System.EventHandler(this.MinvalueTextbox_TextChanged);
            // 
            // MinvalueLabel
            // 
            this.MinvalueLabel.AutoSize = true;
            this.MinvalueLabel.Location = new System.Drawing.Point(12, 35);
            this.MinvalueLabel.Name = "MinvalueLabel";
            this.MinvalueLabel.Size = new System.Drawing.Size(89, 13);
            this.MinvalueLabel.TabIndex = 10;
            this.MinvalueLabel.Text = "Minimum waarde:";
            // 
            // MaxvalueTextbox
            // 
            this.MaxvalueTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxvalueTextbox.Location = new System.Drawing.Point(123, 58);
            this.MaxvalueTextbox.Name = "MaxvalueTextbox";
            this.MaxvalueTextbox.Size = new System.Drawing.Size(218, 20);
            this.MaxvalueTextbox.TabIndex = 13;
            this.MaxvalueTextbox.TextChanged += new System.EventHandler(this.MaxvalueTextbox_TextChanged);
            // 
            // MaxvalueLabel
            // 
            this.MaxvalueLabel.AutoSize = true;
            this.MaxvalueLabel.Location = new System.Drawing.Point(12, 61);
            this.MaxvalueLabel.Name = "MaxvalueLabel";
            this.MaxvalueLabel.Size = new System.Drawing.Size(92, 13);
            this.MaxvalueLabel.TabIndex = 12;
            this.MaxvalueLabel.Text = "Maximum waarde:";
            // 
            // DecimalsTextbox
            // 
            this.DecimalsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DecimalsTextbox.Location = new System.Drawing.Point(123, 84);
            this.DecimalsTextbox.Name = "DecimalsTextbox";
            this.DecimalsTextbox.Size = new System.Drawing.Size(218, 20);
            this.DecimalsTextbox.TabIndex = 15;
            this.DecimalsTextbox.TextChanged += new System.EventHandler(this.DecimalsTextbox_TextChanged);
            // 
            // DecimalsLabel
            // 
            this.DecimalsLabel.AutoSize = true;
            this.DecimalsLabel.Location = new System.Drawing.Point(12, 87);
            this.DecimalsLabel.Name = "DecimalsLabel";
            this.DecimalsLabel.Size = new System.Drawing.Size(105, 13);
            this.DecimalsLabel.TabIndex = 14;
            this.DecimalsLabel.Text = "Cijfers na de komma:";
            // 
            // AddNumberWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 152);
            this.Controls.Add(this.DecimalsTextbox);
            this.Controls.Add(this.DecimalsLabel);
            this.Controls.Add(this.MaxvalueTextbox);
            this.Controls.Add(this.MaxvalueLabel);
            this.Controls.Add(this.MinvalueTextbox);
            this.Controls.Add(this.MinvalueLabel);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddNumberWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Getal toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.TextBox MinvalueTextbox;
        private System.Windows.Forms.Label MinvalueLabel;
        private System.Windows.Forms.TextBox MaxvalueTextbox;
        private System.Windows.Forms.Label MaxvalueLabel;
        private System.Windows.Forms.TextBox DecimalsTextbox;
        private System.Windows.Forms.Label DecimalsLabel;
    }
}