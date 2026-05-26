using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCLoginmanger : UserControl
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["cafe_quanly"]?.ConnectionString
            ?? "Data Source=.\\SQLEXPRESS;Initial Catalog=cafe_quanly;Integrated Security=True;TrustServerCertificate=True";

        public bool IsAuthenticated { get; private set; } = false;

        // 🔥 Sự kiện thông báo đăng nhập thành công
        public event EventHandler LoginSuccess;

        public UCLoginmanger()
        {
            InitializeComponent();
        }

        private void UCLoginmanger_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            txtUsername.Focus();
        }

        // Nút ĐĂNG NHẬP
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                return;
            }

            if (CheckAdminAccount(username, password))
            {
                IsAuthenticated = true;
                // 🔥 Gọi sự kiện đăng nhập thành công
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                lblError.Text = "Sai tài khoản hoặc mật khẩu quản trị viên!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private bool CheckAdminAccount(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}