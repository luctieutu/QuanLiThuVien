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

namespace QuanLiThuVien
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }

        public string chuoikn = "server =LAPTOP-HLCQIVNQ" + ";database = QLTV; uid = sa; pwd = 123456";
        SqlConnection conn;

        public void load()
        {

            string load_nhanvien = "select * from tblSach";
            conn = new SqlConnection(chuoikn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(load_nhanvien, conn);
            DataTable tbl = new DataTable();
            ad.Fill(tbl);
            dataGridView1.DataSource = tbl.DefaultView;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textma.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sách ");
                textma.Focus();
            }else if(textten.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sách ");
                textten.Focus();
            } else if(texttentacgia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tác giả ");
                texttentacgia.Focus();
            } else if(textnhaxb.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nhà xuất bản ");
                textnhaxb.Focus();
            } else if (textnamxb.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nhà xuất bản ");
                textnamxb.Focus();
            } else if(textsoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng ");
                textsoluong.Focus();
            } else
            {
                conn = new SqlConnection(chuoikn);
                conn.Open();
                string them = "insert into tblSach values('" + textma.Text + "',N'" + textten.Text + "', N'" + texttentacgia.Text + "','" + textnhaxb.Text + "', '" + textnamxb.Text + "', N'" + textsoluong.Text + "')";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = them;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công");
                load();
            }
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoikn);
            conn.Open();
            string xoa = "delete from tblSach where MaSach ='" + textma.Text + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = xoa;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoa thành công");
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoikn);
            conn.Open();
            string sua = "update tblSach set TenSach  = N'" + textten.Text + "', TenTacGia = N'" + texttentacgia.Text + "', NhaXB = '" + textnhaxb.Text + "', NamXB = '" + textnamxb.Text + "',SoLuong = '" + textsoluong.Text + "' where MaSach ='" + textma.Text + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sua;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update thành công");
            load();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textma.Enabled = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (dataGridView1.Rows[i].Selected)
                {
                    textma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    textten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    texttentacgia.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    textnhaxb.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    textnamxb.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    textsoluong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                }
        }
    }
}
