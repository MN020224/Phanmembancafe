namespace CafeOrder
{
    partial class UCBanHang
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.Button btnCaPhe;
        private System.Windows.Forms.Button btnTra;
        private System.Windows.Forms.Button btnSinhTo;
        private System.Windows.Forms.Button btnBanh;
        private System.Windows.Forms.Panel pnlSanPham;
        private System.Windows.Forms.FlowLayoutPanel flowSanPham;
        private System.Windows.Forms.Panel pnlDonHang;
        private System.Windows.Forms.Label lblDonHang;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnHuyHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemMon;

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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.btnCaPhe = new System.Windows.Forms.Button();
            this.btnTra = new System.Windows.Forms.Button();
            this.btnSinhTo = new System.Windows.Forms.Button();
            this.btnBanh = new System.Windows.Forms.Button();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.flowSanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDonHang = new System.Windows.Forms.Panel();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            this.pnlDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
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
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1100, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 BÁN HÀNG — Chọn món và thanh toán";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // pnlBody
            this.pnlBody.Controls.Add(this.pnlSanPham);
            this.pnlBody.Controls.Add(this.pnlDonHang);
            this.pnlBody.Controls.Add(this.pnlSidebar);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 52);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBody.Size = new System.Drawing.Size(1100, 648);
            this.pnlBody.TabIndex = 1;
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlSidebar.Controls.Add(this.lblDanhMuc);
            this.pnlSidebar.Controls.Add(this.btnCaPhe);
            this.pnlSidebar.Controls.Add(this.btnTra);
            this.pnlSidebar.Controls.Add(this.btnSinhTo);
            this.pnlSidebar.Controls.Add(this.btnBanh);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(8, 8);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlSidebar.Size = new System.Drawing.Size(168, 632);
            this.pnlSidebar.TabIndex = 0;
            // lblDanhMuc
            this.lblDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDanhMuc.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.lblDanhMuc.Location = new System.Drawing.Point(0, 8);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Padding = new System.Windows.Forms.Padding(12, 8, 0, 8);
            this.lblDanhMuc.Size = new System.Drawing.Size(168, 36);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "DANH MỤC";
            // btnCaPhe
            this.btnCaPhe.Location = new System.Drawing.Point(0, 44);
            this.btnCaPhe.Name = "btnCaPhe";
            this.btnCaPhe.Size = new System.Drawing.Size(168, 48);
            this.btnCaPhe.TabIndex = 1;
            this.btnCaPhe.Text = "☕  Cà phê";
            this.btnCaPhe.UseVisualStyleBackColor = true;
            // btnTra
            this.btnTra.Location = new System.Drawing.Point(0, 92);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(168, 48);
            this.btnTra.TabIndex = 2;
            this.btnTra.Text = "🍵  Trà";
            this.btnTra.UseVisualStyleBackColor = true;
            // btnSinhTo
            this.btnSinhTo.Location = new System.Drawing.Point(0, 140);
            this.btnSinhTo.Name = "btnSinhTo";
            this.btnSinhTo.Size = new System.Drawing.Size(168, 48);
            this.btnSinhTo.TabIndex = 3;
            this.btnSinhTo.Text = "🥤  Sinh tố";
            this.btnSinhTo.UseVisualStyleBackColor = true;
            // btnBanh
            this.btnBanh.Location = new System.Drawing.Point(0, 188);
            this.btnBanh.Name = "btnBanh";
            this.btnBanh.Size = new System.Drawing.Size(168, 48);
            this.btnBanh.TabIndex = 4;
            this.btnBanh.Text = "🥐  Bánh ngọt";
            this.btnBanh.UseVisualStyleBackColor = true;
            // pnlSanPham
            this.pnlSanPham.BackColor = System.Drawing.Color.White;
            this.pnlSanPham.Controls.Add(this.flowSanPham);
            this.pnlSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSanPham.Location = new System.Drawing.Point(176, 8);
            this.pnlSanPham.Name = "pnlSanPham";
            this.pnlSanPham.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSanPham.Size = new System.Drawing.Size(536, 632);
            this.pnlSanPham.TabIndex = 1;
            // flowSanPham
            this.flowSanPham.AutoScroll = true;
            this.flowSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSanPham.Location = new System.Drawing.Point(12, 12);
            this.flowSanPham.Name = "flowSanPham";
            this.flowSanPham.Padding = new System.Windows.Forms.Padding(4);
            this.flowSanPham.Size = new System.Drawing.Size(512, 608);
            this.flowSanPham.TabIndex = 0;
            // pnlDonHang
            this.pnlDonHang.BackColor = System.Drawing.Color.White;
            this.pnlDonHang.Controls.Add(this.dgvGioHang);
            this.pnlDonHang.Controls.Add(this.pnlFooter);
            this.pnlDonHang.Controls.Add(this.lblDonHang);
            this.pnlDonHang.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDonHang.Location = new System.Drawing.Point(712, 8);
            this.pnlDonHang.Name = "pnlDonHang";
            this.pnlDonHang.Padding = new System.Windows.Forms.Padding(12);
            this.pnlDonHang.Size = new System.Drawing.Size(380, 632);
            this.pnlDonHang.TabIndex = 2;
            // lblDonHang
            this.lblDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDonHang.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblDonHang.Location = new System.Drawing.Point(12, 12);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(356, 32);
            this.lblDonHang.TabIndex = 0;
            this.lblDonHang.Text = "🧾 Hóa đơn hiện tại";
            // dgvGioHang
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(12, 44);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(356, 456);
            this.dgvGioHang.TabIndex = 1;
            // pnlFooter
            this.pnlFooter.Controls.Add(this.btnThemMon);
            this.pnlFooter.Controls.Add(this.nudSoLuong);
            this.pnlFooter.Controls.Add(this.btnThanhToan);
            this.pnlFooter.Controls.Add(this.btnHuyHoaDon);
            this.pnlFooter.Controls.Add(this.txtTongTien);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(12, 500);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(356, 120);
            this.pnlFooter.TabIndex = 2;
            // lblTongTien
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTongTien.Location = new System.Drawing.Point(4, 8);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 28);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG TIỀN";
            // txtTongTien
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.txtTongTien.Location = new System.Drawing.Point(110, 4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(238, 39);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.Text = "0 đ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // btnHuyHoaDon
            this.btnHuyHoaDon.Location = new System.Drawing.Point(4, 52);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(120, 36);
            this.btnHuyHoaDon.TabIndex = 2;
            this.btnHuyHoaDon.Text = "Hủy hóa đơn";
            this.btnHuyHoaDon.UseVisualStyleBackColor = true;
            // btnThanhToan
            this.btnThanhToan.Location = new System.Drawing.Point(130, 48);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(218, 44);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "💰 THANH TOÁN (F9)";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // nudSoLuong
            this.nudSoLuong.Location = new System.Drawing.Point(4, 92);
            this.nudSoLuong.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(56, 27);
            this.nudSoLuong.TabIndex = 4;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // btnThemMon
            this.btnThemMon.Location = new System.Drawing.Point(66, 90);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(120, 30);
            this.btnThemMon.TabIndex = 5;
            this.btnThemMon.Text = "➕ Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            // UCBanHang
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UCBanHang";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UCBanHang_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSanPham.ResumeLayout(false);
            this.pnlDonHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
