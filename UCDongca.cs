using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCDongca : UserControl
    {
        private bool _daKhoiTao;

        public UCDongca()
        {
            InitializeComponent();
        }

        public void TaiLaiDuLieu()
        {
            if (!_daKhoiTao)
                return;
            NapDuLieu();
        }

        private void UCDongca_Load(object sender, EventArgs e)
        {
            UiTheme.StyleDataGridView(dgvHoaDonTrongCa);
            UiTheme.StyleFlatButton(btnMoCa, UiTheme.Success, 45);
            UiTheme.StyleFlatButton(btnDongCa, UiTheme.Danger, 45);
            UiTheme.StyleFlatButton(btnXemBaoCao, UiTheme.Primary, 35);
            UiTheme.StyleFlatButton(btnInBaoCao, UiTheme.PrimaryDark, 35);

            dgvHoaDonTrongCa.Columns.Clear();
            dgvHoaDonTrongCa.Columns.Add("MaHD", "Mã HĐ");
            dgvHoaDonTrongCa.Columns.Add("Gio", "Giờ");
            dgvHoaDonTrongCa.Columns.Add("TongTien", "Tổng tiền");
            dgvHoaDonTrongCa.Columns.Add("HinhThuc", "Hình thức");

            btnMoCa.Click += BtnMoCa_Click;
            btnDongCa.Click += BtnDongCa_Click;
            btnXemBaoCao.Click += (s, ev) => NapDuLieu();

            _daKhoiTao = true;
            NapDuLieu();
        }

        private void NapDuLieu()
        {
            try
            {
                txtNhanVien.Text = AppSession.TenDangNhap ?? "";

                if (!AppSession.CaId.HasValue)
                {
                    HienThiChuaMoCa();
                    return;
                }

                var row = CaService.GetCaInfo(AppSession.CaId.Value);
                if (row == null)
                {
                    AppSession.CaId = null;
                    HienThiChuaMoCa();
                    return;
                }

                txtGioMoCa.Text = Convert.ToDateTime(row["gio_mo"]).ToString("HH:mm:ss dd/MM/yyyy");
                txtGioDongCa.Text = row["gio_dong"] == DBNull.Value
                    ? "--:--:--"
                    : Convert.ToDateTime(row["gio_dong"]).ToString("HH:mm:ss dd/MM/yyyy");

                int caId = AppSession.CaId.Value;
                txtSoHoaDon.Text = CaService.DemHoaDonCa(caId).ToString();
                txtTrangThaiCa.Text = row["trang_thai"].ToString() == "dang_mo" ? "ĐANG MỞ CA" : "ĐÃ ĐÓNG CA";
                txtTrangThaiCa.ForeColor = row["trang_thai"].ToString() == "dang_mo"
                    ? Color.FromArgb(39, 174, 96)
                    : Color.Gray;

                decimal tong = CaService.TongDoanhThuCa(caId);
                decimal tienMat = CaService.TongTienMatCa(caId);
                decimal ck = CaService.TongChuyenKhoanCa(caId);
                decimal dauCa = Convert.ToDecimal(row["tien_dau_ca"]);

                txtTongDoanhThu.Text = tong.ToString("N0") + " đ";
                txtTienMat.Text = tienMat.ToString("N0") + " đ";
                txtChuyenKhoan.Text = ck.ToString("N0") + " đ";
                txtTienDauCa.Text = dauCa.ToString("N0");
                txtThucThu.Text = (dauCa + tienMat).ToString("N0") + " đ";
                txtChenhLech.Text = "0 đ";

                dgvHoaDonTrongCa.Rows.Clear();
                var dt = CaService.GetHoaDonTrongCa(caId);
                foreach (DataRow r in dt.Rows)
                {
                    dgvHoaDonTrongCa.Rows.Add(
                        r["MaHD"],
                        r["Gio"],
                        Convert.ToDecimal(r["TongTien"]).ToString("N0") + " đ",
                        r["HinhThuc"]);
                }

                bool dangMo = row["trang_thai"].ToString() == "dang_mo";
                btnMoCa.Visible = !dangMo;
                btnMoCa.Enabled = !dangMo;
                btnDongCa.Visible = dangMo;
                btnDongCa.Enabled = dangMo;
                txtTienDauCa.Enabled = !dangMo;
                btnXemBaoCao.Enabled = true;
                btnInBaoCao.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ca: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiChuaMoCa()
        {
            txtGioMoCa.Text = "--:--:--";
            txtGioDongCa.Text = "--:--:--";
            txtSoHoaDon.Text = "0";
            txtTrangThaiCa.Text = "CHƯA MỞ CA";
            txtTrangThaiCa.ForeColor = Color.FromArgb(243, 156, 18);
            txtTongDoanhThu.Text = "0 đ";
            txtTienMat.Text = "0 đ";
            txtChuyenKhoan.Text = "0 đ";
            txtTienDauCa.Text = "0";
            txtThucThu.Text = "0 đ";
            txtChenhLech.Text = "0 đ";
            dgvHoaDonTrongCa.Rows.Clear();
            btnMoCa.Visible = true;
            btnMoCa.Enabled = true;
            btnDongCa.Visible = false;
            txtTienDauCa.Enabled = true;
        }

        private void BtnMoCa_Click(object sender, EventArgs e)
        {
            if (!AppSession.IsLoggedIn)
                return;

            if (!decimal.TryParse(txtTienDauCa.Text.Replace(".", "").Replace(",", ""),
                out decimal tienDau))
                tienDau = 0;

            try
            {
                CaService.MoCa(AppSession.TaiKhoanId, tienDau);
                AppSession.CaId = CaService.GetOpenCaId(AppSession.TaiKhoanId);
                MessageBox.Show("Mở ca thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                NapDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở ca: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDongCa_Click(object sender, EventArgs e)
        {
            if (!AppSession.CaId.HasValue)
                return;

            if (MessageBox.Show("Xác nhận đóng ca làm việc?", "Đóng ca",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (!decimal.TryParse(txtTienDauCa.Text.Replace(".", "").Replace(",", ""),
                out decimal tienDau))
                tienDau = 0;

            decimal tienMat = CaService.TongTienMatCa(AppSession.CaId.Value);
            decimal tienCuoi = tienDau + tienMat;

            try
            {
                CaService.DongCa(AppSession.CaId.Value, tienCuoi);
                AppSession.CaId = null;
                MessageBox.Show("Đóng ca thành công!\nTiền cuối ca: " + tienCuoi.ToString("N0") + " đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NapDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đóng ca: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoCa_Click_1(object sender, EventArgs e)
        {

        }
    }
}
