using System;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class CaService
    {
        public static int? GetOpenCaId(int taiKhoanId)
        {
            var o = DbHelper.Scalar(
                "SELECT TOP 1 id FROM Ca WHERE tai_khoan_id = @uid AND trang_thai = N'dang_mo' ORDER BY id DESC",
                new SqlParameter("@uid", taiKhoanId));
            if (o == null || o == DBNull.Value)
                return null;
            return Convert.ToInt32(o);
        }

        public static int MoCa(int taiKhoanId, decimal tienDauCa)
        {
            var existing = GetOpenCaId(taiKhoanId);
            if (existing.HasValue)
                return existing.Value;

            return DbHelper.ExecuteIdentity(
                "INSERT INTO Ca(tai_khoan_id, gio_mo, tien_dau_ca, trang_thai) VALUES (@uid, GETDATE(), @tien, N'dang_mo')",
                new SqlParameter("@uid", taiKhoanId),
                new SqlParameter("@tien", tienDauCa));
        }

        public static void DongCa(int caId, decimal tienCuoiCa)
        {
            DbHelper.Execute(
                "UPDATE Ca SET gio_dong = GETDATE(), tien_cuoi_ca = @tien, trang_thai = N'da_dong' WHERE id = @id",
                new SqlParameter("@tien", tienCuoiCa),
                new SqlParameter("@id", caId));
        }

        public static DataRow GetCaInfo(int caId)
        {
            var dt = DbHelper.Query(@"
                SELECT c.id, c.gio_mo, c.gio_dong, c.tien_dau_ca, c.tien_cuoi_ca, c.trang_thai,
                       tk.ten_dang_nhap
                FROM Ca c
                INNER JOIN TaiKhoan tk ON tk.id = c.tai_khoan_id
                WHERE c.id = @id",
                new SqlParameter("@id", caId));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable GetHoaDonTrongCa(int caId)
        {
            return DbHelper.Query(@"
                SELECT ma_hoa_don AS MaHD,
                       CONVERT(varchar(8), tao_luc, 108) AS Gio,
                       thanh_toan AS TongTien,
                       phuong_thuc_tt AS HinhThuc
                FROM HoaDon
                WHERE ca_id = @caId AND trang_thai = N'da_thanh_toan'
                ORDER BY tao_luc DESC",
                new SqlParameter("@caId", caId));
        }

        public static decimal TongDoanhThuCa(int caId)
        {
            var o = DbHelper.Scalar(
                "SELECT ISNULL(SUM(thanh_toan), 0) FROM HoaDon WHERE ca_id = @caId AND trang_thai = N'da_thanh_toan'",
                new SqlParameter("@caId", caId));
            return Convert.ToDecimal(o);
        }

        public static int DemHoaDonCa(int caId)
        {
            var o = DbHelper.Scalar(
                "SELECT COUNT(*) FROM HoaDon WHERE ca_id = @caId AND trang_thai = N'da_thanh_toan'",
                new SqlParameter("@caId", caId));
            return Convert.ToInt32(o);
        }

        public static decimal TongTienMatCa(int caId)
        {
            var o = DbHelper.Scalar(
                "SELECT ISNULL(SUM(thanh_toan), 0) FROM HoaDon WHERE ca_id = @caId AND trang_thai = N'da_thanh_toan' AND phuong_thuc_tt = N'tien_mat'",
                new SqlParameter("@caId", caId));
            return Convert.ToDecimal(o);
        }

        public static decimal TongChuyenKhoanCa(int caId)
        {
            var o = DbHelper.Scalar(
                "SELECT ISNULL(SUM(thanh_toan), 0) FROM HoaDon WHERE ca_id = @caId AND trang_thai = N'da_thanh_toan' AND phuong_thuc_tt = N'chuyen_khoan'",
                new SqlParameter("@caId", caId));
            return Convert.ToDecimal(o);
        }

        public static decimal TongViDienTuCa(int caId)
        {
            var o = DbHelper.Scalar(
                "SELECT ISNULL(SUM(thanh_toan), 0) FROM HoaDon WHERE ca_id = @caId AND trang_thai = N'da_thanh_toan' AND phuong_thuc_tt = N'vi_dien_tu'",
                new SqlParameter("@caId", caId));
            return Convert.ToDecimal(o);
        }

        public static string HienThiPhuongThucThanhToan(string phuongThuc, bool coIcon = true)
        {
            switch (phuongThuc?.Trim().ToLowerInvariant())
            {
                case "tien_mat":
                    return coIcon ? "💵 Tiền mặt" : "Tiền mặt";
                case "chuyen_khoan":
                    return coIcon ? "💳 Chuyển khoản" : "Chuyển khoản";
                case "vi_dien_tu":
                    return coIcon ? "📱 Ví điện tử" : "Ví điện tử";
                default:
                    return string.IsNullOrWhiteSpace(phuongThuc) ? "—" : phuongThuc;
            }
        }

        public static string HienThiTrangThaiCa(string trangThai)
        {
            switch (trangThai?.Trim().ToLowerInvariant())
            {
                case "dang_mo":
                    return "🟢 Đang mở";
                case "da_dong":
                    return "🔴 Đã đóng";
                default:
                    return trangThai ?? "—";
            }
        }

        public static DataTable LayLichSuCa(DateTime tuNgay, DateTime denNgay, int? taiKhoanId = null)
        {
            return DbHelper.Query(@"
                SELECT
                    c.id AS CaId,
                    tk.ten_dang_nhap AS NhanVien,
                    c.gio_mo AS GioMo,
                    c.gio_dong AS GioDong,
                    c.tien_dau_ca AS TienDauCa,
                    c.tien_cuoi_ca AS TienCuoiCa,
                    c.trang_thai AS TrangThai,
                    (SELECT COUNT(*)
                     FROM HoaDon h
                     WHERE h.ca_id = c.id AND h.trang_thai = N'da_thanh_toan') AS SoHoaDon,
                    (SELECT ISNULL(SUM(h.thanh_toan), 0)
                     FROM HoaDon h
                     WHERE h.ca_id = c.id AND h.trang_thai = N'da_thanh_toan') AS DoanhThu
                FROM Ca c
                INNER JOIN TaiKhoan tk ON tk.id = c.tai_khoan_id
                WHERE CAST(c.gio_mo AS date) BETWEEN @tu AND @den
                  AND (@uid IS NULL OR c.tai_khoan_id = @uid)
                ORDER BY c.gio_mo DESC",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date),
                new SqlParameter("@uid", (object)taiKhoanId ?? DBNull.Value));
        }
    }
}
