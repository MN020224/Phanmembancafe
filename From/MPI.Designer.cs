using System.Windows.Forms;

namespace CafeOrder
{
    partial class MPI
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAdminZone;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.Button btnQuanTri;

        private System.Windows.Forms.ToolStripMenuItem MnBanHang;
        private System.Windows.Forms.ToolStripMenuItem MnBaoCao;
        private System.Windows.Forms.ToolStripMenuItem MnDongCa;
        private System.Windows.Forms.ToolStripMenuItem MnDangXuat;
        private System.Windows.Forms.ToolStripMenuItem MnThuChi;

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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.MnBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.MnThuChi = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDongCa = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAdminZone = new System.Windows.Forms.Panel();
            this.btnQuanTri = new System.Windows.Forms.Button();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTopBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlAdminZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.pnlTopBar.Controls.Add(this.menuStrip1);
            this.pnlTopBar.Controls.Add(this.pnlAdminZone);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1372, 48);
            this.pnlTopBar.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnBanHang,
            this.MnBaoCao,
            this.MnThuChi,
            this.MnDongCa,
            this.MnDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1102, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnBanHang
            // 
            this.MnBanHang.ForeColor = System.Drawing.Color.White;
            this.MnBanHang.Name = "MnBanHang";
            this.MnBanHang.Size = new System.Drawing.Size(99, 44);
            this.MnBanHang.Text = "Bán hàng";
            this.MnBanHang.Click += new System.EventHandler(this.MnBanHang_Click);
            // 
            // MnBaoCao
            // 
            this.MnBaoCao.ForeColor = System.Drawing.Color.White;
            this.MnBaoCao.Name = "MnBaoCao";
            this.MnBaoCao.Size = new System.Drawing.Size(86, 44);
            this.MnBaoCao.Text = "Báo cáo";
            this.MnBaoCao.Click += new System.EventHandler(this.MnBaoCao_Click);
            // 
            // MnThuChi
            // 
            this.MnThuChi.ForeColor = System.Drawing.Color.White;
            this.MnThuChi.Name = "MnThuChi";
            this.MnThuChi.Size = new System.Drawing.Size(85, 44);
            this.MnThuChi.Text = "Thu Chi";
            this.MnThuChi.Click += new System.EventHandler(this.MnThuChi_Click);
            // 
            // MnDongCa
            // 
            this.MnDongCa.ForeColor = System.Drawing.Color.White;
            this.MnDongCa.Name = "MnDongCa";
            this.MnDongCa.Size = new System.Drawing.Size(114, 44);
            this.MnDongCa.Text = "Quản Lý Ca";
            this.MnDongCa.Click += new System.EventHandler(this.MnDongCa_Click);
            // 
            // MnDangXuat
            // 
            this.MnDangXuat.ForeColor = System.Drawing.Color.White;
            this.MnDangXuat.Name = "MnDangXuat";
            this.MnDangXuat.ShowShortcutKeys = false;
            this.MnDangXuat.Size = new System.Drawing.Size(107, 44);
            this.MnDangXuat.Text = "Đăng xuất";
            this.MnDangXuat.Click += new System.EventHandler(this.MnDangXuat_Click);
            // 
            // pnlAdminZone
            // 
            this.pnlAdminZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlAdminZone.Controls.Add(this.btnQuanTri);
            this.pnlAdminZone.Controls.Add(this.lblNguoiDung);
            this.pnlAdminZone.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAdminZone.Location = new System.Drawing.Point(1102, 0);
            this.pnlAdminZone.Name = "pnlAdminZone";
            this.pnlAdminZone.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlAdminZone.Size = new System.Drawing.Size(270, 48);
            this.pnlAdminZone.TabIndex = 1;
            // 
            // btnQuanTri
            // 
            this.btnQuanTri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuanTri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnQuanTri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanTri.FlatAppearance.BorderSize = 0;
            this.btnQuanTri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanTri.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuanTri.ForeColor = System.Drawing.Color.White;
            this.btnQuanTri.Location = new System.Drawing.Point(128, 8);
            this.btnQuanTri.Name = "btnQuanTri";
            this.btnQuanTri.Size = new System.Drawing.Size(130, 32);
            this.btnQuanTri.TabIndex = 1;
            this.btnQuanTri.Text = "⚙️ Quản trị";
            this.btnQuanTri.UseVisualStyleBackColor = false;
            this.btnQuanTri.Click += new System.EventHandler(this.BtnQuanTri_Click);
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoEllipsis = true;
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNguoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblNguoiDung.Location = new System.Drawing.Point(8, 6);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(114, 36);
            this.lblNguoiDung.TabIndex = 0;
            this.lblNguoiDung.Text = "👤 Nhân viên";
            this.lblNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 699);
            this.panel1.TabIndex = 1;
            // 
            // MPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1372, 747);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTopBar);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "☕ CAFE POS - Hệ thống quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MPI_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlAdminZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
