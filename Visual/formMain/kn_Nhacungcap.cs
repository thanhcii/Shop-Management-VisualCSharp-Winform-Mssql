using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace formMain
{
    public class kn_Nhacungcap
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
            (string MaNNC, string TenNCC, string Diachi, string DT, string Email)
        {
            string sql = "insert into Nhacungcap(MaNCC, TenNCC, Diachi, DT, Email)" + "values('" + MaNNC + "', N'" + TenNCC + "', N'" + Diachi + "', '" + DT + "', '" + Email + "')";
            SqlCommand scm = new SqlCommand(sql, cnn);
            scm.ExecuteNonQuery();
        }
        public void xoa
            (string MaNNC, string TenNCC, string Diachi, string DT, string Email)
        {
            string sql = "delete from Nhacungcap where MaNCC='" + MaNNC + "'";
            SqlCommand scm = new SqlCommand(sql, cnn);
            scm.ExecuteNonQuery();
        }
        public void sua
            (string MaNNC, string TenNCC, string Diachi, string DT, string Email)
        {
            string sql = "update Nhacungcap set TenNCC=N'" + TenNCC + "', Diachi=N'" + Diachi + "', DT='" + DT + "', Email='" + Email + "' where MaNCC='" + MaNNC + "'";
            SqlCommand scm = new SqlCommand(sql, cnn);
            scm.ExecuteNonQuery();
        }
    }
}
