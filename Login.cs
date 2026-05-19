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
using System.Configuration;

namespace CafeOrder
{
    public partial class Login : Form
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["cafe_quanly"]?.ConnectionString
            ?? "Data Source=.\\SQLEXPRESS;Initial Catalog=cafe_quanly;Integrated Security=True;TrustServerCertificate=True";
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                label4.Text = "Vui lòng nhập tên đăng nhập!";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                label4.Text = "Vui lòng nhập mật khẩu!";
                txtPassword.Focus();
                return;
            }

            // Xóa thông báo cũ
            label4.Text = "";

            // Vô hiệu nút trong lúc xử lý
            btndangnhap.Enabled = false;
            btndangnhap.Text = "Đang xử lý...";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (IsAdminAccount(txtUsername.Text, txtPassword.Text))
                    {
                        // Hiển thị thông báo trên label
                        label4.Text = "Vui lòng đăng nhập tài khoản nhân viên!";
                        txtPassword.Clear();
                        txtPassword.Focus();
                        btndangnhap.Enabled = true;
                        btndangnhap.Text = "ĐĂNG NHẬP";
                        return;
                    }


                    string sql = "SELECT id, ten_dang_nhap, vai_tro FROM TaiKhoan WHERE ten_dang_nhap = @username AND mat_khau = @password AND vai_tro = N'nhan_vien'";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            AppSession.TaiKhoanId = Convert.ToInt32(reader["id"]);
                            AppSession.TenDangNhap = reader["ten_dang_nhap"].ToString();
                            AppSession.VaiTro = reader["vai_tro"].ToString();
                            DbHelper.EnsureSeedData();
                            AppSession.CaId = CaService.GetOpenCaId(AppSession.TaiKhoanId);

                            MPI main = new MPI();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Đăng nhập thất bại
                            label4.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                label4.Text = "Lỗi kết nối database!";
            }
            finally
            {
                // Bật lại nút
                btndangnhap.Enabled = true;
                btndangnhap.Text = "ĐĂNG NHẬP";
            }
        }
        private bool IsAdminAccount(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // ĐÃ SỬA: 'Admin' thành 'admin' (viết thường cho đúng database)
                    string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE ten_dang_nhap = @username AND mat_khau = @password AND vai_tro = 'admin'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void Btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}