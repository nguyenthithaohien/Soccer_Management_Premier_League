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

namespace Soccer_Management_Premier_League
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserTextbox.Text == "admin" && PassTextbox.Text == "admin")
            {
                HomePage admin = new HomePage();
                this.Hide();
                admin.Show();
            }
            else
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from account where USERNAME = N'" + UserTextbox.Text + "' and PASS = N'" + PassTextbox.Text + "'", Connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    FUser user = new FUser();
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
    }
}
