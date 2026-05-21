using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class DbHelper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["cafe_quanly"].ConnectionString;

        public static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);

        public static void TestConnection()
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
            }
        }

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }
            return dt;
        }

        public static object Scalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteIdentity(string sql, params SqlParameter[] parameters)
        {
            sql += "; SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
        }

        public static void EnsureSeedData()
        {
            var count = Convert.ToInt32(Scalar("SELECT COUNT(*) FROM DanhMuc"));
            if (count > 0)
                return;

            Execute("INSERT INTO DanhMuc(ten_danh_muc, thu_tu, hien_thi) VALUES (N'Cà phê', 1, 1)");
            Execute("INSERT INTO DanhMuc(ten_danh_muc, thu_tu, hien_thi) VALUES (N'Trà', 2, 1)");
            Execute("INSERT INTO DanhMuc(ten_danh_muc, thu_tu, hien_thi) VALUES (N'Sinh tố', 3, 1)");
            Execute("INSERT INTO DanhMuc(ten_danh_muc, thu_tu, hien_thi) VALUES (N'Bánh ngọt', 4, 1)");

            var dmCaPhe = Convert.ToInt32(Scalar("SELECT id FROM DanhMuc WHERE ten_danh_muc = N'Cà phê'"));
            var dmTra = Convert.ToInt32(Scalar("SELECT id FROM DanhMuc WHERE ten_danh_muc = N'Trà'"));
            var dmSinhTo = Convert.ToInt32(Scalar("SELECT id FROM DanhMuc WHERE ten_danh_muc = N'Sinh tố'"));
            var dmBanh = Convert.ToInt32(Scalar("SELECT id FROM DanhMuc WHERE ten_danh_muc = N'Bánh ngọt'"));

            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Cà phê đen', 25000, 1, 1)",
                new SqlParameter("@dm", dmCaPhe));
            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Cà phê sữa', 30000, 1, 2)",
                new SqlParameter("@dm", dmCaPhe));
            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Bạc xỉu', 32000, 1, 3)",
                new SqlParameter("@dm", dmCaPhe));
            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Trà đào', 35000, 1, 1)",
                new SqlParameter("@dm", dmTra));
            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Trà sữa', 40000, 1, 2)",
                new SqlParameter("@dm", dmTra));
            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Sinh tố bơ', 45000, 1, 1)",
                new SqlParameter("@dm", dmSinhTo));
            Execute("INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, N'Bánh croissant', 28000, 1, 1)",
                new SqlParameter("@dm", dmBanh));
        }
    }
}
