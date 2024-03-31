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
    public partial class FResult : Form
    {
        public FResult()
        {
            InitializeComponent();
        }

        private string GetNamePlayer(string id)
        {
            string name = "";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select PLNAME from FOOTBALL_PLAYER where IDPL = '" + id + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                name = dt.Rows[0]["PLNAME"].ToString();
            }

            return name;
        }

        private string GetIDMatch(string home,string visit)
        {
            string id = "";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = $"select IDMATCH FROM MATCH1 WHERE CLB1 = '{GetID(home)}' AND CLB2 = '{GetID(visit)}'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                id = dt.Rows[0]["IDMATCH"].ToString();
            }

            return id;
        }

        private void LoadHistory(string home,FlowLayoutPanel flp,string id)
        {
            flp.Controls.Clear();
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "select IDPL,TIME_GOAL,IDPLA,TIME_ASSIST from GOAL where IDMATCH = '" + id + "' and IDCLB = '" + GetID(home) + "' order by TIME_GOAL";

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        if (string.IsNullOrEmpty(dr["IDPLA"].ToString()))
                        {
                            Goal goal = new Goal();
                            goal.lbPlayer.Text = GetNamePlayer(dr["IDPL"].ToString());
                            goal.lbTime.Text = dr["TIME_GOAL"].ToString() + "'";

                            goal.lbAssist.Text = "";

                            flp.Controls.Add(goal);
                        }
                        else
                        {
                            Goal goal = new Goal();
                            goal.lbPlayer.Text = GetNamePlayer(dr["IDPL"].ToString());
                            goal.lbTime.Text = dr["TIME_GOAL"].ToString() + "'";

                            goal.lbAssist.Text = GetNamePlayer(dr["IDPLA"].ToString());

                            flp.Controls.Add(goal);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        private string GetID(string home)
        {
            string id = "";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = $"select IDCLB FROM CLUB WHERE CLBNAME = '{home}'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                id = dt.Rows[0]["IDCLB"].ToString();
            }

            return id;
        }

        private void FResult_Load(object sender, EventArgs e)
        {
            string id = GetIDMatch(HostName.Text, VisitName.Text);
            LoadHistory(HostName.Text,flpHome,id);
            LoadHistory(VisitName.Text, flpVisit, id);
            LoadCard(HostName.Text,flpHome,id);
            LoadCard(VisitName.Text, flpVisit, id);
        }

        private void LoadCard(string text,FlowLayoutPanel flp,string id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "select IDPLY,TIME_YELLOW,IDPLR,TIME_RED from CARD where IDMATCH = '" + id + "' and IDCLB = '" + GetID(text) + "' ";

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        if (string.IsNullOrEmpty(dr["IDPLY"].ToString()))
                        {
                            Card card = new Card();
                            card.lbPlayer.Text = GetNamePlayer(dr["IDPLR"].ToString());
                            card.lbTime.Text = dr["TIME_RED"].ToString() + "'";
                            card.pnlCard.BackColor = Color.Red;
                            flp.Controls.Add(card);

                        }
                        else
                        {
                            Card card = new Card();
                            card.lbPlayer.Text = GetNamePlayer(dr["IDPLY"].ToString());
                            card.lbTime.Text = dr["TIME_YELLOW"].ToString() + "'";
                            card.pnlCard.BackColor = Color.Yellow;
                            flp.Controls.Add(card);
                        }
                    }
                    dr.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
