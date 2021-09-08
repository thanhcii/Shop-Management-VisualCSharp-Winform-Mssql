using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace formMain
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private SqlConnection conn;
        private DataTable dt = new DataTable("");
        private SqlDataAdapter da = new SqlDataAdapter();

        private void connect()
        {
            string s = @"Data Source=KLINH-PC\SQLEXPRESS;Initial Catalog=qlybanhang;Integrated Security=True";
            try
            {
                conn = new SqlConnection(s);
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void disconnect()
        {
            conn.Close();
        }
        private void Dangnhap_Load(object sender, EventArgs e)
        {
            connect();
            txtID.Text = "";
            txtPass.Text = "";
            this.AcceptButton = btnDangnhap;
        }

        
        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string s = @"select * from DangNhap where (id = @id) and (pass=@pass)";
            SqlCommand cmd = new SqlCommand(s, conn);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@pass", txtPass.Text);
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Ribbonform rb = new Ribbonform();
                rb.Show();
                Hide();
            }
            else
            {
                if (MessageBox.Show("Đăng nhập thất bại, Bạn có muốn đăng nhập lại không ", "ĐĂNG NHẬP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtID.Clear();
                    txtPass.Clear();
                    txtID.Focus();
                }
                else
                {
                    conn.Close();
                    this.Close();
                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
