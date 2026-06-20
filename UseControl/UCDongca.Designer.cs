namespace CafeOrder
{
    partial class UCDongca
    {
        private System.ComponentModel.IContainer components = null;

        // Components chính
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlShiftInfo;
        private System.Windows.Forms.Panel pnlFinancial;
        private System.Windows.Forms.DataGridView dgvHoaDonTrongCa;
        private System.Windows.Forms.Label lblGioMoCa;
        private System.Windows.Forms.TextBox txtGioMoCa;
        private System.Windows.Forms.Label lblGioDongCa;
        private System.Windows.Forms.TextBox txtGioDongCa;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label lblTrangThaiCa;
        private System.Windows.Forms.TextBox txtTrangThaiCa;

        // Thông tin tài chính
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label lblTienMat;
        private System.Windows.Forms.TextBox txtTienMat;
        private System.Windows.Forms.Label lblChuyenKhoan;
        private System.Windows.Forms.TextBox txtChuyenKhoan;
        private System.Windows.Forms.Label lblTienDauCa;
        private System.Windows.Forms.TextBox txtTienDauCa;

        // Buttons
        private System.Windows.Forms.Button btnMoCa;
        private System.Windows.Forms.Button btnDongCa;
        private System.Windows.Forms.Button btnInBaoCao;

        // Timer để cập nhật thời gian thực
        private System.Windows.Forms.Timer timerRealTime;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlShiftInfo = new System.Windows.Forms.Panel();
            this.lblGioMoCa = new System.Windows.Forms.Label();
            this.txtGioMoCa = new System.Windows.Forms.TextBox();
            this.lblGioDongCa = new System.Windows.Forms.Label();
            this.txtGioDongCa = new System.Windows.Forms.TextBox();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.lblTrangThaiCa = new System.Windows.Forms.Label();
            this.txtTrangThaiCa = new System.Windows.Forms.TextBox();
            this.pnlFinancial = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTienMat = new System.Windows.Forms.Label();
            this.txtTienMat = new System.Windows.Forms.TextBox();
            this.lblChuyenKhoan = new System.Windows.Forms.Label();
            this.txtChuyenKhoan = new System.Windows.Forms.TextBox();
            this.lblTienDauCa = new System.Windows.Forms.Label();
            this.txtTienDauCa = new System.Windows.Forms.TextBox();
            this.btnMoCa = new System.Windows.Forms.Button();
            this.btnDongCa = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.dgvHoaDonTrongCa = new System.Windows.Forms.DataGridView();
            this.timerRealTime = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlShiftInfo.SuspendLayout();
            this.pnlFinancial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonTrongCa)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpMain.Controls.Add(this.pnlShiftInfo, 0, 1);
            this.tlpMain.Controls.Add(this.pnlFinancial, 0, 2);
            this.tlpMain.Controls.Add(this.dgvHoaDonTrongCa, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(825, 455);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(10, 8);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(805, 35);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(805, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 QUẢN LÝ CA LÀM VIỆC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlShiftInfo
            // 
            this.pnlShiftInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.pnlShiftInfo.Controls.Add(this.lblGioMoCa);
            this.pnlShiftInfo.Controls.Add(this.txtGioMoCa);
            this.pnlShiftInfo.Controls.Add(this.lblGioDongCa);
            this.pnlShiftInfo.Controls.Add(this.txtGioDongCa);
            this.pnlShiftInfo.Controls.Add(this.lblSoHoaDon);
            this.pnlShiftInfo.Controls.Add(this.txtSoHoaDon);
            this.pnlShiftInfo.Controls.Add(this.lblTrangThaiCa);
            this.pnlShiftInfo.Controls.Add(this.txtTrangThaiCa);
            this.pnlShiftInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShiftInfo.Location = new System.Drawing.Point(10, 47);
            this.pnlShiftInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlShiftInfo.Name = "pnlShiftInfo";
            this.pnlShiftInfo.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlShiftInfo.Size = new System.Drawing.Size(805, 94);
            this.pnlShiftInfo.TabIndex = 1;
            // 
            // lblGioMoCa
            // 
            this.lblGioMoCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGioMoCa.Location = new System.Drawing.Point(48, 17);
            this.lblGioMoCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGioMoCa.Name = "lblGioMoCa";
            this.lblGioMoCa.Size = new System.Drawing.Size(129, 20);
            this.lblGioMoCa.TabIndex = 2;
            this.lblGioMoCa.Text = "🕐 Giờ mở ca:";
            this.lblGioMoCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGioMoCa
            // 
            this.txtGioMoCa.BackColor = System.Drawing.Color.White;
            this.txtGioMoCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGioMoCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGioMoCa.Location = new System.Drawing.Point(189, 16);
            this.txtGioMoCa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGioMoCa.Name = "txtGioMoCa";
            this.txtGioMoCa.ReadOnly = true;
            this.txtGioMoCa.Size = new System.Drawing.Size(136, 27);
            this.txtGioMoCa.TabIndex = 3;
            this.txtGioMoCa.Text = "--:--:--";
            // 
            // lblGioDongCa
            // 
            this.lblGioDongCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGioDongCa.Location = new System.Drawing.Point(391, 16);
            this.lblGioDongCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGioDongCa.Name = "lblGioDongCa";
            this.lblGioDongCa.Size = new System.Drawing.Size(120, 20);
            this.lblGioDongCa.TabIndex = 4;
            this.lblGioDongCa.Text = "🔒 Giờ đóng ca:";
            this.lblGioDongCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGioDongCa
            // 
            this.txtGioDongCa.BackColor = System.Drawing.Color.White;
            this.txtGioDongCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGioDongCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGioDongCa.Location = new System.Drawing.Point(544, 17);
            this.txtGioDongCa.Margin = new System.Windows.Forms.Padding(2);
            this.txtGioDongCa.Name = "txtGioDongCa";
            this.txtGioDongCa.ReadOnly = true;
            this.txtGioDongCa.Size = new System.Drawing.Size(163, 27);
            this.txtGioDongCa.TabIndex = 5;
            this.txtGioDongCa.Text = "--:--:--";
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.Location = new System.Drawing.Point(48, 46);
            this.lblSoHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(129, 20);
            this.lblSoHoaDon.TabIndex = 6;
            this.lblSoHoaDon.Text = "📄 Số hóa đơn:";
            this.lblSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.BackColor = System.Drawing.Color.White;
            this.txtSoHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.txtSoHoaDon.Location = new System.Drawing.Point(189, 47);
            this.txtSoHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.ReadOnly = true;
            this.txtSoHoaDon.Size = new System.Drawing.Size(76, 32);
            this.txtSoHoaDon.TabIndex = 7;
            this.txtSoHoaDon.Text = "0";
            this.txtSoHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTrangThaiCa
            // 
            this.lblTrangThaiCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiCa.Location = new System.Drawing.Point(391, 44);
            this.lblTrangThaiCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrangThaiCa.Name = "lblTrangThaiCa";
            this.lblTrangThaiCa.Size = new System.Drawing.Size(120, 20);
            this.lblTrangThaiCa.TabIndex = 8;
            this.lblTrangThaiCa.Text = "📌 Trạng thái:";
            this.lblTrangThaiCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrangThaiCa
            // 
            this.txtTrangThaiCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.txtTrangThaiCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrangThaiCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTrangThaiCa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.txtTrangThaiCa.Location = new System.Drawing.Point(544, 45);
            this.txtTrangThaiCa.Margin = new System.Windows.Forms.Padding(2);
            this.txtTrangThaiCa.Name = "txtTrangThaiCa";
            this.txtTrangThaiCa.ReadOnly = true;
            this.txtTrangThaiCa.Size = new System.Drawing.Size(163, 27);
            this.txtTrangThaiCa.TabIndex = 9;
            this.txtTrangThaiCa.Text = "CHƯA MỞ CA";
            this.txtTrangThaiCa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlFinancial
            // 
            this.pnlFinancial.BackColor = System.Drawing.Color.White;
            this.pnlFinancial.Controls.Add(this.lblTongDoanhThu);
            this.pnlFinancial.Controls.Add(this.txtTongDoanhThu);
            this.pnlFinancial.Controls.Add(this.lblTienMat);
            this.pnlFinancial.Controls.Add(this.txtTienMat);
            this.pnlFinancial.Controls.Add(this.lblChuyenKhoan);
            this.pnlFinancial.Controls.Add(this.txtChuyenKhoan);
            this.pnlFinancial.Controls.Add(this.lblTienDauCa);
            this.pnlFinancial.Controls.Add(this.txtTienDauCa);
            this.pnlFinancial.Controls.Add(this.btnMoCa);
            this.pnlFinancial.Controls.Add(this.btnDongCa);
            this.pnlFinancial.Controls.Add(this.btnInBaoCao);
            this.pnlFinancial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFinancial.Location = new System.Drawing.Point(10, 145);
            this.pnlFinancial.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFinancial.Name = "pnlFinancial";
            this.pnlFinancial.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlFinancial.Size = new System.Drawing.Size(805, 162);
            this.pnlFinancial.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(2, 17);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(150, 20);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = " Tổng doanh thu:";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.BackColor = System.Drawing.Color.White;
            this.txtTongDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.Black;
            this.txtTongDoanhThu.Location = new System.Drawing.Point(156, 12);
            this.txtTongDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(136, 29);
            this.txtTongDoanhThu.TabIndex = 1;
            this.txtTongDoanhThu.Text = "0 VNĐ";
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienMat
            // 
            this.lblTienMat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienMat.Location = new System.Drawing.Point(13, 72);
            this.lblTienMat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTienMat.Name = "lblTienMat";
            this.lblTienMat.Size = new System.Drawing.Size(98, 20);
            this.lblTienMat.TabIndex = 2;
            this.lblTienMat.Text = "Tiền mặt:";
            this.lblTienMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTienMat
            // 
            this.txtTienMat.BackColor = System.Drawing.Color.White;
            this.txtTienMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienMat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienMat.Location = new System.Drawing.Point(156, 64);
            this.txtTienMat.Margin = new System.Windows.Forms.Padding(2);
            this.txtTienMat.Name = "txtTienMat";
            this.txtTienMat.ReadOnly = true;
            this.txtTienMat.Size = new System.Drawing.Size(136, 27);
            this.txtTienMat.TabIndex = 3;
            this.txtTienMat.Text = "0 VNĐ";
            this.txtTienMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChuyenKhoan
            // 
            this.lblChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuyenKhoan.Location = new System.Drawing.Point(13, 123);
            this.lblChuyenKhoan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChuyenKhoan.Name = "lblChuyenKhoan";
            this.lblChuyenKhoan.Size = new System.Drawing.Size(150, 20);
            this.lblChuyenKhoan.TabIndex = 4;
            this.lblChuyenKhoan.Text = "Chuyển khoản:";
            this.lblChuyenKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChuyenKhoan
            // 
            this.txtChuyenKhoan.BackColor = System.Drawing.Color.White;
            this.txtChuyenKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtChuyenKhoan.Location = new System.Drawing.Point(156, 123);
            this.txtChuyenKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.txtChuyenKhoan.Name = "txtChuyenKhoan";
            this.txtChuyenKhoan.ReadOnly = true;
            this.txtChuyenKhoan.Size = new System.Drawing.Size(136, 27);
            this.txtChuyenKhoan.TabIndex = 5;
            this.txtChuyenKhoan.Text = "0 VNĐ";
            this.txtChuyenKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienDauCa
            // 
            this.lblTienDauCa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDauCa.Location = new System.Drawing.Point(310, 14);
            this.lblTienDauCa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTienDauCa.Name = "lblTienDauCa";
            this.lblTienDauCa.Size = new System.Drawing.Size(148, 27);
            this.lblTienDauCa.TabIndex = 6;
            this.lblTienDauCa.Text = " Tiền đầu ca:";
            this.lblTienDauCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTienDauCa
            // 
            this.txtTienDauCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienDauCa.Enabled = false;
            this.txtTienDauCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienDauCa.Location = new System.Drawing.Point(462, 12);
            this.txtTienDauCa.Margin = new System.Windows.Forms.Padding(2);
            this.txtTienDauCa.Name = "txtTienDauCa";
            this.txtTienDauCa.Size = new System.Drawing.Size(136, 27);
            this.txtTienDauCa.TabIndex = 7;
            this.txtTienDauCa.Text = "0";
            this.txtTienDauCa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnMoCa
            // 
            this.btnMoCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnMoCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoCa.FlatAppearance.BorderSize = 0;
            this.btnMoCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoCa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMoCa.ForeColor = System.Drawing.Color.White;
            this.btnMoCa.Location = new System.Drawing.Point(629, 15);
            this.btnMoCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoCa.Name = "btnMoCa";
            this.btnMoCa.Size = new System.Drawing.Size(150, 29);
            this.btnMoCa.TabIndex = 12;
            this.btnMoCa.Text = "🔓 MỞ CA";
            this.btnMoCa.UseVisualStyleBackColor = false;
            // 
            // btnDongCa
            // 
            this.btnDongCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDongCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongCa.Enabled = false;
            this.btnDongCa.FlatAppearance.BorderSize = 0;
            this.btnDongCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongCa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDongCa.ForeColor = System.Drawing.Color.White;
            this.btnDongCa.Location = new System.Drawing.Point(629, 15);
            this.btnDongCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnDongCa.Name = "btnDongCa";
            this.btnDongCa.Size = new System.Drawing.Size(150, 29);
            this.btnDongCa.TabIndex = 13;
            this.btnDongCa.Text = "🔒 ĐÓNG CA";
            this.btnDongCa.UseVisualStyleBackColor = false;
            this.btnDongCa.Visible = false;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.btnInBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInBaoCao.Enabled = false;
            this.btnInBaoCao.FlatAppearance.BorderSize = 0;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Location = new System.Drawing.Point(629, 74);
            this.btnInBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(150, 27);
            this.btnInBaoCao.TabIndex = 15;
            this.btnInBaoCao.Text = "🖨️ XUẤT BÁO CÁO";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click_1);
            // 
            // dgvHoaDonTrongCa
            // 
            this.dgvHoaDonTrongCa.AllowUserToAddRows = false;
            this.dgvHoaDonTrongCa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvHoaDonTrongCa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDonTrongCa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonTrongCa.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.dgvHoaDonTrongCa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHoaDonTrongCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonTrongCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonTrongCa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHoaDonTrongCa.Location = new System.Drawing.Point(10, 311);
            this.dgvHoaDonTrongCa.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoaDonTrongCa.Name = "dgvHoaDonTrongCa";
            this.dgvHoaDonTrongCa.ReadOnly = true;
            this.dgvHoaDonTrongCa.RowHeadersVisible = false;
            this.dgvHoaDonTrongCa.RowHeadersWidth = 51;
            this.dgvHoaDonTrongCa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonTrongCa.Size = new System.Drawing.Size(805, 136);
            this.dgvHoaDonTrongCa.TabIndex = 3;
            // 
            // timerRealTime
            // 
            this.timerRealTime.Interval = 1000;
            // 
            // UCDongca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCDongca";
            this.Size = new System.Drawing.Size(825, 455);
            this.Load += new System.EventHandler(this.UCDongca_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlShiftInfo.ResumeLayout(false);
            this.pnlShiftInfo.PerformLayout();
            this.pnlFinancial.ResumeLayout(false);
            this.pnlFinancial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonTrongCa)).EndInit();
            this.ResumeLayout(false);

        }
    }
}