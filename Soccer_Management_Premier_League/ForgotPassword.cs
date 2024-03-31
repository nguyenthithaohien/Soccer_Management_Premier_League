using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        string email = "projectuit0@gmail.com";

        private string GetEmail(string name)
        {
            string s = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select Email from ACCOUNT where USERNAME = '" + name + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                if (dt.Rows.Count > 0)
                    s = dt.Rows[0].ItemArray[0].ToString();
                else
                    s = "";
            }

            return s;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int n = random.Next(1000, 9999);
            string dest = GetEmail(EmailTextbox.Text);
            if (dest == "")
            {
                MessageBox.Show("Your username is incorrect. Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SendMail(email, dest, "RESET PASSWORD", "YOUR PASSCODE IS: " + n);
                this.Hide();
                ConfirmPassword sc = new ConfirmPassword(n, EmailTextbox.Text);
                sc.Show();
            }
        }
        void SendMail(string from, string to, string subject, string message)
        {
            try
            {
                MailMessage mess = new MailMessage(from, to, subject, message);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential(email, "projectuit01234");

                client.Send(mess);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            this.Hide();
            lg.Show();
        }
    }
}
