using System;
using System.Data;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCQuanTri : UserControl
    {
        private Button _navSelected;
        private bool _daKhoiTao;

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
            UiTheme.StyleDataGridView(dgvTaiKhoan);

            UiTheme.StyleFlatButton(btnThemMon, UiTheme.Primary);
            UiTheme.StyleFlatButton(btnSuaMon, UiTheme.Warning);
            UiTheme.StyleFlatButton(btnXoaMon, UiTheme.Danger);
            UiTheme.StyleFlatButton(btnThemDanhMuc, UiTheme.Primary);
            UiTheme.StyleFlatButton(btnSuaDanhMuc, UiTheme.Warning);
            UiTheme.StyleFlatButton(btnXoaDanhMuc, UiTheme.Danger);
            UiTheme.StyleFlatButton(btnThemTK, UiTheme.Primary);
            UiTheme.StyleFlatButton(btnSuaTK, UiTheme.Warning);
            UiTheme.StyleFlatButton(btnXoaTK, UiTheme.Danger);

            StyleNav(btnNavSanPham, true);
            StyleNav(btnNavNhanVien, false);
            StyleNav(btnNavKhachHang, false);
            StyleNav(btnNavCaiDat, false);
            _navSelected = btnNavSanPham;

            NapComboDanhMuc();
            NapTatCa();

            btnNavSanPham.Click += (s, ev) => SelectNav(btnNavSanPham, 0);
            btnNavNhanVien.Click += (s, ev) => SelectNav(btnNavNhanVien, 2);
            btnNavKhachHang.Click += (s, ev) => SelectNav(btnNavKhachHang, 1);

            btnThemMon.Click += BtnThemMon_Click;
            btnSuaMon.Click += BtnSuaMon_Click;
            btnXoaMon.Click += BtnXoaMon_Click;
            btnThemDanhMuc.Click += BtnThemDanhMuc_Click;
            btnSuaDanhMuc.Click += BtnSuaDanhMuc_Click;
            btnXoaDanhMuc.Click += BtnXoaDanhMuc_Click;
            btnThemTK.Click += BtnThemTK_Click;
            btnSuaTK.Click += BtnSuaTK_Click;
            btnXoaTK.Click += BtnXoaTK_Click;

            dgvMonAn.SelectionChanged += (s, ev) => ChonMonAn();
            dgvDanhMuc.SelectionChanged += (s, ev) => ChonDanhMuc();
            dgvTaiKhoan.SelectionChanged += (s, ev) => ChonTaiKhoan();

            _daKhoiTao = true;
            AppendLog("Module Quản trị — kết nối SQL OK.");
        }

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

                dgvDanhMuc.DataSource = QuanTriService.LoadDanhMuc();
                dgvTaiKhoan.DataSource = QuanTriService.LoadTaiKhoan();
                if (dgvTaiKhoan.Columns.Contains("mat_khau"))
                    dgvTaiKhoan.Columns["mat_khau"].Visible = false;
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
            catch
            {
                // Bỏ qua khi combo chưa bind xong
            }
        }

        private void ChonDanhMuc()
        {
            if (dgvDanhMuc.CurrentRow == null) return;
            txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["ten_danh_muc"].Value?.ToString();
        }

        private void ChonTaiKhoan()
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            txtUsername.Text = dgvTaiKhoan.CurrentRow.Cells["ten_dang_nhap"].Value?.ToString();
            txtPassword.Text = "";
            cboVaiTro.Text = dgvTaiKhoan.CurrentRow.Cells["vai_tro"].Value?.ToString();
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
            if (!decimal.TryParse(txtGia.Text, out decimal gia)) { ThongBaoGia(); return; }
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
            if (!id.HasValue) return;
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
            if (!id.HasValue) return;
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
            try
            {
                QuanTriService.ThemDanhMuc(txtTenDanhMuc.Text.Trim());
                NapTatCa();
                NapComboDanhMuc();
                AppendLog("Thêm danh mục.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvDanhMuc);
            if (!id.HasValue) return;
            try
            {
                QuanTriService.SuaDanhMuc(id.Value, txtTenDanhMuc.Text.Trim());
                NapTatCa();
                NapComboDanhMuc();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvDanhMuc);
            if (!id.HasValue) return;
            if (MessageBox.Show("Xóa danh mục? (Món thuộc danh mục cũng bị ảnh hưởng)", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                QuanTriService.XoaDanhMuc(id.Value);
                NapTatCa();
                NapComboDanhMuc();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnThemTK_Click(object sender, EventArgs e)
        {
            try
            {
                QuanTriService.ThemTaiKhoan(txtUsername.Text.Trim(), txtPassword.Text, cboVaiTro.Text);
                NapTatCa();
                AppendLog("Thêm tài khoản.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSuaTK_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvTaiKhoan);
            if (!id.HasValue) return;
            try
            {
                QuanTriService.SuaTaiKhoan(id.Value, txtUsername.Text.Trim(), txtPassword.Text, cboVaiTro.Text);
                NapTatCa();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnXoaTK_Click(object sender, EventArgs e)
        {
            var id = GetId(dgvTaiKhoan);
            if (!id.HasValue) return;
            if (MessageBox.Show("Xóa tài khoản?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                QuanTriService.XoaTaiKhoan(id.Value);
                NapTatCa();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

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

        private void btnNavCaiDat_Click(object sender, EventArgs e)
        {

        }
    }
}
