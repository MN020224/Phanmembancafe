namespace CafeOrder
{
    partial class UCBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnTabDoanhThu;
        private System.Windows.Forms.Button btnTabLoiNhuan;
        private System.Windows.Forms.Button btnTabDonHang;
        private System.Windows.Forms.FlowLayoutPanel flowKpi;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Label lblChartPlaceholder;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label lblSoLuongHoaDon;
        private System.Windows.Forms.TextBox txtSoLuongHoaDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnTabDoanhThu = new System.Windows.Forms.Button();
            this.btnTabLoiNhuan = new System.Windows.Forms.Button();
            this.btnTabDonHang = new System.Windows.Forms.Button();
            this.flowKpi = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.lblChartPlaceholder = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblSoLuongHoaDon = new System.Windows.Forms.Label();
            this.txtSoLuongHoaDon = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 52);
            this.pnlHeader.TabIndex = 0;
            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblTitle.Text = "📊 BÁO CÁO — Thống kê doanh thu";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // pnlFilter
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnTabDonHang);
            this.pnlFilter.Controls.Add(this.btnTabLoiNhuan);
            this.pnlFilter.Controls.Add(this.btnTabDoanhThu);
            this.pnlFilter.Controls.Add(this.btnXemBaoCao);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 52);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlFilter.Size = new System.Drawing.Size(1100, 56);
            this.pnlFilter.TabIndex = 1;
            // lblTuNgay
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTuNgay.Location = new System.Drawing.Point(16, 18);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(58, 17);
            this.lblTuNgay.Text = "Từ ngày";
            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(80, 14);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 27);
            this.dtpTuNgay.TabIndex = 1;
            // lblDenNgay
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblDenNgay.Location = new System.Drawing.Point(224, 18);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(66, 17);
            this.lblDenNgay.Text = "Đến ngày";
            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(296, 14);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 27);
            this.dtpDenNgay.TabIndex = 2;
            // btnXemBaoCao
            this.btnXemBaoCao.Location = new System.Drawing.Point(440, 12);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(140, 32);
            this.btnXemBaoCao.TabIndex = 3;
            this.btnXemBaoCao.Text = "🔍 Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            // btnTabDoanhThu
            this.btnTabDoanhThu.Location = new System.Drawing.Point(600, 12);
            this.btnTabDoanhThu.Name = "btnTabDoanhThu";
            this.btnTabDoanhThu.Size = new System.Drawing.Size(110, 32);
            this.btnTabDoanhThu.TabIndex = 4;
            this.btnTabDoanhThu.Text = "Doanh thu";
            this.btnTabDoanhThu.UseVisualStyleBackColor = true;
            // btnTabLoiNhuan
            this.btnTabLoiNhuan.Location = new System.Drawing.Point(716, 12);
            this.btnTabLoiNhuan.Name = "btnTabLoiNhuan";
            this.btnTabLoiNhuan.Size = new System.Drawing.Size(110, 32);
            this.btnTabLoiNhuan.TabIndex = 5;
            this.btnTabLoiNhuan.Text = "Lợi nhuận";
            this.btnTabLoiNhuan.UseVisualStyleBackColor = true;
            // btnTabDonHang
            this.btnTabDonHang.Location = new System.Drawing.Point(832, 12);
            this.btnTabDonHang.Name = "btnTabDonHang";
            this.btnTabDonHang.Size = new System.Drawing.Size(110, 32);
            this.btnTabDonHang.TabIndex = 6;
            this.btnTabDonHang.Text = "Đơn hàng";
            this.btnTabDonHang.UseVisualStyleBackColor = true;
            // flowKpi
            this.flowKpi.AutoSize = true;
            this.flowKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowKpi.Location = new System.Drawing.Point(0, 108);
            this.flowKpi.Name = "flowKpi";
            this.flowKpi.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.flowKpi.Size = new System.Drawing.Size(1100, 116);
            this.flowKpi.TabIndex = 2;
            // pnlChart
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Controls.Add(this.lblChartPlaceholder);
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart.Location = new System.Drawing.Point(0, 224);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(16);
            this.pnlChart.Size = new System.Drawing.Size(1100, 180);
            this.pnlChart.TabIndex = 3;
            // lblChartTitle
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblChartTitle.Height = 28;
            this.lblChartTitle.Text = "Biểu đồ doanh thu theo ngày";
            // lblChartPlaceholder
            this.lblChartPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChartPlaceholder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblChartPlaceholder.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblChartPlaceholder.Text = "📈 Khu vực biểu đồ (kết nối dữ liệu sau)";
            this.lblChartPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // pnlGrid
            this.pnlGrid.Controls.Add(this.dgvBaoCao);
            this.pnlGrid.Controls.Add(this.txtSoLuongHoaDon);
            this.pnlGrid.Controls.Add(this.lblSoLuongHoaDon);
            this.pnlGrid.Controls.Add(this.txtTongDoanhThu);
            this.pnlGrid.Controls.Add(this.lblTongDoanhThu);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 404);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12);
            this.pnlGrid.Size = new System.Drawing.Size(1100, 296);
            this.pnlGrid.TabIndex = 4;
            // dgvBaoCao
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(12, 12);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.TabIndex = 0;
            // lblTongDoanhThu
            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(12, 228);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblTongDoanhThu.Size = new System.Drawing.Size(1076, 28);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // txtTongDoanhThu
            this.txtTongDoanhThu.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtTongDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.txtTongDoanhThu.Location = new System.Drawing.Point(12, 256);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(1076, 32);
            this.txtTongDoanhThu.TabIndex = 2;
            this.txtTongDoanhThu.Text = "0 đ";
            // lblSoLuongHoaDon
            this.lblSoLuongHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSoLuongHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongHoaDon.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblSoLuongHoaDon.Location = new System.Drawing.Point(12, 288);
            this.lblSoLuongHoaDon.Name = "lblSoLuongHoaDon";
            this.lblSoLuongHoaDon.Size = new System.Drawing.Size(1076, 0);
            this.lblSoLuongHoaDon.TabIndex = 3;
            this.lblSoLuongHoaDon.Visible = false;
            // txtSoLuongHoaDon
            this.txtSoLuongHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSoLuongHoaDon.Location = new System.Drawing.Point(12, 288);
            this.txtSoLuongHoaDon.Name = "txtSoLuongHoaDon";
            this.txtSoLuongHoaDon.ReadOnly = true;
            this.txtSoLuongHoaDon.Size = new System.Drawing.Size(1076, 0);
            this.txtSoLuongHoaDon.TabIndex = 4;
            this.txtSoLuongHoaDon.Visible = false;
            // UCBaoCao
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.flowKpi);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UCBaoCao";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UCBaoCao_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
