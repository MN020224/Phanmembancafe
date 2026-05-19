namespace CafeOrder
{
    partial class UCBanHang
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các component
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutBan;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.ListBox lstMonAn;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.GroupBox grpBanAn;
        private System.Windows.Forms.GroupBox grpMonAn;
        private System.Windows.Forms.GroupBox grpHoaDon;

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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.grpBanAn = new System.Windows.Forms.GroupBox();
            this.flowLayoutBan = new System.Windows.Forms.FlowLayoutPanel();
            this.grpMonAn = new System.Windows.Forms.GroupBox();
            this.lstMonAn = new System.Windows.Forms.ListBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();

            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.grpBanAn.SuspendLayout();
            this.grpMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.grpHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();

            // panelLeft (Bên trái - chọn bàn và món)
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Size = new System.Drawing.Size(400, 600);

            // grpBanAn
            this.grpBanAn.Text = "🍽️ CHỌN BÀN";
            this.grpBanAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBanAn.Size = new System.Drawing.Size(400, 200);
            this.grpBanAn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // flowLayoutBan (hiển thị các bàn)
            this.flowLayoutBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutBan.AutoScroll = true;
            this.flowLayoutBan.Padding = new System.Windows.Forms.Padding(10);

            // grpMonAn
            this.grpMonAn.Text = "🍜 DANH SÁCH MÓN";
            this.grpMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMonAn.Size = new System.Drawing.Size(400, 400);
            this.grpMonAn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lstMonAn
            this.lstMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMonAn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstMonAn.Size = new System.Drawing.Size(396, 300);

            // nudSoLuong
            this.nudSoLuong.Location = new System.Drawing.Point(10, 310);
            this.nudSoLuong.Size = new System.Drawing.Size(80, 26);
            this.nudSoLuong.Minimum = 1;
            this.nudSoLuong.Maximum = 99;
            this.nudSoLuong.Value = 1;

            // btnThemMon
            this.btnThemMon.Text = "➕ THÊM MÓN";
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemMon.Location = new System.Drawing.Point(100, 308);
            this.btnThemMon.Size = new System.Drawing.Size(120, 30);
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // panelRight (Bên phải - giỏ hàng)
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;

            // grpHoaDon
            this.grpHoaDon.Text = "🧾 GIỎ HÀNG";
            this.grpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpHoaDon.Padding = new System.Windows.Forms.Padding(10);

            // dgvGioHang
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;

            // btnXoaMon
            this.btnXoaMon.Text = "🗑️ XÓA MÓN";
            this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaMon.Location = new System.Drawing.Point(10, 520);
            this.btnXoaMon.Size = new System.Drawing.Size(150, 40);
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // btnThanhToan
            this.btnThanhToan.Text = "💰 THANH TOÁN";
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Location = new System.Drawing.Point(200, 520);
            this.btnThanhToan.Size = new System.Drawing.Size(180, 50);
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // lblTongTien
            this.lblTongTien.Text = "TỔNG TIỀN:";
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(10, 480);
            this.lblTongTien.Size = new System.Drawing.Size(120, 30);

            // txtTongTien
            this.txtTongTien.Text = "0 VNĐ";
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.BackColor = System.Drawing.Color.White;
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Location = new System.Drawing.Point(130, 475);
            this.txtTongTien.Size = new System.Drawing.Size(250, 35);
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // Thêm controls vào grpMonAn
            this.grpMonAn.Controls.Add(this.lstMonAn);
            this.grpMonAn.Controls.Add(this.nudSoLuong);
            this.grpMonAn.Controls.Add(this.btnThemMon);

            // Thêm controls vào grpHoaDon
            this.grpHoaDon.Controls.Add(this.dgvGioHang);
            this.grpHoaDon.Controls.Add(this.btnXoaMon);
            this.grpHoaDon.Controls.Add(this.btnThanhToan);
            this.grpHoaDon.Controls.Add(this.lblTongTien);
            this.grpHoaDon.Controls.Add(this.txtTongTien);

            // Thêm vào panelLeft
            this.panelLeft.Controls.Add(this.grpBanAn);
            this.panelLeft.Controls.Add(this.grpMonAn);
            this.grpBanAn.Controls.Add(this.flowLayoutBan);

            // Thêm vào panelRight
            this.panelRight.Controls.Add(this.grpHoaDon);

            // UCBanHang
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "UCBanHang";
            this.Size = new System.Drawing.Size(1000, 600);

            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.grpBanAn.ResumeLayout(false);
            this.grpMonAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);
        }
    }
}