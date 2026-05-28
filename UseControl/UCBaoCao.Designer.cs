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
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.flowKpi = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.lblChartPlaceholder = new System.Windows.Forms.Label();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.txtSoLuongHoaDon = new System.Windows.Forms.TextBox();
            this.lblSoLuongHoaDon = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(868, 34);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(868, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 BÁO CÁO — Thống kê doanh thu";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnXemBaoCao);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 34);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.pnlFilter.Size = new System.Drawing.Size(868, 36);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(330, 8);
            this.btnXemBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(105, 21);
            this.btnXemBaoCao.TabIndex = 3;
            this.btnXemBaoCao.Text = "🔍 Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(222, 9);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(98, 20);
            this.dtpDenNgay.TabIndex = 2;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblDenNgay.Location = new System.Drawing.Point(168, 12);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(67, 17);
            this.lblDenNgay.TabIndex = 7;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(60, 9);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(98, 20);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTuNgay.Location = new System.Drawing.Point(12, 12);
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(59, 17);
            this.lblTuNgay.TabIndex = 8;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // flowKpi
            // 
            this.flowKpi.AutoSize = true;
            this.flowKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowKpi.Location = new System.Drawing.Point(0, 70);
            this.flowKpi.Margin = new System.Windows.Forms.Padding(2);
            this.flowKpi.Name = "flowKpi";
            this.flowKpi.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.flowKpi.Size = new System.Drawing.Size(868, 6);
            this.flowKpi.TabIndex = 2;
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Controls.Add(this.lblChartPlaceholder);
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart.Location = new System.Drawing.Point(0, 76);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(2);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlChart.Size = new System.Drawing.Size(868, 117);
            this.pnlChart.TabIndex = 3;
            // 
            // lblChartPlaceholder
            // 
            this.lblChartPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChartPlaceholder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblChartPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblChartPlaceholder.Location = new System.Drawing.Point(12, 28);
            this.lblChartPlaceholder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChartPlaceholder.Name = "lblChartPlaceholder";
            this.lblChartPlaceholder.Size = new System.Drawing.Size(844, 79);
            this.lblChartPlaceholder.TabIndex = 0;
            this.lblChartPlaceholder.Text = "📈 Khu vực biểu đồ (kết nối dữ liệu sau)";
            this.lblChartPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblChartTitle.Location = new System.Drawing.Point(12, 10);
            this.lblChartTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(844, 18);
            this.lblChartTitle.TabIndex = 1;
            this.lblChartTitle.Text = "Biểu đồ doanh thu theo ngày";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvBaoCao);
            this.pnlGrid.Controls.Add(this.txtSoLuongHoaDon);
            this.pnlGrid.Controls.Add(this.lblSoLuongHoaDon);
            this.pnlGrid.Controls.Add(this.txtTongDoanhThu);
            this.pnlGrid.Controls.Add(this.lblTongDoanhThu);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 193);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.pnlGrid.Size = new System.Drawing.Size(868, 284);
            this.pnlGrid.TabIndex = 4;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(9, 8);
            this.dgvBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.Size = new System.Drawing.Size(850, 198);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // txtSoLuongHoaDon
            // 
            this.txtSoLuongHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSoLuongHoaDon.Location = new System.Drawing.Point(9, 206);
            this.txtSoLuongHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuongHoaDon.Name = "txtSoLuongHoaDon";
            this.txtSoLuongHoaDon.ReadOnly = true;
            this.txtSoLuongHoaDon.Size = new System.Drawing.Size(850, 20);
            this.txtSoLuongHoaDon.TabIndex = 4;
            this.txtSoLuongHoaDon.Visible = false;
            // 
            // lblSoLuongHoaDon
            // 
            this.lblSoLuongHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSoLuongHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSoLuongHoaDon.Location = new System.Drawing.Point(9, 226);
            this.lblSoLuongHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoLuongHoaDon.Name = "lblSoLuongHoaDon";
            this.lblSoLuongHoaDon.Size = new System.Drawing.Size(850, 0);
            this.lblSoLuongHoaDon.TabIndex = 3;
            this.lblSoLuongHoaDon.Visible = false;
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTongDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.Black;
            this.txtTongDoanhThu.Location = new System.Drawing.Point(9, 226);
            this.txtTongDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(850, 32);
            this.txtTongDoanhThu.TabIndex = 2;
            this.txtTongDoanhThu.Text = "0 đ";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(9, 258);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTongDoanhThu.Size = new System.Drawing.Size(850, 18);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // UCBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.flowKpi);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCBaoCao";
            this.Size = new System.Drawing.Size(868, 477);
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
