using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_1570700839
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Main M = new Main();
            M.Show();
            this.Hide();
            timer1.Stop();
        }

        private void load_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
        }
    }
}
