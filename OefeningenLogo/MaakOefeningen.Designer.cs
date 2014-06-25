namespace OefeningenLogo
{
    partial class MaakOefeningen
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
            this.StartDatumDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EindDatumDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeOefeningCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OefeningenTextbox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.AndereOefeningenTextbox = new System.Windows.Forms.TextBox();
            this.GetalDefinitiesListbox = new System.Windows.Forms.ListBox();
            this.GetalDefToevoegenButton = new System.Windows.Forms.Button();
            this.LaagsteTextbox = new System.Windows.Forms.TextBox();
            this.HoogsteTextbox = new System.Windows.Forms.TextBox();
            this.CijfersNaDeKommaTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.VerbandTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDatumDateTimePicker
            // 
            this.StartDatumDateTimePicker.Location = new System.Drawing.Point(108, 12);
            this.StartDatumDateTimePicker.Name = "StartDatumDateTimePicker";
            this.StartDatumDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDatumDateTimePicker.TabIndex = 0;
            // 
            // EindDatumDateTimePicker
            // 
            this.EindDatumDateTimePicker.Location = new System.Drawing.Point(108, 45);
            this.EindDatumDateTimePicker.Name = "EindDatumDateTimePicker";
            this.EindDatumDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.EindDatumDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Startdatum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Einddatum:";
            // 
            // TypeOefeningCombobox
            // 
            this.TypeOefeningCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOefeningCombobox.FormattingEnabled = true;
            this.TypeOefeningCombobox.Location = new System.Drawing.Point(108, 78);
            this.TypeOefeningCombobox.Name = "TypeOefeningCombobox";
            this.TypeOefeningCombobox.Size = new System.Drawing.Size(200, 21);
            this.TypeOefeningCombobox.TabIndex = 4;
            this.TypeOefeningCombobox.SelectedIndexChanged += new System.EventHandler(this.TypeOefeningCombobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type oefeningen:";
            // 
            // OefeningenTextbox
            // 
            this.OefeningenTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.OefeningenTextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OefeningenTextbox.Location = new System.Drawing.Point(15, 105);
            this.OefeningenTextbox.Multiline = true;
            this.OefeningenTextbox.Name = "OefeningenTextbox";
            this.OefeningenTextbox.Size = new System.Drawing.Size(500, 391);
            this.OefeningenTextbox.TabIndex = 6;
            this.OefeningenTextbox.TextChanged += new System.EventHandler(this.OefeningenTextbox_TextChanged);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.Location = new System.Drawing.Point(784, 76);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(215, 23);
            this.GenerateButton.TabIndex = 7;
            this.GenerateButton.Text = "Oefeningen maken";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // AndereOefeningenTextbox
            // 
            this.AndereOefeningenTextbox.Location = new System.Drawing.Point(315, 78);
            this.AndereOefeningenTextbox.Name = "AndereOefeningenTextbox";
            this.AndereOefeningenTextbox.Size = new System.Drawing.Size(235, 20);
            this.AndereOefeningenTextbox.TabIndex = 8;
            this.AndereOefeningenTextbox.Visible = false;
            // 
            // GetalDefinitiesListbox
            // 
            this.GetalDefinitiesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GetalDefinitiesListbox.FormattingEnabled = true;
            this.GetalDefinitiesListbox.Location = new System.Drawing.Point(521, 153);
            this.GetalDefinitiesListbox.Name = "GetalDefinitiesListbox";
            this.GetalDefinitiesListbox.Size = new System.Drawing.Size(478, 316);
            this.GetalDefinitiesListbox.TabIndex = 9;
            // 
            // GetalDefToevoegenButton
            // 
            this.GetalDefToevoegenButton.Location = new System.Drawing.Point(924, 124);
            this.GetalDefToevoegenButton.Name = "GetalDefToevoegenButton";
            this.GetalDefToevoegenButton.Size = new System.Drawing.Size(75, 23);
            this.GetalDefToevoegenButton.TabIndex = 10;
            this.GetalDefToevoegenButton.Text = "Toevoegen";
            this.GetalDefToevoegenButton.UseVisualStyleBackColor = true;
            this.GetalDefToevoegenButton.Click += new System.EventHandler(this.GetalDefToevoegenButton_Click);
            // 
            // LaagsteTextbox
            // 
            this.LaagsteTextbox.Location = new System.Drawing.Point(521, 127);
            this.LaagsteTextbox.Name = "LaagsteTextbox";
            this.LaagsteTextbox.Size = new System.Drawing.Size(100, 20);
            this.LaagsteTextbox.TabIndex = 11;
            // 
            // HoogsteTextbox
            // 
            this.HoogsteTextbox.Location = new System.Drawing.Point(628, 127);
            this.HoogsteTextbox.Name = "HoogsteTextbox";
            this.HoogsteTextbox.Size = new System.Drawing.Size(100, 20);
            this.HoogsteTextbox.TabIndex = 12;
            // 
            // CijfersNaDeKommaTextbox
            // 
            this.CijfersNaDeKommaTextbox.Location = new System.Drawing.Point(735, 127);
            this.CijfersNaDeKommaTextbox.Name = "CijfersNaDeKommaTextbox";
            this.CijfersNaDeKommaTextbox.Size = new System.Drawing.Size(100, 20);
            this.CijfersNaDeKommaTextbox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Laagste";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(628, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Hoogste";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cijfers na de komma";
            // 
            // VerbandTextbox
            // 
            this.VerbandTextbox.Location = new System.Drawing.Point(676, 476);
            this.VerbandTextbox.Name = "VerbandTextbox";
            this.VerbandTextbox.Size = new System.Drawing.Size(323, 20);
            this.VerbandTextbox.TabIndex = 17;
            this.VerbandTextbox.TextChanged += new System.EventHandler(this.VerbandTextbox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 476);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "verband";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "test2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MaakOefeningen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 508);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.VerbandTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CijfersNaDeKommaTextbox);
            this.Controls.Add(this.HoogsteTextbox);
            this.Controls.Add(this.LaagsteTextbox);
            this.Controls.Add(this.GetalDefToevoegenButton);
            this.Controls.Add(this.GetalDefinitiesListbox);
            this.Controls.Add(this.AndereOefeningenTextbox);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.OefeningenTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeOefeningCombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EindDatumDateTimePicker);
            this.Controls.Add(this.StartDatumDateTimePicker);
            this.Name = "MaakOefeningen";
            this.Text = "Oefeningen Logo";
            this.Load += new System.EventHandler(this.MaakOefeningen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDatumDateTimePicker;
        private System.Windows.Forms.DateTimePicker EindDatumDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TypeOefeningCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OefeningenTextbox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TextBox AndereOefeningenTextbox;
        private System.Windows.Forms.ListBox GetalDefinitiesListbox;
        private System.Windows.Forms.Button GetalDefToevoegenButton;
        private System.Windows.Forms.TextBox LaagsteTextbox;
        private System.Windows.Forms.TextBox HoogsteTextbox;
        private System.Windows.Forms.TextBox CijfersNaDeKommaTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox VerbandTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

