namespace CafeOrder
{
    partial class UCQuanTri
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMonAn;
        private System.Windows.Forms.TabPage tabDanhMuc;
        private System.Windows.Forms.TabPage tabTaiKhoan;

        // Tab Món ăn
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSuaMon;
        private System.Windows.Forms.Button btnXoaMon;

        // Tab Danh mục
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.Button btnThemDanhMuc;
        private System.Windows.Forms.Button btnSuaDanhMuc;
        private System.Windows.Forms.Button btnXoaDanhMuc;

        // Tab Tài khoản
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Button btnSuaTK;
        private System.Windows.Forms.Button btnXoaTK;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMonAn = new System.Windows.Forms.TabPage();
            this.tabDanhMuc = new System.Windows.Forms.TabPage();
            this.tabTaiKhoan = new System.Windows.Forms.TabPage();

            // ========== TAB MÓN ĂN ==========
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnSuaMon = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();

            // ========== TAB DANH MỤC ==========
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.btnThemDanhMuc = new System.Windows.Forms.Button();
            this.btnSuaDanhMuc = new System.Windows.Forms.Button();
            this.btnXoaDanhMuc = new System.Windows.Forms.Button();

            // ========== TAB TÀI KHOẢN ==========
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.btnSuaTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();

            this.tabControl1.SuspendLayout();
            this.tabMonAn.SuspendLayout();
            this.tabDanhMuc.SuspendLayout();
            this.tabTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Controls.Add(this.tabMonAn);
            this.tabControl1.Controls.Add(this.tabDanhMuc);
            this.tabControl1.Controls.Add(this.tabTaiKhoan);

            // tabMonAn
            this.tabMonAn.Text = "🍕 QUẢN LÝ MÓN ĂN";
            this.tabMonAn.Controls.Add(this.dgvMonAn);
            this.tabMonAn.Controls.Add(this.txtTenMon);
            this.tabMonAn.Controls.Add(this.txtGia);
            this.tabMonAn.Controls.Add(this.cboDanhMuc);
            this.tabMonAn.Controls.Add(this.btnThemMon);
            this.tabMonAn.Controls.Add(this.btnSuaMon);
            this.tabMonAn.Controls.Add(this.btnXoaMon);

            // dgvMonAn
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;

            // txtTenMon
            this.txtTenMon.Location = new System.Drawing.Point(10, 10);
            this.txtTenMon.Size = new System.Drawing.Size(200, 27);

            // txtGia
            this.txtGia.Location = new System.Drawing.Point(220, 10);
            this.txtGia.Size = new System.Drawing.Size(120, 27);

            // cboDanhMuc
            this.cboDanhMuc.Location = new System.Drawing.Point(350, 10);
            this.cboDanhMuc.Size = new System.Drawing.Size(150, 27);
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnThemMon
            this.btnThemMon.Text = "➕ Thêm";
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Location = new System.Drawing.Point(520, 8);
            this.btnThemMon.Size = new System.Drawing.Size(80, 30);

            // btnSuaMon
            this.btnSuaMon.Text = "✏️ Sửa";
            this.btnSuaMon.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnSuaMon.ForeColor = System.Drawing.Color.White;
            this.btnSuaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaMon.Location = new System.Drawing.Point(610, 8);
            this.btnSuaMon.Size = new System.Drawing.Size(80, 30);

            // btnXoaMon
            this.btnXoaMon.Text = "🗑️ Xóa";
            this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Location = new System.Drawing.Point(700, 8);
            this.btnXoaMon.Size = new System.Drawing.Size(80, 30);

            // tabDanhMuc
            this.tabDanhMuc.Text = "📁 QUẢN LÝ DANH MỤC";
            this.tabDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.tabDanhMuc.Controls.Add(this.txtTenDanhMuc);
            this.tabDanhMuc.Controls.Add(this.btnThemDanhMuc);
            this.tabDanhMuc.Controls.Add(this.btnSuaDanhMuc);
            this.tabDanhMuc.Controls.Add(this.btnXoaDanhMuc);

            // dgvDanhMuc
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.BackgroundColor = System.Drawing.Color.White;

            // txtTenDanhMuc
            this.txtTenDanhMuc.Location = new System.Drawing.Point(10, 10);
            this.txtTenDanhMuc.Size = new System.Drawing.Size(250, 27);

            // btnThemDanhMuc
            this.btnThemDanhMuc.Text = "➕ Thêm";
            this.btnThemDanhMuc.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnThemDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnThemDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDanhMuc.Location = new System.Drawing.Point(270, 8);
            this.btnThemDanhMuc.Size = new System.Drawing.Size(80, 30);

            // btnSuaDanhMuc
            this.btnSuaDanhMuc.Text = "✏️ Sửa";
            this.btnSuaDanhMuc.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnSuaDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnSuaDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaDanhMuc.Location = new System.Drawing.Point(360, 8);
            this.btnSuaDanhMuc.Size = new System.Drawing.Size(80, 30);

            // btnXoaDanhMuc
            this.btnXoaDanhMuc.Text = "🗑️ Xóa";
            this.btnXoaDanhMuc.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnXoaDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnXoaDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDanhMuc.Location = new System.Drawing.Point(450, 8);
            this.btnXoaDanhMuc.Size = new System.Drawing.Size(80, 30);

            // tabTaiKhoan
            this.tabTaiKhoan.Text = "👤 QUẢN LÝ TÀI KHOẢN";
            this.tabTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.txtUsername);
            this.tabTaiKhoan.Controls.Add(this.txtPassword);
            this.tabTaiKhoan.Controls.Add(this.cboVaiTro);
            this.tabTaiKhoan.Controls.Add(this.btnThemTK);
            this.tabTaiKhoan.Controls.Add(this.btnSuaTK);
            this.tabTaiKhoan.Controls.Add(this.btnXoaTK);

            // dgvTaiKhoan
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(10, 10);
            this.txtUsername.Size = new System.Drawing.Size(150, 27);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(170, 10);
            this.txtPassword.Size = new System.Drawing.Size(150, 27);
            this.txtPassword.UseSystemPasswordChar = true;

            // cboVaiTro
            this.cboVaiTro.Location = new System.Drawing.Point(330, 10);
            this.cboVaiTro.Size = new System.Drawing.Size(120, 27);
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Items.AddRange(new object[] { "admin", "nhan_vien" });

            // btnThemTK
            this.btnThemTK.Text = "➕ Thêm";
            this.btnThemTK.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnThemTK.ForeColor = System.Drawing.Color.White;
            this.btnThemTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTK.Location = new System.Drawing.Point(470, 8);
            this.btnThemTK.Size = new System.Drawing.Size(80, 30);

            // btnSuaTK
            this.btnSuaTK.Text = "✏️ Sửa";
            this.btnSuaTK.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnSuaTK.ForeColor = System.Drawing.Color.White;
            this.btnSuaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTK.Location = new System.Drawing.Point(560, 8);
            this.btnSuaTK.Size = new System.Drawing.Size(80, 30);

            // btnXoaTK
            this.btnXoaTK.Text = "🗑️ Xóa";
            this.btnXoaTK.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnXoaTK.ForeColor = System.Drawing.Color.White;
            this.btnXoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTK.Location = new System.Drawing.Point(650, 8);
            this.btnXoaTK.Size = new System.Drawing.Size(80, 30);

            // UCQuanTri
            this.Controls.Add(this.tabControl1);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "UCQuanTri";
            this.Size = new System.Drawing.Size(1000, 600);

            this.tabControl1.ResumeLayout(false);
            this.tabMonAn.ResumeLayout(false);
            this.tabMonAn.PerformLayout();
            this.tabDanhMuc.ResumeLayout(false);
            this.tabDanhMuc.PerformLayout();
            this.tabTaiKhoan.ResumeLayout(false);
            this.tabTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);
        }
    }
}