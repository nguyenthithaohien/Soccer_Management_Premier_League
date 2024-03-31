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
    public partial class ConfirmPassword : Form
    {
        private int code;
        private string username;
        public ConfirmPassword()
        {
            InitializeComponent();
        }
        public ConfirmPassword(int c, string u)
        {
            InitializeComponent();
            this.code = c;
            this.username = u;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {

            if (q1answer.Text == "")
            {
                MessageBox.Show("Please fill in the code.");
                q1answer.Focus();
            }
            else if (q1answer.Text == code.ToString())
            {
                ChangePassword cp = new ChangePassword(username);
                this.Hide();
                cp.Show();
            }
            else
            {
                MessageBox.Show("Your passcode is incorrect.\nPlease try again.");
            }

        }

        private void ConfirmPassword_Load(object sender, EventArgs e)
        {
            q1answer.Focus();
        }
    }
}
