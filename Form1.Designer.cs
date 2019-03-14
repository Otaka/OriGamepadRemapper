namespace OriGamepadRemapper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LSTextbox = new System.Windows.Forms.TextBox();
            this.LTTextbox = new System.Windows.Forms.TextBox();
            this.SelectTextbox = new System.Windows.Forms.TextBox();
            this.StartTextbox = new System.Windows.Forms.TextBox();
            this.RTTextbox = new System.Windows.Forms.TextBox();
            this.RSTextbox = new System.Windows.Forms.TextBox();
            this.YTextbox = new System.Windows.Forms.TextBox();
            this.BTextbox = new System.Windows.Forms.TextBox();
            this.ATextbox = new System.Windows.Forms.TextBox();
            this.XTextbox = new System.Windows.Forms.TextBox();
            this.gamepadsComboBox = new System.Windows.Forms.ComboBox();
            this.loadConfigButton = new System.Windows.Forms.Button();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(713, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LSTextbox
            // 
            this.LSTextbox.Location = new System.Drawing.Point(26, 101);
            this.LSTextbox.Name = "LSTextbox";
            this.LSTextbox.Size = new System.Drawing.Size(44, 20);
            this.LSTextbox.TabIndex = 1;
            // 
            // LTTextbox
            // 
            this.LTTextbox.Location = new System.Drawing.Point(285, 26);
            this.LTTextbox.Name = "LTTextbox";
            this.LTTextbox.Size = new System.Drawing.Size(44, 20);
            this.LTTextbox.TabIndex = 2;
            // 
            // SelectTextbox
            // 
            this.SelectTextbox.Location = new System.Drawing.Point(285, 65);
            this.SelectTextbox.Name = "SelectTextbox";
            this.SelectTextbox.Size = new System.Drawing.Size(44, 20);
            this.SelectTextbox.TabIndex = 3;
            // 
            // StartTextbox
            // 
            this.StartTextbox.Location = new System.Drawing.Point(418, 65);
            this.StartTextbox.Name = "StartTextbox";
            this.StartTextbox.Size = new System.Drawing.Size(44, 20);
            this.StartTextbox.TabIndex = 4;
            // 
            // RTTextbox
            // 
            this.RTTextbox.Location = new System.Drawing.Point(621, 26);
            this.RTTextbox.Name = "RTTextbox";
            this.RTTextbox.Size = new System.Drawing.Size(44, 20);
            this.RTTextbox.TabIndex = 5;
            // 
            // RSTextbox
            // 
            this.RSTextbox.Location = new System.Drawing.Point(621, 101);
            this.RSTextbox.Name = "RSTextbox";
            this.RSTextbox.Size = new System.Drawing.Size(44, 20);
            this.RSTextbox.TabIndex = 6;
            // 
            // YTextbox
            // 
            this.YTextbox.Location = new System.Drawing.Point(621, 157);
            this.YTextbox.Name = "YTextbox";
            this.YTextbox.Size = new System.Drawing.Size(44, 20);
            this.YTextbox.TabIndex = 7;
            // 
            // BTextbox
            // 
            this.BTextbox.Location = new System.Drawing.Point(681, 185);
            this.BTextbox.Name = "BTextbox";
            this.BTextbox.Size = new System.Drawing.Size(44, 20);
            this.BTextbox.TabIndex = 8;
            // 
            // ATextbox
            // 
            this.ATextbox.Location = new System.Drawing.Point(621, 212);
            this.ATextbox.Name = "ATextbox";
            this.ATextbox.Size = new System.Drawing.Size(44, 20);
            this.ATextbox.TabIndex = 9;
            // 
            // XTextbox
            // 
            this.XTextbox.Location = new System.Drawing.Point(621, 260);
            this.XTextbox.Name = "XTextbox";
            this.XTextbox.Size = new System.Drawing.Size(44, 20);
            this.XTextbox.TabIndex = 10;
            // 
            // gamepadsComboBox
            // 
            this.gamepadsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gamepadsComboBox.FormattingEnabled = true;
            this.gamepadsComboBox.Location = new System.Drawing.Point(12, 395);
            this.gamepadsComboBox.Name = "gamepadsComboBox";
            this.gamepadsComboBox.Size = new System.Drawing.Size(199, 21);
            this.gamepadsComboBox.TabIndex = 11;
            this.gamepadsComboBox.SelectedIndexChanged += new System.EventHandler(this.gamepadsComboBox_SelectedIndexChanged);
            // 
            // loadConfigButton
            // 
            this.loadConfigButton.Location = new System.Drawing.Point(227, 393);
            this.loadConfigButton.Name = "loadConfigButton";
            this.loadConfigButton.Size = new System.Drawing.Size(75, 23);
            this.loadConfigButton.TabIndex = 12;
            this.loadConfigButton.Text = "Load config";
            this.loadConfigButton.UseVisualStyleBackColor = true;
            this.loadConfigButton.Click += new System.EventHandler(this.loadConfigButton_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(320, 393);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(75, 23);
            this.saveConfigButton.TabIndex = 13;
            this.saveConfigButton.Text = "Save config";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "ControllerButtonRemaps.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 428);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.loadConfigButton);
            this.Controls.Add(this.gamepadsComboBox);
            this.Controls.Add(this.XTextbox);
            this.Controls.Add(this.ATextbox);
            this.Controls.Add(this.BTextbox);
            this.Controls.Add(this.YTextbox);
            this.Controls.Add(this.RSTextbox);
            this.Controls.Add(this.RTTextbox);
            this.Controls.Add(this.StartTextbox);
            this.Controls.Add(this.SelectTextbox);
            this.Controls.Add(this.LTTextbox);
            this.Controls.Add(this.LSTextbox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ori gamepad remapper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox LSTextbox;
        private System.Windows.Forms.TextBox LTTextbox;
        private System.Windows.Forms.TextBox SelectTextbox;
        private System.Windows.Forms.TextBox StartTextbox;
        private System.Windows.Forms.TextBox RTTextbox;
        private System.Windows.Forms.TextBox RSTextbox;
        private System.Windows.Forms.TextBox YTextbox;
        private System.Windows.Forms.TextBox BTextbox;
        private System.Windows.Forms.TextBox ATextbox;
        private System.Windows.Forms.TextBox XTextbox;
        private System.Windows.Forms.ComboBox gamepadsComboBox;
        private System.Windows.Forms.Button loadConfigButton;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

