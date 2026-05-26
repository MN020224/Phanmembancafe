using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class DbHelper
    {
        // SỬA: Kiểm tra null an toàn
        public static string ConnectionString
        {
            get
            {
                try
                {
                    // Thử đọc từ config trước
                    var setting = ConfigurationManager.ConnectionStrings["cafe_quanly"];

                    if (setting != null && !string.IsNullOrEmpty(setting.ConnectionString))
                    {
                        return setting.ConnectionString;
                    }

                    // Nếu không có config, dùng hardcode
                    return @"Data Source=DESKTOP-E61FMDN\SQLEXPRESS;Initial Catalog=cafe_quanly;Integrated Security=True;TrustServerCertificate=True";
                }
                catch
                {
                    // Nếu lỗi đọc config, dùng hardcode
                    return @"Data Source=DESKTOP-E61FMDN\SQLEXPRESS;Initial Catalog=cafe_quanly;Integrated Security=True;TrustServerCertificate=True";
                }
            }
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

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
    }
}