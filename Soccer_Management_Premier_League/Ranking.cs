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
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
            LoadRanking();
        }

        private void Ranking_Load_1(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "select * from BXH where PL = 38";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                if(dt.Rows.Count == 20)
                {
                    btnEnd.Enabled = true;
                }

                connection.Close();
            }

        }

        public void LoadRanking()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "Select ROW_NUMBER() OVER(ORDER BY PTS desc) Position, C.PIC, C.CLBNAME, PL, W, D,L,GF,GA,GD,PTS from BXH as B, CLUB as C where C.IDCLB = B.IDCLB";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                DataGridView_ranking.DataSource = dt;

                //DataGridView_ranking.Columns[0].HeaderText = "Po";
                DataGridView_ranking.Columns[1].HeaderText = "";
                DataGridView_ranking.Columns[2].HeaderText = "Name";
                DataGridView_ranking.Columns[3].HeaderText = "Played";
                DataGridView_ranking.Columns[4].HeaderText = "Won";
                DataGridView_ranking.Columns[5].HeaderText = "Drawn";
                DataGridView_ranking.Columns[6].HeaderText = "Lost";
                DataGridView_ranking.Columns[7].HeaderText = "GF";
                DataGridView_ranking.Columns[8].HeaderText = "GA";
                DataGridView_ranking.Columns[9].HeaderText = "GD";
                DataGridView_ranking.Columns[10].HeaderText = "Points";
                //DataGridView_ranking.Columns[3].HeaderText = "Position";

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)DataGridView_ranking.Columns[1];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridView_ranking.Columns[0].Width = 50;
                DataGridView_ranking.Columns[1].Width = 40;
                DataGridView_ranking.Columns[2].Width = 200;
                DataGridView_ranking.Columns[3].Width = 50;
                DataGridView_ranking.Columns[4].Width = 50;
                DataGridView_ranking.Columns[5].Width = 50;
                DataGridView_ranking.Columns[6].Width = 50;
                DataGridView_ranking.Columns[7].Width = 50;
                DataGridView_ranking.Columns[8].Width = 50;
                DataGridView_ranking.Columns[9].Width = 50;
                DataGridView_ranking.Columns[10].Width = 50;

                this.DataGridView_ranking.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DataGridView_ranking.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                connection.Close();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();

            try
            {
                Champion form1 = new Champion();

                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .50d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                form1.lbName.Text = FindChampion();

                //144, 27
                if (form1.lbName.Text.Length >= 11)
                {
                    form1.lbName.Location = new Point(form1.lbName.Location.X - 40, 216);
                }

                form1.Owner = formBackground;
                form1.ShowDialog();


                formBackground.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private string FindChampion()
        {
            string s = "";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9HO6E70\SQLEXPRESS;Initial Catalog=SoccerManage;Integrated Security=True"))
            {
                connection.Open();
                string query = "select top(1) CLBNAME from BXH,CLUB where CLUB.IDCLB = BXH.IDCLB order by PTS desc";

                SqlDataAdapter ada = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                s = dt.Rows[0].ItemArray[0].ToString();

                connection.Close();
            }

            return s;
        }
    }
}
