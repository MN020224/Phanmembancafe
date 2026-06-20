using System;
using System.Collections.Generic;
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
            dt.Columns.Add("TrangThai", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["MaMon"] = $"M{row["id"]:D3}";
                row["TrangThai"] = Convert.ToBoolean(row["kha_dung"]) ? "Đang bán" : "Đã ẩn";
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

        public static void DatTrangThaiMon(int id, bool khaDung)
        {
            DbHelper.Execute(
                "UPDATE MonAn SET kha_dung = @kd WHERE id = @id",
                new SqlParameter("@kd", khaDung),
                new SqlParameter("@id", id));
        }

        public static void DatTrangThaiMonHangLoat(IEnumerable<int> ids, bool khaDung)
        {
            if (ids == null)
                return;

            foreach (int id in ids)
                DatTrangThaiMon(id, khaDung);
        }

        public static int? TimDanhMucIdTheoTen(string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
                return null;

            var dt = DbHelper.Query("SELECT id, ten_danh_muc FROM DanhMuc WHERE hien_thi = 1");
            string tim = tenDanhMuc.Trim();
            foreach (DataRow row in dt.Rows)
            {
                if (string.Equals(row["ten_danh_muc"].ToString().Trim(), tim, StringComparison.OrdinalIgnoreCase))
                    return Convert.ToInt32(row["id"]);
            }
            return null;
        }

        public static bool MonDaTonTai(int danhMucId, string tenMon)
        {
            var o = DbHelper.Scalar(
                "SELECT COUNT(*) FROM MonAn WHERE danh_muc_id = @dm AND LTRIM(RTRIM(ten_mon)) = @ten",
                new SqlParameter("@dm", danhMucId),
                new SqlParameter("@ten", tenMon.Trim()));
            return Convert.ToInt32(o) > 0;
        }

        public class KetQuaImportMon
        {
            public int ThanhCong { get; set; }
            public int BoQua { get; set; }
            public List<string> Loi { get; } = new List<string>();
        }

        public static KetQuaImportMon ImportMonTuFile(IEnumerable<MonAnImportHelper.DongMon> dong)
        {
            var ketQua = new KetQuaImportMon();
            if (dong == null)
                return ketQua;

            foreach (var row in dong)
            {
                try
                {
                    int? dmId = TimDanhMucIdTheoTen(row.DanhMuc);
                    if (!dmId.HasValue)
                    {
                        ketQua.BoQua++;
                        ketQua.Loi.Add($"Dòng {row.DongSo}: Không tìm thấy danh mục \"{row.DanhMuc}\".");
                        continue;
                    }

                    if (MonDaTonTai(dmId.Value, row.TenMon))
                    {
                        ketQua.BoQua++;
                        ketQua.Loi.Add($"Dòng {row.DongSo}: Món \"{row.TenMon}\" đã tồn tại trong danh mục \"{row.DanhMuc}\".");
                        continue;
                    }

                    ThemMon(dmId.Value, row.TenMon, row.Gia);
                    ketQua.ThanhCong++;
                }
                catch (Exception ex)
                {
                    ketQua.BoQua++;
                    ketQua.Loi.Add($"Dòng {row.DongSo}: {ex.Message}");
                }
            }
            return ketQua;
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

        public static DataTable BaoCaoDoanhThuTheoPhuongThuc(DateTime tuNgay, DateTime denNgay)
        {
            return BaoCaoService.ThongKeTheoPhuongThucThanhToan(tuNgay, denNgay);
        }
        #endregion

        #region Tài khoản
        public static DataTable LoadTaiKhoan()
        {
            return DbHelper.Query(@"
                SELECT id, ten_dang_nhap, vai_tro,
                       CASE vai_tro
                           WHEN N'admin' THEN N'Quản trị viên'
                           WHEN N'nhan_vien' THEN N'Nhân viên'
                           ELSE vai_tro
                       END AS VaiTroHienThi
                FROM TaiKhoan
                ORDER BY vai_tro, ten_dang_nhap");
        }

        public static bool TenDangNhapDaTonTai(string ten, int? excludeId = null)
        {
            var o = DbHelper.Scalar(@"
                SELECT COUNT(*) FROM TaiKhoan
                WHERE ten_dang_nhap = @ten AND (@excludeId IS NULL OR id <> @excludeId)",
                new SqlParameter("@ten", ten),
                new SqlParameter("@excludeId", (object)excludeId ?? DBNull.Value));
            return Convert.ToInt32(o) > 0;
        }

        public static void ThemTaiKhoan(string ten, string matKhau, string vaiTro)
        {
            DbHelper.Execute(
                "INSERT INTO TaiKhoan(ten_dang_nhap, mat_khau, vai_tro) VALUES (@ten, @mk, @vt)",
                new SqlParameter("@ten", ten),
                new SqlParameter("@mk", matKhau),
                new SqlParameter("@vt", vaiTro));
        }

        public static void SuaTaiKhoan(int id, string ten, string matKhau, string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                DbHelper.Execute(
                    "UPDATE TaiKhoan SET ten_dang_nhap = @ten, vai_tro = @vt WHERE id = @id",
                    new SqlParameter("@ten", ten),
                    new SqlParameter("@vt", vaiTro),
                    new SqlParameter("@id", id));
            }
            else
            {
                DbHelper.Execute(
                    "UPDATE TaiKhoan SET ten_dang_nhap = @ten, mat_khau = @mk, vai_tro = @vt WHERE id = @id",
                    new SqlParameter("@ten", ten),
                    new SqlParameter("@mk", matKhau),
                    new SqlParameter("@vt", vaiTro),
                    new SqlParameter("@id", id));
                }
        }

        public static void XoaTaiKhoan(int id)
        {
            DbHelper.Execute("DELETE FROM TaiKhoan WHERE id = @id", new SqlParameter("@id", id));
        }

        public static int DemAdmin()
        {
            var o = DbHelper.Scalar("SELECT COUNT(*) FROM TaiKhoan WHERE vai_tro = N'admin'");
            return Convert.ToInt32(o);
        }
        #endregion

        #region Thu chi
        public static DataTable LoadThuChi(DateTime tuNgay, DateTime denNgay)
        {
            return DbHelper.Query(@"
                SELECT id, loai, mo_ta AS MoTa, so_tien AS SoTien, tao_luc AS NgayTao
                FROM ThuChi
                WHERE CAST(tao_luc AS date) BETWEEN @tu AND @den
                ORDER BY tao_luc DESC",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
        }

        public static decimal TongThu(DateTime tuNgay, DateTime denNgay)
        {
            var o = DbHelper.Scalar(@"
                SELECT ISNULL(SUM(so_tien), 0) FROM ThuChi
                WHERE loai = N'Thu' AND CAST(tao_luc AS date) BETWEEN @tu AND @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
            return Convert.ToDecimal(o);
        }

        public static decimal TongChi(DateTime tuNgay, DateTime denNgay)
        {
            var o = DbHelper.Scalar(@"
                SELECT ISNULL(SUM(so_tien), 0) FROM ThuChi
                WHERE loai = N'Chi' AND CAST(tao_luc AS date) BETWEEN @tu AND @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date));
            return Convert.ToDecimal(o);
        }
        #endregion
    }
}