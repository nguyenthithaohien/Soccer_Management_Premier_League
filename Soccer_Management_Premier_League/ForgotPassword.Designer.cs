namespace Soccer_Management_Premier_League
{
    partial class ForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPassword));
            this.EmailPanel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.EmailTextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.Q1Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.BackButton = new Guna.UI2.WinForms.Guna2Button();
            this.forgotpasslabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Q1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailPanel
            // 
            this.EmailPanel.BackColor = System.Drawing.Color.Transparent;
            this.EmailPanel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailPanel.ForeColor = System.Drawing.Color.White;
            this.EmailPanel.Location = new System.Drawing.Point(3, 3);
            this.EmailPanel.Name = "EmailPanel";
            this.EmailPanel.Size = new System.Drawing.Size(105, 27);
            this.EmailPanel.TabIndex = 1;
            this.EmailPanel.Text = "Username:";
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = System.Drawing.Color.Transparent;
            this.EmailTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EmailTextbox.BorderRadius = 5;
            this.EmailTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EmailTextbox.DefaultText = "";
            this.EmailTextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EmailTextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EmailTextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailTextbox.DisabledState.Parent = this.EmailTextbox;
            this.EmailTextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailTextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EmailTextbox.FocusedState.Parent = this.EmailTextbox;
            this.EmailTextbox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.ForeColor = System.Drawing.Color.Black;
            this.EmailTextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EmailTextbox.HoverState.Parent = this.EmailTextbox;
            this.EmailTextbox.Location = new System.Drawing.Point(4, 36);
            this.EmailTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.PasswordChar = '\0';
            this.EmailTextbox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.EmailTextbox.PlaceholderText = "Click to write";
            this.EmailTextbox.SelectedText = "";
            this.EmailTextbox.ShadowDecoration.Parent = this.EmailTextbox;
            this.EmailTextbox.Size = new System.Drawing.Size(285, 27);
            this.EmailTextbox.TabIndex = 3;
            // 
            // Q1Panel
            // 
            this.Q1Panel.BackColor = System.Drawing.Color.Transparent;
            this.Q1Panel.Controls.Add(this.EmailPanel);
            this.Q1Panel.Controls.Add(this.EmailTextbox);
            this.Q1Panel.Location = new System.Drawing.Point(10, 90);
            this.Q1Panel.Name = "Q1Panel";
            this.Q1Panel.Size = new System.Drawing.Size(311, 74);
            this.Q1Panel.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Soccer_Management_Premier_League.Properties.Resources.de_bruyne;
            this.pictureBox1.Location = new System.Drawing.Point(327, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.DisabledState.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::Soccer_Management_Premier_League.Properties.Resources.pngegg;
            this.guna2Button1.ImageSize = new System.Drawing.Size(45, 45);
            this.guna2Button1.Location = new System.Drawing.Point(143, 179);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(50, 43);
            this.guna2Button1.TabIndex = 8;
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
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
            this.BackButton.Image = global::Soccer_Management_Premier_League.Properties.Resources.unnamed2;
            this.BackButton.ImageSize = new System.Drawing.Size(50, 50);
            this.BackButton.Location = new System.Drawing.Point(10, 11);
            this.BackButton.Name = "BackButton";
            this.BackButton.PressedColor = System.Drawing.Color.BurlyWood;
            this.BackButton.ShadowDecoration.Parent = this.BackButton;
            this.BackButton.Size = new System.Drawing.Size(38, 39);
            this.BackButton.TabIndex = 0;
            this.BackButton.UseTransparentBackground = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // forgotpasslabel
            // 
            this.forgotpasslabel.BackColor = System.Drawing.Color.Transparent;
            this.forgotpasslabel.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotpasslabel.ForeColor = System.Drawing.Color.White;
            this.forgotpasslabel.Location = new System.Drawing.Point(91, 45);
            this.forgotpasslabel.Name = "forgotpasslabel";
            this.forgotpasslabel.Size = new System.Drawing.Size(186, 29);
            this.forgotpasslabel.TabIndex = 10;
            this.forgotpasslabel.Text = "FORGOT PASSWORD ";
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(456, 242);
            this.Controls.Add(this.forgotpasslabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.Q1Panel);
            this.Controls.Add(this.BackButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Premier League Manager";
            this.Q1Panel.ResumeLayout(false);
            this.Q1Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button BackButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel EmailPanel;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna.UI2.WinForms.Guna2TextBox EmailTextbox;
        private System.Windows.Forms.FlowLayoutPanel Q1Panel;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel forgotpasslabel;
    }
}

