using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace formMain
{
    public class kn_Banhang
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=KLINH-PC\SQLEXPRESS;Initial Catalog=qlybanhang;Integrated Security=True");
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
        public SqlDataReader LoadCB(string mahang)
        {
            //OpenConnection();
            cmd = new SqlCommand("Select * from SanPham where MaSP=@Masp", conn);
            cmd.Parameters.AddWithValue("@MaSP", mahang);
            SqlDataReader reader =cmd.ExecuteReader();
            return reader; 
        }
        public void luuHDB(string s, string mahd, DateTime ngay, object khach, string tien)
        {

            cmd=new SqlCommand(s,conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaHDB",mahd);
            cmd.Parameters.AddWithValue("@Ngayban", ngay);
            cmd.Parameters.AddWithValue("@MaKH", khach);
            cmd.Parameters.AddWithValue("@Tongtien", tien);
            cmd.ExecuteNonQuery();
        }
        public void luuCTHDB(string s, object mahd, object masp, object sl, object dongia, object thanhtien)
        {
            cmd = new SqlCommand(s,conn);
            cmd.CommandType = CommandType.StoredProcedure;//chuyen lenh thuc thi sang thu tuc
            cmd.Parameters.AddWithValue("@MaHDB", mahd);
            cmd.Parameters.AddWithValue("@MaSP", masp);
            cmd.Parameters.AddWithValue("@SL", sl);
            cmd.Parameters.AddWithValue("@Dongia", dongia);
            cmd.Parameters.AddWithValue("@Thanhtien", thanhtien);
            //cmd.Parameters.AddWithValue("@DVT", dvt);
            cmd.ExecuteNonQuery();
        }
        public void CapnhatSLT(string s)
        {
            cmd = new SqlCommand("select * from CTHDBan where MaHDB='" + s + "'", conn);
            da = new SqlDataAdapter(cmd);
            DataTable dtsp = new DataTable();
            da.Fill(dtsp);
            foreach (DataRow row in dtsp.Rows)
            {
                cmd = new SqlCommand("update SanPham set SLton=SLton-" + (int)row["SL"] + "where MaSP='" + (string)row["MaSP"] + "'", conn);
                cmd.ExecuteNonQuery();
            }
        }
        public int Hangtrongkho(string s)
        {
            cmd = new SqlCommand("Select SLTon from SanPham where MaSP = '"+s+"'",conn);
            int c=(int)cmd.ExecuteScalar();
            return c;
        }
        public void XoaHDB(string mahdb)
        {
            string s = "delete from HDB where MaHDB='" + mahdb + "'";
            cmd = new SqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
        public void XoaCTHDB(string mahdb)
        {
            string s = "delete from CTHDBan where MaHDB='" + mahdb + "'";
            cmd = new SqlCommand(s, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
