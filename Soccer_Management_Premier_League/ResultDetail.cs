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
    public partial class ResultDetail : Form
    {
        AddResult addResult;
        public ResultDetail(AddResult ar)
        {
            InitializeComponent();
            addResult = ar;
            
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
        private void LoadHistory(string home)
        {
            flpHome.Controls.Clear();
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "select IDPL,TIME_GOAL,IDPLA,TIME_ASSIST from GOAL where IDMATCH = '" + ID_txt.Text + "' and IDCLB = '" + GetID(home) + "' order by TIME_GOAL";

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

                            flpHome.Controls.Add(goal);
                        }
                        else
                        {
                            Goal goal = new Goal();
                            goal.lbPlayer.Text = GetNamePlayer(dr["IDPL"].ToString());
                            goal.lbTime.Text = dr["TIME_GOAL"].ToString() + "'";

                            goal.lbAssist.Text = GetNamePlayer(dr["IDPLA"].ToString());

                            flpHome.Controls.Add(goal);
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

        private void LoadHistory1(string visit)
        {
            flpVisit.Controls.Clear();
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "select IDPL,TIME_GOAL,IDPLA,TIME_ASSIST from GOAL where IDMATCH = '" + ID_txt.Text + "' and IDCLB = '" + GetID(visit) + "' order by TIME_GOAL";

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

                            flpVisit.Controls.Add(goal);
                        }
                        else
                        {
                            Goal goal = new Goal();
                            goal.lbPlayer.Text = GetNamePlayer(dr["IDPL"].ToString());
                            goal.lbTime.Text = dr["TIME_GOAL"].ToString() + "'";

                            goal.lbAssist.Text = GetNamePlayer(dr["IDPLA"].ToString());

                            flpVisit.Controls.Add(goal);
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
        private string GetID(string text)
        {
            string hostClub = "";

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

        private void GetPlayer(ComboBox cb)
        {
            cb.Items.Clear();

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select PLNAME from FOOTBALL_PLAYER where IDCLB = '" + GetID(comboBox1.SelectedValue.ToString()) + "' order by PLNAME";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    cb.Items.Add(dr["PLNAME"].ToString());
                }
                dr.Close();
                connection.Close();
            }
        }

        private bool CheckDate()
        {
            bool output = false;

            DateTime dt1 = DateTime.Parse(DateMatch.Text);
            DateTime dt2 = DateTime.Now;

            if (dt1.Date < dt2.Date)
            {
                output = true;
            }

            return output;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                if (MessageBox.Show("Are you sure you want to add this result", "Add result", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int score1 = int.Parse(Score1.Text);
                    int score2 = int.Parse(Score2.Text);

                    using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                    {
                        connection.Open();
                        string query = "Update MATCH1 set SCORED1 = '" + score1 + "',SCORED2 = '" + score2 + "' where IDMatch = '" + ID_txt.Text.ToString() + "'";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Add result successfully");
                            addResult.LoadResult();
                            UpdateRanking(score1, score2, GetID(HostName.Text));
                            UpdateGD(GetID(HostName.Text));
                            UpdateRanking(score2, score1, GetID(VisitName.Text));
                            UpdateGD(GetID(VisitName.Text));
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
                    scoreHome = 0;
                    scoreVisit = 0;
                    Score1.Text = "";
                    Score2.Text = "";

                    DeleteGoal();
                    DeleteCard();
                }
            }
            else
            {
                MessageBox.Show("Match hasn't been started", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteGoal()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "DELETE FROM GOAL where IDMatch = '" + ID_txt.Text.ToString() + "'";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
        }

        private void DeleteCard()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "DELETE FROM CARD where IDMatch = '" + ID_txt.Text.ToString() + "'";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }
        }
        private string GetIDPlayer(string text)
        {
            string id;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select IDPL from FOOTBALL_PLAYER where PLNAME = '" + text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable ds = new DataTable();
                ada.Fill(ds);

                id = ds.Rows[0].ItemArray[0].ToString();
            }

            return id;
        }

        static int scoreHome = 0;
        static int scoreVisit = 0;

        private void LoadScore(FlowLayoutPanel flp)
        {
            if(Player_cbx.Text != "" && Time_txt.Value > 0 && Time_txt.Value <= 100)
            {
                Goal goal = new Goal();
                goal.lbPlayer.Text = Player_cbx.Text;
                goal.lbTime.Text = Time_txt.Value.ToString() + "'";

                if(Assistant_cbx.Text != "")
                {
                    goal.lbAssist.Text = Assistant_cbx.Text;
                }
                else
                {
                    goal.lbAssist.Text = "";
                }
                AddGoal1(goal.lbPlayer.Text, goal.lbAssist.Text, int.Parse(Time_txt.Value.ToString()));
                flp.Controls.Add(goal);
                AddScore();
                
                
            }

            if (Yellow_Cbx.Text != "" && TimeYellow.Value > 0 && TimeYellow.Value <= 100)
            {
                Card card = new Card();
                card.lbPlayer.Text = Yellow_Cbx.Text;
                card.lbTime.Text = TimeYellow.Value.ToString() + "'";
                flp.Controls.Add(card);
                AddCardYellow(card.lbPlayer.Text, int.Parse(TimeYellow.Value.ToString()));
                
            }

            if (Red_Cbx.Text != "" && TimeRed.Value > 0 && TimeRed.Value <= 100)
            {
                Card card = new Card();
                card.lbPlayer.Text = Red_Cbx.Text;
                card.lbTime.Text = TimeRed.Value.ToString() + "'";
                card.pnlCard.BackColor = Color.Red;
                flp.Controls.Add(card);
                AddCardRed(card.lbPlayer.Text, int.Parse(TimeRed.Value.ToString()));
                
            }
        }
        private void AddScore()
        {
            if(comboBox1.Text == HostName.Text)
            {
                scoreHome++;
                Score1.Text = scoreHome.ToString();
            }
            else
            {
                scoreVisit++;
                Score2.Text = scoreVisit.ToString();
            }
        }

        private void AddGoal1(string plName, string plaName,int time)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string idpl = GetIDPlayer(plName);
                string idclb = GetID(comboBox1.SelectedValue.ToString());
                string idmatch = ID_txt.Text;

                string query = "";
                if (plaName != "")
                {
                    string idpla = GetIDPlayer(plaName);
                    query = $"insert into GOAL(IDPL, IDCLB, IDMATCH,TIME_GOAL,IDPLA,TIME_ASSIST) values('{idpl}', '{idclb}', '{idmatch}', {time}, '{idpla}', {time})";
                }
                else
                {
                    query = $"insert into GOAL(IDPL, IDCLB, IDMATCH,TIME_GOAL,IDPLA,TIME_ASSIST) values('{idpl}', '{idclb}', '{idmatch}', {time}, null,null)";
                }

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    sqlCommand.ExecuteNonQuery();
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

        private void AddCardYellow(string plName, int time)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string insertQuery = "insert into CARD(IDPLY, IDCLB, IDMATCH,TIME_YELLOW) values(@idpl, @idclb, @idmatch, @time_yellow)";
                SqlCommand sqlCommand = new SqlCommand(insertQuery, connection);

                sqlCommand.Parameters.AddWithValue("@idclb", GetID(comboBox1.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("@idmatch", ID_txt.Text);

                if (string.IsNullOrEmpty(Yellow_Cbx.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@idpl", null);
                    sqlCommand.Parameters.AddWithValue("@time_yellow", null);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@idpl", GetIDPlayer(plName));
                    sqlCommand.Parameters.AddWithValue("@time_yellow", time);
                }

                try
                {
                    sqlCommand.ExecuteNonQuery();
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

        private void AddCardRed(string plName, int time)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string insertQuery = "insert into CARD(IDPLR, IDCLB, IDMATCH,TIME_RED) values(@idpl, @idclb, @idmatch, @time_red)";
                SqlCommand sqlCommand = new SqlCommand(insertQuery, connection);

                sqlCommand.Parameters.AddWithValue("@idclb", GetID(comboBox1.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("@idmatch", ID_txt.Text);

                if (string.IsNullOrEmpty(Red_Cbx.Text))
                {
                    sqlCommand.Parameters.AddWithValue("@idpl", null);
                    sqlCommand.Parameters.AddWithValue("@time_red", null);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@idpl", GetIDPlayer(plName));
                    sqlCommand.Parameters.AddWithValue("@time_red", time);
                }

                try
                {
                    sqlCommand.ExecuteNonQuery();
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
        private void UpdateRanking(int score1, int score2, string id)
        {
            if (score1 == score2)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Update BXH set PTS = PTS + 1, GF = GF + @score1, GA = GA + @score2, D = D + 1, PL = PL + 1, GD = GF - GA where IDCLB = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@score1", score1);
                        command.Parameters.AddWithValue("@score2", score2);
                        command.ExecuteNonQuery();
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
            else if (score1 > score2)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Update BXH set PTS = PTS + 3, GF = GF + @score1, GA = GA + @score2, W = W + 1, PL = PL + 1, GD = GF - GA where IDCLB = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@score1", score1);
                        command.Parameters.AddWithValue("@score2", score2);
                        command.ExecuteNonQuery();
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
            else
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "Update BXH set PTS = PTS + 0, GF = GF + @score1, GA = GA + @score2,L = L + 1, PL = PL + 1, GD = GF - GA where IDCLB = @id";

                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@score1", score1);
                        command.Parameters.AddWithValue("@score2", score2);
                        command.ExecuteNonQuery();
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

        private void UpdateGD(string id)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "Update BXH set GD = GF - GA where IDCLB = @id";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
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

        private void Clear()
        {
            Yellow_Cbx.SelectedIndex = -1;
            Player_cbx.SelectedIndex = -1;
            Red_Cbx.SelectedIndex = -1;
            Assistant_cbx.SelectedIndex = -1;
            TimeRed.Value = 0;
            TimeYellow.Value = 0;
            Time_txt.Value = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                if (comboBox1.Text == HostName.Text)
                {
                    LoadScore(flpHome);
                }
                else
                {
                    LoadScore(flpVisit);
                }

                Clear();
            }
            else
            {
                MessageBox.Show("Match hasn't been started", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            if (!string.IsNullOrEmpty(combo.Text))
            {
                GetPlayer(Player_cbx);
                GetPlayer(Assistant_cbx);
                GetPlayer(Yellow_Cbx);
                GetPlayer(Red_Cbx);
            }
        }

        private void ResultDetail_Load(object sender, EventArgs e)
        {
            if (addResult.CheckResult())
            {
                LoadHistory(HostName.Text);
                LoadHistory1(VisitName.Text);
                LoadCard(HostName.Text);
                LoadCard1(VisitName.Text);
            }
        }

        private void LoadCard1(string name)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "select IDPLY,TIME_YELLOW,IDPLR,TIME_RED from CARD where IDMATCH = '" + ID_txt.Text + "' and IDCLB = '" + GetID(name) + "' ";

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
                            flpVisit.Controls.Add(card);
                            
                        }
                        else
                        {
                            Card card = new Card();
                            card.lbPlayer.Text = GetNamePlayer(dr["IDPLY"].ToString());
                            card.lbTime.Text = dr["TIME_YELLOW"].ToString() + "'";
                            card.pnlCard.BackColor = Color.Yellow;
                            flpVisit.Controls.Add(card);
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

        private void LoadCard(string text)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "select IDPLY,TIME_YELLOW,IDPLR,TIME_RED from CARD where IDMATCH = '" + ID_txt.Text + "' and IDCLB = '" + GetID(text) + "' ";

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
                            flpHome.Controls.Add(card);

                        }
                        else
                        {
                            Card card = new Card();
                            card.lbPlayer.Text = GetNamePlayer(dr["IDPLY"].ToString());
                            card.lbTime.Text = dr["TIME_YELLOW"].ToString() + "'";
                            card.pnlCard.BackColor = Color.Yellow;
                            flpHome.Controls.Add(card);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
