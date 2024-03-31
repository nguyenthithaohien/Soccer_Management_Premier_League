using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class FClub : Form
    {
        public FClub()
        {
            InitializeComponent();
        }
        
        private void LoadRanking()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select ROW_NUMBER() OVER(ORDER BY PTS desc) Position, C.CLBNAME, PL, W, D,L,GD,PTS from BXH as B, CLUB as C where C.IDCLB = B.IDCLB";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_ranking.DataSource = dt;

                DataGridView_ranking.Columns[0].HeaderText = "";
                DataGridView_ranking.Columns[1].HeaderText = "Name";
                DataGridView_ranking.Columns[2].HeaderText = "Played";
                DataGridView_ranking.Columns[3].HeaderText = "Won";
                DataGridView_ranking.Columns[4].HeaderText = "Drawn";
                DataGridView_ranking.Columns[5].HeaderText = "Lost";
                DataGridView_ranking.Columns[6].HeaderText = "GD";
                DataGridView_ranking.Columns[7].HeaderText = "Points";

                DataGridView_ranking.Columns[0].Width = 30;
                DataGridView_ranking.Columns[1].Width = 200;
                DataGridView_ranking.Columns[2].Width = 50;
                DataGridView_ranking.Columns[3].Width = 50;
                DataGridView_ranking.Columns[4].Width = 50;
                DataGridView_ranking.Columns[5].Width = 50;
                DataGridView_ranking.Columns[6].Width = 50;
                DataGridView_ranking.Columns[7].Width = 50;

                connection.Close();
            }

            foreach (DataGridViewRow row in DataGridView_ranking.Rows)
            {
                if(row.Cells["CLBNAME"].Value.ToString() == lbName.Text)
                {
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        public void LoadPlayers()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();

                string query = "Select P.VITRI,P.PLNAME from FOOTBALL_PLAYER as P,CLUB as C where  C.IDCLB = P.IDCLB and C.CLBNAME = '" + lbName.Text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_player.DataSource = dt;


                DataGridView_player.Columns[0].HeaderText = "Position";
                DataGridView_player.Columns[1].HeaderText = "Name";

                DataGridView_player.Columns[0].Width = 200;
                DataGridView_player.Columns[1].Width = 300;
                
                connection.Close();
            }
        }
        private string GetID(string name)
        {
            string s = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select IDCLB from CLUB where CLBNAME = '" + name + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                s = dt.Rows[0].ItemArray[0].ToString();
            }

            return s;
        }

        private void FClub_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[1];
            LoadPlayers();
            LoadRanking();
            LoadMatch1();
        }
        private void LoadMatch1()
        {
            string id = GetID(lbName.Text);
            label7.Text = "Lịch thi đấu của " + lbName.Text;

            this.Invoke(new Action(() =>
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();
                    string query = $"Select M.IDMATCH,T1.PIC,T1.CLBNAME,T2.PIC,T2.CLBNAME,TIME,SCORED1,SCORED2,DATE from CLUB as T1, CLUB as T2, MATCH1 as M where M.CLB1 = T1.IDCLB and M.CLB2 = T2.IDCLB and (M.CLB1 = '{id}' or M.CLB2 = '{id}') order by DATE asc";

                    SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    Match1 match;
                    Date date1;

                    int check = 0;

                    string s = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime dateTime = (DateTime)row["DATE"];
                        s = dateTime.ToString(@"dd-MM-yyyy");

                        date1 = new Date();
                        date1.label1.Text = s;
                        flpMatch.Controls.Add(date1);
                        break;
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime dateTime = (DateTime)row["DATE"];
                        string date = dateTime.ToString(@"dd-MM-yyyy");

                        if (date != s)
                        {
                            date1 = new Date();
                            date1.label1.Text = date;
                            flpMatch.Controls.Add(date1);
                            s = date;
                        }

                        match = new Match1();
                       
                        match.lbClubHost.Text = row["CLBNAME"].ToString();
                        match.lbClubVisit.Text = row["CLBNAME1"].ToString();

                        string score1 = row["SCORED1"].ToString();
                        string score2 = row["SCORED2"].ToString();

                        byte[] img = (byte[])row["PIC"];
                        MemoryStream ms = new MemoryStream(img);
                        match.ptbClubHost.Image = Image.FromStream(ms);

                        byte[] img1 = (byte[])row["PIC1"];
                        MemoryStream ms1 = new MemoryStream(img1);
                        match.ptbClubVisit.Image = Image.FromStream(ms1);

                        if (!string.IsNullOrEmpty(score1) && !string.IsNullOrEmpty(score2))
                        {
                            match.btnForward.Tag = row["IDMATCH"].ToString();
                            match.btnForward.Click += Match_Click;
                            match.lbScore.Text = score1 + " - " + score2;
                        }
                        else
                        {
                            match.lbScore.Text = "? - ?";
                        }
                        TimeSpan span = (TimeSpan)row["TIME"];

                        match.lbTime.Text = span.ToString(@"hh\:mm");

                        if (check == 0)
                        {
                            match.BackColor = Color.FromArgb(244, 244, 244);
                            flpMatch.Controls.Add(match);
                            check = 1;
                        }
                        else
                        {
                            flpMatch.Controls.Add(match);
                            check = 0;
                        }
                    }

                    connection.Close();
                }
            }));
        }

        private void Match_Click(object sender, EventArgs e)
        {
            FResult result = new FResult();

            Guna2Button b = sender as Guna2Button;
            string id = b.Tag.ToString();

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = $"Select T1.PIC,T1.CLBNAME,T2.PIC,T2.CLBNAME,TIME,SCORED1,SCORED2 from CLUB as T1, CLUB as T2, MATCH1 as M where M.CLB1 = T1.IDCLB and M.CLB2 = T2.IDCLB and M.IDMATCH='{id}'";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    result.HostName.Text = row["CLBNAME"].ToString();
                    result.VisitName.Text = row["CLBNAME1"].ToString();

                    string score1 = row["SCORED1"].ToString();
                    string score2 = row["SCORED2"].ToString();

                    byte[] img = (byte[])row["PIC"];
                    MemoryStream ms = new MemoryStream(img);
                    result.HostImage.Image = Image.FromStream(ms);

                    byte[] img1 = (byte[])row["PIC1"];
                    MemoryStream ms1 = new MemoryStream(img1);
                    result.VisitImage.Image = Image.FromStream(ms1);
                    result.Score1.Text = score1;
                    result.Score2.Text = score2;
                    TimeSpan span = (TimeSpan)row["TIME"];
                    result.lbTime.Text = span.ToString(@"hh\:mm");
                }

                connection.Close();
            }

            result.ShowDialog();
        }
    }
}
