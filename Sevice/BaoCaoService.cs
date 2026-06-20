using System;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class BaoCaoService
    {
        public static DataTable LayBaoCao(DateTime tuNgay, DateTime denNgay)
        {
            return DbHelper.Query(@"
                SELECT CONVERT(varchar(10), tao_luc, 103) AS Ngay,
                       ISNULL(ma_hoa_don, N'') AS MaHD,  
                       ISNULL(ghi_chu, N'') AS Ban, 
                       thanh_toan AS TongTien,
                       ghi_chu AS GhiChu
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND CAST(tao_luc AS date) BETWEEN @tu AND @den
                ORDER BY tao_luc DESC",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
        }

        public static decimal TongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            var o = DbHelper.Scalar(@"
                SELECT ISNULL(SUM(thanh_toan), 0) FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND CAST(tao_luc AS date) BETWEEN @tu AND @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
            return Convert.ToDecimal(o);
        }
        public static int DemHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            var o = DbHelper.Scalar(@"
                SELECT COUNT(*) FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND CAST(tao_luc AS date) BETWEEN @tu AND @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
            return Convert.ToInt32(o);
        }

        public static DataTable LayChiTietHoaDon(string maHoaDon)
        {
            if (string.IsNullOrEmpty(maHoaDon))
                return new DataTable();

            return DbHelper.Query(@"
                SELECT 
                    m.ten_mon AS TenMon,
                    ct.so_luong AS SoLuong,
                    ct.don_gia AS DonGia,
                    ct.thanh_tien AS ThanhTien,
                    ISNULL(ct.ghi_chu, N'') AS GhiChu  
                FROM ChiTietHoaDon ct
                INNER JOIN HoaDon h ON ct.hoa_don_id = h.id
                INNER JOIN MonAn m ON ct.mon_an_id = m.id
                WHERE h.ma_hoa_don = @maHoaDon
                ORDER BY ct.id",
                new SqlParameter("@maHoaDon", maHoaDon));
        }

        public static DataRow LayThongTinHoaDon(string maHoaDon)
        {
            var dt = DbHelper.Query(@"
                SELECT 
                    ma_hoa_don AS MaHD,
                    CONVERT(varchar(10), tao_luc, 103) AS NgayLap,
                    tong_tien AS TongTien,
                    thanh_toan AS ThanhToan,
                    giam_gia AS GiamGia,
                    phuong_thuc_tt AS PhuongThuc,
                    trang_thai AS TrangThai
                FROM HoaDon
                WHERE ma_hoa_don = @maHoaDon",
                new SqlParameter("@maHoaDon", maHoaDon));

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

      
        public static DataTable LayBaoCaoPhanTrang(DateTime tuNgay, DateTime denNgay, int offset, int limit)
        {
            return DbHelper.Query(@"
                SELECT CONVERT(varchar(10), tao_luc, 103) AS Ngay,
                       ma_hoa_don AS MaHD,
                       N'—' AS Ban,
                       thanh_toan AS TongTien
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND CAST(tao_luc AS date) BETWEEN @tu AND @den
                ORDER BY tao_luc DESC
                OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date),
                new SqlParameter("@offset", offset),
                new SqlParameter("@limit", limit));
        }

       
        public static int DemTongHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            var o = DbHelper.Scalar(@"
                SELECT COUNT(*) FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND CAST(tao_luc AS date) BETWEEN @tu AND @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
            return Convert.ToInt32(o);
        }

       
        public static DataTable ThongKeDoanhThuTheoNgayTrongThang(int thang, int nam)
        {
            return DbHelper.Query(@"
                SELECT 
                    DAY(tao_luc) AS Ngay,
                    COUNT(*) AS SoHoaDon,
                    ISNULL(SUM(thanh_toan), 0) AS DoanhThu
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND MONTH(tao_luc) = @thang
                  AND YEAR(tao_luc) = @nam
                GROUP BY DAY(tao_luc)
                ORDER BY Ngay",
                new SqlParameter("@thang", thang),
                new SqlParameter("@nam", nam));
        }

      
        public static DataTable ThongKeDoanhThuTheoThangTrongNam(int nam)
        {
            return DbHelper.Query(@"
                SELECT 
                    MONTH(tao_luc) AS Thang,
                    COUNT(*) AS SoHoaDon,
                    ISNULL(SUM(thanh_toan), 0) AS DoanhThu
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND YEAR(tao_luc) = @nam
                GROUP BY MONTH(tao_luc)
                ORDER BY Thang",
                new SqlParameter("@nam", nam));
        }


        public static DataTable TopMonAnBanChay(DateTime tuNgay, DateTime denNgay, int top = 10)
        {
            return DbHelper.Query(@"
                SELECT TOP (@top)
                    m.ten_mon AS TenMon,
                    SUM(ct.so_luong) AS SoLuongBan,
                    SUM(ct.thanh_tien) AS DoanhThu
                FROM ChiTietHoaDon ct
                INNER JOIN HoaDon h ON ct.hoa_don_id = h.id
                INNER JOIN MonAn m ON ct.mon_an_id = m.id
                WHERE h.trang_thai = N'da_thanh_toan'
                  AND CAST(h.tao_luc AS date) BETWEEN @tu AND @den
                GROUP BY m.id, m.ten_mon
                ORDER BY SoLuongBan DESC",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date),
                new SqlParameter("@top", top));
        }


        public static DataTable ThongKeTheoPhuongThucThanhToan(DateTime tuNgay, DateTime denNgay)
        {
            return DbHelper.Query(@"
                SELECT 
                    CASE phuong_thuc_tt
                        WHEN N'tien_mat' THEN N'Tiền mặt'
                        WHEN N'chuyen_khoan' THEN N'Chuyển khoản'
                        WHEN N'vi_dien_tu' THEN N'Ví điện tử'
                        ELSE phuong_thuc_tt
                    END AS PhuongThuc,
                    COUNT(*) AS SoHoaDon,
                    ISNULL(SUM(thanh_toan), 0) AS DoanhThu
                FROM HoaDon
                WHERE trang_thai = N'da_thanh_toan'
                  AND CAST(tao_luc AS date) BETWEEN @tu AND @den
                GROUP BY phuong_thuc_tt",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
        }
    }
}