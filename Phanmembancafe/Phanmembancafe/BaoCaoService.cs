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
                       ma_hoa_don AS MaHD,
                       N'—' AS Ban,
                       thanh_toan AS TongTien
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
    }
}
