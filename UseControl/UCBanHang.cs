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
        private int? _danhMucDangChon;
        private bool _dangTimKiem;

        public UCBanHang()
        {
            InitializeComponent();
            pnlSidebar.AutoScroll = true;
            InitializeNumericUpDown();
        }

        private void InitializeNumericUpDown()
        {
            if (nudSoLuong == null)
            {
                nudSoLuong = new NumericUpDown
                {
               
                    Size = new Size(80, 20),
                    Minimum = 1,
                    Maximum = 100,
                    Value = 1
                };
            }


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

            UiTheme.StyleFlatButton(btnXoaTimKiem, UiTheme.Primary, 32);


            // Thiết lập DataGridView
            dgvGioHang.Columns.Clear();
            dgvGioHang.Columns.Add("ChiTietId", "ID");
            dgvGioHang.Columns["ChiTietId"].Visible = false;
            dgvGioHang.Columns.Add("TenMon", "Tên món");
            dgvGioHang.Columns.Add("SoLuong", "SL");
            dgvGioHang.Columns["SoLuong"].Width = 50;
            dgvGioHang.Columns.Add("DonGia", "Đơn giá");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");



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


            if (btnThemMon != null && nudSoLuong != null && pnlFooter != null)
            {

                nudSoLuong.Location = new Point(btnThemMon.Right + 5, btnThemMon.Top);
            }

            txtGhiChu.Leave += (s, ev) =>
            {
                if (_hoaDonId.HasValue)
                {
                    string ghichu = txtGhiChu.Text.Trim();
                    BanHangService.CapNhatGhiChuHoaDon(_hoaDonId.Value, ghichu);
                }
            };
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
                pnlSidebar.SuspendLayout();
                pnlSidebar.Controls.Clear();


                var lbl = new Label
                {
                    Text = "📂 DANH MỤC",
                    Dock = DockStyle.Top,
                    Height = 50,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(112, 77, 59),
                    Padding = new Padding(17, 11, 0, 11),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                pnlSidebar.Controls.Add(lbl);

                DataTable dt = BanHangService.GetDanhMuc();
                if (dt.Rows.Count == 0) return;

                Button firstButton = null;

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows[i];
                    int id = Convert.ToInt32(row["id"]);
                    string ten = row["ten_danh_muc"].ToString();

                    var btn = new Button
                    {
                        Text = "  " + ten,
                        Tag = id,
                        Dock = DockStyle.Top,
                        Height = 45,
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft,
                        BackColor = Color.FromArgb(112, 77, 59),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        UseVisualStyleBackColor = false,
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        FlatAppearance = { BorderSize = 0 }
                    };
                    btn.Click += DanhMuc_Click;
                    pnlSidebar.Controls.Add(btn);
                    firstButton = btn; 
                }

                pnlSidebar.ResumeLayout();


                if (firstButton != null)
                {
                    this.BeginInvoke(new Action(() => firstButton.PerformClick()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
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
            _danhMucDangChon = Convert.ToInt32(btn.Tag);
            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Clear();
                return;
            }
            NapSanPham(_danhMucDangChon.Value);
        }

        private void NapSanPham(int danhMucId)
        {
            _danhMucDangChon = danhMucId;
            _dangTimKiem = false;
            HienThiSanPham(BanHangService.GetMonAnByDanhMuc(danhMucId), false);
        }

        private void TimKiemSanPham()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                _dangTimKiem = false;
                if (_danhMucDangChon.HasValue)
                    NapSanPham(_danhMucDangChon.Value);
                else
                    flowSanPham.Controls.Clear();
                return;
            }

            _dangTimKiem = true;
            HienThiSanPham(BanHangService.TimKiemMonAn(tuKhoa), true);
        }

        private void HienThiSanPham(DataTable dt, bool hienDanhMuc)
        {
            flowSanPham.SuspendLayout();
            flowSanPham.Controls.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                var lblTrong = new Label
                {
                    Text = _dangTimKiem ? "Không tìm thấy món phù hợp." : "Danh mục chưa có món.",
                    AutoSize = true,
                    Font = UiTheme.FontBody,
                    ForeColor = UiTheme.TextMuted,
                    Margin = new Padding(16)
                };
                flowSanPham.Controls.Add(lblTrong);
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string ten = row["ten_mon"].ToString();
                    decimal gia = Convert.ToDecimal(row["gia"]);
                    string danhMuc = hienDanhMuc && dt.Columns.Contains("ten_danh_muc")
                        ? row["ten_danh_muc"].ToString()
                        : null;
                    flowSanPham.Controls.Add(CreateProductCard(id, ten, gia, danhMuc));
                }
            }

            flowSanPham.ResumeLayout();
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        private void TxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ThemMonDauTienTuTimKiem();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtTimKiem.Clear();
            }
        }

        private void BtnXoaTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            txtTimKiem.Focus();
        }

        private void ThemMonDauTienTuTimKiem()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
                return;

            var dt = BanHangService.TimKiemMonAn(tuKhoa);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy món phù hợp.", "Tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dt.Rows[0];
            ThemVaoGio(Convert.ToInt32(row["id"]), Convert.ToDecimal(row["gia"]));
            txtTimKiem.Clear();
            txtTimKiem.Focus();
        }

        private Panel CreateProductCard(int monAnId, string name, decimal price, string danhMuc = null)
        {
            var card = new Panel
            {
                Size = new Size(140, danhMuc == null ? 160 : 176),
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = monAnId
            };

            var pic = new Panel
            {
                Size = new Size(124, danhMuc == null ? 72 : 56),
                Location = new Point(8, 8),
                BackColor = Color.FromArgb(236, 240, 241)
            };

            int nameTop = danhMuc == null ? 88 : 68;
            if (danhMuc != null)
            {
                var lblDanhMuc = new Label
                {
                    Text = danhMuc,
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = UiTheme.TextMuted,
                    Location = new Point(8, 68),
                    Size = new Size(124, 18),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                card.Controls.Add(lblDanhMuc);
            }

            var lblName = new Label
            {
                Text = name,
                Font = UiTheme.FontSection,
                ForeColor = UiTheme.TextDark,
                Location = new Point(8, nameTop),
                Size = new Size(124, 40),
                TextAlign = ContentAlignment.TopCenter
            };
            var lblPrice = new Label
            {
                Text = price.ToString("N0") + " đ",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                Location = new Point(8, nameTop + 40),
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
            // 1. Kiểm tra đã chọn dòng trong giỏ hàng
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm số lượng trong giỏ hàng.", "Hướng dẫn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Kiểm tra hóa đơn tồn tại (KHÔNG NULL)
            if (!_hoaDonId.HasValue)
            {
                MessageBox.Show("Chưa có hóa đơn. Vui lòng thêm món từ danh sách bên trái trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvGioHang.SelectedRows[0];

            // 3. Lấy ChiTietId an toàn
            object chiTietObj = selectedRow.Cells["ChiTietId"].Value;
            if (chiTietObj == null || chiTietObj == DBNull.Value)
            {
                MessageBox.Show("Dữ liệu ChiTietId không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int chiTietId = Convert.ToInt32(chiTietObj);

            // 4. Lấy Tên món an toàn
            object tenMonObj = selectedRow.Cells["TenMon"].Value;
            if (tenMonObj == null || tenMonObj == DBNull.Value)
            {
                MessageBox.Show("Dữ liệu Tên món không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenMon = tenMonObj.ToString();

            // 5. Lấy Đơn giá an toàn (loại bỏ dấu phẩy, xử lý định dạng)
            object donGiaObj = selectedRow.Cells["DonGia"].Value;
            if (donGiaObj == null || donGiaObj == DBNull.Value)
            {
                MessageBox.Show("Dữ liệu Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string donGiaStr = donGiaObj.ToString().Replace(",", "");
            if (!decimal.TryParse(donGiaStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không đúng định dạng số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DataTable dt = BanHangService.GetChiTietHoaDon(_hoaDonId.Value);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int monAnId = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["id"]) == chiTietId)
                {
                    monAnId = Convert.ToInt32(row["mon_an_id"]);
                }
            }

            if (monAnId == 0)
            {
                MessageBox.Show("Không tìm thấy mã món ăn tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 7. Hiển thị form nhập số lượng
            var form = new Form
            {
                Text = $"Thêm số lượng - {tenMon}",
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
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
                try
                {
                    BanHangService.ThemChiTiet(_hoaDonId.Value, monAnId, soLuong, donGia);
                    NapGioHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            if (!_hoaDonId.HasValue)
            {
                MessageBox.Show("Chưa có hóa đơn để xóa món.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            if (_hoaDonId.HasValue)
                txtGhiChu.Text = BanHangService.LayGhiChuHoaDon(_hoaDonId.Value);
            else
                txtGhiChu.Text = "";
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {

            if (!_hoaDonId.HasValue)
            {
                MessageBox.Show("Chưa có món trong hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
           
                decimal tongTien = BanHangService.LayTongTien(_hoaDonId.Value);

                if (tongTien <= 0)
                {
                    MessageBox.Show("Không thể thanh toán với tổng tiền bằng 0.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

          
                string phuongThucHienThi = cboPhuongThucThanhToan.SelectedItem?.ToString();
                string phuongThuc = "";

                if (string.IsNullOrEmpty(phuongThucHienThi))
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (phuongThucHienThi.Contains("Tiền mặt"))
                    phuongThuc = "tien_mat";
                else if (phuongThucHienThi.Contains("Chuyển khoản"))
                    phuongThuc = "chuyen_khoan";
                else if (phuongThucHienThi.Contains("Ví điện tử"))
                    phuongThuc = "vi_dien_tu";
                else
                    phuongThuc = "tien_mat";

                DialogResult confirm = MessageBox.Show(
                    $"Xác nhận thanh toán {tongTien:N0} VNĐ bằng {phuongThucHienThi}?",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                // Gọi service thanh toán
                BanHangService.ThanhToan(_hoaDonId.Value, phuongThuc);

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

        private void lblDanhMuc_Click(object sender, EventArgs e)
        {

        }
    }
}