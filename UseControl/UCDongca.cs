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
            // Style DataGridView
            UiTheme.StyleDataGridView(dgvHoaDonTrongCa);

            // Style buttons
            UiTheme.StyleFlatButton(btnMoCa, UiTheme.Success, 45);
            UiTheme.StyleFlatButton(btnDongCa, UiTheme.Danger, 45);
            UiTheme.StyleFlatButton(btnInBaoCao, UiTheme.PrimaryDark, 35);

            // Setup DataGridView columns
            SetupDataGridViewColumns();

            // Register event handlers
            RegisterEventHandlers();

            _daKhoiTao = true;
            NapDuLieu();
        }

        private void SetupDataGridViewColumns()
        {
            dgvHoaDonTrongCa.Columns.Clear();

            // Configure columns with better formatting
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
        }

        private void NapDuLieu()
        {
            try
            {
                // Check if ca is open
                if (!AppSession.CaId.HasValue)
                {
                    HienThiChuaMoCa();
                    return;
                }

                // Get ca information
                var row = CaService.GetCaInfo(AppSession.CaId.Value);
                if (row == null)
                {
                    AppSession.CaId = null;
                    HienThiChuaMoCa();
                    return;
                }

                // Display ca times
                DisplayCaTimes(row);

                // Display statistics
                DisplayStatistics(row);

                // Display invoices list
                DisplayInvoicesList();

                // Update button states
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

            // Basic statistics
            txtSoHoaDon.Text = CaService.DemHoaDonCa(caId).ToString();

            // Status display
            string trangThai = row["trang_thai"].ToString();
            txtTrangThaiCa.Text = trangThai == "dang_mo" ? "🟢 ĐANG MỞ CA" : "🔴 ĐÃ ĐÓNG CA";
            txtTrangThaiCa.ForeColor = trangThai == "dang_mo"
                ? Color.FromArgb(39, 174, 96)
                : Color.FromArgb(149, 165, 166);

            // Financial statistics
            decimal tong = CaService.TongDoanhThuCa(caId);
            decimal tienMat = CaService.TongTienMatCa(caId);
            decimal ck = CaService.TongChuyenKhoanCa(caId);
            decimal dauCa = Convert.ToDecimal(row["tien_dau_ca"]);

            txtTongDoanhThu.Text = $"{tong:N0} đ";
            txtTienMat.Text = $"{tienMat:N0} đ";
            txtChuyenKhoan.Text = $"{ck:N0} đ";
            txtTienDauCa.Text = dauCa.ToString("N0");

            decimal thucThu = dauCa + tienMat;
            txtThucThu.Text = $"{thucThu:N0} đ";

            // Calculate difference
            decimal chenhLech = thucThu - tong;
            txtChenhLech.Text = $"{chenhLech:N0} đ";
            txtChenhLech.ForeColor = chenhLech >= 0 ? Color.FromArgb(39, 174, 96) : Color.FromArgb(231, 76, 60);
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
                string hinhThuc = r["HinhThuc"].ToString();

                // Add icon based on payment method
                string hinhThucDisplay = hinhThuc == "TienMat" ? "💵 Tiền mặt" : "💳 Chuyển khoản";

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
            txtThucThu.Text = "0 đ";
            txtChenhLech.Text = "0 đ";
            txtChenhLech.ForeColor = SystemColors.ControlText;

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

            // Parse and validate opening cash
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

            // Confirm closing
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng ca làm việc?\n" +
                "Sau khi đóng ca, bạn sẽ không thể thêm hóa đơn mới!",
                "Xác nhận đóng ca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            // Get opening cash
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

        // THÊM METHOD NÀY - XUẤT BÁO CÁO EXCEL
        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            if (!AppSession.CaId.HasValue)
            {
                MessageBox.Show("Không có ca nào để xuất báo cáo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy tiền đầu ca
                decimal tienDauCa = 0;
                string tienText = txtTienDauCa.Text.Replace(",", "").Trim();
                if (!string.IsNullOrEmpty(tienText))
                {
                    decimal.TryParse(tienText, out tienDauCa);
                }

                // Lấy dữ liệu
                var caInfo = CaService.GetCaInfo(AppSession.CaId.Value);
                var hoaDonList = CaService.GetHoaDonTrongCa(AppSession.CaId.Value);

                // Tính tổng
                decimal tongDoanhThu = CaService.TongDoanhThuCa(AppSession.CaId.Value);
                decimal tongTienMat = CaService.TongTienMatCa(AppSession.CaId.Value);
                decimal tongChuyenKhoan = CaService.TongChuyenKhoanCa(AppSession.CaId.Value);

                // Hộp thoại lưu file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveDialog.FileName = $"BaoCaoCa_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                saveDialog.Title = "Xuất báo cáo Excel";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Tiêu đề
                    sb.AppendLine("================== CAFE ORDER ==================");
                    sb.AppendLine("              BÁO CÁO TỔNG KẾT CA");
                    sb.AppendLine("==================================================");
                    sb.AppendLine();

                    // Thông tin ca
                    sb.AppendLine("THÔNG TIN CA,");
                    sb.AppendLine($"Mở ca,{Convert.ToDateTime(caInfo["gio_mo"]):HH:mm:ss dd/MM/yyyy}");
                    if (caInfo["gio_dong"] != DBNull.Value)
                        sb.AppendLine($"Đóng ca,{Convert.ToDateTime(caInfo["gio_dong"]):HH:mm:ss dd/MM/yyyy}");
                    else
                        sb.AppendLine("Đóng ca,Chưa đóng");
                    sb.AppendLine($"Tiền đầu ca,{tienDauCa:N0} đ");
                    sb.AppendLine();

                    // Danh sách hóa đơn
                    sb.AppendLine("DANH SÁCH HÓA ĐƠN,");
                    sb.AppendLine("Mã HĐ,Giờ,Tổng tiền,Hình thức");

                    foreach (DataRow r in hoaDonList.Rows)
                    {
                        string ma = r["MaHD"].ToString();
                        string gio = Convert.ToDateTime(r["Gio"]).ToString("HH:mm:ss");
                        decimal tien = Convert.ToDecimal(r["TongTien"]);
                        string ht = r["HinhThuc"].ToString() == "TienMat" ? "Tiền mặt" : "Chuyển khoản";

                        sb.AppendLine($"{ma},{gio},{tien:N0},{ht}");
                    }

                    sb.AppendLine();

                    // Tổng kết
                    sb.AppendLine("TỔNG KẾT,");
                    sb.AppendLine($"Số hóa đơn,{hoaDonList.Rows.Count}");
                    sb.AppendLine($"Tổng doanh thu,{tongDoanhThu:N0} đ");
                    sb.AppendLine($"Tiền mặt,{tongTienMat:N0} đ");
                    sb.AppendLine($"Chuyển khoản,{tongChuyenKhoan:N0} đ");
                    sb.AppendLine();

                    // Đối chiếu
                    decimal thucThu = tienDauCa + tongTienMat;
                    decimal chenhLech = thucThu - tongDoanhThu;

                    sb.AppendLine("ĐỐI CHIẾU TIỀN,");
                    sb.AppendLine($"Tiền đầu ca,{tienDauCa:N0} đ");
                    sb.AppendLine($"Tiền mặt thu,{tongTienMat:N0} đ");
                    sb.AppendLine($"Tiền thực thu,{thucThu:N0} đ");
                    sb.AppendLine($"Chênh lệch,{chenhLech:N0} đ");
                    sb.AppendLine();
                    sb.AppendLine($"In lúc,{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

                    // Ghi file
                    System.IO.File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                    // Thông báo thành công và hỏi mở file
                    DialogResult result = MessageBox.Show(
                        $"Xuất báo cáo thành công!\nFile lưu tại: {saveDialog.FileName}\n\nBạn có muốn mở file không?",
                        "Thành công",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
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

        // Helper method to format currency
        private string FormatCurrency(decimal amount)
        {
            return $"{amount:N0} đ";
        }

        // Ensure numeric input for txtTienDauCa
        private void txtTienDauCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and decimal separator
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