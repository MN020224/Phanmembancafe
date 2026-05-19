using System;
using System.Data;
using System.Data.SqlClient;

namespace CafeOrder
{
    public static class QuanTriService
    {
        public static DataTable LoadDanhMuc()
        {
            return DbHelper.Query("SELECT id, ten_danh_muc, thu_tu, hien_thi FROM DanhMuc ORDER BY thu_tu");
        }

        public static DataTable LoadMonAn()
        {
            return DbHelper.Query(@"
                SELECT m.id, m.ten_mon, m.gia, d.ten_danh_muc AS DanhMuc, m.danh_muc_id, m.kha_dung
                FROM MonAn m
                INNER JOIN DanhMuc d ON d.id = m.danh_muc_id
                ORDER BY d.thu_tu, m.thu_tu");
        }

        public static DataTable LoadTaiKhoan()
        {
            return DbHelper.Query("SELECT id, ten_dang_nhap, mat_khau, vai_tro FROM TaiKhoan ORDER BY id");
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

        public static void ThemTaiKhoan(string user, string pass, string vaiTro)
        {
            DbHelper.Execute(
                "INSERT INTO TaiKhoan(ten_dang_nhap, mat_khau, vai_tro) VALUES (@u, @p, @v)",
                new SqlParameter("@u", user),
                new SqlParameter("@p", pass),
                new SqlParameter("@v", vaiTro));
        }

        public static void SuaTaiKhoan(int id, string user, string pass, string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(pass))
            {
                DbHelper.Execute(
                    "UPDATE TaiKhoan SET ten_dang_nhap = @u, vai_tro = @v WHERE id = @id",
                    new SqlParameter("@u", user),
                    new SqlParameter("@v", vaiTro),
                    new SqlParameter("@id", id));
            }
            else
            {
                DbHelper.Execute(
                    "UPDATE TaiKhoan SET ten_dang_nhap = @u, mat_khau = @p, vai_tro = @v WHERE id = @id",
                    new SqlParameter("@u", user),
                    new SqlParameter("@p", pass),
                    new SqlParameter("@v", vaiTro),
                    new SqlParameter("@id", id));
            }
        }

        public static void XoaTaiKhoan(int id)
        {
            DbHelper.Execute("DELETE FROM TaiKhoan WHERE id = @id", new SqlParameter("@id", id));
        }
    }
}
