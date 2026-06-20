using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCDongca : UserControl
    {
        private bool _daKhoiTao;

        private TabControl _tabCa;
        private DataGridView _dgvLichSuCa;
        private DataGridView _dgvHoaDonLichSu;
        private DateTimePicker _dtpLichSuTu;
        private DateTimePicker _dtpLichSuDen;
        private Button _btnTimLichSuCa;
        private Button _btnXuatLichSuCa;
        private Label _lblLichSuChiTiet;
        private int? _caLichSuId;

        public UCDongca()
        {
            InitializeComponent();
        }

        public void TaiLaiDuLieu()
        {
            if (!_daKhoiTao)
                return;
            NapDuLieu();
            if (_tabCa?.SelectedIndex == 1)
                NapLichSuCa();
        }

        private void UCDongca_Load(object sender, EventArgs e)
        {
            KhoiTaoTabLichSu();

            UiTheme.StyleDataGridView(dgvHoaDonTrongCa);
            UiTheme.StyleDataGridView(_dgvLichSuCa);
            UiTheme.StyleDataGridView(_dgvHoaDonLichSu);

            UiTheme.StyleFlatButton(btnMoCa, UiTheme.Success, 45);
            UiTheme.StyleFlatButton(btnDongCa, UiTheme.Danger, 45);
            UiTheme.StyleFlatButton(btnInBaoCao, UiTheme.PrimaryDark, 35);
            UiTheme.StyleFlatButton(_btnTimLichSuCa, UiTheme.Primary, 32);
            UiTheme.StyleFlatButton(_btnXuatLichSuCa, UiTheme.PrimaryDark, 32);

            SetupDataGridViewColumns();
            SetupLichSuCaColumns();
            SetupHoaDonLichSuColumns();

            RegisterEventHandlers();

            _daKhoiTao = true;
            NapDuLieu();
        }

        private void KhoiTaoTabLichSu()
        {
            _tabCa = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            var tabHienTai = new TabPage { Text = "Ca hiện tại", Padding = new Padding(3) };
            var tabLichSu = new TabPage { Text = "Lịch sử ca", Padding = new Padding(3) };

            Controls.Remove(tlpMain);
            tabHienTai.Controls.Add(tlpMain);
            tlpMain.Dock = DockStyle.Fill;

            var tlpLichSu = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(8, 6, 8, 6)
            };
            tlpLichSu.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpLichSu.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            tlpLichSu.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            var pnlLoc = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(253, 245, 236) };
            var lblTu = new Label
            {
                Text = "Từ ngày:",
                Location = new Point(12, 12),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            _dtpLichSuTu = new DateTimePicker
            {
                Location = new Point(88, 8),
                Width = 130,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddDays(-30)
            };
            var lblDen = new Label
            {
                Text = "Đến ngày:",
                Location = new Point(240, 12),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            _dtpLichSuDen = new DateTimePicker
            {
                Location = new Point(322, 8),
                Width = 130,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };
            _btnTimLichSuCa = new Button
            {
                Text = "🔍 Tìm kiếm",
                Location = new Point(470, 6),
                Width = 120,
                Height = 32
            };
            _btnXuatLichSuCa = new Button
            {
                Text = "🖨️ Xuất báo cáo",
                Location = new Point(600, 6),
                Width = 130,
                Height = 32,
                Enabled = false
            };
            pnlLoc.Controls.AddRange(new Control[] { lblTu, _dtpLichSuTu, lblDen, _dtpLichSuDen, _btnTimLichSuCa, _btnXuatLichSuCa });

            _dgvLichSuCa = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(253, 245, 236)
            };

            var pnlChiTiet = new Panel { Dock = DockStyle.Fill };
            _lblLichSuChiTiet = new Label
            {
                Dock = DockStyle.Top,
                Height = 28,
                Text = "Chọn một ca để xem hóa đơn",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                Padding = new Padding(4, 6, 0, 0)
            };
            _dgvHoaDonLichSu = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            pnlChiTiet.Controls.Add(_dgvHoaDonLichSu);
            pnlChiTiet.Controls.Add(_lblLichSuChiTiet);

            tlpLichSu.Controls.Add(pnlLoc, 0, 0);
            tlpLichSu.Controls.Add(_dgvLichSuCa, 0, 1);
            tlpLichSu.Controls.Add(pnlChiTiet, 0, 2);
            tabLichSu.Controls.Add(tlpLichSu);

            _tabCa.TabPages.Add(tabHienTai);
            _tabCa.TabPages.Add(tabLichSu);
            _tabCa.SelectedIndexChanged += TabCa_SelectedIndexChanged;

            Controls.Add(_tabCa);
            _tabCa.BringToFront();
        }

        private void TabCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tabCa?.SelectedIndex == 1)
                NapLichSuCa();
        }

        private void SetupLichSuCaColumns()
        {
            _dgvLichSuCa.Columns.Clear();
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CaId",
                HeaderText = "ID",
                Visible = false
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NhanVien",
                HeaderText = "NHÂN VIÊN",
                FillWeight = 90
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GioMo",
                HeaderText = "GIỜ MỞ",
                FillWeight = 110
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GioDong",
                HeaderText = "GIỜ ĐÓNG",
                FillWeight = 110
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TienDauCa",
                HeaderText = "TIỀN ĐẦU CA",
                FillWeight = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DoanhThu",
                HeaderText = "DOANH THU",
                FillWeight = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoHoaDon",
                HeaderText = "SỐ HĐ",
                FillWeight = 55,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            _dgvLichSuCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "TRẠNG THÁI",
                FillWeight = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void SetupHoaDonLichSuColumns()
        {
            _dgvHoaDonLichSu.Columns.Clear();
            _dgvHoaDonLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHD", HeaderText = "MÃ HĐ", FillWeight = 80 });
            _dgvHoaDonLichSu.Columns.Add(new DataGridViewTextBoxColumn { Name = "Gio", HeaderText = "GIỜ", FillWeight = 70 });
            _dgvHoaDonLichSu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongTien",
                HeaderText = "TỔNG TIỀN",
                FillWeight = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
            _dgvHoaDonLichSu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HinhThuc",
                HeaderText = "HÌNH THỨC",
                FillWeight = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void NapLichSuCa()
        {
            if (!_daKhoiTao || _dgvLichSuCa == null)
                return;

            try
            {
                var tu = _dtpLichSuTu.Value.Date;
                var den = _dtpLichSuDen.Value.Date;
                if (tu > den)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? taiKhoanLoc = AppSession.HasAdminAccess ? (int?)null : AppSession.TaiKhoanId;
                var dt = CaService.LayLichSuCa(tu, den, taiKhoanLoc);

                _dgvLichSuCa.Rows.Clear();
                _dgvHoaDonLichSu.Rows.Clear();
                _caLichSuId = null;
                _btnXuatLichSuCa.Enabled = false;
                _lblLichSuChiTiet.Text = dt.Rows.Count > 0
                    ? $"Tìm thấy {dt.Rows.Count} ca — chọn một dòng để xem hóa đơn"
                    : "Không có ca nào trong khoảng thời gian đã chọn";

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
                    DgvLichSuCa_SelectionChanged(_dgvLichSuCa, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử ca: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLichSuCa_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvLichSuCa?.SelectedRows.Count == 0)
                return;

            var row = _dgvLichSuCa.SelectedRows[0];
            if (row.Cells["CaId"].Value == null || row.Cells["CaId"].Value == DBNull.Value)
                return;

            int caId = Convert.ToInt32(row.Cells["CaId"].Value);
            _caLichSuId = caId;
            _btnXuatLichSuCa.Enabled = true;

            _lblLichSuChiTiet.Text =
                $"Ca #{caId} — {row.Cells["NhanVien"].Value} | Mở: {row.Cells["GioMo"].Value} | Doanh thu: {row.Cells["DoanhThu"].Value}";

            NapHoaDonLichSuCa(caId);
        }

        private void NapHoaDonLichSuCa(int caId)
        {
            _dgvHoaDonLichSu.Rows.Clear();
            var dt = CaService.GetHoaDonTrongCa(caId);
            foreach (DataRow r in dt.Rows)
            {
                _dgvHoaDonLichSu.Rows.Add(
                    r["MaHD"],
                    Convert.ToDateTime(r["Gio"]).ToString("HH:mm:ss"),
                    Convert.ToDecimal(r["TongTien"]),
                    CaService.HienThiPhuongThucThanhToan(r["HinhThuc"].ToString()));
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvHoaDonTrongCa.Columns.Clear();


            dgvHoaDonTrongCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaHD",
                HeaderText = "MÃ HĐ",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvHoaDonTrongCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Gio",
                HeaderText = "GIỜ",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvHoaDonTrongCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongTien",
                HeaderText = "TỔNG TIỀN",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }
            });

            dgvHoaDonTrongCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HinhThuc",
                HeaderText = "HÌNH THỨC",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void RegisterEventHandlers()
        {
            btnMoCa.Click -= BtnMoCa_Click;
            btnMoCa.Click += BtnMoCa_Click;

            btnDongCa.Click -= BtnDongCa_Click;
            btnDongCa.Click += BtnDongCa_Click;
            btnInBaoCao.Click -= BtnInBaoCao_Click;
            btnInBaoCao.Click += BtnInBaoCao_Click;

            _btnTimLichSuCa.Click += (s, e) => NapLichSuCa();
            _btnXuatLichSuCa.Click += BtnXuatLichSuCa_Click;
            _dgvLichSuCa.SelectionChanged += DgvLichSuCa_SelectionChanged;
        }

        private void NapDuLieu()
        {
            try
            {

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

                DisplayCaTimes(row);


                DisplayStatistics(row);

                DisplayInvoicesList();

                UpdateButtonStates(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu ca: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCaTimes(DataRow row)
        {
            txtGioMoCa.Text = Convert.ToDateTime(row["gio_mo"]).ToString("HH:mm:ss dd/MM/yyyy");
            txtGioDongCa.Text = row["gio_dong"] == DBNull.Value
                ? "--:--:--"
                : Convert.ToDateTime(row["gio_dong"]).ToString("HH:mm:ss dd/MM/yyyy");
        }

        private void DisplayStatistics(DataRow row)
        {
            int caId = AppSession.CaId.Value;


            txtSoHoaDon.Text = CaService.DemHoaDonCa(caId).ToString();


            string trangThai = row["trang_thai"].ToString();
            txtTrangThaiCa.Text = trangThai == "dang_mo" ? "🟢 ĐANG MỞ CA" : "🔴 ĐÃ ĐÓNG CA";
            txtTrangThaiCa.ForeColor = trangThai == "dang_mo"
                ? Color.FromArgb(39, 174, 96)
                : Color.FromArgb(149, 165, 166);


            decimal tong = CaService.TongDoanhThuCa(caId);
            decimal tienMat = CaService.TongTienMatCa(caId);
            decimal ck = CaService.TongChuyenKhoanCa(caId);
            decimal dauCa = Convert.ToDecimal(row["tien_dau_ca"]);

            txtTongDoanhThu.Text = $"{tong:N0} đ";
            txtTienMat.Text = $"{tienMat:N0} đ";
            txtChuyenKhoan.Text = $"{ck:N0} đ";
            txtTienDauCa.Text = dauCa.ToString("N0");

     
        }

        private void DisplayInvoicesList()
        {
            dgvHoaDonTrongCa.Rows.Clear();

            if (!AppSession.CaId.HasValue)
                return;

            var dt = CaService.GetHoaDonTrongCa(AppSession.CaId.Value);

            foreach (DataRow r in dt.Rows)
            {
                decimal tongTien = Convert.ToDecimal(r["TongTien"]);
                string hinhThucDisplay = CaService.HienThiPhuongThucThanhToan(r["HinhThuc"].ToString());

                dgvHoaDonTrongCa.Rows.Add(
                    r["MaHD"],
                    Convert.ToDateTime(r["Gio"]).ToString("HH:mm:ss"),
                    tongTien,
                    hinhThucDisplay);
            }
        }

        private void UpdateButtonStates(DataRow row)
        {
            bool dangMo = row["trang_thai"].ToString() == "dang_mo";

            btnMoCa.Visible = !dangMo;
            btnMoCa.Enabled = !dangMo;
            btnDongCa.Visible = dangMo;
            btnDongCa.Enabled = dangMo;
            txtTienDauCa.Enabled = !dangMo;
            btnInBaoCao.Enabled = true;
        }

        private void HienThiChuaMoCa()
        {
            txtGioMoCa.Text = "--:--:--";
            txtGioDongCa.Text = "--:--:--";
            txtSoHoaDon.Text = "0";
            txtTrangThaiCa.Text = "⚪ CHƯA MỞ CA";
            txtTrangThaiCa.ForeColor = Color.FromArgb(243, 156, 18);
            txtTongDoanhThu.Text = "0 đ";
            txtTienMat.Text = "0 đ";
            txtChuyenKhoan.Text = "0 đ";
            txtTienDauCa.Text = "0";
         
            dgvHoaDonTrongCa.Rows.Clear();

            btnMoCa.Visible = true;
            btnMoCa.Enabled = true;
            btnDongCa.Visible = false;
            btnDongCa.Enabled = false;
            txtTienDauCa.Enabled = true;
            btnInBaoCao.Enabled = false;
        }

        private void BtnMoCa_Click(object sender, EventArgs e)
        {
            if (!AppSession.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi mở ca!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTienDauCa.Text.Replace(",", "").Trim(), out decimal tienDau))
            {
                tienDau = 0;
            }

            if (tienDau < 0)
            {
                MessageBox.Show("Tiền đầu ca không thể âm!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                CaService.MoCa(AppSession.TaiKhoanId, tienDau);
                AppSession.CaId = CaService.GetOpenCaId(AppSession.TaiKhoanId);

                MessageBox.Show($"Mở ca thành công!\nTiền đầu ca: {tienDau:N0} đ", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                NapDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở ca: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDongCa_Click(object sender, EventArgs e)
        {
            if (!AppSession.CaId.HasValue)
            {
                MessageBox.Show("Không có ca nào đang mở!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
      
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng ca làm việc?\n" +
                "Sau khi đóng ca, bạn sẽ không thể thêm hóa đơn mới!",
                "Xác nhận đóng ca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!decimal.TryParse(txtTienDauCa.Text.Replace(",", "").Trim(), out decimal tienDau))
                tienDau = 0;

            try
            {
                decimal tienMat = CaService.TongTienMatCa(AppSession.CaId.Value);
                decimal tienCuoi = tienDau + tienMat;

                CaService.DongCa(AppSession.CaId.Value, tienCuoi);
                AppSession.CaId = null;

                MessageBox.Show(
                    $"Đóng ca thành công!\n\n" +
                    $"Tiền đầu ca: {tienDau:N0} đ\n" +
                    $"Tiền mặt thu: {tienMat:N0} đ\n" +
                    $"Tiền cuối ca: {tienCuoi:N0} đ",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                NapDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đóng ca: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            if (!AppSession.CaId.HasValue)
            {
                MessageBox.Show("Không có ca nào để xuất báo cáo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XuatBaoCaoCa(AppSession.CaId.Value);
        }

        private void BtnXuatLichSuCa_Click(object sender, EventArgs e)
        {
            if (!_caLichSuId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ca trong lịch sử để xuất báo cáo.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XuatBaoCaoCa(_caLichSuId.Value);
        }

        private void XuatBaoCaoCa(int caId)
        {
            try
            {
                var caInfo = CaService.GetCaInfo(caId);
                if (caInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin ca.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal tienDauCa = Convert.ToDecimal(caInfo["tien_dau_ca"]);
                var hoaDonList = CaService.GetHoaDonTrongCa(caId);

                decimal tongDoanhThu = CaService.TongDoanhThuCa(caId);
                decimal tongTienMat = CaService.TongTienMatCa(caId);
                decimal tongChuyenKhoan = CaService.TongChuyenKhoanCa(caId);
                decimal tongViDienTu = CaService.TongViDienTuCa(caId);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveDialog.FileName = $"BaoCaoCa_{caId}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                saveDialog.Title = "Xuất báo cáo Excel";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("================== CAFE ORDER ==================");
                    sb.AppendLine("              BÁO CÁO TỔNG KẾT CA");
                    sb.AppendLine("==================================================");
                    sb.AppendLine();

                    sb.AppendLine("THÔNG TIN CA,");
                    sb.AppendLine($"Mã ca,{caId}");
                    sb.AppendLine($"Nhân viên,{caInfo["ten_dang_nhap"]}");
                    sb.AppendLine($"Mở ca,{Convert.ToDateTime(caInfo["gio_mo"]):HH:mm:ss dd/MM/yyyy}");
                    if (caInfo["gio_dong"] != DBNull.Value)
                        sb.AppendLine($"Đóng ca,{Convert.ToDateTime(caInfo["gio_dong"]):HH:mm:ss dd/MM/yyyy}");
                    else
                        sb.AppendLine("Đóng ca,Chưa đóng");
                    sb.AppendLine($"Tiền đầu ca,{tienDauCa:N0} đ");
                    sb.AppendLine();

                    sb.AppendLine("DANH SÁCH HÓA ĐƠN,");
                    sb.AppendLine("Mã HĐ,Giờ,Tổng tiền,Hình thức");

                    foreach (DataRow r in hoaDonList.Rows)
                    {
                        string ma = r["MaHD"].ToString();
                        string gio = Convert.ToDateTime(r["Gio"]).ToString("HH:mm:ss");
                        decimal tien = Convert.ToDecimal(r["TongTien"]);
                        string ht = CaService.HienThiPhuongThucThanhToan(r["HinhThuc"].ToString(), coIcon: false);

                        sb.AppendLine($"{ma},{gio},{tien:N0},{ht}");
                    }

                    sb.AppendLine();
                    sb.AppendLine("TỔNG KẾT,");
                    sb.AppendLine($"Số hóa đơn,{hoaDonList.Rows.Count}");
                    sb.AppendLine($"Tổng doanh thu,{tongDoanhThu:N0} đ");
                    sb.AppendLine($"Tiền mặt,{tongTienMat:N0} đ");
                    sb.AppendLine($"Chuyển khoản,{tongChuyenKhoan:N0} đ");
                    sb.AppendLine($"Ví điện tử,{tongViDienTu:N0} đ");
                    sb.AppendLine();

                    sb.AppendLine("ĐỐI CHIẾU TIỀN,");
                    sb.AppendLine($"Tiền đầu ca,{tienDauCa:N0} đ");
                    sb.AppendLine($"Tiền mặt thu,{tongTienMat:N0} đ");
                    sb.AppendLine();
                    sb.AppendLine($"In lúc,{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

                    System.IO.File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                    DialogResult result = MessageBox.Show(
                        $"Xuất báo cáo thành công!\nFile lưu tại: {saveDialog.FileName}\n\nBạn có muốn mở file không?",
                        "Thành công",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXemBaoCao_Click(object sender, EventArgs e)
        {
            NapDuLieu();
        }


        private string FormatCurrency(decimal amount)
        {
            return $"{amount:N0} đ";
        }


        private void txtTienDauCa_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtTienDauCa_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienDauCa.Text, out decimal value))
            {
                txtTienDauCa.Text = value.ToString("N0");
            }
        }

        private void btnXemBaoCao_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnInBaoCao_Click_1(object sender, EventArgs e)
        {

        }
    }
}