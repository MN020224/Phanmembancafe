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
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;

        // Khai báo các control mới cho phương thức thanh toán
        private System.Windows.Forms.Label lblPhuongThucThanhToan;
        private System.Windows.Forms.ComboBox cboPhuongThucThanhToan;
        private System.Windows.Forms.Panel pnlThanhToan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlDonHang = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.lblPhuongThucThanhToan = new System.Windows.Forms.Label();
            this.cboPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHuyHoaDon = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.flowSanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.btnCaPhe = new System.Windows.Forms.Button();
            this.btnTra = new System.Windows.Forms.Button();
            this.btnSinhTo = new System.Windows.Forms.Button();
            this.btnBanh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlThanhToan.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(120, 97);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(80, 22);
            this.nudSoLuong.TabIndex = 0;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1257, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1257, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "☕ CAFE ORDER - HỆ THỐNG BÁN HÀNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlDonHang);
            this.pnlBody.Controls.Add(this.pnlSanPham);
            this.pnlBody.Controls.Add(this.pnlSidebar);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 64);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pnlBody.Size = new System.Drawing.Size(1257, 683);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlDonHang
            // 
            this.pnlDonHang.BackColor = System.Drawing.Color.White;
            this.pnlDonHang.Controls.Add(this.dgvGioHang);
            this.pnlDonHang.Controls.Add(this.pnlFooter);
            this.pnlDonHang.Controls.Add(this.lblDonHang);
            this.pnlDonHang.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDonHang.Location = new System.Drawing.Point(661, 11);
            this.pnlDonHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDonHang.Name = "pnlDonHang";
            this.pnlDonHang.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.pnlDonHang.Size = new System.Drawing.Size(584, 661);
            this.pnlDonHang.TabIndex = 2;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.dgvGioHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(17, 59);
            this.dgvGioHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(550, 367);
            this.dgvGioHang.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.pnlFooter.Controls.Add(this.pnlThanhToan);
            this.pnlFooter.Controls.Add(this.lblSoLuong);
            this.pnlFooter.Controls.Add(this.btnXoaMon);
            this.pnlFooter.Controls.Add(this.btnThemMon);
            this.pnlFooter.Controls.Add(this.btnThanhToan);
            this.pnlFooter.Controls.Add(this.btnHuyHoaDon);
            this.pnlFooter.Controls.Add(this.txtTongTien);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(17, 426);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(550, 219);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.lblPhuongThucThanhToan);
            this.pnlThanhToan.Controls.Add(this.cboPhuongThucThanhToan);
            this.pnlThanhToan.Location = new System.Drawing.Point(297, 75);
            this.pnlThanhToan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(223, 87);
            this.pnlThanhToan.TabIndex = 8;
            // 
            // lblPhuongThucThanhToan
            // 
            this.lblPhuongThucThanhToan.AutoSize = true;
            this.lblPhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPhuongThucThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblPhuongThucThanhToan.Location = new System.Drawing.Point(4, 10);
            this.lblPhuongThucThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhuongThucThanhToan.Name = "lblPhuongThucThanhToan";
            this.lblPhuongThucThanhToan.Size = new System.Drawing.Size(163, 19);
            this.lblPhuongThucThanhToan.TabIndex = 0;
            this.lblPhuongThucThanhToan.Text = "Phương thức thanh toán:";
            // 
            // cboPhuongThucThanhToan
            // 
            this.cboPhuongThucThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPhuongThucThanhToan.FormattingEnabled = true;
            this.cboPhuongThucThanhToan.Items.AddRange(new object[] {
            "💵 Tiền mặt",
            "🏦 Chuyển khoản",
            "📱 Ví điện tử"});
            this.cboPhuongThucThanhToan.Location = new System.Drawing.Point(4, 46);
            this.cboPhuongThucThanhToan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPhuongThucThanhToan.Name = "cboPhuongThucThanhToan";
            this.cboPhuongThucThanhToan.Size = new System.Drawing.Size(213, 28);
            this.cboPhuongThucThanhToan.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuong.Location = new System.Drawing.Point(4, 107);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(0, 20);
            this.lblSoLuong.TabIndex = 7;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnXoaMon.FlatAppearance.BorderSize = 0;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.Location = new System.Drawing.Point(4, 167);
            this.btnXoaMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(149, 43);
            this.btnXoaMon.TabIndex = 6;
            this.btnXoaMon.Text = "XÓA MÓN";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(4, 119);
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(149, 43);
            this.btnThemMon.TabIndex = 5;
            this.btnThemMon.Text = "THÊM MÓN";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.BtnThemMon_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(297, 166);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(223, 43);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "💰 THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.BtnThanhToan_Click);
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnHuyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHuyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(4, 71);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(149, 43);
            this.btnHuyHoaDon.TabIndex = 2;
            this.btnHuyHoaDon.Text = "HỦY HÓA ĐƠN";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.Location = new System.Drawing.Point(175, 11);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(326, 43);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.Text = "0 VNĐ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTongTien.Location = new System.Drawing.Point(4, 11);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(149, 32);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG TIỀN:";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDonHang
            // 
            this.lblDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDonHang.Location = new System.Drawing.Point(17, 16);
            this.lblDonHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(550, 43);
            this.lblDonHang.TabIndex = 0;
            this.lblDonHang.Text = "🧾 HÓA ĐƠN HIỆN TẠI";
            this.lblDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSanPham
            // 
            this.pnlSanPham.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSanPham.Controls.Add(this.flowSanPham);
            this.pnlSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSanPham.Location = new System.Drawing.Point(240, 11);
            this.pnlSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSanPham.Name = "pnlSanPham";
            this.pnlSanPham.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.pnlSanPham.Size = new System.Drawing.Size(1005, 661);
            this.pnlSanPham.TabIndex = 1;
            // 
            // flowSanPham
            // 
            this.flowSanPham.AutoScroll = true;
            this.flowSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.flowSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSanPham.Location = new System.Drawing.Point(12, 11);
            this.flowSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowSanPham.Name = "flowSanPham";
            this.flowSanPham.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowSanPham.Size = new System.Drawing.Size(981, 639);
            this.flowSanPham.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.lblDanhMuc);
            this.pnlSidebar.Controls.Add(this.btnCaPhe);
            this.pnlSidebar.Controls.Add(this.btnTra);
            this.pnlSidebar.Controls.Add(this.btnSinhTo);
            this.pnlSidebar.Controls.Add(this.btnBanh);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(12, 11);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 11, 0, 11);
            this.pnlSidebar.Size = new System.Drawing.Size(228, 661);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMuc.ForeColor = System.Drawing.Color.White;
            this.lblDanhMuc.Location = new System.Drawing.Point(0, 11);
            this.lblDanhMuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Padding = new System.Windows.Forms.Padding(17, 11, 0, 11);
            this.lblDanhMuc.Size = new System.Drawing.Size(228, 48);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "📂 DANH MỤC";
            // 
            // btnCaPhe
            // 
            this.btnCaPhe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnCaPhe.FlatAppearance.BorderSize = 0;
            this.btnCaPhe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaPhe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaPhe.ForeColor = System.Drawing.Color.White;
            this.btnCaPhe.Location = new System.Drawing.Point(0, 59);
            this.btnCaPhe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCaPhe.Name = "btnCaPhe";
            this.btnCaPhe.Size = new System.Drawing.Size(228, 59);
            this.btnCaPhe.TabIndex = 1;
            this.btnCaPhe.Text = "☕ Cà phê";
            this.btnCaPhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaPhe.UseVisualStyleBackColor = false;
            // 
            // btnTra
            // 
            this.btnTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnTra.FlatAppearance.BorderSize = 0;
            this.btnTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTra.ForeColor = System.Drawing.Color.White;
            this.btnTra.Location = new System.Drawing.Point(0, 117);
            this.btnTra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(228, 59);
            this.btnTra.TabIndex = 2;
            this.btnTra.Text = "🍵 Trà";
            this.btnTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTra.UseVisualStyleBackColor = false;
            // 
            // btnSinhTo
            // 
            this.btnSinhTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnSinhTo.FlatAppearance.BorderSize = 0;
            this.btnSinhTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhTo.ForeColor = System.Drawing.Color.White;
            this.btnSinhTo.Location = new System.Drawing.Point(0, 176);
            this.btnSinhTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSinhTo.Name = "btnSinhTo";
            this.btnSinhTo.Size = new System.Drawing.Size(228, 59);
            this.btnSinhTo.TabIndex = 3;
            this.btnSinhTo.Text = "🥤 Sinh tố";
            this.btnSinhTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinhTo.UseVisualStyleBackColor = false;
            // 
            // btnBanh
            // 
            this.btnBanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnBanh.FlatAppearance.BorderSize = 0;
            this.btnBanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanh.ForeColor = System.Drawing.Color.White;
            this.btnBanh.Location = new System.Drawing.Point(0, 235);
            this.btnBanh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBanh.Name = "btnBanh";
            this.btnBanh.Size = new System.Drawing.Size(228, 59);
            this.btnBanh.TabIndex = 4;
            this.btnBanh.Text = "🥐 Bánh ngọt";
            this.btnBanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanh.UseVisualStyleBackColor = false;
            // 
            // UCBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCBanHang";
            this.Size = new System.Drawing.Size(1257, 747);
            this.Load += new System.EventHandler(this.UCBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlDonHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.pnlSanPham.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}