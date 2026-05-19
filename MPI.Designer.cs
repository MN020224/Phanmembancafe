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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mnBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDongCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDangXuat = new System.Windows.Forms.ToolStripMenuItem();

            // menuStrip1
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnBanHang, this.mnBaoCao, this.mnQuanTri, this.mnDongCa, this.mnDangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;

            // mnBanHang
            this.mnBanHang.ForeColor = System.Drawing.Color.White;
            this.mnBanHang.Name = "mnBanHang";
            this.mnBanHang.Size = new System.Drawing.Size(83, 24);
            this.mnBanHang.Text = "📋 Bán hàng";

            // mnBaoCao
            this.mnBaoCao.ForeColor = System.Drawing.Color.White;
            this.mnBaoCao.Name = "mnBaoCao";
            this.mnBaoCao.Size = new System.Drawing.Size(78, 24);
            this.mnBaoCao.Text = "📊 Báo cáo";

            // mnQuanTri
            this.mnQuanTri.ForeColor = System.Drawing.Color.White;
            this.mnQuanTri.Name = "mnQuanTri";
            this.mnQuanTri.Size = new System.Drawing.Size(73, 24);
            this.mnQuanTri.Text = "⚙️ Quản trị";

            // mnDongCa
            this.mnDongCa.ForeColor = System.Drawing.Color.White;
            this.mnDongCa.Name = "mnDongCa";
            this.mnDongCa.Size = new System.Drawing.Size(75, 24);
            this.mnDongCa.Text = "🔒 Đóng ca";

            // mnDangXuat
            this.mnDangXuat.ForeColor = System.Drawing.Color.White;
            this.mnDangXuat.Name = "mnDangXuat";
            this.mnDangXuat.Size = new System.Drawing.Size(85, 24);
            this.mnDangXuat.Text = "🚪 Đăng xuất";

            // panel1
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 672);
            this.panel1.TabIndex = 1;

            // MPI
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "☕ CAFE POS - Hệ thống quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MPI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}