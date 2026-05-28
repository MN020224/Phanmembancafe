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
                       ct.don_gia AS DonGia, ct.thanh_tien AS ThanhTien, ct.mon_an_id AS MonAnId
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

        // Thêm method mới: Lấy thông tin chi tiết hóa đơn
        public static DataRow GetHoaDonInfo(int hoaDonId)
        {
            var dt = DbHelper.Query("SELECT * FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        // Cập nhật method ThanhToan với kiểm tra và log
        public static void ThanhToan(int hoaDonId, string phuongThuc = "tien_mat")
        {
            // Kiểm tra hóa đơn tồn tại và trạng thái
            var trangThai = DbHelper.Scalar(
                "SELECT trang_thai FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));

            if (trangThai == null || trangThai == DBNull.Value)
                throw new Exception("Hóa đơn không tồn tại!");

            if (trangThai.ToString() == "da_thanh_toan")
                throw new Exception("Hóa đơn đã được thanh toán trước đó!");

            if (trangThai.ToString() == "huy")
                throw new Exception("Hóa đơn đã bị hủy, không thể thanh toán!");

            // Thực hiện thanh toán - ĐÃ XÓA thanh_toan_luc
            DbHelper.Execute(@"
        UPDATE HoaDon 
        SET trang_thai = N'da_thanh_toan', 
            phuong_thuc_tt = @ptt,
            thanh_toan = tong_tien - giam_gia
        WHERE id = @id",
                new SqlParameter("@ptt", phuongThuc),
                new SqlParameter("@id", hoaDonId));

            // Ghi log thanh toán
            GhiLogThanhToan(hoaDonId, phuongThuc);
        }

        // Method ghi log thanh toán
        private static void GhiLogThanhToan(int hoaDonId, string phuongThuc)
        {
            try
            {
                // Kiểm tra bảng LogThanhToan tồn tại không
                var checkTable = DbHelper.Scalar(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LogThanhToan'");

                if (checkTable != null && Convert.ToInt32(checkTable) > 0)
                {
                    DbHelper.Execute(@"
                        INSERT INTO LogThanhToan(hoa_don_id, phuong_thuc, thoi_gian)
                        VALUES(@hd, @ptt, GETDATE())",
                        new SqlParameter("@hd", hoaDonId),
                        new SqlParameter("@ptt", phuongThuc));
                }
            }
            catch
            {
                // Log lỗi nhưng không ảnh hưởng đến thanh toán chính
                // Có thể ghi ra file log nếu cần
            }
        }

        public static void HuyHoaDon(int hoaDonId)
        {
            // Kiểm tra hóa đơn có tồn tại không
            var exists = DbHelper.Scalar("SELECT id FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));

            if (exists == null || exists == DBNull.Value)
                throw new Exception("Hóa đơn không tồn tại!");

            // Kiểm tra trạng thái
            var trangThai = DbHelper.Scalar("SELECT trang_thai FROM HoaDon WHERE id = @id",
                new SqlParameter("@id", hoaDonId));

            if (trangThai != null && trangThai.ToString() == "da_thanh_toan")
                throw new Exception("Không thể hủy hóa đơn đã thanh toán!");

            // Thực hiện hủy hóa đơn
            DbHelper.Execute("DELETE FROM ChiTietHoaDon WHERE hoa_don_id = @id",
                new SqlParameter("@id", hoaDonId));
            DbHelper.Execute(
                "UPDATE HoaDon SET trang_thai = N'huy', tong_tien = 0, thanh_toan = 0, giam_gia = 0 WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
        }

        public static void XoaChiTiet(int hoaDonId, int chiTietId)
        {
            // Kiểm tra chi tiết có tồn tại không
            var exists = DbHelper.Scalar(
                "SELECT id FROM ChiTietHoaDon WHERE id = @ctId AND hoa_don_id = @hdId",
                new SqlParameter("@ctId", chiTietId),
                new SqlParameter("@hdId", hoaDonId));

            if (exists == null || exists == DBNull.Value)
                throw new Exception("Không tìm thấy món cần xóa!");

            // Xóa chi tiết
            DbHelper.Execute("DELETE FROM ChiTietHoaDon WHERE id = @id",
                new SqlParameter("@id", chiTietId));
            CapNhatTongHoaDon(hoaDonId);
        }

        // Thêm method để lấy tổng số lượng món trong hóa đơn
        public static int GetTongSoLuongMon(int hoaDonId)
        {
            var o = DbHelper.Scalar(
                "SELECT ISNULL(SUM(so_luong), 0) FROM ChiTietHoaDon WHERE hoa_don_id = @id",
                new SqlParameter("@id", hoaDonId));
            return o == null || o == DBNull.Value ? 0 : Convert.ToInt32(o);
        }

        // Thêm method để kiểm tra hóa đơn có trống không
        public static bool IsHoaDonEmpty(int hoaDonId)
        {
            int count = GetTongSoLuongMon(hoaDonId);
            return count == 0;
        }

        // Thêm method để áp dụng giảm giá (nếu cần)
        public static void ApGiamGia(int hoaDonId, decimal giamGia)
        {
            if (giamGia < 0)
                throw new Exception("Giảm giá không thể âm!");

            var tongTien = LayTongTien(hoaDonId);
            if (giamGia > tongTien)
                throw new Exception("Giảm giá không thể lớn hơn tổng tiền!");

            DbHelper.Execute(@"
                UPDATE HoaDon 
                SET giam_gia = @giamGia,
                    thanh_toan = tong_tien - @giamGia
                WHERE id = @id",
                new SqlParameter("@giamGia", giamGia),
                new SqlParameter("@id", hoaDonId));
        }

        // Thêm method để thống kê doanh thu theo phương thức thanh toán
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
                    AND thanh_toan_luc >= @tuNgay
                    AND thanh_toan_luc <= @denNgay
                GROUP BY phuong_thuc_tt",
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }
    }
}