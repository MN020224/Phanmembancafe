using System;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class BanHangService
    {
        public static DataTable GetDanhMuc()
        {
            return DbHelper.Query(
                "SELECT id, ten_danh_muc FROM DanhMuc WHERE hien_thi = 1 ORDER BY thu_tu, ten_danh_muc");
        }

        public static DataTable GetMonAnByDanhMuc(int danhMucId)
        {
            return DbHelper.Query(
                "SELECT id, ten_mon, gia FROM MonAn WHERE danh_muc_id = @dm AND kha_dung = 1 ORDER BY thu_tu, ten_mon",
                new SqlParameter("@dm", danhMucId));
        }

        public static int? GetHoaDonChoThanhToan(int caId)
        {
            var o = DbHelper.Scalar(
                "SELECT TOP 1 id FROM HoaDon WHERE ca_id = @caId AND trang_thai = N'cho_thanh_toan' ORDER BY id DESC",
                new SqlParameter("@caId", caId));
            if (o == null || o == DBNull.Value)
                return null;
            return Convert.ToInt32(o);
        }

        public static int TaoHoaDon(int caId)
        {
            var ma = "HD" + DateTime.Now.ToString("yyMMddHHmmss");
            return DbHelper.ExecuteIdentity(@"
                INSERT INTO HoaDon(ca_id, ma_hoa_don, tong_tien, giam_gia, thanh_toan, phuong_thuc_tt, trang_thai, tao_luc)
                VALUES (@caId, @ma, 0, 0, 0, N'tien_mat', N'cho_thanh_toan', GETDATE())",
                new SqlParameter("@caId", caId),
                new SqlParameter("@ma", ma));
        }

        public static void ThemChiTiet(int hoaDonId, int monAnId, int soLuong, decimal donGia)
        {
            var thanhTien = donGia * soLuong;
            var existing = DbHelper.Scalar(
                "SELECT id FROM ChiTietHoaDon WHERE hoa_don_id = @hd AND mon_an_id = @mon",
                new SqlParameter("@hd", hoaDonId),
                new SqlParameter("@mon", monAnId));

            if (existing != null && existing != DBNull.Value)
            {
                DbHelper.Execute(@"
                    UPDATE ChiTietHoaDon
                    SET so_luong = so_luong + @sl,
                        thanh_tien = (so_luong + @sl) * don_gia
                    WHERE hoa_don_id = @hd AND mon_an_id = @mon",
                    new SqlParameter("@sl", soLuong),
                    new SqlParameter("@hd", hoaDonId),
                    new SqlParameter("@mon", monAnId));
            }
            else
            {
                DbHelper.Execute(@"
                    INSERT INTO ChiTietHoaDon(hoa_don_id, mon_an_id, so_luong, don_gia, thanh_tien)
                    VALUES (@hd, @mon, @sl, @gia, @tt)",
                    new SqlParameter("@hd", hoaDonId),
                    new SqlParameter("@mon", monAnId),
                    new SqlParameter("@sl", soLuong),
                    new SqlParameter("@gia", donGia),
                    new SqlParameter("@tt", thanhTien));
            }
            CapNhatTongHoaDon(hoaDonId);
        }

        public static void CapNhatTongHoaDon(int hoaDonId)
        {
            DbHelper.Execute(@"
                UPDATE HoaDon SET tong_tien = (
                    SELECT ISNULL(SUM(thanh_tien), 0) FROM ChiTietHoaDon WHERE hoa_don_id = @id
                ), thanh_toan = (
                    SELECT ISNULL(SUM(thanh_tien), 0) FROM ChiTietHoaDon WHERE hoa_don_id = @id
                ) - giam_gia
                WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
        }

        public static DataTable GetChiTietHoaDon(int hoaDonId)
        {
            return DbHelper.Query(@"
                SELECT ct.id, m.ten_mon AS TenMon, ct.so_luong AS SoLuong,
                       ct.don_gia AS DonGia, ct.thanh_tien AS ThanhTien, ct.mon_an_id AS mon_an_id
                FROM ChiTietHoaDon ct
                INNER JOIN MonAn m ON m.id = ct.mon_an_id
                WHERE ct.hoa_don_id = @id
                ORDER BY ct.id",
                new SqlParameter("@id", hoaDonId));
        }

        public static decimal LayTongTien(int hoaDonId)
        {
            var o = DbHelper.Scalar("SELECT thanh_toan FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
            return o == null || o == DBNull.Value ? 0 : Convert.ToDecimal(o);
        }

        public static DataRow GetHoaDonInfo(int hoaDonId)
        {
            var dt = DbHelper.Query("SELECT * FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public static void ThanhToan(int hoaDonId, string phuongThuc = "tien_mat")
        {
            var trangThai = DbHelper.Scalar(
                "SELECT trang_thai FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));

            if (trangThai == null || trangThai == DBNull.Value)
                throw new Exception("Hóa đơn không tồn tại!");

            if (trangThai.ToString() == "da_thanh_toan")
                throw new Exception("Hóa đơn đã được thanh toán trước đó!");

            if (trangThai.ToString() == "huy")
                throw new Exception("Hóa đơn đã bị hủy, không thể thanh toán!");

            DbHelper.Execute(@"
                UPDATE HoaDon 
                SET trang_thai = N'da_thanh_toan', 
                    phuong_thuc_tt = @ptt,
                    thanh_toan = tong_tien - giam_gia
                WHERE id = @id",
                new SqlParameter("@ptt", phuongThuc),
                new SqlParameter("@id", hoaDonId));
        }

        public static void HuyHoaDon(int hoaDonId)
        {
            var exists = DbHelper.Scalar("SELECT id FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));

            if (exists == null || exists == DBNull.Value)
                throw new Exception("Hóa đơn không tồn tại!");

            var trangThai = DbHelper.Scalar("SELECT trang_thai FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));

            if (trangThai != null && trangThai.ToString() == "da_thanh_toan")
                throw new Exception("Không thể hủy hóa đơn đã thanh toán!");

            DbHelper.Execute("DELETE FROM ChiTietHoaDon WHERE hoa_don_id = @id",
                new SqlParameter("@id", hoaDonId));
            DbHelper.Execute(
                "UPDATE HoaDon SET trang_thai = N'huy', tong_tien = 0, thanh_toan = 0, giam_gia = 0 WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
        }

        public static void XoaChiTiet(int hoaDonId, int chiTietId)
        {
            var exists = DbHelper.Scalar(
                "SELECT id FROM ChiTietHoaDon WHERE id = @ctId AND hoa_don_id = @hdId",
                new SqlParameter("@ctId", chiTietId),
                new SqlParameter("@hdId", hoaDonId));

            if (exists == null || exists == DBNull.Value)
                throw new Exception("Không tìm thấy món cần xóa!");

            DbHelper.Execute("DELETE FROM ChiTietHoaDon WHERE id = @id",
                new SqlParameter("@id", chiTietId));
            CapNhatTongHoaDon(hoaDonId);
        }

        public static int GetTongSoLuongMon(int hoaDonId)
        {
            var o = DbHelper.Scalar(
                "SELECT ISNULL(SUM(so_luong), 0) FROM ChiTietHoaDon WHERE hoa_don_id = @id",
                new SqlParameter("@id", hoaDonId));
            return o == null || o == DBNull.Value ? 0 : Convert.ToInt32(o);
        }

        public static bool IsHoaDonEmpty(int hoaDonId)
        {
            int count = GetTongSoLuongMon(hoaDonId);
            return count == 0;
        }

        // 🔥 ĐÃ XÓA METHOD ApGiamGia

        public static DataTable ThongKeDoanhThuTheoPhuongThuc(DateTime tuNgay, DateTime denNgay)
        {
            return DbHelper.Query(@"
                SELECT 
                    CASE phuong_thuc_tt
                        WHEN N'tien_mat' THEN N'Tiền mặt'
                        WHEN N'chuyen_khoan' THEN N'Chuyển khoản'
                        WHEN N'vi_dien_tu' THEN N'Ví điện tử'
                        ELSE phuong_thuc_tt
                    END AS PhuongThucThanhToan,
                    COUNT(*) AS SoLuongHoaDon,
                    SUM(thanh_toan) AS TongDoanhThu
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                    AND tao_luc >= @tuNgay
                    AND tao_luc <= @denNgay
                GROUP BY phuong_thuc_tt",
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }
        public static string LayGhiChuHoaDon(int hoaDonId)
        {
            var o = DbHelper.Scalar("SELECT ghi_chu FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
            return o == null || o == DBNull.Value ? "" : o.ToString();
        }

        public static void CapNhatGhiChuHoaDon(int hoaDonId, string ghiChu)
        {
            DbHelper.Execute(
                "UPDATE HoaDon SET ghi_chu = @ghichu WHERE id = @id",
                new SqlParameter("@ghichu", string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu),
                new SqlParameter("@id", hoaDonId));
        }
    }
}