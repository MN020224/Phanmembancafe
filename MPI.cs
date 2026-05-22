using System;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class MPI : Form
    {
        private UCBanHang ucBanHang;
        private UCBaoCao ucBaoCao;
        private UCQuanTri ucQuanTri;
        private UCDongca ucDongCa;

        public MPI()
        {
            InitializeComponent();

            mnBanHang.Click += mnBanHang_Click;
            mnBaoCao.Click += mnBaoCao_Click;
            mnQuanTri.Click += mnQuanTri_Click;
            mnDongCa.Click += mnDongCa_Click;
            mnDangXuat.Click += mnDangXuat_Click;
        }

        private static void LamMoiCaSession()
        {
            if (AppSession.IsLoggedIn)
                AppSession.CaId = CaService.GetOpenCaId(AppSession.TaiKhoanId);
        }

        private void XoaPanel()
        {
            panel1.Controls.Clear();
        }

        private void HienThiUserControl(UserControl uc)
        {
            XoaPanel();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            uc.Show();
        }

        private void mnBanHang_Click(object sender, EventArgs e)
        {
            LamMoiCaSession();
            if (ucBanHang == null)
                ucBanHang = new UCBanHang();

            HienThiUserControl(ucBanHang);
            ucBanHang.TaiLai();

            Text = "☕ CAFE POS - Đang bán hàng — " + AppSession.TenDangNhap;
<<<<<<< HEAD
           
        }
        public void SwitchToBanHang()
        {
            LamMoiCaSession();                     // Làm mới session ca (nếu cần)
            if (ucBanHang == null)
                ucBanHang = new UCBanHang();

            HienThiUserControl(ucBanHang);
            ucBanHang.TaiLai();

            Text = "☕ CAFE POS - Đang bán hàng — " + AppSession.TenDangNhap;
=======
>>>>>>> bdd71a7ec14dc6161cb6a899fe3b9b14c8d24755
        }

        private void mnBaoCao_Click(object sender, EventArgs e)
        {
            if (ucBaoCao == null)
                ucBaoCao = new UCBaoCao();

            HienThiUserControl(ucBaoCao);
            ucBaoCao.TaiLai();

            Text = "☕ CAFE POS - Báo cáo thống kê";
        }

        private void mnQuanTri_Click(object sender, EventArgs e)
        {
            if (ucQuanTri == null)
                ucQuanTri = new UCQuanTri();

            HienThiUserControl(ucQuanTri);
            ucQuanTri.TaiLai();

            Text = "☕ CAFE POS - Quản trị hệ thống";
        }

        private void mnDongCa_Click(object sender, EventArgs e)
        {
            LamMoiCaSession();
            if (ucDongCa == null)
                ucDongCa = new UCDongca();

            HienThiUserControl(ucDongCa);
            ucDongCa.TaiLaiDuLieu();

            Text = "☕ CAFE POS - Đóng ca làm việc";
        }

        private void mnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppSession.Clear();
                var loginForm = new Login();
                loginForm.Show();
                Close();
            }
        }

        private void MPI_Load(object sender, EventArgs e)
        {
            Text = "☕ CAFE POS — " + (AppSession.TenDangNhap ?? "");
            mnBanHang_Click(null, EventArgs.Empty);
        }
<<<<<<< HEAD

        private void mnQuanTri_Click_1(object sender, EventArgs e)
        {
            // Nếu tài khoản hiện tại đã là admin hoặc đã được cấp quyền tạm
            if (AppSession.HasAdminAccess)
            {
                ShowQuanTri();
                return;
            }

            // Chưa có quyền -> yêu cầu đăng nhập quản lý
            using (var frm = new FormLoginManager())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AppSession.IsImpersonatedAdmin = true;
                    ShowQuanTri();
                }
            }
        
        }
        private void ShowQuanTri()
        {
            // Xóa control hiện tại trong panel (ví dụ panel1, nếu tên khác thì sửa)
            panel1.Controls.Clear();
            UCQuanTri uc = new UCQuanTri();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void mnDangXuat_Click_1(object sender, EventArgs e)
        {
            AppSession.Clear(); // Xóa toàn bộ session (bao gồm IsImpersonatedAdmin)
            this.Close();
            Login login = new Login();
            login.Show();
        }
=======
>>>>>>> bdd71a7ec14dc6161cb6a899fe3b9b14c8d24755
    }
}
