
namespace Soccer_Management_Premier_League
{
    partial class ConfirmPassword
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
            this.question1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.q1answer = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelquestion1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pass2label = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ContinueButton = new Guna.UI2.WinForms.Guna2Button();
            this.BackButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panelquestion1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // question1
            // 
            this.question1.BackColor = System.Drawing.Color.Transparent;
            this.question1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question1.ForeColor = System.Drawing.Color.White;
            this.question1.Location = new System.Drawing.Point(3, 3);
            this.question1.Name = "question1";
            this.question1.Size = new System.Drawing.Size(216, 22);
            this.question1.TabIndex = 1;
            this.question1.Text = "Enter code sended in email:";
            // 
            // q1answer
            // 
            this.q1answer.BackColor = System.Drawing.Color.Transparent;
            this.q1answer.BorderRadius = 5;
            this.q1answer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.q1answer.DefaultText = "";
            this.q1answer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.q1answer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.q1answer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.q1answer.DisabledState.Parent = this.q1answer;
            this.q1answer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.q1answer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.q1answer.FocusedState.Parent = this.q1answer;
            this.q1answer.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.q1answer.ForeColor = System.Drawing.Color.Black;
            this.q1answer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.q1answer.HoverState.Parent = this.q1answer;
            this.q1answer.Location = new System.Drawing.Point(5, 33);
            this.q1answer.Margin = new System.Windows.Forms.Padding(5);
            this.q1answer.Name = "q1answer";
            this.q1answer.PasswordChar = '\0';
            this.q1answer.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.q1answer.PlaceholderText = "Click to write";
            this.q1answer.SelectedText = "";
            this.q1answer.ShadowDecoration.Parent = this.q1answer;
            this.q1answer.Size = new System.Drawing.Size(208, 38);
            this.q1answer.TabIndex = 2;
            // 
            // panelquestion1
            // 
            this.panelquestion1.BackColor = System.Drawing.Color.Transparent;
            this.panelquestion1.Controls.Add(this.question1);
            this.panelquestion1.Controls.Add(this.q1answer);
            this.panelquestion1.Location = new System.Drawing.Point(28, 105);
            this.panelquestion1.Name = "panelquestion1";
            this.panelquestion1.Size = new System.Drawing.Size(231, 81);
            this.panelquestion1.TabIndex = 3;
            // 
            // pass2label
            // 
            this.pass2label.BackColor = System.Drawing.Color.Transparent;
            this.pass2label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass2label.ForeColor = System.Drawing.Color.White;
            this.pass2label.Location = new System.Drawing.Point(39, 61);
            this.pass2label.Name = "pass2label";
            this.pass2label.Size = new System.Drawing.Size(208, 31);
            this.pass2label.TabIndex = 9;
            this.pass2label.Text = "EMAIL VERIFICATION";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Image = global::Soccer_Management_Premier_League.Properties.Resources.bruno;
            this.pictureBox.Location = new System.Drawing.Point(288, 42);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(170, 233);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // ContinueButton
            // 
            this.ContinueButton.BackColor = System.Drawing.Color.Transparent;
            this.ContinueButton.CheckedState.Parent = this.ContinueButton;
            this.ContinueButton.CustomImages.Parent = this.ContinueButton;
            this.ContinueButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ContinueButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ContinueButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ContinueButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ContinueButton.DisabledState.Parent = this.ContinueButton;
            this.ContinueButton.FillColor = System.Drawing.Color.Transparent;
            this.ContinueButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ContinueButton.ForeColor = System.Drawing.Color.White;
            this.ContinueButton.HoverState.Parent = this.ContinueButton;
            this.ContinueButton.Image = global::Soccer_Management_Premier_League.Properties.Resources.pngegg1;
            this.ContinueButton.ImageSize = new System.Drawing.Size(45, 45);
            this.ContinueButton.Location = new System.Drawing.Point(111, 193);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.ShadowDecoration.Parent = this.ContinueButton;
            this.ContinueButton.Size = new System.Drawing.Size(52, 50);
            this.ContinueButton.TabIndex = 7;
            this.ContinueButton.UseTransparentBackground = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackButton.CheckedState.Parent = this.BackButton;
            this.BackButton.CustomImages.Parent = this.BackButton;
            this.BackButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BackButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BackButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BackButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BackButton.DisabledState.Parent = this.BackButton;
            this.BackButton.FillColor = System.Drawing.Color.Transparent;
            this.BackButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.HoverState.Parent = this.BackButton;
            this.BackButton.Image = global::Soccer_Management_Premier_League.Properties.Resources.unnamed;
            this.BackButton.ImageSize = new System.Drawing.Size(55, 55);
            this.BackButton.Location = new System.Drawing.Point(10, 11);
            this.BackButton.Name = "BackButton";
            this.BackButton.ShadowDecoration.Parent = this.BackButton;
            this.BackButton.Size = new System.Drawing.Size(40, 44);
            this.BackButton.TabIndex = 6;
            this.BackButton.UseTransparentBackground = true;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Firebrick;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Firebrick;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(429, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(40, 29);
            this.guna2ControlBox1.TabIndex = 10;
            // 
            // ConfirmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(470, 287);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.pass2label);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.panelquestion1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ConfirmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "premier_league_manager";
            this.panelquestion1.ResumeLayout(false);
            this.panelquestion1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel question1;
        private Guna.UI2.WinForms.Guna2TextBox q1answer;
        private System.Windows.Forms.FlowLayoutPanel panelquestion1;
        private Guna.UI2.WinForms.Guna2Button BackButton;
        private Guna.UI2.WinForms.Guna2Button ContinueButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel pass2label;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}

