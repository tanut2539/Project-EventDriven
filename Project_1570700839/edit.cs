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
    public partial class edit : Form
    {
        public edit()
        {
            InitializeComponent();
        }

        // ดึงข้อมูลจาก database
        DataSet ds = new DataSet();
        string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Toey\Desktop\Allnew\Project_1570700839\Project_1570700839\Project_1570700839\Database1.mdf;Integrated Security=True;User Instance=True";

        private void edit_Load(object sender, EventArgs e)
        {
            // เลือกจากตาราง Minimart //
            string sql = "SELECT *FROM Minimart";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "Id");
            gridview.DataSource = ds.Tables["Id"];
        }

        private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridview.Rows[e.RowIndex].Selected = true;
            // ดึงจาก DataTable
            DataRow dr = ds.Tables["Id"].Rows[e.RowIndex];
            txt_id.Text = dr["Id"].ToString();
            txt_name.Text = dr["Name"].ToString();
            numericUpDown1.Value = Convert.ToDecimal(dr["Quantity"]);
            txt_price.Text = dr["Price"].ToString();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_id.Text != "" & txt_name.Text != "" & txt_price.Text != "")
            {
                DataRow[] drs = ds.Tables["Id"].Select("id='" + txt_id.Text + "'");
                if (drs.Length == 0) // ไม่มีข้อมูล ให้ทำการ Insert
                {
                    DataRow dr = ds.Tables["Name"].NewRow();
                    dr["id"] = txt_id.Text;
                    dr["Name"] = txt_name.Text;
                    dr["Quantity"] = numericUpDown1.Value;
                    dr["Price"] = txt_price.Text;
                    ds.Tables["Id"].Rows.Add(dr); // เอาข้อมูลใหม่ใส่ให้ database
                    // ส่วนของการปรับปรุงฐานข้อมูล
                    string sql = "SELECT *FROM Minimart";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "Id");
                    //
                    ds.Tables["Id"].AcceptChanges(); // เปลี่ยนแปลง
                }
                else // มีข้อมูล ให้ทำการ Update
                {
                    drs[0]["Name"] = txt_name.Text;
                    drs[0]["Quantity"] = numericUpDown1.Value;
                    drs[0]["Price"] = txt_price.Text;
                    // ส่วนของการปรับปรุงฐานข้อมูล
                    string sql = "SELECT *FROM Minimart";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "Id");
                    //
                    ds.Tables["Id"].AcceptChanges(); // เปลี่ยนแปลง
                }
                gridview.DataSource = ds.Tables["Id"];
                txt_id.Text = "";
                txt_name.Text = "";
                numericUpDown1.Value = 1;
                txt_price.Text = "";
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "Edit Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else // หาก ID,Name และ Price เป็นค่า ว่าง หรือ อย่างใดอย่างหนึ่ง แสดงเตือนข้อมูลไม่ถูกต้อง
            {
                MessageBox.Show("ข้อมูลไม่ถูกต้องโปรดกรอกข้อมูลให้ครบถ้วน", "Wraning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["Id"].Select("id='" + txt_id.Text + "'");
            if (drs.Length == 0) // หาไม่เจอ
            {
                MessageBox.Show("ไม่พบข้อมูลที่ต้องการ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else // หาเจอ
            {
                drs[0].Delete(); // ลบข้อมูลในแถว
                // ส่วนของการปรับปรุงฐานข้อมูล
                string sql = "SELECT *FROM Minimart";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "Id");
                //
                ds.Tables["Id"].AcceptChanges(); // เปลี่ยนแปลง
                //
                txt_id.Text = "";
                txt_name.Text = "";
                numericUpDown1.Value = 1;
                txt_price.Text = "";
                MessageBox.Show("ลบสำเร็จ", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
