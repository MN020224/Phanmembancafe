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
        private System.Windows.Forms.Button btnNavNhanVien;
        private System.Windows.Forms.Button btnNavKhachHang;
        private System.Windows.Forms.Button btnNavCaiDat;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMonAn;
        private System.Windows.Forms.TabPage tabDanhMuc;
        private System.Windows.Forms.TabPage tabTaiKhoan;
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
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel pnlToolbarTk;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Button btnSuaTK;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;

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
            this.tabTaiKhoan = new System.Windows.Forms.TabPage();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.pnlToolbarTk = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.btnSuaTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavCaiDat = new System.Windows.Forms.Button();
            this.btnNavKhachHang = new System.Windows.Forms.Button();
            this.btnNavNhanVien = new System.Windows.Forms.Button();
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
            this.tabTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.pnlToolbarTk.SuspendLayout();
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
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1100, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚙️ QUẢN TRỊ — Sản phẩm, nhân viên, cài đặt";
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
            this.pnlContent.Location = new System.Drawing.Point(188, 8);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(8);
            this.pnlContent.Size = new System.Drawing.Size(904, 512);
            this.pnlContent.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabMonAn);
            this.tabControl1.Controls.Add(this.tabDanhMuc);
            this.tabControl1.Controls.Add(this.tabTaiKhoan);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 496);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabMonAn
            // 
            this.tabMonAn.Controls.Add(this.dgvMonAn);
            this.tabMonAn.Controls.Add(this.pnlToolbarMon);
            this.tabMonAn.Location = new System.Drawing.Point(4, 5);
            this.tabMonAn.Name = "tabMonAn";
            this.tabMonAn.Size = new System.Drawing.Size(880, 487);
            this.tabMonAn.TabIndex = 0;
            this.tabMonAn.Text = "Mon";
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.Location = new System.Drawing.Point(0, 48);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.Size = new System.Drawing.Size(880, 439);
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
            this.pnlToolbarMon.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbarMon.Name = "pnlToolbarMon";
            this.pnlToolbarMon.Padding = new System.Windows.Forms.Padding(4);
            this.pnlToolbarMon.Size = new System.Drawing.Size(880, 48);
            this.pnlToolbarMon.TabIndex = 1;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(8, 10);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(200, 20);
            this.txtTenMon.TabIndex = 0;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(216, 10);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(120, 20);
            this.txtGia.TabIndex = 1;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Location = new System.Drawing.Point(344, 10);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(150, 21);
            this.cboDanhMuc.TabIndex = 2;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(504, 8);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(88, 32);
            this.btnThemMon.TabIndex = 3;
            this.btnThemMon.Text = "➕ Thêm";
            // 
            // btnSuaMon
            // 
            this.btnSuaMon.Location = new System.Drawing.Point(598, 8);
            this.btnSuaMon.Name = "btnSuaMon";
            this.btnSuaMon.Size = new System.Drawing.Size(88, 32);
            this.btnSuaMon.TabIndex = 4;
            this.btnSuaMon.Text = "✏️ Sửa";
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Location = new System.Drawing.Point(692, 8);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(88, 32);
            this.btnXoaMon.TabIndex = 5;
            this.btnXoaMon.Text = "🗑️ Xóa";
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.tabDanhMuc.Controls.Add(this.pnlToolbarDm);
            this.tabDanhMuc.Location = new System.Drawing.Point(4, 5);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.Size = new System.Drawing.Size(0, 59);
            this.tabDanhMuc.TabIndex = 1;
            this.tabDanhMuc.Text = "DM";
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 48);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.Size = new System.Drawing.Size(0, 11);
            this.dgvDanhMuc.TabIndex = 0;
            // 
            // pnlToolbarDm
            // 
            this.pnlToolbarDm.Controls.Add(this.txtTenDanhMuc);
            this.pnlToolbarDm.Controls.Add(this.btnThemDanhMuc);
            this.pnlToolbarDm.Controls.Add(this.btnSuaDanhMuc);
            this.pnlToolbarDm.Controls.Add(this.btnXoaDanhMuc);
            this.pnlToolbarDm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarDm.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbarDm.Name = "pnlToolbarDm";
            this.pnlToolbarDm.Size = new System.Drawing.Size(0, 48);
            this.pnlToolbarDm.TabIndex = 1;
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Location = new System.Drawing.Point(8, 10);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(260, 20);
            this.txtTenDanhMuc.TabIndex = 0;
            // 
            // btnThemDanhMuc
            // 
            this.btnThemDanhMuc.Location = new System.Drawing.Point(276, 8);
            this.btnThemDanhMuc.Name = "btnThemDanhMuc";
            this.btnThemDanhMuc.Size = new System.Drawing.Size(88, 32);
            this.btnThemDanhMuc.TabIndex = 1;
            this.btnThemDanhMuc.Text = "➕ Thêm";
            // 
            // btnSuaDanhMuc
            // 
            this.btnSuaDanhMuc.Location = new System.Drawing.Point(370, 8);
            this.btnSuaDanhMuc.Name = "btnSuaDanhMuc";
            this.btnSuaDanhMuc.Size = new System.Drawing.Size(88, 32);
            this.btnSuaDanhMuc.TabIndex = 2;
            this.btnSuaDanhMuc.Text = "✏️ Sửa";
            // 
            // btnXoaDanhMuc
            // 
            this.btnXoaDanhMuc.Location = new System.Drawing.Point(464, 8);
            this.btnXoaDanhMuc.Name = "btnXoaDanhMuc";
            this.btnXoaDanhMuc.Size = new System.Drawing.Size(88, 32);
            this.btnXoaDanhMuc.TabIndex = 3;
            this.btnXoaDanhMuc.Text = "🗑️ Xóa";
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.pnlToolbarTk);
            this.tabTaiKhoan.Location = new System.Drawing.Point(4, 5);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Size = new System.Drawing.Size(0, 59);
            this.tabTaiKhoan.TabIndex = 2;
            this.tabTaiKhoan.Text = "TK";
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(0, 48);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.Size = new System.Drawing.Size(0, 11);
            this.dgvTaiKhoan.TabIndex = 0;
            // 
            // pnlToolbarTk
            // 
            this.pnlToolbarTk.Controls.Add(this.txtUsername);
            this.pnlToolbarTk.Controls.Add(this.txtPassword);
            this.pnlToolbarTk.Controls.Add(this.cboVaiTro);
            this.pnlToolbarTk.Controls.Add(this.btnThemTK);
            this.pnlToolbarTk.Controls.Add(this.btnSuaTK);
            this.pnlToolbarTk.Controls.Add(this.btnXoaTK);
            this.pnlToolbarTk.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbarTk.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbarTk.Name = "pnlToolbarTk";
            this.pnlToolbarTk.Size = new System.Drawing.Size(0, 48);
            this.pnlToolbarTk.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(8, 10);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(164, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Items.AddRange(new object[] {
            "admin",
            "nhan_vien"});
            this.cboVaiTro.Location = new System.Drawing.Point(320, 10);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(120, 21);
            this.cboVaiTro.TabIndex = 2;
            // 
            // btnThemTK
            // 
            this.btnThemTK.Location = new System.Drawing.Point(448, 8);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(88, 32);
            this.btnThemTK.TabIndex = 3;
            this.btnThemTK.Text = "➕ Thêm";
            // 
            // btnSuaTK
            // 
            this.btnSuaTK.Location = new System.Drawing.Point(542, 8);
            this.btnSuaTK.Name = "btnSuaTK";
            this.btnSuaTK.Size = new System.Drawing.Size(88, 32);
            this.btnSuaTK.TabIndex = 4;
            this.btnSuaTK.Text = "✏️ Sửa";
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Location = new System.Drawing.Point(636, 8);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(88, 32);
            this.btnXoaTK.TabIndex = 5;
            this.btnXoaTK.Text = "🗑️ Xóa";
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlNav.Controls.Add(this.btnNavCaiDat);
            this.pnlNav.Controls.Add(this.btnNavKhachHang);
            this.pnlNav.Controls.Add(this.btnNavNhanVien);
            this.pnlNav.Controls.Add(this.btnNavSanPham);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(8, 8);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlNav.Size = new System.Drawing.Size(180, 512);
            this.pnlNav.TabIndex = 1;
            // 
            // btnNavCaiDat
            // 
            this.btnNavCaiDat.Location = new System.Drawing.Point(0, 0);
            this.btnNavCaiDat.Name = "btnNavCaiDat";
            this.btnNavCaiDat.Size = new System.Drawing.Size(75, 23);
            this.btnNavCaiDat.TabIndex = 0;
            this.btnNavCaiDat.Text = "⚙️  Cài đặt";
            this.btnNavCaiDat.Click += new System.EventHandler(this.btnNavCaiDat_Click);
            // 
            // btnNavKhachHang
            // 
            this.btnNavKhachHang.Location = new System.Drawing.Point(0, 0);
            this.btnNavKhachHang.Name = "btnNavKhachHang";
            this.btnNavKhachHang.Size = new System.Drawing.Size(75, 23);
            this.btnNavKhachHang.TabIndex = 1;
            this.btnNavKhachHang.Text = "Danh Mục" +
                " ";
 
            // 
            // btnNavSanPham
            // 
            this.btnNavSanPham.Location = new System.Drawing.Point(0, 0);
            this.btnNavSanPham.Name = "btnNavSanPham";
            this.btnNavSanPham.Size = new System.Drawing.Size(75, 23);
            this.btnNavSanPham.TabIndex = 3;
            this.btnNavSanPham.Text = "🍕  Sản phẩm";
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
            this.tabTaiKhoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.pnlToolbarTk.ResumeLayout(false);
            this.pnlToolbarTk.PerformLayout();
            this.pnlNav.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
