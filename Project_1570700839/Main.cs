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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bt_buy_Click(object sender, EventArgs e)
        {
            buy B = new buy();
            B.Show();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            add A = new add();
            A.Show();
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            edit E = new edit();
            E.Show();
        }
    }
}
