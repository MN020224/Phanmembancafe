using System;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class MPI : Form
    {
        // Khởi tạo các UserControl
        private UCBanHang ucBanHang;
        private UCBaoCao ucBaoCao;
        private UCQuanTri ucQuanTri;
        private UCDongca ucDongCa;

        public MPI()
        {
            InitializeComponent();

            // Gán sự kiện click cho MenuStrip
            this.mnBanHang.Click += new EventHandler(mnBanHang_Click);
            this.mnBaoCao.Click += new EventHandler(mnBaoCao_Click);
            this.mnQuanTri.Click += new EventHandler(mnQuanTri_Click);
            this.mnDongCa.Click += new EventHandler(mnDongCa_Click);
            this.mnDangXuat.Click += new EventHandler(mnDangXuat_Click);
        }

        // Hàm xóa các UserControl cũ trong Panel
        private void XoaPanel()
        {
            panel1.Controls.Clear();
        }

        // Hàm hiển thị UserControl lên Panel
        private void HienThiUserControl(UserControl uc)
        {
            XoaPanel();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        // 1. Hiển thị giao diện BÁN HÀNG
        private void mnBanHang_Click(object sender, EventArgs e)
        {
            if (ucBanHang == null)
            {
                ucBanHang = new UCBanHang();
            }
            HienThiUserControl(ucBanHang);
            this.Text = "☕ CAFE POS - Đang bán hàng";
        }

        // 2. Hiển thị giao diện BÁO CÁO
        private void mnBaoCao_Click(object sender, EventArgs e)
        {
            if (ucBaoCao == null)
            {
                ucBaoCao = new UCBaoCao();
            }
            HienThiUserControl(ucBaoCao);
            this.Text = "☕ CAFE POS - Báo cáo thống kê";
        }

        // 3. Hiển thị giao diện QUẢN TRỊ
        private void mnQuanTri_Click(object sender, EventArgs e)
        {
            if (ucQuanTri == null)
            {
                ucQuanTri = new UCQuanTri();
            }
            HienThiUserControl(ucQuanTri);
            this.Text = "☕ CAFE POS - Quản trị hệ thống";
        }

        // 4. Hiển thị giao diện ĐÓNG CA
        private void mnDongCa_Click(object sender, EventArgs e)
        {
            if (ucDongCa == null)
            {
                ucDongCa = new UCDongca();
            }
            HienThiUserControl(ucDongCa);
            this.Text = "☕ CAFE POS - Đóng ca làm việc";
        }

        // 5. ĐĂNG XUẤT
        private void mnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
        }

        // Khi form load, mặc định hiển thị giao diện BÁN HÀNG
        private void MPI_Load(object sender, EventArgs e)
        {
            mnBanHang_Click(null, null);
        }
    }
}