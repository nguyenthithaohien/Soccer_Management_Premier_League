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
    public partial class ChangePassword : Form
    {
        private string username;
        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(string u)
        {
            InitializeComponent();
            this.username = u;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            this.Hide();
            lg.Show();
        }

        private string GetPassword(string name)
        {
            string s = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select Pass from ACCOUNT where USERNAME = '" + name + "'";
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
        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string pass = GetPassword(username);

            if (EmailTextbox.Text == "")
            {
                MessageBox.Show("Please fill in your new password.");
                EmailTextbox.Focus();
            }
            else if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please fill in the rewrite password.");
                guna2TextBox1.Focus();
            }
            else if (pass.Trim() == EmailTextbox.Text.Trim())
            {
                MessageBox.Show("Your new password is the same as the old one.\nTry another password.");
                EmailTextbox.Focus();
                EmailTextbox.SelectAll();
            }
            else if (guna2TextBox1.Text != EmailTextbox.Text)
            {
                MessageBox.Show("Password and Rewrite Password must be the same!");
                guna2TextBox1.Focus();
                guna2TextBox1.SelectAll();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "UPDATE ACCOUNT SET PASS = '" + EmailTextbox.Text + "' WHERE USERNAME = '" + username + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("CHANGE PASSWORD SUCCESSFULLY !\nHAVE A GREAT DAY.");
                        Form1 lg = new Form1();
                        this.Close();
                        lg.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    connection.Close();
                }
            }
        }

        private void ChangePassword_Load_1(object sender, EventArgs e)
        {
            EmailTextbox.Focus();
        }
    }
}
