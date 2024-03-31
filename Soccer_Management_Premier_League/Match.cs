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
using System.IO;

namespace Soccer_Management_Premier_League
{
    public partial class Match : Form
    {
        AddMatch add;

        public Match(AddMatch ad)
        {
            InitializeComponent();
            GetHomeClub();
            GetVisitClub();
            GetStadium();
            GetReferee();
            add = ad;
        }

        private void GetReferee()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select REF_NAME,IDREF from REFEREE";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                IDREF_cbx.DataSource = ds.Tables[0];
                IDREF_cbx.DisplayMember = "REF_NAME";
                IDREF_cbx.ValueMember = "IDREF";
                IDREF_cbx.SelectedIndex = -1;
            }
        }
        private void GetHomeClub()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select CLBNAME from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Club_cbx.DataSource = ds.Tables[0];
                Club_cbx.DisplayMember = "CLBNAME";

            }
        }

        private void GetVisitClub()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select CLBNAME from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);

                Club_cbx1.DataSource = ds.Tables[0];
                Club_cbx1.DisplayMember = "CLBNAME";

            }
        }

        private void GetStadium()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select STADIUM from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                ada.Fill(ds);


                Stadium_cbx.DataSource = ds.Tables[0];
                Stadium_cbx.DisplayMember = "STADIUM";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Club_cbx.Text == Club_cbx1.Text)
            {
                MessageBox.Show("Can't add match for 2 same team", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hostClub = GetID(Club_cbx.Text);
            string visitClub = GetID(Club_cbx1.Text);

            DateTime ngay = dateTimePicker1.Value;
            DateTime gio = dateTimePicker1.Value;
            string stadium = Stadium_cbx.Text;

            gio.ToShortTimeString();

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "insert into MATCH1(CLB1,CLB2, DATE,TIME, STAYDIUM,IDREF) values(@hostClub,@visitClub,@ngay,@gio,@san,@idmatch)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@hostClub", hostClub);
                command.Parameters.AddWithValue("@visitClub", visitClub);
                command.Parameters.AddWithValue("@ngay", ngay);
                command.Parameters.AddWithValue("@gio", gio);
                command.Parameters.AddWithValue("@san", stadium);
                command.Parameters.AddWithValue("@idmatch", IDREF_cbx.SelectedValue.ToString());
                
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Add match successfully");
                    add.LoadMatchs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
        }

        private string GetID(string text)
        {
            string hostClub;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDCLB from CLUB where CLBNAME = '" + text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                hostClub = dt.Rows[0]["IDCLB"].ToString();
            }

            return hostClub;
        }
    }
}
