using System;
using System.Windows.Forms;
using CafeOrder.UseControl;

namespace CafeOrder
{
    public partial class MPI : Form
    {
        private UCBanHang ucBanHang;
        private UCBaoCao ucBaoCao;
        private UCQuanTri ucQuanTri;
        private UCDongca ucDongCa;
        private UCThuChi ucThuChi;  

        public MPI()
        {
            InitializeComponent();

            MnBanHang.Click += MnBanHang_Click;
            MnBaoCao.Click += MnBaoCao_Click;
            MnQuanTri.Click += MnQuanTri_Click;
            MnDongCa.Click += MnDongCa_Click;
            MnThuChi.Click += MnThuChi_Click;  
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

        private void MnBanHang_Click(object sender, EventArgs e)
        {
            LamMoiCaSession();
            if (ucBanHang == null)
                ucBanHang = new UCBanHang();

            HienThiUserControl(ucBanHang);
            ucBanHang.TaiLai();

            Text = "☕ CAFE POS - Đang bán hàng — " + AppSession.TenDangNhap;
        }

        public void SwitchToBanHang()
        {
            LamMoiCaSession();
            if (ucBanHang == null)
                ucBanHang = new UCBanHang();

            HienThiUserControl(ucBanHang);
            ucBanHang.TaiLai();

            Text = "☕ CAFE POS - Đang bán hàng — " + AppSession.TenDangNhap;
        }

        private void MnBaoCao_Click(object sender, EventArgs e)
        {
            if (ucBaoCao == null)
                ucBaoCao = new UCBaoCao();

            HienThiUserControl(ucBaoCao);
            ucBaoCao.TaiLai();

            Text = "☕ CAFE POS - Báo cáo thống kê";
        }

        private void MnQuanTri_Click(object sender, EventArgs e)
        {
            if (AppSession.HasAdminAccess)
            {
                ShowQuanTri();
                return;
            }

            var ucLogin = new UCLoginmanger();

            ucLogin.LoginSuccess += (s, args) =>
            {
                AppSession.IsImpersonatedAdmin = true;
                ShowQuanTri();
            };

            HienThiUserControl(ucLogin);
            Text = "☕ CAFE POS - Đăng nhập Quản trị";
        }

        private void ShowQuanTri()
        {
            if (ucQuanTri == null)
                ucQuanTri = new UCQuanTri();

            HienThiUserControl(ucQuanTri);
            ucQuanTri.TaiLai();

            Text = "☕ CAFE POS - Quản trị hệ thống";
        }

        private void MnDongCa_Click(object sender, EventArgs e)
        {
            LamMoiCaSession();
            if (ucDongCa == null)
                ucDongCa = new UCDongca();

            HienThiUserControl(ucDongCa);
            ucDongCa.TaiLaiDuLieu();

            Text = "☕ CAFE POS - Đóng ca làm việc";
        }

        private void MnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppSession.Clear();
                var loginForm = new Login();
                loginForm.Show();
                Close();
            }
        }

        // 🔥 THÊM METHOD NÀY - XỬ LÝ MENU THU CHI
        private void MnThuChi_Click(object sender, EventArgs e)
        {
            LamMoiCaSession();

            if (ucThuChi == null)
                ucThuChi = new UCThuChi();

            HienThiUserControl(ucThuChi);

            Text = "☕ CAFE POS - Quản lý thu chi";
        }

        private void MPI_Load(object sender, EventArgs e)
        {
            Text = "☕ CAFE POS — " + (AppSession.TenDangNhap ?? "");
            MnBanHang_Click(null, EventArgs.Empty);
        }
    }
}