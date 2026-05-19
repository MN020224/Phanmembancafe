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
    }
}
