namespace CafeOrder
{
    partial class MPI
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các component
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;

        // MenuStrip items
        private System.Windows.Forms.ToolStripMenuItem mnBanHang;
        private System.Windows.Forms.ToolStripMenuItem mnBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnDongCa;
        private System.Windows.Forms.ToolStripMenuItem mnDangXuat;

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
            this.mnBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDongCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBanHang,
            this.mnBaoCao,
            this.mnQuanTri,
            this.mnDongCa,
            this.mnDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1029, 27);
            this.menuStrip1.TabIndex = 0;
            // 
            // mnBanHang
            // 
            this.mnBanHang.ForeColor = System.Drawing.Color.White;
            this.mnBanHang.Name = "mnBanHang";
            this.mnBanHang.Size = new System.Drawing.Size(83, 23);
            this.mnBanHang.Text = "Bán hàng";
            // 
            // mnBaoCao
            // 
            this.mnBaoCao.ForeColor = System.Drawing.Color.White;
            this.mnBaoCao.Name = "mnBaoCao";
            this.mnBaoCao.Size = new System.Drawing.Size(75, 23);
            this.mnBaoCao.Text = "Báo cáo";
            // 
            // mnQuanTri
            // 
            this.mnQuanTri.ForeColor = System.Drawing.Color.White;
            this.mnQuanTri.Name = "mnQuanTri";
            this.mnQuanTri.Size = new System.Drawing.Size(110, 23);
            this.mnQuanTri.Text = "Quản Tri Viên";
            // 
            // mnDongCa
            // 
            this.mnDongCa.ForeColor = System.Drawing.Color.White;
            this.mnDongCa.Name = "mnDongCa";
            this.mnDongCa.Size = new System.Drawing.Size(96, 23);
            this.mnDongCa.Text = "Quản Lý Ca";
            // 
            // mnDangXuat
            // 
            this.mnDangXuat.ForeColor = System.Drawing.Color.White;
            this.mnDangXuat.Name = "mnDangXuat";
            this.mnDangXuat.Size = new System.Drawing.Size(89, 23);
            this.mnDangXuat.Text = "Đăng xuất";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 580);
            this.panel1.TabIndex = 1;
            // 
            // MPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1029, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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