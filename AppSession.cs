namespace CafeOrder
{
    public static class AppSession
    {
        public static int TaiKhoanId { get; set; }
        public static string TenDangNhap { get; set; }
        public static string VaiTro { get; set; }
        public static int? CaId { get; set; }

        public static bool IsAdmin => VaiTro == "admin";
        public static bool IsLoggedIn => TaiKhoanId > 0;



        // Nhân viên sau khi nh?p ðúng admin s? ðý?c c?p quy?n t?m
        public static bool IsImpersonatedAdmin { get; set; } = false;

        // Ki?m tra chung: có ph?i admin th?t ho?c ð? ðý?c c?p quy?n
        public static bool HasAdminAccess => IsAdmin || IsImpersonatedAdmin;

        public static void Clear()
        {
            TaiKhoanId = 0;
            TenDangNhap = null;
            VaiTro = null;
            CaId = null;
        }
    }
}
