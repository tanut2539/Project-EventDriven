using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_1570700839
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        // ดึงข้อมูลจาก database
        DataSet ds = new DataSet();
        string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Toey\Desktop\Allnew\Project_1570700839\Project_1570700839\Project_1570700839\Database1.mdf;Integrated Security=True;User Instance=True";

        private void add_Load(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM Minimart";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "Id");
            gridview.DataSource = ds.Tables["Id"];
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if(txt_id.Text != "" & txt_name.Text != "" & txt_price.Text != "")
            {
                DataRow[] drs = ds.Tables["Id"].Select("id='" + txt_id.Text + "'");
                if (drs.Length == 0) // Insert
                {
                    DataRow dr = ds.Tables["Id"].NewRow();
                    dr["Id"] = txt_id.Text;
                    dr["Name"] = txt_name.Text;
                    dr["Quantity"] = numericUpDown1.Value;
                    dr["Price"] = txt_price.Text;
                    ds.Tables["Id"].Rows.Add(dr); // เอาข้อมูลใหม่ใส่ database
                    // ส่วนปรับปรุงฐานข้อมูลมูล
                    string sql = "SELECT *FROM Minimart";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "Id");
                    //
                    ds.Tables["Id"].AcceptChanges(); // เปลี่ยนแปลง
                    MessageBox.Show("สำเร็จ", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_id.Text = "";
                    txt_name.Text = "";
                    numericUpDown1.Value = 1;
                    txt_price.Text = "";
                }
                else // มีข้อมูลแจ้งเตือนค่าซ้ำ
                {
                    MessageBox.Show("ขออภัยข้อมูลซ้ำ", "Wraning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                gridview.DataSource = ds.Tables["Id"];
            }
            else // หาก ID,Name และ Price เป็นค่า ว่าง หรือ อย่างใดอย่างหนึ่ง แสดงเตือนข้อมูลไม่ถูกต้อง
            {
                MessageBox.Show("ข้อมูลไม่ถูกต้องโปรดกรอกข้อมูลให้ครบถ้วน", "Wraning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
