using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CafeOrder
{
    public partial class UCQuanTri : UserControl
    {
        private bool _daKhoiTao;
        private DataTable _currentBaoCaoData;

        // Tab Lịch sử ca
        private DataGridView _dgvLichSuCa;
        private DataGridView _dgvHdLichSuCa;
        private DateTimePicker _dtpLsTu;
        private DateTimePicker _dtpLsDen;
        private Label _lblLsChiTiet;

        // Tab Thu chi
        private DataGridView _dgvThuChi;
        private DateTimePicker _dtpTcTu;
        private DateTimePicker _dtpTcDen;
        private Label _lblTcTong;

        private Button _btnHienMon;
        private Button _btnImportMon;
        private Button _btnTaiMauImport;

        public UCQuanTri()
        {
            InitializeComponent();
        }

        public void TaiLai()
        {
            if (!_daKhoiTao)
                return;
            NapComboDanhMuc();
            NapTatCa();
            NapLichSuCa();
            NapThuChi();
        }

        private void UCQuanTri_Load(object sender, EventArgs e)
        {
            UiTheme.StyleDataGridView(dgvMonAn);
            UiTheme.StyleDataGridView(dgvDanhMuc);
            UiTheme.StyleDataGridView(dgvBaoCao);

            UiTheme.StyleFlatButton(btnThemMon, UiTheme.Primary);
            UiTheme.StyleFlatButton(btnSuaMon, UiTheme.Warning);
            UiTheme.StyleFlatButton(btnXoaMon, UiTheme.Danger);
            UiTheme.StyleFlatButton(btnThemDanhMuc, UiTheme.Primary);
            UiTheme.StyleFlatButton(btnSuaDanhMuc, UiTheme.Warning);
            UiTheme.StyleFlatButton(btnXoaDanhMuc, UiTheme.Danger);
            UiTheme.StyleFlatButton(btnXuatExcel, UiTheme.Success);
            UiTheme.StyleFlatButton(btnLocBaoCao, UiTheme.Primary);
            UiTheme.StyleFlatButton(btnExitAdmin, UiTheme.Danger, 34);

            lblTitle.Text = "⚙️ QUẢN TRỊ";
            btnExitAdmin.Text = "← Quay lại bán hàng";
            btnExitAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExitAdmin.BringToFront();

            pnlToolbarMon.BackColor = Color.FromArgb(253, 245, 236);
            pnlToolbarDm.BackColor = Color.FromArgb(253, 245, 236);
            pnlToolbarMon.Padding = new Padding(8, 6, 8, 6);
            pnlToolbarDm.Padding = new Padding(8, 6, 8, 6);

            tabControl1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabMonAn.Text = "☕ Sản phẩm";
            tabDanhMuc.Text = "📂 Danh mục";
            tabPageBaoCao.Text = "📊 Báo cáo";

            KhoiTaoToolbarMonMoRong();

            KhoiTaoTabBoSung();

            NapComboDanhMuc();
            NapTatCa();

            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.AddRange(new object[] {
                "Doanh thu theo ngày",
                "Doanh thu theo tháng",
                "Món ăn bán chạy",
                "Chi tiết hóa đơn",
                "Doanh thu theo PT thanh toán"
            });
            cboLoaiBaoCao.SelectedIndex = 0;

            btnThemMon.Click += BtnThemMon_Click;
            btnSuaMon.Click += BtnSuaMon_Click;
            btnXoaMon.Click += BtnXoaMon_Click;
            btnThemDanhMuc.Click += BtnThemDanhMuc_Click;
            btnSuaDanhMuc.Click += BtnSuaDanhMuc_Click;
            btnXoaDanhMuc.Click += BtnXoaDanhMuc_Click;
            dgvMonAn.SelectionChanged += (s, ev) => ChonMonAn();
            dgvMonAn.CellFormatting += DgvMonAn_CellFormatting;
            dgvDanhMuc.SelectionChanged += (s, ev) => ChonDanhMuc();

            btnLocBaoCao.Click += BtnLocBaoCao_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            cboLoaiBaoCao.SelectedIndexChanged += CboLoaiBaoCao_SelectedIndexChanged;

            TaiBaoCao();
            NapLichSuCa();
            NapThuChi();

            _daKhoiTao = true;
            AppendLog("Module Quản trị — kết nối SQL OK.");
        }

        private void KhoiTaoToolbarMonMoRong()
        {
            pnlToolbarMon.Height = 90;
            btnXoaMon.Text = "🚫 Ẩn đã chọn";
            btnXoaMon.Size = new Size(115, 32);
            btnXoaMon.Location = new Point(632, 8);

            dgvMonAn.MultiSelect = true;
            dgvMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _btnHienMon = new Button
            {
                Text = "✅ Hiện đã chọn",
                Location = new Point(753, 8),
                Size = new Size(115, 32)
            };
            _btnImportMon = new Button
            {
                Text = "📥 Import Excel",
                Location = new Point(8, 52),
                Size = new Size(130, 32)
            };
            _btnTaiMauImport = new Button
            {
                Text = "📄 Tải file mẫu",
                Location = new Point(144, 52),
                Size = new Size(120, 32)
            };
            var lblHuongDan = new Label
            {
                Text = "Giữ Ctrl hoặc Shift để chọn nhiều món cùng lúc",
                Location = new Point(280, 58),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = UiTheme.TextMuted
            };

            UiTheme.StyleFlatButton(_btnHienMon, UiTheme.Success, 32);
            UiTheme.StyleFlatButton(_btnImportMon, UiTheme.Primary, 32);
            UiTheme.StyleFlatButton(_btnTaiMauImport, UiTheme.Warning, 32);

            _btnHienMon.Click += BtnHienMonDaChon_Click;
            _btnImportMon.Click += BtnImportMon_Click;
            _btnTaiMauImport.Click += BtnTaiMauImport_Click;

            pnlToolbarMon.Controls.Add(_btnHienMon);
            pnlToolbarMon.Controls.Add(_btnImportMon);
            pnlToolbarMon.Controls.Add(_btnTaiMauImport);
            pnlToolbarMon.Controls.Add(lblHuongDan);
        }

        private void KhoiTaoTabBoSung()
        {
            KhoiTaoTabLichSuCa();
            KhoiTaoTabThuChi();
        }

        private void KhoiTaoTabLichSuCa()
        {
            var tab = new TabPage { Text = "Lịch sử ca", Padding = new Padding(3) };
            var tlp = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1 };
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            var pnlLoc = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(253, 245, 236) };
            pnlLoc.Controls.Add(new Label { Text = "Từ ngày:", Location = new Point(12, 14), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            _dtpLsTu = new DateTimePicker { Location = new Point(78, 10), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(-30) };
            pnlLoc.Controls.Add(new Label { Text = "Đến ngày:", Location = new Point(210, 14), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            _dtpLsDen = new DateTimePicker { Location = new Point(286, 10), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            var btnTim = new Button { Text = "🔍 Tìm kiếm", Location = new Point(420, 8), Size = new Size(110, 30) };
            UiTheme.StyleFlatButton(btnTim, UiTheme.Primary, 30);
            btnTim.Click += (s, e) => NapLichSuCa();
            pnlLoc.Controls.AddRange(new Control[] { _dtpLsTu, _dtpLsDen, btnTim });

            _dgvLichSuCa = TaoGridCa();
            _dgvLichSuCa.SelectionChanged += DgvLichSuCa_Admin_SelectionChanged;

            var pnlCt = new Panel { Dock = DockStyle.Fill };
            _lblLsChiTiet = new Label
            {
                Dock = DockStyle.Top,
                Height = 26,
                Text = "Chọn ca để xem hóa đơn",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                Padding = new Padding(4, 4, 0, 0)
            };
            _dgvHdLichSuCa = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            _dgvHdLichSuCa.Columns.Add("MaHD", "MÃ HĐ");
            _dgvHdLichSuCa.Columns.Add("Gio", "GIỜ");
            _dgvHdLichSuCa.Columns.Add("TongTien", "TỔNG TIỀN");
            _dgvHdLichSuCa.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            _dgvHdLichSuCa.Columns.Add("HinhThuc", "HÌNH THỨC");
            pnlCt.Controls.Add(_dgvHdLichSuCa);
            pnlCt.Controls.Add(_lblLsChiTiet);

            tlp.Controls.Add(pnlLoc, 0, 0);
            tlp.Controls.Add(_dgvLichSuCa, 0, 1);
            tlp.Controls.Add(pnlCt, 0, 2);
            tab.Controls.Add(tlp);
            tabControl1.TabPages.Add(tab);

            UiTheme.StyleDataGridView(_dgvLichSuCa);
            UiTheme.StyleDataGridView(_dgvHdLichSuCa);
        }

        private static DataGridView TaoGridCa()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgv.Columns.Add("CaId", "ID");
            dgv.Columns["CaId"].Visible = false;
            dgv.Columns.Add("NhanVien", "NHÂN VIÊN");
            dgv.Columns.Add("GioMo", "GIỜ MỞ");
            dgv.Columns.Add("GioDong", "GIỜ ĐÓNG");
            dgv.Columns.Add("TienDauCa", "TIỀN ĐẦU CA");
            dgv.Columns["TienDauCa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns.Add("DoanhThu", "DOANH THU");
            dgv.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns.Add("SoHoaDon", "SỐ HĐ");
            dgv.Columns["SoHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add("TrangThai", "TRẠNG THÁI");
            dgv.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return dgv;
        }

        private void KhoiTaoTabThuChi()
        {
            var tab = new TabPage { Text = "Thu chi", Padding = new Padding(3) };
            var tlp = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1 };
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var pnlLoc = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(253, 245, 236) };
            pnlLoc.Controls.Add(new Label { Text = "Từ ngày:", Location = new Point(12, 14), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            _dtpTcTu = new DateTimePicker { Location = new Point(78, 10), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(-30) };
            pnlLoc.Controls.Add(new Label { Text = "Đến ngày:", Location = new Point(210, 14), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            _dtpTcDen = new DateTimePicker { Location = new Point(286, 10), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            var btnTim = new Button { Text = "🔍 Tìm kiếm", Location = new Point(420, 8), Size = new Size(110, 30) };
            UiTheme.StyleFlatButton(btnTim, UiTheme.Primary, 30);
            btnTim.Click += (s, e) => NapThuChi();
            pnlLoc.Controls.AddRange(new Control[] { _dtpTcTu, _dtpTcDen, btnTim });

            _lblTcTong = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                Padding = new Padding(8, 0, 0, 0)
            };

            _dgvThuChi = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            tlp.Controls.Add(pnlLoc, 0, 0);
            tlp.Controls.Add(_lblTcTong, 0, 1);
            tlp.Controls.Add(_dgvThuChi, 0, 2);
            tab.Controls.Add(tlp);
            tabControl1.TabPages.Add(tab);

            UiTheme.StyleDataGridView(_dgvThuChi);
        }

        #region Báo cáo
        private void CboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiBaoCao();
        }

        private void BtnLocBaoCao_Click(object sender, EventArgs e)
        {
            TaiBaoCao();
        }

        private void TaiBaoCao()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboLoaiBaoCao.SelectedIndex < 0)
                {
                    cboLoaiBaoCao.SelectedIndex = 0;
                    return;
                }

                switch (cboLoaiBaoCao.SelectedIndex)
                {
                    case 0: // Doanh thu theo ngày
                        _currentBaoCaoData = QuanTriService.BaoCaoDoanhThuTheoNgay(tuNgay, denNgay);
                        FormatBaoCaoDoanhThu();
                        break;
                    case 1: // Doanh thu theo tháng
                        _currentBaoCaoData = QuanTriService.BaoCaoDoanhThuTheoThang(dtpTuNgay.Value.Year);
                        FormatBaoCaoDoanhThuTheoThang();
                        break;
                    case 2: // Món ăn bán chạy
                        _currentBaoCaoData = QuanTriService.BaoCaoMonAnBanChay(tuNgay, denNgay, 20);
                        FormatBaoCaoMonAnBanChay();
                        break;
                    case 3: // Chi tiết hóa đơn
                        _currentBaoCaoData = QuanTriService.BaoCaoChiTietHoaDon(tuNgay, denNgay);
                        FormatBaoCaoChiTiet();
                        break;
                    case 4: // Doanh thu theo PT thanh toán
                        _currentBaoCaoData = QuanTriService.BaoCaoDoanhThuTheoPhuongThuc(tuNgay, denNgay);
                        FormatBaoCaoPhuongThuc();
                        break;
                    default:
                        _currentBaoCaoData = new DataTable();
                        break;
                }

                if (_currentBaoCaoData != null && _currentBaoCaoData.Rows.Count > 0)
                {
                    dgvBaoCao.DataSource = _currentBaoCaoData;
                    decimal tongDoanhThu = QuanTriService.TongDoanhThu(tuNgay, denNgay);
                    lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";
                    lblTongDoanhThu.ForeColor = Color.Red;
                    lblTongDoanhThu.Visible = true;
                    AppendLog($"Đã tải báo cáo: {cboLoaiBaoCao.Text} - {_currentBaoCaoData.Rows.Count} dòng");
                }
                else
                {
                    dgvBaoCao.DataSource = null;
                    lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
                    AppendLog($"Không có dữ liệu cho báo cáo: {cboLoaiBaoCao.Text}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog($"Lỗi tải báo cáo: {ex.Message}");
                dgvBaoCao.DataSource = null;
            }
        }

        private void FormatBaoCaoDoanhThu()
        {
            if (_currentBaoCaoData == null) return;
            if (_currentBaoCaoData.Columns.Contains("Ngay"))
                _currentBaoCaoData.Columns["Ngay"].ColumnName = "Ngày";
            if (_currentBaoCaoData.Columns.Contains("SoHoaDon"))
                _currentBaoCaoData.Columns["SoHoaDon"].ColumnName = "Số Hóa Đơn";
            if (_currentBaoCaoData.Columns.Contains("DoanhThu"))
                _currentBaoCaoData.Columns["DoanhThu"].ColumnName = "Doanh Thu (VNĐ)";
        }

        private void FormatBaoCaoDoanhThuTheoThang()
        {
            if (_currentBaoCaoData == null) return;
            if (_currentBaoCaoData.Columns.Contains("Thang"))
                _currentBaoCaoData.Columns["Thang"].ColumnName = "Tháng";
            if (_currentBaoCaoData.Columns.Contains("SoHoaDon"))
                _currentBaoCaoData.Columns["SoHoaDon"].ColumnName = "Số Hóa Đơn";
            if (_currentBaoCaoData.Columns.Contains("DoanhThu"))
                _currentBaoCaoData.Columns["DoanhThu"].ColumnName = "Doanh Thu (VNĐ)";
        }

        private void FormatBaoCaoMonAnBanChay()
        {
            if (_currentBaoCaoData == null) return;
            if (_currentBaoCaoData.Columns.Contains("ten_mon"))
                _currentBaoCaoData.Columns["ten_mon"].ColumnName = "Tên Món";
            if (_currentBaoCaoData.Columns.Contains("SoLuongBan"))
                _currentBaoCaoData.Columns["SoLuongBan"].ColumnName = "Số Lượng Bán";
            if (_currentBaoCaoData.Columns.Contains("DoanhThu"))
                _currentBaoCaoData.Columns["DoanhThu"].ColumnName = "Doanh Thu (VNĐ)";
            if (_currentBaoCaoData.Columns.Contains("XepHang"))
                _currentBaoCaoData.Columns["XepHang"].ColumnName = "Xếp Hạng";
        }

        private void FormatBaoCaoChiTiet()
        {
            if (_currentBaoCaoData == null) return;
            if (_currentBaoCaoData.Columns.Contains("MaHoaDon"))
                _currentBaoCaoData.Columns["MaHoaDon"].ColumnName = "Mã HĐ";
            if (_currentBaoCaoData.Columns.Contains("NgayLap"))
                _currentBaoCaoData.Columns["NgayLap"].ColumnName = "Ngày Lập";
            if (_currentBaoCaoData.Columns.Contains("TongTien"))
                _currentBaoCaoData.Columns["TongTien"].ColumnName = "Tổng Tiền (VNĐ)";
            if (_currentBaoCaoData.Columns.Contains("Ban"))
                _currentBaoCaoData.Columns["Ban"].ColumnName = "Ca ID";
        }

        private void FormatBaoCaoPhuongThuc()
        {
            if (_currentBaoCaoData == null) return;
            if (_currentBaoCaoData.Columns.Contains("PhuongThuc"))
                _currentBaoCaoData.Columns["PhuongThuc"].ColumnName = "Phương thức";
            if (_currentBaoCaoData.Columns.Contains("SoHoaDon"))
                _currentBaoCaoData.Columns["SoHoaDon"].ColumnName = "Số Hóa Đơn";
            if (_currentBaoCaoData.Columns.Contains("DoanhThu"))
                _currentBaoCaoData.Columns["DoanhThu"].ColumnName = "Doanh Thu (VNĐ)";
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_currentBaoCaoData == null || _currentBaoCaoData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv|Excel Files|*.xlsx";
            sfd.FileName = $"BaoCao_{cboLoaiBaoCao.Text}_{DateTime.Now:yyyyMMdd_HHmmss}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(_currentBaoCaoData, sfd.FileName);
                    MessageBox.Show($"Xuất file thành công!\nĐã lưu tại: {sfd.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppendLog($"Xuất báo cáo: {sfd.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppendLog($"Lỗi xuất file: {ex.Message}");
                }
            }
        }

        private void ExportToExcel(DataTable dt, string filePath)
        {
            string csvContent = "";

            // Thêm header
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                csvContent += dt.Columns[i].ColumnName;
                if (i < dt.Columns.Count - 1) csvContent += ",";
            }
            csvContent += Environment.NewLine;

            // Thêm dữ liệu
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string value = dt.Rows[i][j]?.ToString().Replace(",", ";");
                    csvContent += value;
                    if (j < dt.Columns.Count - 1) csvContent += ",";
                }
                csvContent += Environment.NewLine;
            }

            // Ghi file - Đã sửa
            string outputPath = filePath;
            if (!outputPath.EndsWith(".csv"))
                outputPath = Path.ChangeExtension(filePath, ".csv");

            File.WriteAllText(outputPath, csvContent, System.Text.Encoding.UTF8);
        }
        #endregion

        #region Lịch sử ca
        private void NapLichSuCa()
        {
            if (_dgvLichSuCa == null) return;
            try
            {
                var tu = _dtpLsTu.Value.Date;
                var den = _dtpLsDen.Value.Date;
                if (tu > den)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dt = CaService.LayLichSuCa(tu, den, null);
                _dgvLichSuCa.Rows.Clear();
                _dgvHdLichSuCa.Rows.Clear();
                _lblLsChiTiet.Text = dt.Rows.Count > 0
                    ? $"Tìm thấy {dt.Rows.Count} ca — chọn để xem hóa đơn"
                    : "Không có ca trong khoảng thời gian đã chọn";

                foreach (DataRow row in dt.Rows)
                {
                    _dgvLichSuCa.Rows.Add(
                        row["CaId"],
                        row["NhanVien"],
                        Convert.ToDateTime(row["GioMo"]).ToString("HH:mm dd/MM/yyyy"),
                        row["GioDong"] == DBNull.Value ? "—" : Convert.ToDateTime(row["GioDong"]).ToString("HH:mm dd/MM/yyyy"),
                        Convert.ToDecimal(row["TienDauCa"]).ToString("N0") + " đ",
                        Convert.ToDecimal(row["DoanhThu"]).ToString("N0") + " đ",
                        row["SoHoaDon"],
                        CaService.HienThiTrangThaiCa(row["TrangThai"].ToString()));
                }

                if (_dgvLichSuCa.Rows.Count > 0)
                {
                    _dgvLichSuCa.Rows[0].Selected = true;
                    DgvLichSuCa_Admin_SelectionChanged(_dgvLichSuCa, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử ca: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLichSuCa_Admin_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvLichSuCa?.SelectedRows.Count == 0) return;
            var row = _dgvLichSuCa.SelectedRows[0];
            if (row.Cells["CaId"].Value == null || row.Cells["CaId"].Value == DBNull.Value) return;

            int caId = Convert.ToInt32(row.Cells["CaId"].Value);
            _lblLsChiTiet.Text = $"Ca #{caId} — {row.Cells["NhanVien"].Value} | Doanh thu: {row.Cells["DoanhThu"].Value}";

            _dgvHdLichSuCa.Rows.Clear();
            var dt = CaService.GetHoaDonTrongCa(caId);
            foreach (DataRow r in dt.Rows)
            {
                _dgvHdLichSuCa.Rows.Add(
                    r["MaHD"],
                    Convert.ToDateTime(r["Gio"]).ToString("HH:mm:ss"),
                    Convert.ToDecimal(r["TongTien"]),
                    CaService.HienThiPhuongThucThanhToan(r["HinhThuc"].ToString()));
            }
        }
        #endregion

        #region Thu chi
        private void NapThuChi()
        {
            if (_dgvThuChi == null) return;
            try
            {
                var tu = _dtpTcTu.Value.Date;
                var den = _dtpTcDen.Value.Date;
                if (tu > den)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dt = QuanTriService.LoadThuChi(tu, den);
                _dgvThuChi.DataSource = dt;
                AnCotNeuCo(_dgvThuChi, "id");
                if (_dgvThuChi.Columns.Contains("MoTa"))
                    _dgvThuChi.Columns["MoTa"].HeaderText = "Mô tả";
                if (_dgvThuChi.Columns.Contains("SoTien"))
                {
                    _dgvThuChi.Columns["SoTien"].HeaderText = "Số tiền";
                    _dgvThuChi.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                    _dgvThuChi.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (_dgvThuChi.Columns.Contains("NgayTao"))
                {
                    _dgvThuChi.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    _dgvThuChi.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (_dgvThuChi.Columns.Contains("loai"))
                    _dgvThuChi.Columns["loai"].HeaderText = "Loại";

                decimal tongThu = QuanTriService.TongThu(tu, den);
                decimal tongChi = QuanTriService.TongChi(tu, den);
                _lblTcTong.Text = $"Tổng thu: {tongThu:N0} đ  |  Tổng chi: {tongChi:N0} đ  |  Còn lại: {tongThu - tongChi:N0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thu chi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void AnCotNeuCo(DataGridView dgv, params string[] cols)
        {
            foreach (var c in cols)
                if (dgv.Columns.Contains(c))
                    dgv.Columns[c].Visible = false;
        }
        #endregion

        #region Quản lý danh mục và món ăn
        private void NapComboDanhMuc()
        {
            cboDanhMuc.DisplayMember = "ten_danh_muc";
            cboDanhMuc.ValueMember = "id";
            cboDanhMuc.DataSource = QuanTriService.LoadDanhMucCombo();
        }

        private void NapTatCa()
        {
            try
            {
                dgvMonAn.DataSource = QuanTriService.LoadMonAn();
                if (dgvMonAn.Columns.Contains("danh_muc_id"))
                    dgvMonAn.Columns["danh_muc_id"].Visible = false;
                if (dgvMonAn.Columns.Contains("kha_dung"))
                    dgvMonAn.Columns["kha_dung"].Visible = false;
                if (dgvMonAn.Columns.Contains("id"))
                    dgvMonAn.Columns["id"].Visible = false;
                if (dgvMonAn.Columns.Contains("ten_mon"))
                    dgvMonAn.Columns["ten_mon"].HeaderText = "Tên món";
                if (dgvMonAn.Columns.Contains("gia"))
                {
                    dgvMonAn.Columns["gia"].HeaderText = "Giá";
                    dgvMonAn.Columns["gia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvMonAn.Columns.Contains("DanhMuc"))
                    dgvMonAn.Columns["DanhMuc"].HeaderText = "Danh mục";
                if (dgvMonAn.Columns.Contains("MaMon"))
                    dgvMonAn.Columns["MaMon"].HeaderText = "Mã món";
                if (dgvMonAn.Columns.Contains("TrangThai"))
                    dgvMonAn.Columns["TrangThai"].HeaderText = "Trạng thái";

                dgvDanhMuc.DataSource = QuanTriService.LoadDanhMuc();
                if (dgvDanhMuc.Columns.Contains("id"))
                    dgvDanhMuc.Columns["id"].Visible = false;
                if (dgvDanhMuc.Columns.Contains("thu_tu"))
                    dgvDanhMuc.Columns["thu_tu"].Visible = false;
                if (dgvDanhMuc.Columns.Contains("hien_thi"))
                    dgvDanhMuc.Columns["hien_thi"].Visible = false;
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi: " + ex.Message);
            }
        }

        private void ChonMonAn()
        {
            if (dgvMonAn.CurrentRow == null || dgvMonAn.CurrentRow.IsNewRow)
                return;

            txtTenMon.Text = dgvMonAn.CurrentRow.Cells["ten_mon"].Value?.ToString();
            txtGia.Text = dgvMonAn.CurrentRow.Cells["gia"].Value?.ToString();

            if (!dgvMonAn.Columns.Contains("danh_muc_id"))
                return;

            var dmId = dgvMonAn.CurrentRow.Cells["danh_muc_id"].Value;
            if (dmId == null || dmId == DBNull.Value)
                return;

            try
            {
                cboDanhMuc.SelectedValue = Convert.ToInt32(dmId);
            }
            catch { }
        }

        private void DgvMonAn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvMonAn.Columns.Contains("kha_dung"))
                return;

            var row = dgvMonAn.Rows[e.RowIndex];
            var val = row.Cells["kha_dung"].Value;
            if (val == null || val == DBNull.Value || Convert.ToBoolean(val))
                return;

            e.CellStyle.ForeColor = Color.Gray;
        }

        private void ChonDanhMuc()
        {
            if (dgvDanhMuc.CurrentRow == null) return;
            txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["ten_danh_muc"].Value?.ToString();
        }

        private List<int> LayIdMonDuocChon()
        {
            var ids = new List<int>();
            if (!dgvMonAn.Columns.Contains("id"))
                return ids;

            foreach (DataGridViewRow row in dgvMonAn.SelectedRows)
            {
                if (row.IsNewRow)
                    continue;
                var val = row.Cells["id"].Value;
                if (val != null && val != DBNull.Value)
                    ids.Add(Convert.ToInt32(val));
            }
            return ids;
        }

        private int? GetId(DataGridView dgv)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.IsNewRow)
                return null;
            if (!dgv.Columns.Contains("id"))
                return null;
            var val = dgv.CurrentRow.Cells["id"].Value;
            if (val == null || val == DBNull.Value)
                return null;
            return Convert.ToInt32(val);
        }

        private void BtnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtGia.Text, out decimal gia)) { ThongBaoGia(); return; }
            if (cboDanhMuc.SelectedValue == null) { MessageBox.Show("Vui lòng chọn danh mục!"); return; }
            try
            {
                QuanTriService.ThemMon((int)cboDanhMuc.SelectedValue, txtTenMon.Text.Trim(), gia);
                NapTatCa();
                AppendLog("Thêm món: " + txtTenMon.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSuaMon_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvMonAn);
            if (!id.HasValue) { MessageBox.Show("Vui lòng chọn món cần sửa!"); return; }
            if (!decimal.TryParse(txtGia.Text, out decimal gia)) { ThongBaoGia(); return; }
            try
            {
                QuanTriService.SuaMon(id.Value, (int)cboDanhMuc.SelectedValue, txtTenMon.Text.Trim(), gia);
                NapTatCa();
                AppendLog("Sửa món id=" + id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnXoaMon_Click(object sender, EventArgs e)
        {
            AnHienMonDaChon(false);
        }

        private void BtnHienMonDaChon_Click(object sender, EventArgs e)
        {
            AnHienMonDaChon(true);
        }

        private void AnHienMonDaChon(bool hienLai)
        {
            var ids = LayIdMonDuocChon();
            if (ids.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món trong bảng.\nDùng Ctrl hoặc Shift để chọn nhiều dòng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string hanhDong = hienLai ? "hiện lại" : "ẩn";
            if (MessageBox.Show(
                $"{(hienLai ? "Hiện" : "Ẩn")} {ids.Count} món đã chọn khỏi menu bán hàng?",
                $"Xác nhận {hanhDong} món",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                QuanTriService.DatTrangThaiMonHangLoat(ids, hienLai);
                NapTatCa();
                AppendLog($"{(hienLai ? "Hiện" : "Ẩn")} {ids.Count} món: id={string.Join(",", ids)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImportMon_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file Excel / CSV để import món";
                ofd.Filter = "Excel / CSV (*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv|Tất cả (*.*)|*.*";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    var dong = MonAnImportHelper.DocFile(ofd.FileName);
                    if (dong.Count == 0)
                    {
                        MessageBox.Show("File không có dữ liệu món để import.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show(
                        $"Tìm thấy {dong.Count} dòng món.\nTiếp tục import vào hệ thống?",
                        "Xác nhận import",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    var ketQua = QuanTriService.ImportMonTuFile(dong);
                    NapTatCa();
                    NapComboDanhMuc();

                    var sb = new StringBuilder();
                    sb.AppendLine("Import hoàn tất!");
                    sb.AppendLine($"• Thành công: {ketQua.ThanhCong}");
                    sb.AppendLine($"• Bỏ qua: {ketQua.BoQua}");
                    if (ketQua.Loi.Count > 0)
                    {
                        sb.AppendLine();
                        sb.AppendLine("Chi tiết lỗi:");
                        int max = Math.Min(ketQua.Loi.Count, 8);
                        for (int i = 0; i < max; i++)
                            sb.AppendLine("  - " + ketQua.Loi[i]);
                        if (ketQua.Loi.Count > max)
                            sb.AppendLine($"  ... và {ketQua.Loi.Count - max} lỗi khác");
                    }

                    MessageBox.Show(sb.ToString(), "Kết quả import",
                        MessageBoxButtons.OK,
                        ketQua.ThanhCong > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    AppendLog($"Import món: OK={ketQua.ThanhCong}, bỏ qua={ketQua.BoQua}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppendLog("Lỗi import: " + ex.Message);
                }
            }
        }

        private void BtnTaiMauImport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu file mẫu import món";
                sfd.Filter = "CSV Excel (*.csv)|*.csv";
                sfd.FileName = "MauImportMon.csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    MonAnImportHelper.GhiFileMau(sfd.FileName);
                    MessageBox.Show(
                        "Đã tạo file mẫu.\n\nMở bằng Excel, điền cột: Tên món, Giá, Danh mục\n(Danh mục phải trùng tên trong hệ thống)",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không lưu được file mẫu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnThemDanhMuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                QuanTriService.ThemDanhMuc(txtTenDanhMuc.Text.Trim());
                NapTatCa();
                NapComboDanhMuc();
                txtTenDanhMuc.Clear();
                AppendLog("Thêm danh mục.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvDanhMuc);
            if (!id.HasValue) { MessageBox.Show("Vui lòng chọn danh mục cần sửa!"); return; }
            try
            {
                QuanTriService.SuaDanhMuc(id.Value, txtTenDanhMuc.Text.Trim());
                NapTatCa();
                NapComboDanhMuc();
                AppendLog("Sửa danh mục id=" + id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvDanhMuc);
            if (!id.HasValue) { MessageBox.Show("Vui lòng chọn danh mục cần xóa!"); return; }
            if (MessageBox.Show("Xóa danh mục? (Món thuộc danh mục cũng bị ảnh hưởng)", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                QuanTriService.XoaDanhMuc(id.Value);
                NapTatCa();
                NapComboDanhMuc();
                AppendLog("Xóa danh mục id=" + id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion

        private static void ThongBaoGia()
        {
            MessageBox.Show("Giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AppendLog(string message)
        {
            if (txtLog != null)
                txtLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine);
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNavSanPham_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAminCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnExitAdmin_Click(object sender, EventArgs e)
        {
            if (AppSession.IsImpersonatedAdmin)
                AppSession.IsImpersonatedAdmin = false;

            Form parent = this.FindForm();
            if (parent is MPI mainForm)
            {
                mainForm.CapNhatThongTinNguoiDung();
                mainForm.SwitchToBanHang();
            }
        }

        private void btnNavBaocao_Click(object sender, EventArgs e)
        {

        }
    }
}
