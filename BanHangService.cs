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

        public static void ThanhToan(int hoaDonId, string phuongThuc = "tien_mat")
        {
            DbHelper.Execute(@"
                UPDATE HoaDon SET trang_thai = N'da_thanh_toan', phuong_thuc_tt = @ptt,
                    thanh_toan = tong_tien - giam_gia
                WHERE id = @id",
                new SqlParameter("@ptt", phuongThuc),
                new SqlParameter("@id", hoaDonId));
        }

        public static void HuyHoaDon(int hoaDonId)
        {
            DbHelper.Execute("DELETE FROM ChiTietHoaDon WHERE hoa_don_id = @id",
                new SqlParameter("@id", hoaDonId));
            DbHelper.Execute(
                "UPDATE HoaDon SET trang_thai = N'huy', tong_tien = 0, thanh_toan = 0 WHERE id = @id",
                new SqlParameter("@id", hoaDonId));
        }

        public static void XoaChiTiet(int chiTietId, int hoaDonId)
        {
            DbHelper.Execute("DELETE FROM ChiTietHoaDon WHERE id = @id",
                new SqlParameter("@id", chiTietId));
            CapNhatTongHoaDon(hoaDonId);
        }
    }
}
