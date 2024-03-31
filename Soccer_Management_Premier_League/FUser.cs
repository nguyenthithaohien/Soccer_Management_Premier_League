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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class FUser : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.audiotheme);
        private string username;
        public FUser()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public FUser (string u)
        {
            InitializeComponent();
            this.username = u;
            
        }

        public void LoadClubs()
        {
            //metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                string query = "Select Pic,CLBNAME, STADIUM from CLUB";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_club.DataSource = dt;

                

                DataGridView_club.Columns[0].HeaderText = "Logo";
                DataGridView_club.Columns[1].HeaderText = "Name Club";
                DataGridView_club.Columns[2].HeaderText = "Stadium";

                DataGridView_club.Columns[0].Width = 50;
                DataGridView_club.Columns[1].Width = 150;
                DataGridView_club.Columns[2].Width = 300;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_club.Columns[0];

                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridView_club.Columns[1].CellTemplate.Style.ForeColor = Color.FromArgb(34, 72, 157);
            }
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
        }

        int dem = 1;

        private void LoadMatch1(int i, int dem)
        {
            this.Invoke(new Action(() =>
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "Select T1.PIC,T1.CLBNAME,T2.PIC,T2.CLBNAME,TIME,SCORED1,SCORED2,DATE from CLUB as T1, CLUB as T2, MATCH1 as M where M.CLB1 = T1.IDCLB and " +
                            "M.CLB2 = T2.IDCLB order by DATE asc";

                    SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    Match1 match;
                    Date date1;
                    Week week = new Week();
                    week.label1.Text = "Week " + dem;
                    flpMatch.Controls.Add(week);

                    int check = 0;

                    string s = "";

                    for (int j = dem * 10 - 10; j < dt.Rows.Count; j++)
                    {
                        DataRow row = dt.Rows[j];
                        DateTime dateTime = (DateTime)row["DATE"];
                        s = dateTime.ToString(@"dd-MM-yyyy");
                        date1 = new Date();
                        date1.label1.Text = s;
                        flpMatch.Controls.Add(date1);
                        break;
                    }

                    for (int j = dem * 10 - 10; j < dt.Rows.Count; j++)
                    {
                        DataRow row = dt.Rows[j];
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

                        if (j == i * 10 - 1)
                        {
                            return;
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

        private void metroTabControl1_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab.Text == "Ranking")
            {
                LoadRanking();
            }
            else if (metroTabControl1.SelectedTab.Text == "Club")
            {
                LoadClubs();
            }
            else if (metroTabControl1.SelectedTab.Text == "Top Player")
            {
                LoadTopPlayer();
            }
        }

        private void LoadLogo(string text)
        {
            FClub form1 = new FClub();

            form1.lbName.Text = text;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select PIC,DAYBUILT,ADDRESS,NATION,STADIUM,CITY from CLUB where CLBNAME = '" + text + "'";
                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                byte[] img = (byte[])dt.Rows[0].ItemArray[0];
                MemoryStream ms = new MemoryStream(img);
                form1.pictureBox1.Image = Image.FromStream(ms);

                DateTime dateTime = (DateTime)dt.Rows[0].ItemArray[1];
                string date = dateTime.ToString(@"dd-MM-yyyy");

                form1.lbFoundedDate.Text = date;
                form1.lbCity.Text = dt.Rows[0].ItemArray[5].ToString();
                form1.lbNation.Text = dt.Rows[0].ItemArray[3].ToString();
                form1.lbStadium.Text = dt.Rows[0].ItemArray[4].ToString();
                form1.lbAddress.Text = dt.Rows[0].ItemArray[2].ToString();
            }

            
            form1.Show();
        }
        private void DataGridView_club_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                LoadLogo(DataGridView_club.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void FUser_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];
            LoadClubs();
            LoadMatch1(dem % 10,dem);
            this.hellolabel.Text = "Hello, " + username;
            player.PlayLooping();
            
        }

        private void LoadTopPlayer()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select ROW_NUMBER() OVER(ORDER BY COUNT(G.IDGOAL) desc) Position, F.PLNAME,C.CLBNAME,COUNT(G.IDGOAL) as SCORE " +
                    "from GOAL as G,FOOTBALL_PLAYER as F,CLUB as C " +
                    "where C.IDCLB = F.IDCLB and G.IDCLB = C.IDCLB and G.IDPL = F.IDPL " +
                    "group by F.PLNAME,C.CLBNAME";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                dgvPlayer.DataSource = dt;

                dgvPlayer.Columns[0].HeaderText = "";
                dgvPlayer.Columns[1].HeaderText = "Player Name";
                dgvPlayer.Columns[2].HeaderText = "Club Name";
                dgvPlayer.Columns[3].HeaderText = "Number Goal";

                dgvPlayer.Columns[0].Width = 30;
                dgvPlayer.Columns[1].Width = 200;
                dgvPlayer.Columns[2].Width = 150;
                dgvPlayer.Columns[3].Width = 200;

                connection.Close();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            flpMatch.Controls.Clear();
            dem++;
            if (dem >= 10)
            {
                LoadMatch1(dem, dem);
            }
            else
            {
                LoadMatch1(dem % 10, dem);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            flpMatch.Controls.Clear();
            if (dem > 1)
                dem--;
            if (dem >= 10)
            {
                LoadMatch1(dem, dem);
            }
            else
            {
                LoadMatch1(dem % 10, dem);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you surely want to log out ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 lg = new Form1();
                this.Close();
                lg.Show();
                player.Stop();
            }
        }
  
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            player.Stop();
            guna2Button2.Visible = true;
            guna2Button1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            player.PlayLooping();
            guna2Button2.Visible = false;
            guna2Button1.Visible = true;
        }
    }
}
