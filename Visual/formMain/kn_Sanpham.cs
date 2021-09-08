using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace formMain
{
    public class kn_Sanpham
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=KLINH-PC\SQLEXPRESS;Initial Catalog=qlybanhang;Integrated Security=True");
        //public SqlConnection conn = new SqlConnection(@"Data Source=KLINH-PC\SQLEXPRESS;Initial Catalog=qlybanhang;Integrated Security=True");
        public SqlCommand cmd;
        public SqlDataAdapter da;


        public void OpenConnection()
        {
            conn.Open();
        }
        public void DisConnection()
        {
            conn.Close();
        }
        public DataTable taobang(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(cmd);
            DataTable db = new DataTable();
            da.Fill(db);
            return (db);
        }
        public void them(string masp, string tensp, string mansx, string gm, string gb, string slt, string dvt)
        {
            string s = "SP_insert";
            cmd = new SqlCommand(s, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSP",masp);
            cmd.Parameters.AddWithValue("@TenSP",tensp);
            cmd.Parameters.AddWithValue("@MaNSX",mansx);
            cmd.Parameters.AddWithValue("@Giamua",gm);
            cmd.Parameters.AddWithValue("@Giaban",gb);
            cmd.Parameters.AddWithValue("@SLton",slt);
            cmd.Parameters.AddWithValue("@DVT",dvt);
            cmd.ExecuteNonQuery();
        }
        public void sua(string masp, string tensp, string mansx, string gm, string gb, string slt, string dvt)
        {
            string s = "SP_update";
            cmd = new SqlCommand(s, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSP", masp);
            cmd.Parameters.AddWithValue("@TenSP", tensp);
            cmd.Parameters.AddWithValue("@MaNSX", mansx);
            cmd.Parameters.AddWithValue("@Giamua", gm);
            cmd.Parameters.AddWithValue("@Giaban", gb);
            cmd.Parameters.AddWithValue("@SLton", slt);
            cmd.Parameters.AddWithValue("@DVT", dvt);
            cmd.ExecuteNonQuery();
        }
        public void xoa(string masp)
        {
            string s = "delete from SanPham where MaSP=N'" + masp + "'";
            cmd = new SqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
