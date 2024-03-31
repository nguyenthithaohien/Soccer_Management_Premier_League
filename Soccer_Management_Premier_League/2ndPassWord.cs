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
    public partial class _2ndPassWord : Form
    {
        private string username;
        private string password;
        private string emaill;
        private int code;
        public _2ndPassWord()
        {
            InitializeComponent();
        }

        public _2ndPassWord(string user, string pass, string email, int c)
        {
            InitializeComponent();
            this.username = user;
            this.password = pass;
            this.emaill = email;
            this.code = c;
        }

        public _2ndPassWord (int c)
        {
            InitializeComponent();
            this.code = c;
        }

        private void _2ndPassWord_Load(object sender, EventArgs e)
        {

        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            // Kiem tra neu user de trong cac o nhap lieu
            if (q1answer.Text == "")
            {
                MessageBox.Show("Please fill in the first private question.");
                q1answer.Focus();
            }
            else if (q1answer.Text == this.code.ToString()) //Khi da nhap lieu du
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True")) { 
                    connection.Open();

                    //Cau lenh SQL de them tai khoan vao database
                    string query = "INSERT INTO ACCOUNT VALUES('" + username + "','" + password + "','" + emaill + "')";
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        // Thuc thi cau lenh them cau hoi bi mat
                        command.ExecuteNonQuery();
                        MessageBox.Show(" SIGN UP SUCCESSFULLY !\n THANK YOU FOR YOUR REGISTRATION TO OUR APP. \n HAVE A GREAT DAY.");
                        Form1 lg = new Form1();
                        this.Hide();
                        lg.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Your code is incorrect. Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            Signup su = new Signup(username, password, emaill);
            this.Hide();
            su.Show();
        }
    }
}
