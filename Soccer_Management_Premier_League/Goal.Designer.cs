
namespace Soccer_Management_Premier_League
{
    partial class Goal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbAssist = new System.Windows.Forms.Label();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAssist
            // 
            this.lbAssist.AutoSize = true;
            this.lbAssist.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbAssist.Location = new System.Drawing.Point(225, 6);
            this.lbAssist.Name = "lbAssist";
            this.lbAssist.Size = new System.Drawing.Size(50, 20);
            this.lbAssist.TabIndex = 2;
            this.lbAssist.Text = "label1";
            // 
            // lbPlayer
            // 
            this.lbPlayer.AutoSize = true;
            this.lbPlayer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbPlayer.Location = new System.Drawing.Point(3, 6);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(50, 20);
            this.lbPlayer.TabIndex = 3;
            this.lbPlayer.Text = "label1";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTime.Location = new System.Drawing.Point(204, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(19, 15);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "60";
            // 
            // Goal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbPlayer);
            this.Controls.Add(this.lbAssist);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Goal";
            this.Size = new System.Drawing.Size(384, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbAssist;
        public System.Windows.Forms.Label lbPlayer;
        public System.Windows.Forms.Label lbTime;
    }
}
