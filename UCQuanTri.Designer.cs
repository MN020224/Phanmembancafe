namespace CafeOrder
{
    partial class UCQuanTri
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnNavSanPham;
        private System.Windows.Forms.Button btnNavDanhmuc;
        private System.Windows.Forms.Button btnNavBaocao;
        private System.Windows.Forms.Button btnNavCaiDat;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMonAn;
        private System.Windows.Forms.TabPage tabDanhMuc;
        private System.Windows.Forms.TabPage tabPageBaoCao;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.Panel pnlToolbarMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSuaMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.Panel pnlToolbarDm;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.Button btnThemDanhMuc;
        private System.Windows.Forms.Button btnSuaDanhMuc;
        private System.Windows.Forms.Button btnXoaDanhMuc;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;

        // Controls cho báo cáo
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnLocBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMonAn = new System.Windows.Forms.TabPage();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.pnlToolbarMon = new System.Windows.Forms.Panel();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnSuaMon = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.tabDanhMuc = new System.Windows.Forms.TabPage();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.pnlToolbarDm = new System.Windows.Forms.Panel();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.btnThemDanhMuc = new System.Windows.Forms.Button();
            this.btnSuaDanhMuc = new System.Windows.Forms.Button();
            this.btnXoaDanhMuc = new System.Windows.Forms.Button();
            this.tabPageBaoCao = new System.Windows.Forms.TabPage();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLocBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavBaocao = new System.Windows.Forms.Button();
            this.btnNavCaiDat = new System.Windows.Forms.Button();
            this.btnNavDanhmuc = new System.Windows.Forms.Button();
            this.btnNavSanPham = new System.Windows.Forms.Button();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.pnlToolbarMon.SuspendLayout();
            this.tabDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.pnlToolbarDm.SuspendLayout();
            this.tabPageBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.pnlNav.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 52);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1100, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚙️ QUẢN TRỊ — Sản phẩm | Danh mục | Báo cáo";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlNav);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 52);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(8);
            this.pnlMain.Size = new System.Drawing.Size(1100, 528);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.tabControl1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(208, 8);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(8);
            this.pnlContent.Size = new System.Drawing.Size(884, 512);
            this.pnlContent.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMonAn);
            this.tabControl1.Controls.Add(this.tabDanhMuc);
            this.tabControl1.Controls.Add(this.tabPageBaoCao);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 496);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMonAn
            // 
            this.tabMonAn.Controls.Add(this.dgvMonAn);
            this.tabMonAn.Controls.Add(this.pnlToolbarMon);
            this.tabMonAn.Location = new System.Drawing.Point(4, 22);
            this.tabMonAn.Name = "tabMonAn";
            this.tabMonAn.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonAn.Size = new System.Drawing.Size(860, 470);
            this.tabMonAn.TabIndex = 0;
            this.tabMonAn.Text = "Sản phẩm";
            this.tabMonAn.UseVisualStyleBackColor = true;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.Location = new System.Drawing.Point(3, 51);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.Size = new System.Drawing.Size(854, 416);
            this.dgvMonAn.TabIndex = 0;
            // 
            // pnlToolbarMon
            // 
            this.pnlToolbarMon.Controls.Add(this.txtTenMon);
            this.pnlToolbarMon.Controls.Add(this.txtGia);
            this.pnlToolbarMon.Controls.Add(this.cboDanhMuc);
            this.pnlToolbarMon.Controls.Add(this.btnThemMon);
            this.pnlToolbarMon.Controls.Add(this.btnSuaMon);
            this.pnlToolbarMon.Controls.Add(this.btnXoaMon);
            this.pnlToolbarMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarMon.Location = new System.Drawing.Point(3, 3);
            this.pnlToolbarMon.Name = "pnlToolbarMon";
            this.pnlToolbarMon.Size = new System.Drawing.Size(854, 48);
            this.pnlToolbarMon.TabIndex = 1;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(8, 14);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(180, 20);
            this.txtTenMon.TabIndex = 0;
            this.txtTenMon.Text = "Tên món";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(194, 14);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(100, 20);
            this.txtGia.TabIndex = 1;
            this.txtGia.Text = "Giá";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Location = new System.Drawing.Point(300, 13);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(140, 21);
            this.cboDanhMuc.TabIndex = 2;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(450, 8);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(85, 32);
            this.btnThemMon.TabIndex = 3;
            this.btnThemMon.Text = "➕ Thêm";
            this.btnThemMon.UseVisualStyleBackColor = true;
            // 
            // btnSuaMon
            // 
            this.btnSuaMon.Location = new System.Drawing.Point(541, 8);
            this.btnSuaMon.Name = "btnSuaMon";
            this.btnSuaMon.Size = new System.Drawing.Size(85, 32);
            this.btnSuaMon.TabIndex = 4;
            this.btnSuaMon.Text = "✏️ Sửa";
            this.btnSuaMon.UseVisualStyleBackColor = true;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Location = new System.Drawing.Point(632, 8);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(85, 32);
            this.btnXoaMon.TabIndex = 5;
            this.btnXoaMon.Text = "🗑️ Xóa";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.tabDanhMuc.Controls.Add(this.pnlToolbarDm);
            this.tabDanhMuc.Location = new System.Drawing.Point(4, 22);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhMuc.Size = new System.Drawing.Size(860, 470);
            this.tabDanhMuc.TabIndex = 1;
            this.tabDanhMuc.Text = "Danh mục";
            this.tabDanhMuc.UseVisualStyleBackColor = true;
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.Location = new System.Drawing.Point(3, 51);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.Size = new System.Drawing.Size(854, 416);
            this.dgvDanhMuc.TabIndex = 0;
            // 
            // pnlToolbarDm
            // 
            this.pnlToolbarDm.Controls.Add(this.txtTenDanhMuc);
            this.pnlToolbarDm.Controls.Add(this.btnThemDanhMuc);
            this.pnlToolbarDm.Controls.Add(this.btnSuaDanhMuc);
            this.pnlToolbarDm.Controls.Add(this.btnXoaDanhMuc);
            this.pnlToolbarDm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarDm.Location = new System.Drawing.Point(3, 3);
            this.pnlToolbarDm.Name = "pnlToolbarDm";
            this.pnlToolbarDm.Size = new System.Drawing.Size(854, 48);
            this.pnlToolbarDm.TabIndex = 1;
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Location = new System.Drawing.Point(8, 14);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(250, 20);
            this.txtTenDanhMuc.TabIndex = 0;
            this.txtTenDanhMuc.Text = "Tên danh mục";
            // 
            // btnThemDanhMuc
            // 
            this.btnThemDanhMuc.Location = new System.Drawing.Point(264, 8);
            this.btnThemDanhMuc.Name = "btnThemDanhMuc";
            this.btnThemDanhMuc.Size = new System.Drawing.Size(85, 32);
            this.btnThemDanhMuc.TabIndex = 1;
            this.btnThemDanhMuc.Text = "➕ Thêm";
            this.btnThemDanhMuc.UseVisualStyleBackColor = true;
            // 
            // btnSuaDanhMuc
            // 
            this.btnSuaDanhMuc.Location = new System.Drawing.Point(355, 8);
            this.btnSuaDanhMuc.Name = "btnSuaDanhMuc";
            this.btnSuaDanhMuc.Size = new System.Drawing.Size(85, 32);
            this.btnSuaDanhMuc.TabIndex = 2;
            this.btnSuaDanhMuc.Text = "✏️ Sửa";
            this.btnSuaDanhMuc.UseVisualStyleBackColor = true;
            // 
            // btnXoaDanhMuc
            // 
            this.btnXoaDanhMuc.Location = new System.Drawing.Point(446, 8);
            this.btnXoaDanhMuc.Name = "btnXoaDanhMuc";
            this.btnXoaDanhMuc.Size = new System.Drawing.Size(85, 32);
            this.btnXoaDanhMuc.TabIndex = 3;
            this.btnXoaDanhMuc.Text = "🗑️ Xóa";
            this.btnXoaDanhMuc.UseVisualStyleBackColor = true;
            // 
            // tabPageBaoCao
            // 
            this.tabPageBaoCao.Controls.Add(this.dgvBaoCao);
            this.tabPageBaoCao.Controls.Add(this.dtpTuNgay);
            this.tabPageBaoCao.Controls.Add(this.dtpDenNgay);
            this.tabPageBaoCao.Controls.Add(this.btnLocBaoCao);
            this.tabPageBaoCao.Controls.Add(this.btnXuatExcel);
            this.tabPageBaoCao.Controls.Add(this.lblTuNgay);
            this.tabPageBaoCao.Controls.Add(this.lblDenNgay);
            this.tabPageBaoCao.Controls.Add(this.lblTongDoanhThu);
            this.tabPageBaoCao.Controls.Add(this.cboLoaiBaoCao);
            this.tabPageBaoCao.Location = new System.Drawing.Point(4, 22);
            this.tabPageBaoCao.Name = "tabPageBaoCao";
            this.tabPageBaoCao.Size = new System.Drawing.Size(860, 470);
            this.tabPageBaoCao.TabIndex = 2;
            this.tabPageBaoCao.Text = "Báo cáo";
            this.tabPageBaoCao.UseVisualStyleBackColor = true;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(16, 112);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.Size = new System.Drawing.Size(828, 340);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(96, 24);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 20);
            this.dtpTuNgay.TabIndex = 1;
            this.dtpTuNgay.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(280, 24);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 20);
            this.dtpDenNgay.TabIndex = 2;
            this.dtpDenNgay.Value = new System.DateTime(2026, 5, 20, 3, 35, 42, 418);
            // 
            // btnLocBaoCao
            // 
            this.btnLocBaoCao.Location = new System.Drawing.Point(416, 22);
            this.btnLocBaoCao.Name = "btnLocBaoCao";
            this.btnLocBaoCao.Size = new System.Drawing.Size(100, 23);
            this.btnLocBaoCao.TabIndex = 3;
            this.btnLocBaoCao.Text = "🔍 Lọc báo cáo";
            this.btnLocBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(528, 22);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 23);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(32, 28);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(49, 13);
            this.lblTuNgay.TabIndex = 5;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(224, 28);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(56, 13);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(16, 72);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(179, 17);
            this.lblTongDoanhThu.TabIndex = 7;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.Items.AddRange(new object[] {
            "Doanh thu theo ngày",
            "Doanh thu theo tháng",
            "Món ăn bán chạy",
            "Chi tiết hóa đơn"});
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(650, 24);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(180, 21);
            this.cboLoaiBaoCao.TabIndex = 8;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.pnlNav.Controls.Add(this.btnNavBaocao);
            this.pnlNav.Controls.Add(this.btnNavCaiDat);
            this.pnlNav.Controls.Add(this.btnNavDanhmuc);
            this.pnlNav.Controls.Add(this.btnNavSanPham);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(8, 8);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlNav.Size = new System.Drawing.Size(200, 512);
            this.pnlNav.TabIndex = 1;
            // 
            // btnNavBaocao
            // 
            this.btnNavBaocao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavBaocao.FlatAppearance.BorderSize = 0;
            this.btnNavBaocao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBaocao.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavBaocao.ForeColor = System.Drawing.Color.White;
            this.btnNavBaocao.Location = new System.Drawing.Point(0, 143);
            this.btnNavBaocao.Name = "btnNavBaocao";
            this.btnNavBaocao.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavBaocao.Size = new System.Drawing.Size(200, 45);
            this.btnNavBaocao.TabIndex = 2;
            this.btnNavBaocao.Text = "📊 Báo cáo";
            this.btnNavBaocao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBaocao.UseVisualStyleBackColor = true;
            // 
            // btnNavCaiDat
            // 
            this.btnNavCaiDat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCaiDat.FlatAppearance.BorderSize = 0;
            this.btnNavCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCaiDat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnNavCaiDat.Location = new System.Drawing.Point(0, 98);
            this.btnNavCaiDat.Name = "btnNavCaiDat";
            this.btnNavCaiDat.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavCaiDat.Size = new System.Drawing.Size(200, 45);
            this.btnNavCaiDat.TabIndex = 3;
            this.btnNavCaiDat.Text = "⚙️ Cài đặt";
            this.btnNavCaiDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCaiDat.UseVisualStyleBackColor = true;
            // 
            // btnNavDanhmuc
            // 
            this.btnNavDanhmuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDanhmuc.FlatAppearance.BorderSize = 0;
            this.btnNavDanhmuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDanhmuc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavDanhmuc.ForeColor = System.Drawing.Color.White;
            this.btnNavDanhmuc.Location = new System.Drawing.Point(0, 53);
            this.btnNavDanhmuc.Name = "btnNavDanhmuc";
            this.btnNavDanhmuc.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavDanhmuc.Size = new System.Drawing.Size(200, 45);
            this.btnNavDanhmuc.TabIndex = 1;
            this.btnNavDanhmuc.Text = "📁 Danh mục";
            this.btnNavDanhmuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDanhmuc.UseVisualStyleBackColor = true;
            // 
            // btnNavSanPham
            // 
            this.btnNavSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSanPham.FlatAppearance.BorderSize = 0;
            this.btnNavSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSanPham.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavSanPham.ForeColor = System.Drawing.Color.White;
            this.btnNavSanPham.Location = new System.Drawing.Point(0, 8);
            this.btnNavSanPham.Name = "btnNavSanPham";
            this.btnNavSanPham.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavSanPham.Size = new System.Drawing.Size(200, 45);
            this.btnNavSanPham.TabIndex = 0;
            this.btnNavSanPham.Text = "🍕 Sản phẩm";
            this.btnNavSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSanPham.UseVisualStyleBackColor = true;
            this.btnNavSanPham.Click += new System.EventHandler(this.btnNavSanPham_Click);
            // 
            // pnlLog
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlLog.Controls.Add(this.txtLog);
            this.pnlLog.Controls.Add(this.lblLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLog.Location = new System.Drawing.Point(0, 580);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlLog.Size = new System.Drawing.Size(1100, 120);
            this.pnlLog.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.txtLog.Location = new System.Drawing.Point(12, 30);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1076, 82);
            this.txtLog.TabIndex = 0;
            // 
            // lblLog
            // 
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblLog.Location = new System.Drawing.Point(12, 8);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(1076, 22);
            this.lblLog.TabIndex = 1;
            this.lblLog.Text = "▸ System Log";
            // 
            // UCQuanTri
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UCQuanTri";
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.UCQuanTri_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMonAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.pnlToolbarMon.ResumeLayout(false);
            this.pnlToolbarMon.PerformLayout();
            this.tabDanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.pnlToolbarDm.ResumeLayout(false);
            this.pnlToolbarDm.PerformLayout();
            this.tabPageBaoCao.ResumeLayout(false);
            this.tabPageBaoCao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.pnlNav.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}