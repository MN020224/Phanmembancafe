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
            dt.Columns.Add("MaDanhMuc", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["MaDanhMuc"] = $"DM{row["id"]:D3}";
            }
            return dt;
        }

        public static DataTable LoadDanhMucCombo()
        {
            return DbHelper.Query("SELECT id, ten_danh_muc FROM DanhMuc WHERE hien_thi = 1 ORDER BY thu_tu");
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
                    COUNT(*) as SoHoaDon,
                    ISNULL(SUM(thanh_toan), 0) as DoanhThu
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                    AND CAST(tao_luc AS DATE) >= @tuNgay 
                    AND CAST(tao_luc AS DATE) <= @denNgay
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
                    COUNT(*) as SoHoaDon,
                    ISNULL(SUM(thanh_toan), 0) as DoanhThu
                FROM HoaDon
                WHERE YEAR(tao_luc) = @nam
                    AND trang_thai = N'da_thanh_toan'
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
                    ISNULL(SUM(ct.thanh_tien), 0) as DoanhThu
                FROM ChiTietHoaDon ct
                INNER JOIN HoaDon h ON ct.hoa_don_id = h.id
                INNER JOIN MonAn m ON ct.mon_an_id = m.id
                WHERE h.trang_thai = N'da_thanh_toan'
                    AND CAST(h.tao_luc AS DATE) >= @tuNgay 
                    AND CAST(h.tao_luc AS DATE) <= @denNgay
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
                    h.thanh_toan as TongTien
                FROM HoaDon h
                WHERE h.trang_thai = N'da_thanh_toan'
                    AND CAST(h.tao_luc AS DATE) >= @tuNgay 
                    AND CAST(h.tao_luc AS DATE) <= @denNgay
                ORDER BY h.tao_luc DESC";

            return DbHelper.Query(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));
        }

        public static decimal TongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string query = @"
                SELECT ISNULL(SUM(thanh_toan), 0)
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                    AND CAST(tao_luc AS DATE) >= @tuNgay 
                    AND CAST(tao_luc AS DATE) <= @denNgay";

            object result = DbHelper.Scalar(query,
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay));

            return Convert.ToDecimal(result);
        }
        #endregion
    }
}