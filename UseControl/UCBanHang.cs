using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCBanHang : UserControl
    {
        private const int TheMargin = 10;
        private const int ChieuCaoThe = 150;
        private const int ChieuCaoTheCoDanhMuc = 168;

        private Button _categorySelected;
        private int? _hoaDonId;
        private bool _daKhoiTao;
        private int? _danhMucDangChon;
        private bool _dangTimKiem;
        private TableLayoutPanel _sanPhamGrid;

        public UCBanHang()
        {
            InitializeComponent();
            pnlDanhMucList.AutoScroll = true;
            pnlSanPham.Resize += (s, e) => CapNhatKichThuocTheSanPham();
            flowSanPham.Resize += (s, e) => CapNhatKichThuocTheSanPham();
            pnlTimKiem.Resize += (s, e) => CanThanhTimKiem();
            pnlFooter.Resize += (s, e) => ThietLapFooterHoaDon();
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
            dgvGioHang.Columns.Add("DonGia", "Đơn giá");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");
            dgvGioHang.Columns["TenMon"].FillWeight = 130;
            dgvGioHang.Columns["SoLuong"].FillWeight = 45;
            dgvGioHang.Columns["DonGia"].FillWeight = 70;
            dgvGioHang.Columns["ThanhTien"].FillWeight = 80;
            dgvGioHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

            txtGhiChu.Leave += (s, ev) =>
            {
                if (_hoaDonId.HasValue)
                {
                    string ghichu = txtGhiChu.Text.Trim();
                    BanHangService.CapNhatGhiChuHoaDon(_hoaDonId.Value, ghichu);
                }
            };

            ThietLapGiaoDien();
        }

        private void ThietLapGiaoDien()
        {
            ThietLapBoCucLuoiBanHang();
            pnlBody.BackColor = UiTheme.Background;
            pnlDonHang.BackColor = Color.White;
            pnlDonHang.MinimumSize = new Size(340, 0);
            pnlFooter.BackColor = Color.White;
            lblDonHang.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDonHang.ForeColor = UiTheme.PrimaryDark;
            lblDonHang.Text = "HOA DON";
            lblDonHang.Height = 46;

            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.BackColor = Color.White;
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.Font = UiTheme.FontBody;
            cboPhuongThucThanhToan.FlatStyle = FlatStyle.Flat;
            btnHuyHoaDon.Text = "HỦY";
            btnThemMon.Text = "THÊM";
            btnXoaMon.Text = "XÓA";
            btnThanhToan.Text = "THANH TOÁN";

            ThietLapFooterHoaDon();
            pnlTimKiem.BringToFront();
            pnlDonHang.BringToFront();
        }

        private void ThietLapBoCucLuoiBanHang()
        {
            pnlBody.SuspendLayout();

            if (!(pnlBody.Controls.Count == 1 && pnlBody.Controls[0] is TableLayoutPanel))
            {
                pnlBody.Controls.Clear();
                pnlBody.Padding = new Padding(16);

                var grid = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    RowCount = 1,
                    BackColor = UiTheme.Background
                };
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                grid.Controls.Add(pnlSidebar, 0, 0);
                grid.Controls.Add(pnlSanPham, 1, 0);
                grid.Controls.Add(pnlDonHang, 2, 0);
                pnlBody.Controls.Add(grid);
            }

            pnlSidebar.Dock = DockStyle.Fill;
            pnlSidebar.Margin = new Padding(0, 0, 14, 0);
            pnlSidebar.Padding = new Padding(0);
            pnlSidebar.BackColor = Color.White;
            pnlDanhMucList.BackColor = Color.White;
            lblDanhMuc.Text = "DANH MUC";
            lblDanhMuc.ForeColor = UiTheme.PrimaryDark;
            lblDanhMuc.BackColor = Color.White;
            lblDanhMuc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDanhMuc.Padding = new Padding(14, 0, 0, 0);

            pnlSanPham.Dock = DockStyle.Fill;
            pnlSanPham.Margin = new Padding(0, 0, 14, 0);
            pnlSanPham.Padding = new Padding(0);
            pnlSanPham.BackColor = UiTheme.Background;

            ThietLapKhungSanPham();

            pnlTimKiem.Height = 58;
            pnlTimKiem.Padding = new Padding(12);
            pnlTimKiem.BackColor = Color.White;
            lblTimKiem.Text = "TIM MON";
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoaTimKiem.Text = "XOA";
            CanThanhTimKiem();

            flowSanPham.Padding = new Padding(10);
            flowSanPham.BackColor = UiTheme.Background;

            pnlDonHang.Dock = DockStyle.Fill;
            pnlDonHang.Margin = new Padding(0);
            pnlDonHang.Padding = new Padding(14);
            pnlFooter.Height = 290;
            dgvGioHang.BackgroundColor = Color.White;
            dgvGioHang.RowTemplate.Height = 34;

            pnlBody.ResumeLayout();
        }

        private void ThietLapKhungSanPham()
        {
            if (_sanPhamGrid == null)
            {
                pnlSanPham.Controls.Remove(pnlTimKiem);
                pnlSanPham.Controls.Remove(flowSanPham);

                _sanPhamGrid = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 2,
                    BackColor = UiTheme.Background,
                    Margin = Padding.Empty,
                    Padding = Padding.Empty
                };
                _sanPhamGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                _sanPhamGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
                _sanPhamGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                pnlTimKiem.Dock = DockStyle.Fill;
                pnlTimKiem.Margin = new Padding(0, 0, 0, 10);
                flowSanPham.Dock = DockStyle.Fill;
                flowSanPham.Margin = Padding.Empty;

                _sanPhamGrid.Controls.Add(pnlTimKiem, 0, 0);
                _sanPhamGrid.Controls.Add(flowSanPham, 0, 1);
                pnlSanPham.Controls.Add(_sanPhamGrid);
            }

            _sanPhamGrid.RowStyles[0].Height = 68F;
        }

        private void CanThanhTimKiem()
        {
            if (pnlTimKiem == null || txtTimKiem == null || btnXoaTimKiem == null)
                return;

            int rightButtonX = Math.Max(220, pnlTimKiem.ClientSize.Width - 88);
            lblTimKiem.SetBounds(12, 12, 82, 32);
            txtTimKiem.SetBounds(98, 13, Math.Max(120, rightButtonX - 106), 30);
            btnXoaTimKiem.SetBounds(rightButtonX, 12, 76, 32);
        }

        private void ThietLapFooterHoaDon()
        {
            if (lblPhuongThucThanhToan.Parent != pnlFooter)
            {
                pnlThanhToan.Controls.Remove(lblPhuongThucThanhToan);
                pnlThanhToan.Controls.Remove(cboPhuongThucThanhToan);
                pnlFooter.Controls.Add(lblPhuongThucThanhToan);
                pnlFooter.Controls.Add(cboPhuongThucThanhToan);
            }
            pnlThanhToan.Visible = false;

            pnlFooter.Padding = new Padding(14);
            int w = pnlFooter.ClientSize.Width - pnlFooter.Padding.Horizontal;
            if (w <= 0)
                return;

            int x = pnlFooter.Padding.Left;
            int y = pnlFooter.Padding.Top;

            label1.SetBounds(x, y, w, 20);
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtGhiChu.SetBounds(x, y + 22, w, 26);

            y += 56;
            lblTongTien.SetBounds(x, y, w, 20);
            lblTongTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtTongTien.SetBounds(x, y + 22, w, 34);
            txtTongTien.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtTongTien.BackColor = Color.White;

            y += 66;
            int btnW = (w - 8) / 3;
            btnHuyHoaDon.SetBounds(x, y, btnW, 34);
            btnThemMon.SetBounds(x + btnW + 4, y, btnW, 34);
            btnXoaMon.SetBounds(x + (btnW + 4) * 2, y, btnW, 34);
            lblSoLuong.Visible = false;
            nudSoLuong.Visible = false;

            y += 44;
            lblPhuongThucThanhToan.SetBounds(x, y, w, 18);
            lblPhuongThucThanhToan.Font = new Font("Segoe UI", 8.5F);
            y += 20;
            cboPhuongThucThanhToan.SetBounds(x, y, w, 28);

            y += 36;
            btnThanhToan.SetBounds(x, y, w, 46);
            btnThanhToan.Text = "THANH TOÁN";

            lblPhuongThucThanhToan.BringToFront();
            cboPhuongThucThanhToan.BringToFront();
            btnThanhToan.BringToFront();
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
                pnlDanhMucList.SuspendLayout();
                pnlDanhMucList.Controls.Clear();
                _categorySelected = null;

                DataTable dt = BanHangService.GetDanhMuc();
                if (dt.Rows.Count == 0)
                {
                    pnlDanhMucList.ResumeLayout();
                    return;
                }

                Button firstButton = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    int id = Convert.ToInt32(row["id"]);
                    string ten = row["ten_danh_muc"].ToString();

                    var btn = new Button
                    {
                        Text = ten,
                        Tag = id
                    };
                    UiTheme.StyleSidebarButton(btn, false);
                    btn.Click += DanhMuc_Click;
                    pnlDanhMucList.Controls.Add(btn);

                    if (i == 0)
                        firstButton = btn;
                }

                pnlDanhMucList.ResumeLayout();

                if (firstButton != null)
                    BeginInvoke(new Action(() => firstButton.PerformClick()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private static string LayIconDanhMuc(string tenDanhMuc)
        {
            string ten = (tenDanhMuc ?? "").ToLowerInvariant();
            if (ten.Contains("cà phê") || ten.Contains("ca phe") || ten.Contains("coffee"))
                return "☕";
            if (ten.Contains("trà") || ten.Contains("tra") || ten.Contains("tea"))
                return "🍵";
            if (ten.Contains("sinh tố") || ten.Contains("sinh to") || ten.Contains("nước"))
                return "🥤";
            if (ten.Contains("bánh") || ten.Contains("banh"))
                return "🥐";
            return "•";
        }

        private void DanhMuc_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (_categorySelected != null)
                UiTheme.StyleSidebarButton(_categorySelected, false);
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
            CapNhatKichThuocTheSanPham();
        }

        private Size TinhKichThuocThe(bool hienDanhMuc)
        {
            int available = flowSanPham.ClientSize.Width - flowSanPham.Padding.Horizontal - 20;
            int columns = Math.Max(2, Math.Min(5, available / 180));
            int marginTong = columns * TheMargin * 2;
            int cardW = Math.Max(150, (available - marginTong) / columns);
            int cardH = hienDanhMuc ? ChieuCaoTheCoDanhMuc : ChieuCaoThe;
            return new Size(cardW, cardH);
        }

        private void CapNhatKichThuocTheSanPham()
        {
            if (flowSanPham.Controls.Count == 0)
                return;

            bool hienDanhMuc = flowSanPham.Controls[0] is Panel p && p.Controls.Count > 3;
            var size = TinhKichThuocThe(hienDanhMuc);

            flowSanPham.SuspendLayout();
            foreach (Control c in flowSanPham.Controls)
            {
                if (c is Panel card)
                {
                    card.Size = size;
                    card.Margin = new Padding(TheMargin);
                    bool coDanhMuc = card.Controls.Count > 3;
                    DieuChinhNoiDungThe(card, size, coDanhMuc);
                }
            }
            flowSanPham.ResumeLayout();
        }

        private static void DieuChinhNoiDungThe(Panel card, Size size, bool coDanhMuc)
        {
            const int pad = 6;
            int contentW = size.Width - pad * 2;
            int picH = coDanhMuc ? 58 : 64;
            int nameTop = pad + picH + (coDanhMuc ? 22 : 8);
            int nameH = size.Height - nameTop - 34;

            foreach (Control c in card.Controls)
            {
                if (c.Name == "picThumb")
                {
                    c.Size = new Size(contentW, picH);
                    c.Location = new Point(pad, pad);
                }
                else if (c.Name == "lblDanhMuc")
                {
                    c.Location = new Point(pad, pad + picH);
                    c.Size = new Size(contentW, 16);
                }
                else if (c.Name == "lblName")
                {
                    c.Location = new Point(pad, nameTop);
                    c.Size = new Size(contentW, Math.Max(28, nameH));
                }
                else if (c.Name == "lblPrice")
                {
                    c.Location = new Point(pad, size.Height - pad - 28);
                    c.Size = new Size(contentW, 28);
                }
            }
        }

        private static string LayIconMon(string tenMon)
        {
            string ten = (tenMon ?? "").ToLowerInvariant();
            if (ten.Contains("cà phê") || ten.Contains("ca phe") || ten.Contains("coffee") || ten.Contains("cappuccino") || ten.Contains("latte") || ten.Contains("espresso"))
                return "☕";
            if (ten.Contains("trà") || ten.Contains("tra") || ten.Contains("tea"))
                return "🍵";
            if (ten.Contains("sinh tố") || ten.Contains("sinh to") || ten.Contains("nước") || ten.Contains("nuoc"))
                return "🥤";
            if (ten.Contains("bánh") || ten.Contains("banh") || ten.Contains("croissant"))
                return "🥐";
            if (ten.Contains("sữa") || ten.Contains("sua"))
                return "🥛";
            return "🍽";
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
            bool coDanhMuc = danhMuc != null;
            var size = TinhKichThuocThe(coDanhMuc);

            var card = new Panel
            {
                Size = size,
                BackColor = Color.White,
                Margin = new Padding(TheMargin),
                Cursor = Cursors.Hand,
                Tag = monAnId
            };
            UiTheme.ApplyRoundedCard(card);

            int pad = 6;
            int contentW = size.Width - pad * 2;
            int picH = coDanhMuc ? 58 : 64;

            var pic = new Panel
            {
                Name = "picThumb",
                Size = new Size(contentW, picH),
                Location = new Point(pad, pad),
                BackColor = Color.FromArgb(245, 237, 228)
            };
            var lblIcon = new Label
            {
                Text = LayIconMon(name),
                Font = new Font("Segoe UI Emoji", 26F),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
            pic.Controls.Add(lblIcon);

            int nameTop = pad + picH + (coDanhMuc ? 22 : 8);
            int nameH = size.Height - nameTop - 34;

            if (coDanhMuc)
            {
                var lblDanhMuc = new Label
                {
                    Name = "lblDanhMuc",
                    Text = danhMuc,
                    Font = new Font("Segoe UI", 7.5F),
                    ForeColor = UiTheme.TextMuted,
                    Location = new Point(pad, pad + picH),
                    Size = new Size(contentW, 16),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };
                card.Controls.Add(lblDanhMuc);
            }

            var lblName = new Label
            {
                Name = "lblName",
                Text = name,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = UiTheme.TextDark,
                Location = new Point(pad, nameTop),
                Size = new Size(contentW, Math.Max(28, nameH)),
                TextAlign = ContentAlignment.TopCenter,
                Cursor = Cursors.Hand
            };
            var lblPrice = new Label
            {
                Name = "lblPrice",
                Text = price.ToString("N0") + " đ",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                Location = new Point(pad, size.Height - pad - 28),
                Size = new Size(contentW, 28),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);

            Color hoverBg = Color.FromArgb(255, 251, 245);
            card.MouseEnter += (s, ev) => { card.BackColor = hoverBg; card.Invalidate(); };
            card.MouseLeave += (s, ev) => { card.BackColor = Color.White; card.Invalidate(); };
            pic.MouseEnter += (s, ev) => { card.BackColor = hoverBg; card.Invalidate(); };
            pic.MouseLeave += (s, ev) => { card.BackColor = Color.White; card.Invalidate(); };

            EventHandler click = (s, ev) => ThemVaoGio(monAnId, price);
            card.Click += click;
            foreach (Control c in card.Controls)
            {
                c.Click += click;
                if (c is Panel pnl)
                {
                    foreach (Control sub in pnl.Controls)
                        sub.Click += click;
                }
            }

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

            try
            {
                BanHangService.ThemChiTiet(_hoaDonId.Value, monAnId, 1, price);
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

        private void pnlSanPham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowSanPham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowSanPham_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void lblTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
