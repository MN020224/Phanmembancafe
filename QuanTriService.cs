using System;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class QuanTriService
    {
        #region Danh mục
        public static DataTable LoadDanhMuc()
        {
            DataTable dt = DbHelper.Query("SELECT id, ten_danh_muc, thu_tu, hien_thi FROM DanhMuc ORDER BY thu_tu");
            // Thêm cột ID dạng DMxxx
            dt.Columns.Add("MaDanhMuc", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["MaDanhMuc"] = $"DM{row["id"]:D3}";
            }
            return dt;
        }

        public static DataTable LoadDanhMucCombo()
        {
            DataTable dt = DbHelper.Query("SELECT id, ten_danh_muc FROM DanhMuc WHERE hien_thi = 1 ORDER BY thu_tu");
            return dt;
        }

        public static void ThemDanhMuc(string ten)
        {
            DbHelper.Execute("INSERT INTO DanhMuc(ten_danh_muc, thu_tu, hien_thi) VALUES (@ten, 0, 1)",
                new SqlParameter("@ten", ten));
        }

        public static void SuaDanhMuc(int id, string ten)
        {
            DbHelper.Execute("UPDATE DanhMuc SET ten_danh_muc = @ten WHERE id = @id",
                new SqlParameter("@ten", ten),
                new SqlParameter("@id", id));
        }

        public static void XoaDanhMuc(int id)
        {
            DbHelper.Execute("DELETE FROM DanhMuc WHERE id = @id", new SqlParameter("@id", id));
        }
        #endregion

        #region Món ăn
        public static DataTable LoadMonAn()
        {
            DataTable dt = DbHelper.Query(@"
                SELECT m.id, m.ten_mon, m.gia, d.ten_danh_muc AS DanhMuc, m.danh_muc_id, m.kha_dung
                FROM MonAn m
                INNER JOIN DanhMuc d ON d.id = m.danh_muc_id
                ORDER BY d.thu_tu, m.thu_tu");

            // Thêm cột ID dạng Mxxx
            dt.Columns.Add("MaMon", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["MaMon"] = $"M{row["id"]:D3}";
            }
            return dt;
        }

        public static void ThemMon(int danhMucId, string ten, decimal gia)
        {
            DbHelper.Execute(
                "INSERT INTO MonAn(danh_muc_id, ten_mon, gia, kha_dung, thu_tu) VALUES (@dm, @ten, @gia, 1, 0)",
                new SqlParameter("@dm", danhMucId),
                new SqlParameter("@ten", ten),
                new SqlParameter("@gia", gia));
        }

        public static void SuaMon(int id, int danhMucId, string ten, decimal gia)
        {
            DbHelper.Execute(
                "UPDATE MonAn SET danh_muc_id = @dm, ten_mon = @ten, gia = @gia WHERE id = @id",
                new SqlParameter("@dm", danhMucId),
                new SqlParameter("@ten", ten),
                new SqlParameter("@gia", gia),
                new SqlParameter("@id", id));
        }

        public static void XoaMon(int id)
        {
            DbHelper.Execute("DELETE FROM MonAn WHERE id = @id", new SqlParameter("@id", id));
        }
        #endregion

        #region Báo cáo
        public static DataTable BaoCaoDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT 
                    CAST(tao_luc AS DATE) as Ngay,
                    COUNT(DISTINCT id) as SoHoaDon,
                    ISNULL(SUM(tong_tien), 0) as DoanhThu
                FROM HoaDon
                WHERE tao_luc >= @tuNgay AND tao_luc <= @denNgay
                    AND trang_thai = N'Đã thanh toán'
                GROUP BY CAST(tao_luc AS DATE)
                ORDER BY Ngay DESC";

            return DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }

        public static DataTable BaoCaoDoanhThuTheoThang(int nam)
        {
            string query = @"
                SELECT 
                    MONTH(tao_luc) as Thang,
                    COUNT(DISTINCT id) as SoHoaDon,
                    ISNULL(SUM(tong_tien), 0) as DoanhThu
                FROM HoaDon
                WHERE YEAR(tao_luc) = @nam
                    AND trang_thai = N'Đã thanh toán'
                GROUP BY MONTH(tao_luc)
                ORDER BY Thang";

            return DbHelper.Query(query, new SqlParameter("@nam", nam));
        }

        public static DataTable BaoCaoMonAnBanChay(DateTime tuNgay, DateTime denNgay, int top = 20)
        {
            string query = @"
                SELECT TOP (@top)
                    m.ten_mon,
                    ISNULL(SUM(ct.so_luong), 0) as SoLuongBan,
                    ISNULL(SUM(ct.so_luong * ct.don_gia), 0) as DoanhThu
                FROM ChiTietHoaDon ct
                INNER JOIN HoaDon h ON ct.hoa_don_id = h.id
                INNER JOIN MonAn m ON ct.mon_an_id = m.id
                WHERE h.tao_luc >= @tuNgay AND h.tao_luc <= @denNgay
                    AND h.trang_thai = N'Đã thanh toán'
                GROUP BY m.id, m.ten_mon
                ORDER BY SoLuongBan DESC";

            DataTable dt = DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay),
                new SqlParameter("@top", top));

            // Thêm cột xếp hạng
            dt.Columns.Add("XepHang", typeof(int));
            int rank = 1;
            foreach (DataRow row in dt.Rows)
            {
                row["XepHang"] = rank++;
            }
            return dt;
        }

        public static DataTable BaoCaoChiTietHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT 
                    h.ma_hoa_don as MaHoaDon,
                    h.tao_luc as NgayLap,
                    ISNULL(h.ca_id, 0) as Ban,
                    h.tong_tien as TongTien,
                    N'N/A' as NhanVien
                FROM HoaDon h
                WHERE h.tao_luc >= @tuNgay AND h.tao_luc <= @denNgay
                    AND h.trang_thai = N'Đã thanh toán'
                ORDER BY h.tao_luc DESC";

            return DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }

        public static decimal TongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT ISNULL(SUM(tong_tien), 0)
                FROM HoaDon
                WHERE tao_luc >= @tuNgay AND tao_luc <= @denNgay
                    AND trang_thai = N'Đã thanh toán'";

            DataTable dt = DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                return Convert.ToDecimal(dt.Rows[0][0]);
            return 0;
        }

        // Báo cáo doanh thu theo danh mục
        public static DataTable BaoCaoDoanhThuTheoDanhMuc(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT 
                    d.ten_danh_muc as DanhMuc,
                    ISNULL(SUM(ct.so_luong), 0) as SoLuongBan,
                    ISNULL(SUM(ct.so_luong * ct.don_gia), 0) as DoanhThu
                FROM ChiTietHoaDon ct
                INNER JOIN HoaDon h ON ct.hoa_don_id = h.id
                INNER JOIN MonAn m ON ct.mon_an_id = m.id
                INNER JOIN DanhMuc d ON m.danh_muc_id = d.id
                WHERE h.tao_luc >= @tuNgay AND h.tao_luc <= @denNgay
                    AND h.trang_thai = N'Đã thanh toán'
                GROUP BY d.id, d.ten_danh_muc
                ORDER BY DoanhThu DESC";

            return DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }

        // Báo cáo tổng hợp
        public static DataTable BaoCaoTongHop(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT 
                    COUNT(DISTINCT h.id) as TongSoHoaDon,
                    ISNULL(SUM(h.tong_tien), 0) as TongDoanhThu,
                    ISNULL(AVG(h.tong_tien), 0) as TrungBinhDonHang,
                    (SELECT COUNT(DISTINCT ct.mon_an_id) 
                     FROM ChiTietHoaDon ct 
                     INNER JOIN HoaDon h2 ON ct.hoa_don_id = h2.id
                     WHERE h2.tao_luc >= @tuNgay AND h2.tao_luc <= @denNgay
                        AND h2.trang_thai = N'Đã thanh toán') as SoMonDaBan
                FROM HoaDon h
                WHERE h.tao_luc >= @tuNgay AND h.tao_luc <= @denNgay
                    AND h.trang_thai = N'Đã thanh toán'";

            return DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }
        #endregion
    }
}