using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace formMain
{
    public class kn_Khachhang
    {
        public SqlConnection cnn = new SqlConnection
        (@"Data Source=KLINH-PC\SQLEXPRESS;Initial Catalog=qlybanhang;Integrated Security=True");
        
        public void myconnect()
        {
            cnn.Open();
        }
        public void myclose()
        {
            cnn.Close();
        }
        public DataTable taobang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, cnn);
            ds.Fill(dt);
            return (dt);
        }
        public void them
            (string MaKH, string Hoten, string Ngaysinh, string Gioitinh, string Diachi, String DT, string Email)
        {
            string sql = "insert into Khachhang(MaKH, Hoten, Ngaysinh, Gioitinh, Diachi, DT, Email)" + "values(N'" + MaKH + "', N'" + Hoten + "', '" + Ngaysinh + "', N'" + Gioitinh + "', N'" + Diachi + "', '" + DT + "', '" + Email + "')";
            SqlCommand scm = new SqlCommand(sql, cnn);
            scm.ExecuteNonQuery();
        }
        public void xoa
            (string MaKH, string Hoten, string Ngaysinh, string Gioitinh, string Diachi, String DT, string Email)
        {
            string sql = "delete from Khachhang where MaKH='" + MaKH + "'";
            SqlCommand scm = new SqlCommand(sql, cnn);
            scm.ExecuteNonQuery();
        }
        public void sua
            (string MaKH, string Hoten, string Ngaysinh, string Gioitinh, string Diachi, String DT, string Email)
        {
            string sql = "update Khachhang set Hoten=N'" + Hoten + "', Ngaysinh='" + Ngaysinh + "', Gioitinh=N'" + Gioitinh + "', Diachi=N'" + Diachi + "', DT='" + DT + "', Email='" + Email + "' where MaKH='" + MaKH + "'";
            SqlCommand scm = new SqlCommand(sql, cnn);
            scm.ExecuteNonQuery();
        }
    }
}
