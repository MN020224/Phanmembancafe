using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeOrder.UseControl
{
    public partial class UCThuChi : UserControl
    {
        private DataTable currentData;
        private int? selectedId;

        public UCThuChi()
        {
            InitializeComponent();
            SetupTheme();
            LoadData();
        }

        private void SetupTheme()
        {
            // Style DataGridView
            dgvThuChi.BackgroundColor = Color.White;
            dgvThuChi.BorderStyle = BorderStyle.None;
            dgvThuChi.EnableHeadersVisualStyles = false;
            dgvThuChi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(112, 77, 59);
            dgvThuChi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvThuChi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvThuChi.ColumnHeadersHeight = 40;
            dgvThuChi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvThuChi.RowHeadersVisible = false;
            dgvThuChi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuChi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvThuChi.GridColor = Color.FromArgb(236, 240, 241);

            // Style buttons
            StyleButton(btnXem, Color.FromArgb(112, 77, 59));
            StyleButton(btnThem, Color.FromArgb(39, 174, 96));
            StyleButton(btnSua, Color.FromArgb(241, 196, 15));
            StyleButton(btnXoa, Color.FromArgb(231, 76, 60));
            StyleButton(btnXuatExcel, Color.FromArgb(41, 128, 185));

            // Set default dates
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;

            // Register events
            btnXem.Click += BtnXem_Click;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            dgvThuChi.SelectionChanged += DgvThuChi_SelectionChanged;
        }

        private void StyleButton(Button btn, Color backColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        // 🔥 ĐÃ SỬA: private -> public
        public void LoadData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                string query = @"
                    SELECT 
                        tc.id,
                        tc.loai,
                        tc.mo_ta,
                        tc.so_tien,
                        tc.tao_luc AS NgayTao,
                        CASE tc.loai 
                            WHEN 'thu' THEN tc.so_tien 
                            ELSE 0 
                        END AS Thu,
                        CASE tc.loai 
                            WHEN 'chi' THEN tc.so_tien 
                            ELSE 0 
                        END AS Chi
                    FROM ThuChi tc
                    WHERE tc.tao_luc >= @tuNgay AND tc.tao_luc <= @denNgay
                    ORDER BY tc.tao_luc DESC";

                currentData = DbHelper.Query(query,
                    new SqlParameter("@tuNgay", tuNgay),
                    new SqlParameter("@denNgay", denNgay));

                dgvThuChi.DataSource = currentData;

                // Set column headers
                if (dgvThuChi.Columns.Contains("id"))
                    dgvThuChi.Columns["id"].Visible = false;
                if (dgvThuChi.Columns.Contains("loai"))
                    dgvThuChi.Columns["loai"].HeaderText = "Loại";
                if (dgvThuChi.Columns.Contains("mo_ta"))
                    dgvThuChi.Columns["mo_ta"].HeaderText = "Mô tả";
                if (dgvThuChi.Columns.Contains("so_tien"))
                    dgvThuChi.Columns["so_tien"].HeaderText = "Số tiền";
                if (dgvThuChi.Columns.Contains("NgayTao"))
                    dgvThuChi.Columns["NgayTao"].HeaderText = "Ngày tạo";
                if (dgvThuChi.Columns.Contains("Thu"))
                    dgvThuChi.Columns["Thu"].Visible = false;
                if (dgvThuChi.Columns.Contains("Chi"))
                    dgvThuChi.Columns["Chi"].Visible = false;

                // Format columns
                if (dgvThuChi.Columns.Contains("so_tien"))
                {
                    dgvThuChi.Columns["so_tien"].DefaultCellStyle.Format = "N0";
                    dgvThuChi.Columns["so_tien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvThuChi.Columns.Contains("NgayTao"))
                {
                    dgvThuChi.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                // Calculate totals
                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals()
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                txtTongThu.Text = "0 đ";
                txtTongChi.Text = "0 đ";
                txtChenhLech.Text = "0 đ";
                return;
            }

            decimal tongThu = 0;
            decimal tongChi = 0;

            foreach (DataRow row in currentData.Rows)
            {
                string loai = row["loai"].ToString();
                decimal soTien = Convert.ToDecimal(row["so_tien"]);

                if (loai == "thu")
                    tongThu += soTien;
                else if (loai == "chi")
                    tongChi += soTien;
            }

            decimal chenhLech = tongThu - tongChi;

            txtTongThu.Text = tongThu.ToString("N0") + " đ";
            txtTongChi.Text = tongChi.ToString("N0") + " đ";
            txtChenhLech.Text = chenhLech.ToString("N0") + " đ";

            // Set color for chênh lệch
            if (chenhLech > 0)
                txtChenhLech.ForeColor = Color.FromArgb(39, 174, 96);
            else if (chenhLech < 0)
                txtChenhLech.ForeColor = Color.FromArgb(231, 76, 60);
            else
                txtChenhLech.ForeColor = Color.FromArgb(41, 128, 185);
        }

        private void BtnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (!selectedId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Chức năng đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!selectedId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DbHelper.Execute("DELETE FROM ThuChi WHERE id = @id",
                        new SqlParameter("@id", selectedId.Value));

                    MessageBox.Show("Xóa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            sfd.FileName = $"ThuChi_{DateTime.Now:yyyyMMdd_HHmmss}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string content = "";
                    content += "Loại,Mô tả,Số tiền,Ngày tạo" + Environment.NewLine;

                    foreach (DataRow row in currentData.Rows)
                    {
                        content += $"{row["loai"]}," +
                                  $"{row["mo_ta"]}," +
                                  $"{row["so_tien"]}," +
                                  $"{row["NgayTao"]}" + Environment.NewLine;
                    }

                    System.IO.File.WriteAllText(sfd.FileName, content, System.Text.Encoding.UTF8);
                    MessageBox.Show($"Xuất file thành công!\n{sfd.FileName}", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvThuChi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThuChi.SelectedRows.Count > 0)
            {
                var row = dgvThuChi.SelectedRows[0];
                if (row.Cells["id"].Value != null && row.Cells["id"].Value != DBNull.Value)
                {
                    selectedId = Convert.ToInt32(row.Cells["id"].Value);
                }
            }
            else
            {
                selectedId = null;
            }
        }
    }
}