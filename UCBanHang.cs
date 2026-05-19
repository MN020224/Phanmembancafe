using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCBanHang : UserControl
    {
        private Button _categorySelected;
        private int? _hoaDonId;
        private bool _daKhoiTao;

        public UCBanHang()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daKhoiTao)
                return;

            AppSession.CaId = CaService.GetOpenCaId(AppSession.TaiKhoanId);
            if (!KiemTraCa())
                return;

            NapDanhMuc();
            KhoiTaoHoaDon();
        }

        private void UCBanHang_Load(object sender, EventArgs e)
        {
            UiTheme.StyleDataGridView(dgvGioHang);
            UiTheme.StyleFlatButton(btnThanhToan, UiTheme.Success, 44);
            UiTheme.StyleFlatButton(btnHuyHoaDon, UiTheme.Danger, 36);
            UiTheme.StyleFlatButton(btnThemMon, UiTheme.Primary, 30);

            dgvGioHang.Columns.Clear();
            dgvGioHang.Columns.Add("ChiTietId", "ID");
            dgvGioHang.Columns["ChiTietId"].Visible = false;
            dgvGioHang.Columns.Add("TenMon", "Tên món");
            dgvGioHang.Columns.Add("SoLuong", "SL");
            dgvGioHang.Columns["SoLuong"].Width = 50;
            dgvGioHang.Columns.Add("DonGia", "Đơn giá");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");

            btnThanhToan.Click += BtnThanhToan_Click;
            btnHuyHoaDon.Click += BtnHuyHoaDon_Click;

            _daKhoiTao = true;
            TaiLai();
        }

        private bool KiemTraCa()
        {
            if (!AppSession.CaId.HasValue)
            {
                MessageBox.Show(
                    "Bạn chưa mở ca làm việc.\nVào menu \"Đóng ca\" → \"MỞ CA\" trước khi bán hàng.",
                    "Chưa mở ca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void NapDanhMuc()
        {
            try
            {
                pnlSidebar.Controls.Clear();
                var lbl = new Label
                {
                    Text = "DANH MỤC",
                    Dock = DockStyle.Top,
                    Height = 36,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(189, 195, 199),
                    Padding = new Padding(12, 8, 0, 8)
                };
                pnlSidebar.Controls.Add(lbl);

                var dt = BanHangService.GetDanhMuc();
                Button first = null;
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string ten = row["ten_danh_muc"].ToString();
                    var btn = new Button { Text = "  " + ten, Tag = id };
                    UiTheme.StyleSidebarButton(btn, false);
                    btn.BackColor = UiTheme.Sidebar;
                    btn.Click += DanhMuc_Click;
                    pnlSidebar.Controls.Add(btn);
                    if (first == null)
                        first = btn;
                }

                if (first != null)
                    first.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DanhMuc_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (_categorySelected != null)
            {
                UiTheme.StyleSidebarButton(_categorySelected, false);
                _categorySelected.BackColor = UiTheme.Sidebar;
            }
            UiTheme.StyleSidebarButton(btn, true);
            _categorySelected = btn;
            NapSanPham(Convert.ToInt32(btn.Tag));
        }

        private void NapSanPham(int danhMucId)
        {
            flowSanPham.SuspendLayout();
            flowSanPham.Controls.Clear();
            var dt = BanHangService.GetMonAnByDanhMuc(danhMucId);
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string ten = row["ten_mon"].ToString();
                decimal gia = Convert.ToDecimal(row["gia"]);
                flowSanPham.Controls.Add(CreateProductCard(id, ten, gia));
            }
            flowSanPham.ResumeLayout();
        }

        private Panel CreateProductCard(int monAnId, string name, decimal price)
        {
            var card = new Panel
            {
                Size = new Size(140, 160),
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = monAnId
            };

            var pic = new Panel
            {
                Size = new Size(124, 72),
                Location = new Point(8, 8),
                BackColor = Color.FromArgb(236, 240, 241)
            };
            var lblName = new Label
            {
                Text = name,
                Font = UiTheme.FontSection,
                ForeColor = UiTheme.TextDark,
                Location = new Point(8, 88),
                Size = new Size(124, 40),
                TextAlign = ContentAlignment.TopCenter
            };
            var lblPrice = new Label
            {
                Text = price.ToString("N0") + " đ",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                Location = new Point(8, 128),
                Size = new Size(124, 24),
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);

            EventHandler click = (s, ev) => ThemVaoGio(monAnId, price);
            card.Click += click;
            foreach (Control c in card.Controls)
                c.Click += click;

            return card;
        }

        private void KhoiTaoHoaDon()
        {
            if (!AppSession.CaId.HasValue)
                return;

            _hoaDonId = BanHangService.GetHoaDonChoThanhToan(AppSession.CaId.Value);
            if (!_hoaDonId.HasValue)
                _hoaDonId = BanHangService.TaoHoaDon(AppSession.CaId.Value);
            NapGioHang();
        }

        private void ThemVaoGio(int monAnId, decimal price)
        {
            if (!AppSession.CaId.HasValue)
                return;
            if (!_hoaDonId.HasValue)
                KhoiTaoHoaDon();

            int qty = (int)nudSoLuong.Value;
            try
            {
                BanHangService.ThemChiTiet(_hoaDonId.Value, monAnId, qty, price);
                NapGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NapGioHang()
        {
            if (dgvGioHang.Columns.Count == 0)
                return;

            dgvGioHang.Rows.Clear();
            if (!_hoaDonId.HasValue)
                return;

            var dt = BanHangService.GetChiTietHoaDon(_hoaDonId.Value);
            foreach (DataRow row in dt.Rows)
            {
                dgvGioHang.Rows.Add(
                    row["id"],
                    row["TenMon"],
                    row["SoLuong"],
                    Convert.ToDecimal(row["DonGia"]).ToString("N0"),
                    Convert.ToDecimal(row["ThanhTien"]).ToString("N0"));
            }
            txtTongTien.Text = BanHangService.LayTongTien(_hoaDonId.Value).ToString("N0") + " đ";
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (!_hoaDonId.HasValue || dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món trong hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                BanHangService.ThanhToan(_hoaDonId.Value);
                MessageBox.Show("Thanh toán thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _hoaDonId = null;
                KhoiTaoHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (!_hoaDonId.HasValue)
                return;

            if (MessageBox.Show("Hủy hóa đơn hiện tại?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                BanHangService.HuyHoaDon(_hoaDonId.Value);
                _hoaDonId = null;
                KhoiTaoHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
