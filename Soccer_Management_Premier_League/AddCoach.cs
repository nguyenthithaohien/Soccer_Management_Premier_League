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
    public partial class AddCoach : Form
    {
        Coach coach;
        Registration registration;
        public AddCoach(Coach c)
        {
            InitializeComponent();
            coach = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                string name = Name_Txt.Text;
                string id = ID_Txt.Text;
                string nationality = Nation_Txt.Text;
                string type = cbType.Text;
                DateTime dt = Birth_Date.Value;
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "insert into COACH(IDCLB, COACHNAME, NATIONALITY, DAY_BORN, TYPE_COACH) values(@id, @name,@nationality,@dt,@type)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@nationality", nationality);
                    command.Parameters.AddWithValue("@dt", dt);
                    command.Parameters.AddWithValue("@type", type);


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Add Successfully");
                        coach.LoadCoach();

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
                MessageBox.Show("Please add full information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool Verify()
        {
            if (ID_Txt.Text == "" || Name_Txt.Text == "" || Nation_Txt.Text == "" || cbType.Text == "")
                return false;

            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ID_Txt.Text = "";
            Name_Txt.Text = "";
            Nation_Txt.Text = "";
            cbType.SelectedIndex = -1;
        }
    }
}
