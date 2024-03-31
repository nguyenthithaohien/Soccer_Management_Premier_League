using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Management_Premier_League
{
    public partial class Champion : Form
    {
        public Champion()
        {
            InitializeComponent();
        }

        private void Champion_Load(object sender, EventArgs e)
        {
            lbName.Parent = pictureBox1;
            lbName.BackColor = Color.Transparent;
            lbName.BringToFront();
        }
    }
}
