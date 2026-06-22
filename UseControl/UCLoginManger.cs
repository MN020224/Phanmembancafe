using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCLoginmanger : UserControl
    {
        private readonly string connectionString = DbHelper.ConnectionString;

        public bool IsAuthenticated { get; private set; } = false;

        public event EventHandler LoginSuccess;

        public UCLoginmanger()
        {
            InitializeComponent();
            Load += UCLoginmanger_Load;
            txtUsername.KeyDown += DangNhapAdmin_KeyDown;
            txtPassword.KeyDown += DangNhapAdmin_KeyDown;
            txtPassword.PasswordChar = '●';
        }

        private void UCLoginmanger_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            label1.Text = "Quản trị viên";
            UiTheme.StyleFlatButton(btndangnhap, UiTheme.Primary, 48);
            btndangnhap.Text = "🔐 Đăng nhập quản trị";
            btndangnhap.ForeColor = Color.White;
            btndangnhap.UseVisualStyleBackColor = false;
            lblError.ForeColor = Color.FromArgb(231, 76, 60);
            lblError.BackColor = Color.Transparent;
            lblError.Font = new System.Drawing.Font("Segoe UI", 10F);

            txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtPassword.PasswordChar = '●';
            txtUsername.Focus();
        }

        private void DangNhapAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            btndangnhap.PerformClick();
        }

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
