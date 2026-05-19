using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace CafeOrder
{
    public partial class UCQuanTri : UserControl
    {
        private Button _navSelected;
        private bool _daKhoiTao;
        private DataTable _currentBaoCaoData;

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

            StyleNav(btnNavSanPham, true);
            StyleNav(btnNavDanhmuc, false);
            StyleNav(btnNavBaocao, false);
            _navSelected = btnNavSanPham;

            NapComboDanhMuc();
            NapTatCa();

            // Khởi tạo báo cáo
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.AddRange(new object[] {
                "Doanh thu theo ngày",
                "Doanh thu theo tháng",
                "Món ăn bán chạy",
                "Chi tiết hóa đơn"
            });
            cboLoaiBaoCao.SelectedIndex = 0;

            // Đăng ký sự kiện
            btnNavSanPham.Click += (s, ev) => SelectNav(btnNavSanPham, 0);
            btnNavDanhmuc.Click += (s, ev) => SelectNav(btnNavDanhmuc, 1);
            btnNavBaocao.Click += (s, ev) => SelectNav(btnNavBaocao, 2);
            btnThemMon.Click += BtnThemMon_Click;
            btnSuaMon.Click += BtnSuaMon_Click;
            btnXoaMon.Click += BtnXoaMon_Click;
            btnThemDanhMuc.Click += BtnThemDanhMuc_Click;
            btnSuaDanhMuc.Click += BtnSuaDanhMuc_Click;
            btnXoaDanhMuc.Click += BtnXoaDanhMuc_Click;
            dgvMonAn.SelectionChanged += (s, ev) => ChonMonAn();
            dgvDanhMuc.SelectionChanged += (s, ev) => ChonDanhMuc();

            // Sự kiện báo cáo
            btnLocBaoCao.Click += BtnLocBaoCao_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            cboLoaiBaoCao.SelectedIndexChanged += CboLoaiBaoCao_SelectedIndexChanged;

            // Tải báo cáo mặc định
            TaiBaoCao();

            _daKhoiTao = true;
            AppendLog("Module Quản trị — kết nối SQL OK.");
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
                }

                dgvBaoCao.DataSource = _currentBaoCaoData;

                // Hiển thị tổng doanh thu
                decimal tongDoanhThu = QuanTriService.TongDoanhThu(tuNgay, denNgay);
                lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";
                lblTongDoanhThu.ForeColor = Color.Red;

                AppendLog($"Đã tải báo cáo: {cboLoaiBaoCao.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog($"Lỗi tải báo cáo: {ex.Message}");
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
        }

        private void FormatBaoCaoChiTiet()
        {
            if (_currentBaoCaoData == null) return;
            if (_currentBaoCaoData.Columns.Contains("MaHoaDon"))
                _currentBaoCaoData.Columns["MaHoaDon"].ColumnName = "Mã HĐ";
            if (_currentBaoCaoData.Columns.Contains("NgayLap"))
                _currentBaoCaoData.Columns["NgayLap"].ColumnName = "Ngày Lập";
            if (_currentBaoCaoData.Columns.Contains("Ban"))
                _currentBaoCaoData.Columns["Ban"].ColumnName = "Bàn";
            if (_currentBaoCaoData.Columns.Contains("TongTien"))
                _currentBaoCaoData.Columns["TongTien"].ColumnName = "Tổng Tiền (VNĐ)";
            if (_currentBaoCaoData.Columns.Contains("NhanVien"))
                _currentBaoCaoData.Columns["NhanVien"].ColumnName = "Nhân Viên";
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
            sfd.Filter = "Excel Files|*.xlsx|CSV Files|*.csv";
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

            // Ghi file
            string outputPath = filePath;
            if (!outputPath.EndsWith(".csv"))
                outputPath = filePath.Replace(".xlsx", ".csv");

            System.IO.File.WriteAllText(outputPath, csvContent, System.Text.Encoding.UTF8);
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
                // Ẩn cột id
                if (dgvMonAn.Columns.Contains("id"))
                    dgvMonAn.Columns["id"].Visible = false;

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

        private void ChonDanhMuc()
        {
            if (dgvDanhMuc.CurrentRow == null) return;
            txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["ten_danh_muc"].Value?.ToString();
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
            var id = GetId(dgvMonAn);
            if (!id.HasValue) { MessageBox.Show("Vui lòng chọn món cần xóa!"); return; }
            if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                QuanTriService.XoaMon(id.Value);
                NapTatCa();
                AppendLog("Xóa món id=" + id);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        private void SelectNav(Button btn, int tabIndex)
        {
            if (_navSelected != null)
                StyleNav(_navSelected, false);
            StyleNav(btn, true);
            _navSelected = btn;
            if (tabIndex >= 0 && tabIndex < tabControl1.TabPages.Count)
                tabControl1.SelectedIndex = tabIndex;
        }

        private void StyleNav(Button btn, bool selected)
        {
            UiTheme.StyleSidebarButton(btn, selected);
            if (!selected)
                btn.BackColor = UiTheme.Sidebar;
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine);
        }
    }
}