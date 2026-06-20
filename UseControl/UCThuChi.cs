using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CafeOrder.UseControl
{
    public partial class UCTHuchi : UserControl
    {
        private int? editId = null;

        public UCTHuchi()
        {
            InitializeComponent();
            dtpNgayTao.Value = DateTime.Now;

            if (cboLoai.Items.Count == 0)
            {
                cboLoai.Items.AddRange(new string[] { "Thu", "Chi" });
            }

            dtpDenNgay.Value = DateTime.Now;
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);

            LoadData();
        }

        public UCTHuchi(int id, string loai, string moTa, decimal soTien, DateTime ngayTao)
        {
            InitializeComponent();
            editId = id;

            if (cboLoai.Items.Count == 0)
            {
                cboLoai.Items.AddRange(new string[] { "Thu", "Chi" });
            }

            if (cboLoai.Items.Contains(loai))
                cboLoai.SelectedItem = loai;
            else if (cboLoai.Items.Count > 0)
                cboLoai.SelectedIndex = 0;

            txtMoTa.Text = moTa;
            txtSoTien.Text = soTien.ToString();
            dtpNgayTao.Value = ngayTao;

            dtpDenNgay.Value = DateTime.Now;
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);

            if (this.ParentForm != null)
                this.ParentForm.Text = "✏️ SỬA THU CHI";

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                string query = @"
                    SELECT 
                        id, 
                        loai, 
                        mo_ta AS MoTa, 
                        so_tien, 
                        tao_luc AS NgayTao,
                        CASE WHEN loai = N'Thu' THEN so_tien ELSE 0 END AS Thu,
                        CASE WHEN loai = N'Chi' THEN so_tien ELSE 0 END AS Chi
                    FROM ThuChi 
                    WHERE tao_luc BETWEEN @tuNgay AND @denNgay
                    ORDER BY tao_luc DESC";

                DataTable dt = DbHelper.Query(query,
                    new SqlParameter("@tuNgay", tuNgay),
                    new SqlParameter("@denNgay", denNgay));

                dgvDanhSach.DataSource = dt;

                if (dgvDanhSach.Columns.Count > 0)
                {
                    if (dgvDanhSach.Columns["id"] != null)
                        dgvDanhSach.Columns["id"].Visible = false;

                    if (dgvDanhSach.Columns["loai"] != null)
                        dgvDanhSach.Columns["loai"].HeaderText = "Loại";

                    if (dgvDanhSach.Columns["MoTa"] != null)
                        dgvDanhSach.Columns["MoTa"].HeaderText = "Mô tả";

                    if (dgvDanhSach.Columns["so_tien"] != null)
                    {
                        dgvDanhSach.Columns["so_tien"].HeaderText = "Số tiền";
                        dgvDanhSach.Columns["so_tien"].DefaultCellStyle.Format = "#,##0";
                        dgvDanhSach.Columns["so_tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (dgvDanhSach.Columns["NgayTao"] != null)
                    {
                        dgvDanhSach.Columns["NgayTao"].HeaderText = "Ngày tạo";
                        dgvDanhSach.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    }

                    if (dgvDanhSach.Columns["Thu"] != null)
                        dgvDanhSach.Columns["Thu"].Visible = false;

                    if (dgvDanhSach.Columns["Chi"] != null)
                        dgvDanhSach.Columns["Chi"].Visible = false;
                }

                decimal tongThu = 0;
                decimal tongChi = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["loai"].ToString() == "Thu")
                        tongThu += Convert.ToDecimal(row["so_tien"]);
                    else if (row["loai"].ToString() == "Chi")
                        tongChi += Convert.ToDecimal(row["so_tien"]);
                }

                decimal tongCong = tongThu - tongChi;

                lblTitle.Text = $"QUẢN LÝ THU CHI | Thu: {tongThu:#,##0}đ | Chi: {tongChi:#,##0}đ | Tổng: {tongCong:#,##0}đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadData();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMoTa.Focus();
                return;
            }

            string soTienRaw = txtSoTien.Text.Replace(",", "");
            if (!decimal.TryParse(soTienRaw, out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            soTien = Math.Round(soTien, 0);
            if (soTien >= 10000000000)
            {
                MessageBox.Show("Số tiền không được vượt quá 9,999,999,999đ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            if (cboLoai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại thu/chi!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoai.Focus();
                return;
            }

            try
            {
                string loai = cboLoai.SelectedItem.ToString();
                string moTa = txtMoTa.Text.Trim();
                DateTime ngayTao = dtpNgayTao.Value;

                if (editId.HasValue)
                {
                    DbHelper.Execute("UPDATE ThuChi SET loai=@loai, mo_ta=@moTa, so_tien=@soTien, tao_luc=@ngayTao WHERE id=@id",
                        new SqlParameter("@loai", loai),
                        new SqlParameter("@moTa", moTa),
                        new SqlParameter("@soTien", soTien),
                        new SqlParameter("@ngayTao", ngayTao),
                        new SqlParameter("@id", editId.Value));

                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DbHelper.Execute("INSERT INTO ThuChi (loai, mo_ta, so_tien, tao_luc) VALUES (@loai, @moTa, @soTien, @ngayTao)",
                        new SqlParameter("@loai", loai),
                        new SqlParameter("@moTa", moTa),
                        new SqlParameter("@soTien", soTien),
                        new SqlParameter("@ngayTao", ngayTao));

                    MessageBox.Show("Thêm mới thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                editId = null;
                ClearForm();
                LoadData();

                if (this.ParentForm != null)
                    this.ParentForm.Text = "QUẢN LÝ THU CHI";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            editId = null;

            if (this.ParentForm != null)
                this.ParentForm.Text = "QUẢN LÝ THU CHI";
        }

        private void TxtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            TextBox txt = sender as TextBox;
            if (char.IsDigit(e.KeyChar) && txt.Text.Replace(",", "").Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void TxtSoTien_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTien.Text))
                return;

            if (decimal.TryParse(txtSoTien.Text.Replace(",", ""), out decimal amount))
            {
                amount = Math.Round(amount, 0);
                if (amount >= 10000000000)
                {
                    MessageBox.Show("Số tiền không được vượt quá 9,999,999,999đ!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTien.Text = "";
                    txtSoTien.Focus();
                    return;
                }
                txtSoTien.Text = amount.ToString("#,##0");
            }
            else if (!string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Text = "";
                txtSoTien.Focus();
            }
        }

        private void DgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

                editId = Convert.ToInt32(row.Cells["id"].Value);
                string loai = row.Cells["loai"].Value.ToString();
                string moTa = row.Cells["MoTa"].Value.ToString();
                decimal soTien = Convert.ToDecimal(row.Cells["so_tien"].Value);
                DateTime ngayTao = Convert.ToDateTime(row.Cells["NgayTao"].Value);

                if (cboLoai.Items.Contains(loai))
                    cboLoai.SelectedItem = loai;

                txtMoTa.Text = moTa;
                txtSoTien.Text = soTien.ToString("#,##0");
                dtpNgayTao.Value = ngayTao;

                if (this.ParentForm != null)
                    this.ParentForm.Text = "✏️ SỬA THU CHI";
            }
        }

        private void UCTHuchi_Load(object sender, EventArgs e)
        {
            if (cboLoai.SelectedItem == null && cboLoai.Items.Count > 0)
            {
                cboLoai.SelectedIndex = 0;
            }
        }

        public void ClearForm()
        {
            editId = null;
            cboLoai.SelectedIndex = -1;
            txtMoTa.Text = string.Empty;
            txtSoTien.Text = string.Empty;
            dtpNgayTao.Value = DateTime.Now;

            if (this.ParentForm != null)
                this.ParentForm.Text = "QUẢN LÝ THU CHI";
        }

        public void SetEditData(int id, string loai, string moTa, decimal soTien, DateTime ngayTao)
        {
            editId = id;

            if (cboLoai.Items.Contains(loai))
                cboLoai.SelectedItem = loai;
            else if (cboLoai.Items.Count > 0)
                cboLoai.SelectedIndex = 0;

            txtMoTa.Text = moTa;
            txtSoTien.Text = soTien.ToString("#,##0");
            dtpNgayTao.Value = ngayTao;

            if (this.ParentForm != null)
                this.ParentForm.Text = "✏️ SỬA THU CHI";
        }

        public void RefreshData()
        {
            LoadData();
        }
    }
}