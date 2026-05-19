using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeOrder
{
    public partial class UCBaoCao : UserControl
    {
        private Button _tabSelected;
        private bool _daKhoiTao;

        public UCBaoCao()
        {
            InitializeComponent();
        }

        public void TaiLai() => NapBaoCao();

        private void UCBaoCao_Load(object sender, EventArgs e)
        {
            UiTheme.StyleDataGridView(dgvBaoCao);
            UiTheme.StyleFlatButton(btnXemBaoCao, UiTheme.Primary, 32);
            StyleTab(btnTabDoanhThu, true);
            StyleTab(btnTabLoiNhuan, false);
            StyleTab(btnTabDonHang, false);
            _tabSelected = btnTabDoanhThu;

            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;

            dgvBaoCao.Columns.Clear();
            dgvBaoCao.Columns.Add("Ngay", "Ngày");
            dgvBaoCao.Columns.Add("MaHD", "Mã HĐ");
            dgvBaoCao.Columns.Add("Ban", "Ghi chú");
            dgvBaoCao.Columns.Add("TongTien", "Tổng tiền");

            btnTabDoanhThu.Click += (s, ev) => { SelectTab(btnTabDoanhThu); NapBaoCao(); };
            btnTabLoiNhuan.Click += (s, ev) => SelectTab(btnTabLoiNhuan);
            btnTabDonHang.Click += (s, ev) => SelectTab(btnTabDonHang);
            btnXemBaoCao.Click += (s, ev) => NapBaoCao();

            _daKhoiTao = true;
            NapBaoCao();
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
    }
}
