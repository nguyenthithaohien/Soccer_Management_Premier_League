using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Soccer_Management_Premier_League
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        public Signup(string u, string p, string e)
        {
            InitializeComponent();
            this.Usertextbox.Text = u;
            this.PassTestbox.Text = p;
            this.RwPassTestbox.Text = p;
            this.EmailTextbox.Text = e;
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            Usertextbox.Focus();
            // Kiem tra neu user de trong cac o nhap lieu
            if (Usertextbox.Text == "")
            {
                MessageBox.Show("Please fill in the Username!");
                Usertextbox.Focus();
            }
            else if (PassTestbox.Text == "")
            {
                MessageBox.Show("Please fill in the Password!");
                PassTestbox.Focus();
            }
            else if (RwPassTestbox.Text == "")
            {
                MessageBox.Show("Please fill in the Rewrite Password!");
                RwPassTestbox.Focus();
            }
            else if (PassTestbox.Text != RwPassTestbox.Text)
            {
                MessageBox.Show("Password and Rewrite Password must be the same!");
                RwPassTestbox.Focus();
                RwPassTestbox.SelectAll();
            }
            else if (EmailTextbox.Text == "")
            {
                MessageBox.Show("Please fill in the Email");
                EmailTextbox.Focus();
            }
            else // Khi da nhap lieu du
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True");

                // Tao cau lenh de lay ra user co trung ten voi ten User ma nguoi dung dang chon
                SqlDataAdapter da = new SqlDataAdapter("select USERNAME from account where USERNAME = N'" + Usertextbox.Text + "'", connection);
                SqlDataAdapter dae = new SqlDataAdapter("select EMAIL from account where EMAIL = N'" + EmailTextbox.Text + "'", connection);


                // Tao bang de luu du lieu database tra ve (neu co)
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable dte = new DataTable();
                dae.Fill(dte);

                // Neu bang co du lieu tra ve tu database nghia la da co ten Username nguoi dung dang chon trong database
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Your username has been already existed. Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Usertextbox.SelectAll();
                    Usertextbox.Focus();
                }
                else if (dte.Rows.Count > 0)
                {
                    MessageBox.Show("Your email has been already existed. Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmailTextbox.SelectAll();
                    EmailTextbox.Focus();
                }
                else // Neu bang khong co du lieu thi User co the dung duoc cai ten do
                {
                    Random rnd = new Random();
                    int n = rnd.Next(1000, 9999);
                    SendMail(email, EmailTextbox.Text, "ACTIVATION EMAIL", "Your activation code is: " + n);
                    this.Hide();
                    _2ndPassWord sp = new _2ndPassWord(Usertextbox.Text, PassTestbox.Text, EmailTextbox.Text, n);
                    sp.Show();
                }
            }
        }

        string email = "projectuit0@gmail.com";
        void SendMail(string from, string to, string subject, string message)
        {
            MailMessage mess = new MailMessage(from, to, subject, message);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential(email, "projectuit01234");

            client.Send(mess);
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            this.Hide();
            lg.Show();
        }
    }
}
