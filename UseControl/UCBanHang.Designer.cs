namespace CafeOrder
{
    partial class UCBanHang
    {
        private System.ComponentModel.IContainer components = null;

        // ============= CÁC THÀNH PHẦN GIAO DIỆN =============

        // Panel Body chính
        private System.Windows.Forms.Panel pnlBody;

        // Sidebar - Phần 1 (Danh mục)
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.Panel pnlDanhMucList;

        // Panel Sản phẩm - Phần 2 (Danh sách sản phẩm - 2/4)
        private System.Windows.Forms.Panel pnlSanPham;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnXoaTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flowSanPham;

        // Panel Hóa đơn - Phần 3 (1/4)
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
        private System.Windows.Forms.Label lblPhuongThucThanhToan;
        private System.Windows.Forms.ComboBox cboPhuongThucThanhToan;
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGhiChu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlDanhMucList = new System.Windows.Forms.Panel();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.flowSanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnXoaTimKiem = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlDonHang = new System.Windows.Forms.Panel();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            this.pnlDonHang.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudSoLuong.Location = new System.Drawing.Point(132, 139);
            this.nudSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(41, 25);
            this.nudSoLuong.TabIndex = 0;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlSanPham);
            this.pnlBody.Controls.Add(this.pnlDonHang);
            this.pnlBody.Controls.Add(this.pnlSidebar);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBody.Size = new System.Drawing.Size(750, 528);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.pnlDanhMucList);
            this.pnlSidebar.Controls.Add(this.lblDanhMuc);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(8, 8);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlSidebar.Size = new System.Drawing.Size(150, 512);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlDanhMucList
            // 
            this.pnlDanhMucList.AutoScroll = true;
            this.pnlDanhMucList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(57)))), ((int)(((byte)(39)))));
            this.pnlDanhMucList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhMucList.Location = new System.Drawing.Point(0, 37);
            this.pnlDanhMucList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDanhMucList.Name = "pnlDanhMucList";
            this.pnlDanhMucList.Size = new System.Drawing.Size(150, 471);
            this.pnlDanhMucList.TabIndex = 1;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDanhMuc.ForeColor = System.Drawing.Color.White;
            this.lblDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.lblDanhMuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Padding = new System.Windows.Forms.Padding(11, 8, 0, 8);
            this.lblDanhMuc.Size = new System.Drawing.Size(150, 37);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "📂 DANH MỤC";
            this.lblDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSanPham
            // 
            this.pnlSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlSanPham.Controls.Add(this.flowSanPham);
            this.pnlSanPham.Controls.Add(this.pnlTimKiem);
            this.pnlSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSanPham.Location = new System.Drawing.Point(8, 8);
            this.pnlSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSanPham.Name = "pnlSanPham";
            this.pnlSanPham.Padding = new System.Windows.Forms.Padding(8);
            this.pnlSanPham.Size = new System.Drawing.Size(539, 512);
            this.pnlSanPham.TabIndex = 1;
            this.pnlSanPham.Controls.SetChildIndex(this.pnlTimKiem, 0);
            this.pnlSanPham.Controls.SetChildIndex(this.flowSanPham, 1);
            // 
            // flowSanPham
            // 
            this.flowSanPham.AutoScroll = true;
            this.flowSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.flowSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSanPham.Location = new System.Drawing.Point(50, 100);
            this.flowSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.flowSanPham.Name = "flowSanPham";
            this.flowSanPham.Padding = new System.Windows.Forms.Padding(4);
            this.flowSanPham.Size = new System.Drawing.Size(523, 451);
            this.flowSanPham.TabIndex = 0;
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.BackColor = System.Drawing.Color.White;
            this.pnlTimKiem.Controls.Add(this.btnXoaTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(8, 8);
            this.pnlTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTimKiem.Size = new System.Drawing.Size(523, 45);
            this.pnlTimKiem.TabIndex = 1;
            // 
            // btnXoaTimKiem
            // 
            this.btnXoaTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaTimKiem.FlatAppearance.BorderSize = 0;
            this.btnXoaTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnXoaTimKiem.Location = new System.Drawing.Point(452, 8);
            this.btnXoaTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaTimKiem.Name = "btnXoaTimKiem";
            this.btnXoaTimKiem.Size = new System.Drawing.Size(64, 27);
            this.btnXoaTimKiem.TabIndex = 2;
            this.btnXoaTimKiem.Text = "✕ Xóa";
            this.btnXoaTimKiem.UseVisualStyleBackColor = false;
            this.btnXoaTimKiem.Click += new System.EventHandler(this.BtnXoaTimKiem_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTimKiem.Location = new System.Drawing.Point(8, 6);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(75, 28);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "🔍 Tìm:";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiem.Location = new System.Drawing.Point(86, 8);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(359, 27);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.TxtTimKiem_TextChanged);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTimKiem_KeyDown);
            // 
            // pnlDonHang
            // 
            this.pnlDonHang.BackColor = System.Drawing.Color.White;
            this.pnlDonHang.Controls.Add(this.dgvGioHang);
            this.pnlDonHang.Controls.Add(this.pnlFooter);
            this.pnlDonHang.Controls.Add(this.lblDonHang);
            this.pnlDonHang.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDonHang.Location = new System.Drawing.Point(547, 8);
            this.pnlDonHang.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDonHang.Name = "pnlDonHang";
            this.pnlDonHang.Padding = new System.Windows.Forms.Padding(8);
            this.pnlDonHang.Size = new System.Drawing.Size(195, 512);
            this.pnlDonHang.TabIndex = 2;
            // 
            // lblDonHang
            // 
            this.lblDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDonHang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDonHang.Location = new System.Drawing.Point(8, 8);
            this.lblDonHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(179, 32);
            this.lblDonHang.TabIndex = 0;
            this.lblDonHang.Text = "🧾 HÓA ĐƠN";
            this.lblDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.pnlFooter.Controls.Add(this.txtGhiChu);
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Controls.Add(this.pnlThanhToan);
            this.pnlFooter.Controls.Add(this.btnXoaMon);
            this.pnlFooter.Controls.Add(this.btnThemMon);
            this.pnlFooter.Controls.Add(this.btnThanhToan);
            this.pnlFooter.Controls.Add(this.btnHuyHoaDon);
            this.pnlFooter.Controls.Add(this.txtTongTien);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(8, 201);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(8);
            this.pnlFooter.Size = new System.Drawing.Size(179, 303);
            this.pnlFooter.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(59, 44);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(72, 25);
            this.txtGhiChu.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(61, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ghi chú:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThanhToan.Controls.Add(this.lblPhuongThucThanhToan);
            this.pnlThanhToan.Controls.Add(this.cboPhuongThucThanhToan);
            this.pnlThanhToan.Location = new System.Drawing.Point(5, 210);
            this.pnlThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(169, 48);
            this.pnlThanhToan.TabIndex = 8;
            // 
            // lblPhuongThucThanhToan
            // 
            this.lblPhuongThucThanhToan.AutoSize = true;
            this.lblPhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPhuongThucThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblPhuongThucThanhToan.Location = new System.Drawing.Point(4, 3);
            this.lblPhuongThucThanhToan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhuongThucThanhToan.Name = "lblPhuongThucThanhToan";
            this.lblPhuongThucThanhToan.Size = new System.Drawing.Size(138, 13);
            this.lblPhuongThucThanhToan.TabIndex = 0;
            this.lblPhuongThucThanhToan.Text = "Phương thức thanh toán:";
            // 
            // cboPhuongThucThanhToan
            // 
            this.cboPhuongThucThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhuongThucThanhToan.FormattingEnabled = true;
            this.cboPhuongThucThanhToan.Items.AddRange(new object[] {
            "💵 Tiền mặt",
            "🏦 Chuyển khoản",
            "📱 Ví điện tử"});
            this.cboPhuongThucThanhToan.Location = new System.Drawing.Point(7, 19);
            this.cboPhuongThucThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.cboPhuongThucThanhToan.Name = "cboPhuongThucThanhToan";
            this.cboPhuongThucThanhToan.Size = new System.Drawing.Size(138, 25);
            this.cboPhuongThucThanhToan.TabIndex = 1;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSoLuong.Location = new System.Drawing.Point(83, 141);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(45, 23);
            this.lblSoLuong.TabIndex = 7;
            this.lblSoLuong.Text = "Số lượng:";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMon.FlatAppearance.BorderSize = 0;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.Location = new System.Drawing.Point(109, 180);
            this.btnXoaMon.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(60, 26);
            this.btnXoaMon.TabIndex = 6;
            this.btnXoaMon.Text = "🗑 XÓA";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(10, 139);
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(60, 26);
            this.btnThemMon.TabIndex = 5;
            this.btnThemMon.Text = "➕ THÊM";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.BtnThemMon_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(12, 262);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(161, 31);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "💰 THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.BtnThanhToan_Click);
            // 
            // btnHuyHoaDon
            // 
            this.btnHuyHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnHuyHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHuyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyHoaDon.Location = new System.Drawing.Point(10, 180);
            this.btnHuyHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyHoaDon.Name = "btnHuyHoaDon";
            this.btnHuyHoaDon.Size = new System.Drawing.Size(60, 26);
            this.btnHuyHoaDon.TabIndex = 2;
            this.btnHuyHoaDon.Text = "✖ HỦY HĐ";
            this.btnHuyHoaDon.UseVisualStyleBackColor = false;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.txtTongTien.Location = new System.Drawing.Point(59, 99);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(120, 36);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.Text = "0 VNĐ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTongTien.Location = new System.Drawing.Point(53, 71);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(126, 26);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "💰 TỔNG TIỀN:";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dgvGioHang.Location = new System.Drawing.Point(8, 8);
            this.dgvGioHang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(179, 496);
            this.dgvGioHang.TabIndex = 1;
            // 
            // UCBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlBody);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCBanHang";
            this.Size = new System.Drawing.Size(750, 528);
            this.Load += new System.EventHandler(this.UCBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSanPham.ResumeLayout(false);
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.pnlDonHang.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
