using System;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    internal static class QuanTriServiceHelpers
    {
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
    }
}