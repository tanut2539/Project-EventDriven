using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Project_1570700839
{
    public partial class buy : Form
    {
        public buy()
        {
            InitializeComponent();
        }

        // ส่วนสร้างตารางเก็บสินค้าผู้ที่มาซื้อ
        
        DataTable dt = new DataTable();
        
        // ส่วนเชื่อมต่อฐานข้อมูล
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Toey\Desktop\Allnew\Project_1570700839\Project_1570700839\Project_1570700839\Database1.mdf;Integrated Security=True;User Instance=True");
        SqlCommand Cmd;
        SqlDataReader Cmr;
        string s = null;

        private void buy_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Price", typeof(int));
            dt.Columns.Add("Total", typeof(int));
        }

        int i = 0,total = 0,amt = 0,q = 0,qty = 0,price = 0;

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID.Text != "")
                {
                    // นำข้อมูลจากดาต้าเบสเข้ามา
                    
                    Con.Open();
                    s = "SELECT *FROM Minimart WHERE Id = '" + txtID.Text + "'";
                    Cmd = new SqlCommand(s, Con);
                    Cmr = Cmd.ExecuteReader();
                    if (Cmr.Read())
                    {
                        lbl_name.Text = Cmr["Name"].ToString();
                        lbl_price.Text = Cmr["Price"].ToString();
                    }
                    if (MessageBox.Show("คุณต้องการเพิ่มสินค้านี้ในรายการหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        
                        // คำนวณ ราคา ใส่ลงใน datagridview
                        qty = Convert.ToInt32(numericUpDown1.Value);
                        price = Convert.ToInt32(lbl_price.Text);
                        total = qty * price;
                        // เพิ่มข้อมูลลงบน datagridview
                        dt.Rows.Add(txtID.Text, lbl_name.Text, numericUpDown1.Value, lbl_price.Text, total);
                        datagrid.DataSource = dt;
                        // คำนวณเพื่อหาราคาสินค้ารวม
                        Double l = 0;
                        for (i = 0; i < datagrid.Rows.Count - 1; i++)
                        {
                            l += Convert.ToInt32(datagrid.Rows[i].Cells[4].Value);
                        }
                        lbl_price2.Text = l.ToString();
                        // ตัดสินค้าออกจากคลัง
                        q = Convert.ToInt32(Cmr["Quantity"]);
                        amt = q - qty;
                        Cmr.Close();
                        SqlCommand update = new SqlCommand("UPDATE Minimart SET Quantity ='"+amt+"' WHERE (Id = N'"+txtID.Text+"')",Con);
                        update.ExecuteNonQuery();
                        // หลังจากเพิ่มเสร็จให้เคลียเป็นค่าว่างเพื่อเพิ่มสินค้าใหม่
                        txtID.Text = "";
                        lbl_name.Text = "";
                        numericUpDown1.Value = 1;
                        lbl_price.Text = "";
                    }
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("คุณทำรายการไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void money_ValueChanged(object sender, EventArgs e)
        {
            Double p = 0;
            p = Convert.ToInt32(lbl_price2.Text);
            Double s = Convert.ToDouble(money.Value) - p;
            lbl_change.Text = s.ToString();
        }

        private void bt_receipt_Click(object sender, EventArgs e)
        {

        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            lbl_price2.Text = "0";
            lbl_change.Text = "0";
            money.Value = 0;
            dt.Clear();
        }
    }
}
