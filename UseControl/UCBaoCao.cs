using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace CafeOrder
{
    /// <summary>
    /// UserControl báo cáo thống kê doanh thu
    /// </summary>
    public partial class UCBaoCao : UserControl
    {
        private Button _tabSelected;
        private bool _daKhoiTao;
        private string _currentMaHoaDon;  // Lưu mã hóa đơn đang chọn

        public UCBaoCao()
        {
            InitializeComponent();
        }

        public void TaiLai() => NapBaoCao();

        private void UCBaoCao_Load(object sender, EventArgs e)
        {
            UiTheme.StyleDataGridView(dgvBaoCao);
            UiTheme.StyleFlatButton(btnXemBaoCao, UiTheme.Primary, 32);

            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;

            // Thiết lập DataGridView chính
            dgvBaoCao.Columns.Clear();
            dgvBaoCao.Columns.Add("Ngay", "Ngày");
            dgvBaoCao.Columns.Add("MaHD", "Mã HĐ");
            dgvBaoCao.Columns.Add("Ban", "Ghi chú");
            dgvBaoCao.Columns.Add("TongTien", "Tổng tiền");

            // 🔥 Thêm sự kiện click vào dòng
            dgvBaoCao.CellClick += DgvBaoCao_CellClick;

            // 🔥 Tạo DataGridView chi tiết hóa đơn (nếu chưa có)
            TaoDataGridViewChiTiet();

            btnXemBaoCao.Click += (s, ev) => NapBaoCao();

            _daKhoiTao = true;
            NapBaoCao();
        }

        /// <summary>
        /// Tạo DataGridView hiển thị chi tiết hóa đơn
        /// </summary>
        private void TaoDataGridViewChiTiet()
        {
            // Tìm panel hoặc tạo mới để chứa chi tiết
            Panel pnlChiTiet = null;

            // Tìm panel chi tiết (có thể đã có sẵn trong Designer)
            foreach (Control ctl in this.Controls)
            {
                if (ctl.Name == "pnlChiTiet")
                {
                    pnlChiTiet = ctl as Panel;
                    break;
                }
            }

            // Nếu chưa có, tạo mới
            if (pnlChiTiet == null)
            {
                pnlChiTiet = new Panel
                {
                    Name = "pnlChiTiet",
                    Dock = DockStyle.Bottom,
                    Height = 250,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };
                this.Controls.Add(pnlChiTiet);

                // Thêm label tiêu đề
                var lblTitle = new Label
                {
                    Text = "CHI TIẾT HÓA ĐƠN",
                    Dock = DockStyle.Top,
                    Height = 30,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = UiTheme.Primary,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0)
                };
                pnlChiTiet.Controls.Add(lblTitle);
            }

            // Tạo DataGridView chi tiết
            var dgvChiTiet = new DataGridView
            {
                Name = "dgvChiTiet",
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                RowHeadersVisible = false
            };

            // Style cho DataGridView chi tiết
            UiTheme.StyleDataGridView(dgvChiTiet);

            // Thêm các cột
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add("TenMon", "Tên món");
            dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvChiTiet.Columns.Add("ThanhTien", "Thành tiền");

            // Format cột tiền
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Xóa control cũ nếu có
            var oldGrid = pnlChiTiet.Controls.Find("dgvChiTiet", true);
            if (oldGrid.Length > 0)
                pnlChiTiet.Controls.Remove(oldGrid[0]);

            pnlChiTiet.Controls.Add(dgvChiTiet);
        }

        /// <summary>
        /// Sự kiện click vào dòng - Hiển thị chi tiết hóa đơn
        /// </summary>
        private void DgvBaoCao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvBaoCao.Rows[e.RowIndex];
            string maHoaDon = row.Cells["MaHD"].Value?.ToString();

            if (!string.IsNullOrEmpty(maHoaDon))
            {
                _currentMaHoaDon = maHoaDon;
                HienThiChiTietHoaDon(maHoaDon);
            }
        }

        /// <summary>
        /// Sự kiện double click - Mở form chi tiết riêng
        /// </summary>
       

        /// <summary>
        /// Hiển thị chi tiết hóa đơn trong DataGridView
        /// </summary>
        private void HienThiChiTietHoaDon(string maHoaDon)
        {
            try
            {
                // Tìm DataGridView chi tiết
                var dgvChiTiet = this.Controls.Find("dgvChiTiet", true);
                if (dgvChiTiet.Length == 0) return;

                var grid = dgvChiTiet[0] as DataGridView;
                if (grid == null) return;

                // Lấy chi tiết hóa đơn từ database
                var dt = LayChiTietHoaDon(maHoaDon);

                grid.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        grid.Rows.Add(
                            row["TenMon"],
                            row["SoLuong"],
                            Convert.ToDecimal(row["DonGia"]).ToString("N0"),
                            Convert.ToDecimal(row["ThanhTien"]).ToString("N0"));
                    }
                }
                else
                {
                    grid.Rows.Add("Không có dữ liệu", "", "", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị chi tiết: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable LayChiTietHoaDon(string maHoaDon)
        {
            string query = @"
                SELECT 
                    m.ten_mon AS TenMon,
                    ct.so_luong AS SoLuong,
                    ct.don_gia AS DonGia,
                    ct.thanh_tien AS ThanhTien
                FROM ChiTietHoaDon ct
                INNER JOIN HoaDon h ON ct.hoa_don_id = h.id
                INNER JOIN MonAn m ON ct.mon_an_id = m.id
                WHERE h.ma_hoa_don = @maHoaDon
                ORDER BY ct.id";

            return DbHelper.Query(query, new System.Data.SqlClient.SqlParameter("@maHoaDon", maHoaDon));
        }

        private void NapBaoCao()
        {
            if (!_daKhoiTao || dgvBaoCao.Columns.Count == 0)
                return;

            try
            {
                var tu = dtpTuNgay.Value.Date;
                var den = dtpDenNgay.Value.Date;
                if (tu > den)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal tong = BaoCaoService.TongDoanhThu(tu, den);
                int soHd = BaoCaoService.DemHoaDon(tu, den);
                decimal tb = soHd > 0 ? tong / soHd : 0;

                flowKpi.Controls.Clear();
                flowKpi.Controls.Add(UiTheme.CreateKpiCard("Doanh thu", tong.ToString("N0") + " đ", UiTheme.Success));
                flowKpi.Controls.Add(UiTheme.CreateKpiCard("Số đơn", soHd.ToString(), UiTheme.Primary));
                flowKpi.Controls.Add(UiTheme.CreateKpiCard("TB/đơn", tb.ToString("N0") + " đ", UiTheme.Warning));

                dgvBaoCao.Rows.Clear();
                var dt = BaoCaoService.LayBaoCao(tu, den);
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    dgvBaoCao.Rows.Add(
                        row["Ngay"],
                        row["MaHD"],
                        row["Ban"],
                        Convert.ToDecimal(row["TongTien"]).ToString("N0") + " đ");
                }

                txtTongDoanhThu.Text = tong.ToString("N0") + " đ";
                txtSoLuongHoaDon.Text = soHd.ToString();

                // Xóa chi tiết khi tải báo cáo mới
                var dgvChiTiet = this.Controls.Find("dgvChiTiet", true);
                if (dgvChiTiet.Length > 0)
                {
                    (dgvChiTiet[0] as DataGridView)?.Rows.Clear();
                }
                _currentMaHoaDon = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectTab(Button btn)
        {
            if (_tabSelected != null)
                StyleTab(_tabSelected, false);
            StyleTab(btn, true);
            _tabSelected = btn;
        }

        private void StyleTab(Button btn, bool selected)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = selected ? 0 : 1;
            btn.FlatAppearance.BorderColor = UiTheme.Primary;
            if (selected)
            {
                btn.BackColor = UiTheme.Primary;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = UiTheme.Primary;
            }
            btn.UseVisualStyleBackColor = false;
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Refresh dữ liệu khi click vào tiêu đề
            NapBaoCao();
        }

        private void lblChartPlaceholder_Click(object sender, EventArgs e)
        {

        }
    }
}