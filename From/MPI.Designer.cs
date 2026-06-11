using System.Windows.Forms;

namespace CafeOrder
{
    partial class MPI
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các component
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;

        // MenuStrip items
        private System.Windows.Forms.ToolStripMenuItem MnBanHang;
        private System.Windows.Forms.ToolStripMenuItem MnBaoCao;
        private System.Windows.Forms.ToolStripMenuItem MnQuanTri;
        private System.Windows.Forms.ToolStripMenuItem MnDongCa;
        private System.Windows.Forms.ToolStripMenuItem MnDangXuat;
        private System.Windows.Forms.ToolStripMenuItem MnThuChi;  // 🔥 Thêm menu Thu Chi

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.MnBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.MnQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.MnThuChi = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDongCa = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnBanHang,
            this.MnBaoCao,
            this.MnQuanTri,
            this.MnThuChi,
            this.MnDongCa,
            this.MnDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1372, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnBanHang
            // 
            this.MnBanHang.ForeColor = System.Drawing.Color.White;
            this.MnBanHang.Name = "MnBanHang";
            this.MnBanHang.Size = new System.Drawing.Size(99, 27);
            this.MnBanHang.Text = "Bán hàng";
            this.MnBanHang.Click += new System.EventHandler(this.MnBanHang_Click);
            // 
            // MnBaoCao
            // 
            this.MnBaoCao.ForeColor = System.Drawing.Color.White;
            this.MnBaoCao.Name = "MnBaoCao";
            this.MnBaoCao.Size = new System.Drawing.Size(86, 27);
            this.MnBaoCao.Text = "Báo cáo";
            this.MnBaoCao.Click += new System.EventHandler(this.MnBaoCao_Click);
            // 
            // MnQuanTri
            // 
            this.MnQuanTri.ForeColor = System.Drawing.Color.White;
            this.MnQuanTri.Name = "MnQuanTri";
            this.MnQuanTri.Size = new System.Drawing.Size(132, 27);
            this.MnQuanTri.Text = "Quản Trị Viên";
            this.MnQuanTri.Click += new System.EventHandler(this.MnQuanTri_Click);
            // 
            // MnThuChi
            // 
            this.MnThuChi.ForeColor = System.Drawing.Color.White;
            this.MnThuChi.Name = "MnThuChi";
            this.MnThuChi.Size = new System.Drawing.Size(85, 27);
            this.MnThuChi.Text = "Thu Chi";
            this.MnThuChi.Click += new System.EventHandler(this.MnThuChi_Click);
            // 
            // MnDongCa
            // 
            this.MnDongCa.ForeColor = System.Drawing.Color.White;
            this.MnDongCa.Name = "MnDongCa";
            this.MnDongCa.Size = new System.Drawing.Size(114, 27);
            this.MnDongCa.Text = "Quản Lý Ca";
            this.MnDongCa.Click += new System.EventHandler(this.MnDongCa_Click);
            // 
            // MnDangXuat
            // 
            this.MnDangXuat.ForeColor = System.Drawing.Color.White;
            this.MnDangXuat.Name = "MnDangXuat";
            this.MnDangXuat.ShowShortcutKeys = false;
            this.MnDangXuat.Size = new System.Drawing.Size(107, 27);
            this.MnDangXuat.Text = "Đăng xuất";
            this.MnDangXuat.Click += new System.EventHandler(this.MnDangXuat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 716);
            this.panel1.TabIndex = 1;
            // 
            // MPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1372, 747);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "☕ CAFE POS - Hệ thống quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MPI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}