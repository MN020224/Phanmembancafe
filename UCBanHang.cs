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
            InitializeNumericUpDown();
        }

        // Khởi tạo control NumericUpDown
        private void InitializeNumericUpDown()
        {
            if (nudSoLuong == null)
            {
                nudSoLuong = new NumericUpDown
                {
                    Location = new Point(120, 97),
                    Size = new Size(80, 20),
                    Minimum = 1,
                    Maximum = 100,
                    Value = 1
                };
            }

            // Thêm vào panel footer nếu chưa có
            if (pnlFooter != null && !pnlFooter.Controls.Contains(nudSoLuong))
            {
                pnlFooter.Controls.Add(nudSoLuong);
                nudSoLuong.BringToFront();
            }
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
<<<<<<< HEAD
            btnThanhToan.Click -= BtnThanhToan_Click;
            btnThanhToan.Click += BtnThanhToan_Click;

            UiTheme.StyleFlatButton(btnHuyHoaDon, UiTheme.Danger, 36);
            btnHuyHoaDon.Click -= BtnHuyHoaDon_Click;
            btnHuyHoaDon.Click += BtnHuyHoaDon_Click;

            UiTheme.StyleFlatButton(btnThemMon, UiTheme.Primary, 30);
            btnThemMon.Click -= BtnThemMon_Click;
            btnThemMon.Click += BtnThemMon_Click;

            UiTheme.StyleFlatButton(btnXoaMon, UiTheme.Warning, 30);
            btnXoaMon.Click -= BtnXoaMon_Click;
            btnXoaMon.Click += BtnXoaMon_Click;

=======
            UiTheme.StyleFlatButton(btnHuyHoaDon, UiTheme.Danger, 36);
            UiTheme.StyleFlatButton(btnThemMon, UiTheme.Primary, 30);
            UiTheme.StyleFlatButton(btnXoaMon, UiTheme.Warning, 30);
>>>>>>> bdd71a7ec14dc6161cb6a899fe3b9b14c8d24755

            // Thiết lập DataGridView
            dgvGioHang.Columns.Clear();
            dgvGioHang.Columns.Add("ChiTietId", "ID");
            dgvGioHang.Columns["ChiTietId"].Visible = false;
            dgvGioHang.Columns.Add("TenMon", "Tên món");
            dgvGioHang.Columns.Add("SoLuong", "SL");
            dgvGioHang.Columns["SoLuong"].Width = 50;
            dgvGioHang.Columns.Add("DonGia", "Đơn giá");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");

<<<<<<< HEAD
           
=======
            // Gán sự kiện
            btnThanhToan.Click += BtnThanhToan_Click;
            btnHuyHoaDon.Click += BtnHuyHoaDon_Click;
            btnThemMon.Click += BtnThemMon_Click;
            btnXoaMon.Click += BtnXoaMon_Click;
>>>>>>> bdd71a7ec14dc6161cb6a899fe3b9b14c8d24755

            // Thiết lập ComboBox mặc định
            if (cboPhuongThucThanhToan.Items.Count == 0)
            {
                cboPhuongThucThanhToan.Items.AddRange(new object[] {
                    "💵 Tiền mặt",
                    "🏦 Chuyển khoản",
                    "📱 Ví điện tử"
                });
            }
            cboPhuongThucThanhToan.SelectedIndex = 0;

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

        private void BtnThemMon_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm số lượng trong giỏ hàng.", "Hướng dẫn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvGioHang.SelectedRows[0];
            int chiTietId = Convert.ToInt32(selectedRow.Cells["ChiTietId"].Value);
            string tenMon = selectedRow.Cells["TenMon"].Value.ToString();
            decimal donGia = decimal.Parse(selectedRow.Cells["DonGia"].Value.ToString().Replace(",", ""));

            // Tìm MonAnId từ chi tiết
            var dt = BanHangService.GetChiTietHoaDon(_hoaDonId.Value);
            int monAnId = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["id"]) == chiTietId)
                {
<<<<<<< HEAD
                    monAnId = Convert.ToInt32(row["monAnId"]);
=======
                    monAnId = Convert.ToInt32(row["mon_an_id"]);
>>>>>>> bdd71a7ec14dc6161cb6a899fe3b9b14c8d24755
                    break;
                }
            }

            if (monAnId == 0) return;

            // Hiển thị form nhập số lượng
            var form = new Form
            {
                Text = $"Thêm số lượng - {tenMon}",
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterParent
            };

            var nud = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Location = new Point(50, 30),
                Size = new Size(80, 20)
            };

            var btnOK = new Button
            {
                Text = "Thêm",
                Location = new Point(150, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK
            };

            form.Controls.Add(nud);
            form.Controls.Add(btnOK);

            if (form.ShowDialog() == DialogResult.OK)
            {
                int soLuong = (int)nud.Value;
                BanHangService.ThemChiTiet(_hoaDonId.Value, monAnId, soLuong, donGia);
                NapGioHang();
            }
        }

        private void BtnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa trong giỏ hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int chiTietId = Convert.ToInt32(dgvGioHang.SelectedRows[0].Cells["ChiTietId"].Value);

            if (MessageBox.Show("Xóa món đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                BanHangService.XoaChiTiet(_hoaDonId.Value, chiTietId);
                NapGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemVaoGio(int monAnId, decimal price)
        {
            if (!AppSession.CaId.HasValue)
            {
                MessageBox.Show("Chưa mở ca làm việc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_hoaDonId.HasValue)
                KhoiTaoHoaDon();

            int qty = (int)nudSoLuong.Value;

            try
            {
                BanHangService.ThemChiTiet(_hoaDonId.Value, monAnId, qty, price);
                NapGioHang();
                nudSoLuong.Value = 1;
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
            // Kiểm tra hóa đơn tồn tại
<<<<<<< HEAD
            if (!_hoaDonId.HasValue)
=======
            if (!_hoaDonId.HasValue || dgvGioHang.Rows.Count == 0)
>>>>>>> bdd71a7ec14dc6161cb6a899fe3b9b14c8d24755
            {
                MessageBox.Show("Chưa có món trong hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lấy tổng tiền từ service thay vì từ textbox
                decimal tongTien = BanHangService.LayTongTien(_hoaDonId.Value);

                if (tongTien <= 0)
                {
                    MessageBox.Show("Không thể thanh toán với tổng tiền bằng 0.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy phương thức thanh toán được chọn
                string phuongThucHienThi = cboPhuongThucThanhToan.SelectedItem?.ToString();
                string phuongThuc = "";

                if (string.IsNullOrEmpty(phuongThucHienThi))
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi phương thức thanh toán
                if (phuongThucHienThi.Contains("Tiền mặt"))
                    phuongThuc = "tien_mat";
                else if (phuongThucHienThi.Contains("Chuyển khoản"))
                    phuongThuc = "chuyen_khoan";
                else if (phuongThucHienThi.Contains("Ví điện tử"))
                    phuongThuc = "vi_dien_tu";
                else
                    phuongThuc = "tien_mat";

                // Xác nhận thanh toán
                DialogResult confirm = MessageBox.Show(
                    $"Xác nhận thanh toán {tongTien:N0} VNĐ bằng {phuongThucHienThi}?",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                // Gọi service thanh toán
                BanHangService.ThanhToan(_hoaDonId.Value, phuongThuc);

                // Hiển thị thông báo thành công
                MessageBox.Show($"Thanh toán thành công bằng {phuongThucHienThi}!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Reset hóa đơn
                _hoaDonId = null;
                KhoiTaoHoaDon();

                // Reset comboBox về mặc định
                cboPhuongThucThanhToan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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