using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms;

namespace Soccer_Management_Premier_League
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Btn_Club_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Registration());
            btnSound.Visible = true;
            changedmusic();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;

            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManagePlayer());
            btnSound.Visible = true;
            changedmusic();
        }

        private void Btn_MatchSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddMatch());
            btnSound.Visible = true;
            changedmusic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you surely want to log out ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 login = new Form1();


                axWindowsMediaPlayer1.Ctlcontrols.stop();
                timer1.Stop();
                player.Stop();
                timer2.Stop();
                this.Dispose();
                login.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddResult());
            btnSound.Visible = true;
            changedmusic();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ranking());
            btnSound.Visible = true;
            changedmusic();
        }

        private void Btn_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Referee());
            btnSound.Visible = true;
            changedmusic();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Coach());
            btnSound.Visible = true;
            changedmusic();
        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.audiotheme);
        private void HomePage_Load(object sender, EventArgs e)
        {
            var strTempFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Video.avi");
            axWindowsMediaPlayer1.uiMode = "none";
            File.WriteAllBytes(strTempFile, Properties.Resources.intro);
            axWindowsMediaPlayer1.URL = strTempFile;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void changedmusic()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            timer1.Stop();
            audio();
        }
        private void audio()
        {
            if (btnSound.Checked)
            {
            }
            else
            {
                if (timer2.Enabled == false)
                {
                    player.Play();
                    timer2.Enabled = true;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            player.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            player.Stop();
            timer2.Enabled = false;
            HomePage hp = new HomePage();
            this.Dispose();
            hp.Show();
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            if (btnSound.Checked)
            {
                btnSound.Image = new Bitmap(Properties.Resources.outline_volume_up_black_24dp);
                btnSound.Checked = false;
                player.Play();
                timer2.Enabled = true;
            }
            else
            {
                btnSound.Image = new Bitmap(Properties.Resources.outline_volume_mute_black_24dp);
                btnSound.Checked = true;
                player.Stop();
                timer2.Enabled = false;
            }
        }
    }
}
