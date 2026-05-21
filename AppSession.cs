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

        public static void Clear()
        {
            TaiKhoanId = 0;
            TenDangNhap = null;
            VaiTro = null;
            CaId = null;
        }
    }
}
