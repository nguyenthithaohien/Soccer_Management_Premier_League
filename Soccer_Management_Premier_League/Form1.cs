using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserTextbox.Text == "admin" && PassTextbox.Text == "admin")
            {
                HomePage admin = new HomePage();
                this.Close();
                admin.ShowDialog();
            }
            else
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from ACCOUNT where USERNAME = N'" + UserTextbox.Text + "' and PASS = N'" + PassTextbox.Text + "'", Connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    FUser user = new FUser(UserTextbox.Text);
                    this.Hide();
                    user.Show();
                }
                else MessageBox.Show("Your Username or Password is incorrect \nPlease try again!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPassword forgot = new ForgotPassword();
            this.Hide();
            forgot.Show();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            this.Hide();
            signup.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserTextbox.Select();
        }
    }
}
