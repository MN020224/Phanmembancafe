namespace CafeOrder
{
    partial class UCBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label lblSoLuongHoaDon;
        private System.Windows.Forms.TextBox txtSoLuongHoaDon;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.GroupBox grpThongKe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpLoc = new System.Windows.Forms.GroupBox();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblSoLuongHoaDon = new System.Windows.Forms.Label();
            this.txtSoLuongHoaDon = new System.Windows.Forms.TextBox();

            this.grpLoc.SuspendLayout();
            this.grpThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();

            // grpLoc
            this.grpLoc.Text = "📅 CHỌN THỜI GIAN";
            this.grpLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoc.Size = new System.Drawing.Size(1000, 80);
            this.grpLoc.Padding = new System.Windows.Forms.Padding(10);

            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(20, 35);
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 27);

            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(220, 35);
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 27);

            // btnXemBaoCao
            this.btnXemBaoCao.Text = "🔍 XEM BÁO CÁO";
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Location = new System.Drawing.Point(400, 30);
            this.btnXemBaoCao.Size = new System.Drawing.Size(150, 35);

            // grpThongKe
            this.grpThongKe.Text = "📊 KẾT QUẢ THỐNG KÊ";
            this.grpThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongKe.Padding = new System.Windows.Forms.Padding(10);

            // dgvBaoCao
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCao.ReadOnly = true;

            // lblTongDoanhThu
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(20, 520);

            // txtTongDoanhThu
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.Green;
            this.txtTongDoanhThu.BackColor = System.Drawing.Color.White;
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(250, 32);
            this.txtTongDoanhThu.Location = new System.Drawing.Point(180, 515);

            // lblSoLuongHoaDon
            this.lblSoLuongHoaDon.Text = "Số hóa đơn:";
            this.lblSoLuongHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongHoaDon.Location = new System.Drawing.Point(500, 520);

            // txtSoLuongHoaDon
            this.txtSoLuongHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtSoLuongHoaDon.ForeColor = System.Drawing.Color.Blue;
            this.txtSoLuongHoaDon.BackColor = System.Drawing.Color.White;
            this.txtSoLuongHoaDon.ReadOnly = true;
            this.txtSoLuongHoaDon.Size = new System.Drawing.Size(150, 32);
            this.txtSoLuongHoaDon.Location = new System.Drawing.Point(630, 515);

            // Thêm controls
            this.grpLoc.Controls.Add(this.dtpTuNgay);
            this.grpLoc.Controls.Add(this.dtpDenNgay);
            this.grpLoc.Controls.Add(this.btnXemBaoCao);

            this.grpThongKe.Controls.Add(this.dgvBaoCao);
            this.grpThongKe.Controls.Add(this.lblTongDoanhThu);
            this.grpThongKe.Controls.Add(this.txtTongDoanhThu);
            this.grpThongKe.Controls.Add(this.lblSoLuongHoaDon);
            this.grpThongKe.Controls.Add(this.txtSoLuongHoaDon);

            this.Controls.Add(this.grpThongKe);
            this.Controls.Add(this.grpLoc);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "UCBaoCao";
            this.Size = new System.Drawing.Size(1000, 600);

            this.grpLoc.ResumeLayout(false);
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
        }
    }
}