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

        // Thông tin ca làm việc
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.TextBox txtNhanVien;
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
        private System.Windows.Forms.Label lblThucThu;
        private System.Windows.Forms.TextBox txtThucThu;
        private System.Windows.Forms.Label lblChenhLech;
        private System.Windows.Forms.TextBox txtChenhLech;

        // Buttons
        private System.Windows.Forms.Button btnMoCa;
        private System.Windows.Forms.Button btnDongCa;
        private System.Windows.Forms.Button btnXemBaoCao;
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

            // Khởi tạo các thành phần
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlShiftInfo = new System.Windows.Forms.Panel();
            this.pnlFinancial = new System.Windows.Forms.Panel();
            this.dgvHoaDonTrongCa = new System.Windows.Forms.DataGridView();
            this.timerRealTime = new System.Windows.Forms.Timer(this.components);

            // Thông tin ca
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.lblGioMoCa = new System.Windows.Forms.Label();
            this.txtGioMoCa = new System.Windows.Forms.TextBox();
            this.lblGioDongCa = new System.Windows.Forms.Label();
            this.txtGioDongCa = new System.Windows.Forms.TextBox();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.lblTrangThaiCa = new System.Windows.Forms.Label();
            this.txtTrangThaiCa = new System.Windows.Forms.TextBox();

            // Thông tin tài chính
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTienMat = new System.Windows.Forms.Label();
            this.txtTienMat = new System.Windows.Forms.TextBox();
            this.lblChuyenKhoan = new System.Windows.Forms.Label();
            this.txtChuyenKhoan = new System.Windows.Forms.TextBox();
            this.lblTienDauCa = new System.Windows.Forms.Label();
            this.txtTienDauCa = new System.Windows.Forms.TextBox();
            this.lblThucThu = new System.Windows.Forms.Label();
            this.txtThucThu = new System.Windows.Forms.TextBox();
            this.lblChenhLech = new System.Windows.Forms.Label();
            this.txtChenhLech = new System.Windows.Forms.TextBox();

            // Buttons
            this.btnMoCa = new System.Windows.Forms.Button();
            this.btnDongCa = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();

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
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 700);

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(13, 13);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(974, 54);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(974, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 QUẢN LÝ CA LÀM VIỆC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlShiftInfo
            // 
            this.pnlShiftInfo.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlShiftInfo.Controls.Add(this.lblNhanVien);
            this.pnlShiftInfo.Controls.Add(this.txtNhanVien);
            this.pnlShiftInfo.Controls.Add(this.lblGioMoCa);
            this.pnlShiftInfo.Controls.Add(this.txtGioMoCa);
            this.pnlShiftInfo.Controls.Add(this.lblGioDongCa);
            this.pnlShiftInfo.Controls.Add(this.txtGioDongCa);
            this.pnlShiftInfo.Controls.Add(this.lblSoHoaDon);
            this.pnlShiftInfo.Controls.Add(this.txtSoHoaDon);
            this.pnlShiftInfo.Controls.Add(this.lblTrangThaiCa);
            this.pnlShiftInfo.Controls.Add(this.txtTrangThaiCa);
            this.pnlShiftInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShiftInfo.Location = new System.Drawing.Point(13, 73);
            this.pnlShiftInfo.Name = "pnlShiftInfo";
            this.pnlShiftInfo.Padding = new System.Windows.Forms.Padding(15);
            this.pnlShiftInfo.Size = new System.Drawing.Size(974, 144);
            this.pnlShiftInfo.TabIndex = 1;

            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Location = new System.Drawing.Point(20, 20);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(100, 30);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "👤 Nhân viên:";
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtNhanVien
            // 
            this.txtNhanVien.BackColor = System.Drawing.Color.White;
            this.txtNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNhanVien.Location = new System.Drawing.Point(130, 18);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.ReadOnly = true;
            this.txtNhanVien.Size = new System.Drawing.Size(200, 32);
            this.txtNhanVien.TabIndex = 1;

            // 
            // lblGioMoCa
            // 
            this.lblGioMoCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGioMoCa.Location = new System.Drawing.Point(350, 20);
            this.lblGioMoCa.Name = "lblGioMoCa";
            this.lblGioMoCa.Size = new System.Drawing.Size(110, 30);
            this.lblGioMoCa.TabIndex = 2;
            this.lblGioMoCa.Text = "🕐 Giờ mở ca:";
            this.lblGioMoCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtGioMoCa
            // 
            this.txtGioMoCa.BackColor = System.Drawing.Color.White;
            this.txtGioMoCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGioMoCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGioMoCa.Location = new System.Drawing.Point(470, 18);
            this.txtGioMoCa.Name = "txtGioMoCa";
            this.txtGioMoCa.ReadOnly = true;
            this.txtGioMoCa.Size = new System.Drawing.Size(180, 32);
            this.txtGioMoCa.TabIndex = 3;
            this.txtGioMoCa.Text = "--:--:--";

            // 
            // lblGioDongCa
            // 
            this.lblGioDongCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGioDongCa.Location = new System.Drawing.Point(20, 65);
            this.lblGioDongCa.Name = "lblGioDongCa";
            this.lblGioDongCa.Size = new System.Drawing.Size(110, 30);
            this.lblGioDongCa.TabIndex = 4;
            this.lblGioDongCa.Text = "🔒 Giờ đóng ca:";
            this.lblGioDongCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtGioDongCa
            // 
            this.txtGioDongCa.BackColor = System.Drawing.Color.White;
            this.txtGioDongCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGioDongCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGioDongCa.Location = new System.Drawing.Point(130, 63);
            this.txtGioDongCa.Name = "txtGioDongCa";
            this.txtGioDongCa.ReadOnly = true;
            this.txtGioDongCa.Size = new System.Drawing.Size(200, 32);
            this.txtGioDongCa.TabIndex = 5;
            this.txtGioDongCa.Text = "--:--:--";

            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.Location = new System.Drawing.Point(350, 65);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(110, 30);
            this.lblSoHoaDon.TabIndex = 6;
            this.lblSoHoaDon.Text = "📄 Số hóa đơn:";
            this.lblSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.BackColor = System.Drawing.Color.White;
            this.txtSoHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.txtSoHoaDon.Location = new System.Drawing.Point(470, 60);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.ReadOnly = true;
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 36);
            this.txtSoHoaDon.TabIndex = 7;
            this.txtSoHoaDon.Text = "0";
            this.txtSoHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // lblTrangThaiCa
            // 
            this.lblTrangThaiCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiCa.Location = new System.Drawing.Point(20, 108);
            this.lblTrangThaiCa.Name = "lblTrangThaiCa";
            this.lblTrangThaiCa.Size = new System.Drawing.Size(110, 30);
            this.lblTrangThaiCa.TabIndex = 8;
            this.lblTrangThaiCa.Text = "📌 Trạng thái:";
            this.lblTrangThaiCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtTrangThaiCa
            // 
            this.txtTrangThaiCa.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
            this.txtTrangThaiCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrangThaiCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTrangThaiCa.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.txtTrangThaiCa.Location = new System.Drawing.Point(130, 106);
            this.txtTrangThaiCa.Name = "txtTrangThaiCa";
            this.txtTrangThaiCa.ReadOnly = true;
            this.txtTrangThaiCa.Size = new System.Drawing.Size(200, 32);
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
            this.pnlFinancial.Controls.Add(this.lblThucThu);
            this.pnlFinancial.Controls.Add(this.txtThucThu);
            this.pnlFinancial.Controls.Add(this.lblChenhLech);
            this.pnlFinancial.Controls.Add(this.txtChenhLech);
            this.pnlFinancial.Controls.Add(this.btnMoCa);
            this.pnlFinancial.Controls.Add(this.btnDongCa);
            this.pnlFinancial.Controls.Add(this.btnXemBaoCao);
            this.pnlFinancial.Controls.Add(this.btnInBaoCao);
            this.pnlFinancial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFinancial.Location = new System.Drawing.Point(13, 223);
            this.pnlFinancial.Name = "pnlFinancial";
            this.pnlFinancial.Padding = new System.Windows.Forms.Padding(15);
            this.pnlFinancial.Size = new System.Drawing.Size(974, 154);
            this.pnlFinancial.TabIndex = 2;

            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(15, 20);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(130, 30);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "💰 Tổng doanh thu:";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            this.txtTongDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.Green;
            this.txtTongDoanhThu.Location = new System.Drawing.Point(155, 18);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(180, 34);
            this.txtTongDoanhThu.TabIndex = 1;
            this.txtTongDoanhThu.Text = "0 VNĐ";
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblTienMat
            // 
            this.lblTienMat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienMat.Location = new System.Drawing.Point(15, 65);
            this.lblTienMat.Name = "lblTienMat";
            this.lblTienMat.Size = new System.Drawing.Size(130, 30);
            this.lblTienMat.TabIndex = 2;
            this.lblTienMat.Text = "💵 Tiền mặt:";
            this.lblTienMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtTienMat
            // 
            this.txtTienMat.BackColor = System.Drawing.Color.White;
            this.txtTienMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienMat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienMat.Location = new System.Drawing.Point(155, 63);
            this.txtTienMat.Name = "txtTienMat";
            this.txtTienMat.ReadOnly = true;
            this.txtTienMat.Size = new System.Drawing.Size(180, 32);
            this.txtTienMat.TabIndex = 3;
            this.txtTienMat.Text = "0 VNĐ";
            this.txtTienMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblChuyenKhoan
            // 
            this.lblChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblChuyenKhoan.Location = new System.Drawing.Point(15, 108);
            this.lblChuyenKhoan.Name = "lblChuyenKhoan";
            this.lblChuyenKhoan.Size = new System.Drawing.Size(130, 30);
            this.lblChuyenKhoan.TabIndex = 4;
            this.lblChuyenKhoan.Text = "💳 Chuyển khoản:";
            this.lblChuyenKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtChuyenKhoan
            // 
            this.txtChuyenKhoan.BackColor = System.Drawing.Color.White;
            this.txtChuyenKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtChuyenKhoan.Location = new System.Drawing.Point(155, 106);
            this.txtChuyenKhoan.Name = "txtChuyenKhoan";
            this.txtChuyenKhoan.ReadOnly = true;
            this.txtChuyenKhoan.Size = new System.Drawing.Size(180, 32);
            this.txtChuyenKhoan.TabIndex = 5;
            this.txtChuyenKhoan.Text = "0 VNĐ";
            this.txtChuyenKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblTienDauCa
            // 
            this.lblTienDauCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienDauCa.Location = new System.Drawing.Point(360, 20);
            this.lblTienDauCa.Name = "lblTienDauCa";
            this.lblTienDauCa.Size = new System.Drawing.Size(120, 30);
            this.lblTienDauCa.TabIndex = 6;
            this.lblTienDauCa.Text = "🎯 Tiền đầu ca:";
            this.lblTienDauCa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtTienDauCa
            // 
            this.txtTienDauCa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienDauCa.Enabled = false;
            this.txtTienDauCa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienDauCa.Location = new System.Drawing.Point(490, 18);
            this.txtTienDauCa.Name = "txtTienDauCa";
            this.txtTienDauCa.Size = new System.Drawing.Size(180, 32);
            this.txtTienDauCa.TabIndex = 7;
            this.txtTienDauCa.Text = "0";
            this.txtTienDauCa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblThucThu
            // 
            this.lblThucThu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblThucThu.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblThucThu.Location = new System.Drawing.Point(360, 65);
            this.lblThucThu.Name = "lblThucThu";
            this.lblThucThu.Size = new System.Drawing.Size(120, 35);
            this.lblThucThu.TabIndex = 8;
            this.lblThucThu.Text = "✅ Thực thu:";
            this.lblThucThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtThucThu
            // 
            this.txtThucThu.BackColor = System.Drawing.Color.FromArgb(255, 245, 245);
            this.txtThucThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThucThu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtThucThu.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.txtThucThu.Location = new System.Drawing.Point(490, 60);
            this.txtThucThu.Name = "txtThucThu";
            this.txtThucThu.ReadOnly = true;
            this.txtThucThu.Size = new System.Drawing.Size(200, 40);
            this.txtThucThu.TabIndex = 9;
            this.txtThucThu.Text = "0 VNĐ";
            this.txtThucThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // lblChenhLech
            // 
            this.lblChenhLech.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblChenhLech.Location = new System.Drawing.Point(360, 108);
            this.lblChenhLech.Name = "lblChenhLech";
            this.lblChenhLech.Size = new System.Drawing.Size(120, 30);
            this.lblChenhLech.TabIndex = 10;
            this.lblChenhLech.Text = "⚖️ Chênh lệch:";
            this.lblChenhLech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtChenhLech
            // 
            this.txtChenhLech.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.txtChenhLech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChenhLech.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtChenhLech.Location = new System.Drawing.Point(490, 106);
            this.txtChenhLech.Name = "txtChenhLech";
            this.txtChenhLech.ReadOnly = true;
            this.txtChenhLech.Size = new System.Drawing.Size(180, 32);
            this.txtChenhLech.TabIndex = 11;
            this.txtChenhLech.Text = "0 VNĐ";
            this.txtChenhLech.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // btnMoCa
            // 
            this.btnMoCa.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnMoCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoCa.Enabled = true;
            this.btnMoCa.FlatAppearance.BorderSize = 0;
            this.btnMoCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoCa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMoCa.ForeColor = System.Drawing.Color.White;
            this.btnMoCa.Location = new System.Drawing.Point(740, 15);
            this.btnMoCa.Name = "btnMoCa";
            this.btnMoCa.Size = new System.Drawing.Size(200, 45);
            this.btnMoCa.TabIndex = 12;
            this.btnMoCa.Text = "🔓 MỞ CA";
            this.btnMoCa.UseVisualStyleBackColor = false;

            // 
            // btnDongCa
            // 
            this.btnDongCa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDongCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongCa.Enabled = false;
            this.btnDongCa.FlatAppearance.BorderSize = 0;
            this.btnDongCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongCa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDongCa.ForeColor = System.Drawing.Color.White;
            this.btnDongCa.Location = new System.Drawing.Point(740, 15);
            this.btnDongCa.Name = "btnDongCa";
            this.btnDongCa.Size = new System.Drawing.Size(200, 45);
            this.btnDongCa.TabIndex = 13;
            this.btnDongCa.Text = "🔒 ĐÓNG CA";
            this.btnDongCa.UseVisualStyleBackColor = false;
            this.btnDongCa.Visible = false;

            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnXemBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemBaoCao.Enabled = false;
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(740, 65);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(200, 35);
            this.btnXemBaoCao.TabIndex = 14;
            this.btnXemBaoCao.Text = "📊 XEM BÁO CÁO";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;

            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnInBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInBaoCao.Enabled = false;
            this.btnInBaoCao.FlatAppearance.BorderSize = 0;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Location = new System.Drawing.Point(740, 106);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(200, 35);
            this.btnInBaoCao.TabIndex = 15;
            this.btnInBaoCao.Text = "🖨️ IN BÁO CÁO";
            this.btnInBaoCao.UseVisualStyleBackColor = false;

            // 
            // dgvHoaDonTrongCa
            // 
            this.dgvHoaDonTrongCa.AllowUserToAddRows = false;
            this.dgvHoaDonTrongCa.AllowUserToDeleteRows = false;
            this.dgvHoaDonTrongCa.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvHoaDonTrongCa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonTrongCa.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDonTrongCa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHoaDonTrongCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonTrongCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonTrongCa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHoaDonTrongCa.Location = new System.Drawing.Point(13, 383);
            this.dgvHoaDonTrongCa.Name = "dgvHoaDonTrongCa";
            this.dgvHoaDonTrongCa.ReadOnly = true;
            this.dgvHoaDonTrongCa.RowHeadersVisible = false;
            this.dgvHoaDonTrongCa.RowHeadersWidth = 51;
            this.dgvHoaDonTrongCa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonTrongCa.Size = new System.Drawing.Size(974, 304);
            this.dgvHoaDonTrongCa.TabIndex = 3;

            // 
            // timerRealTime
            // 
            this.timerRealTime.Interval = 1000;

            // 
            // UCDongca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.Controls.Add(this.tlpMain);
            this.Name = "UCDongca";
            this.Size = new System.Drawing.Size(1000, 700);
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