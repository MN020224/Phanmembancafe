using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CafeOrder
{
    public static class MonAnImportHelper
    {
        public class DongMon
        {
            public string TenMon { get; set; }
            public decimal Gia { get; set; }
            public string DanhMuc { get; set; }
            public int DongSo { get; set; }
        }

        public static List<DongMon> DocFile(string duongDan)
        {
            string ext = Path.GetExtension(duongDan).ToLowerInvariant();
            if (ext == ".csv")
                return DocCsv(duongDan);
            if (ext == ".xlsx" || ext == ".xls")
                return DocExcel(duongDan);
            throw new Exception("Chỉ hỗ trợ file .xlsx, .xls hoặc .csv");
        }

        public static void GhiFileMau(string duongDan)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Tên món,Giá,Danh mục");
            sb.AppendLine("Cà phê sữa,35000,Cà phê");
            sb.AppendLine("Trà đào,45000,Trà");
            sb.AppendLine("Bánh croissant,28000,Bánh ngọt");
            File.WriteAllText(duongDan, sb.ToString(), new UTF8Encoding(true));
        }

        private static List<DongMon> DocCsv(string path)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length == 0)
                return new List<DongMon>();

            var result = new List<DongMon>();
            char sep = lines[0].Contains(";") ? ';' : ',';
            var headers = TachDongCsv(lines[0], sep);
            var colMap = TaoBanDoCot(headers);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var cells = TachDongCsv(lines[i], sep);
                var row = ParseCells(cells, colMap, i + 1);
                if (row != null)
                    result.Add(row);
            }
            return result;
        }

        private static string[] TachDongCsv(string line, char sep)
        {
            var cells = new List<string>();
            var cur = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        cur.Append('"');
                        i++;
                    }
                    else
                        inQuotes = !inQuotes;
                }
                else if (c == sep && !inQuotes)
                {
                    cells.Add(cur.ToString().Trim());
                    cur.Clear();
                }
                else
                    cur.Append(c);
            }
            cells.Add(cur.ToString().Trim());
            return cells.ToArray();
        }

        private static List<DongMon> DocExcel(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            string connStr = ext == ".xlsx"
                ? $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'"
                : $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path};Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";

            try
            {
                using (var conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    string sheet = LayTenSheet(conn);
                    using (var adapter = new OleDbDataAdapter($"SELECT * FROM [{sheet}]", conn))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return ParseDataTable(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Không đọc được file Excel. Hãy lưu file dạng .csv hoặc cài Microsoft Access Database Engine (ACE).\n\nChi tiết: " + ex.Message);
            }
        }

        private static string LayTenSheet(OleDbConnection conn)
        {
            var schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (schema == null || schema.Rows.Count == 0)
                throw new Exception("File Excel không có sheet dữ liệu.");

            foreach (DataRow row in schema.Rows)
            {
                string name = row["TABLE_NAME"]?.ToString();
                if (!string.IsNullOrEmpty(name) && name.EndsWith("$"))
                    return name;
            }
            return schema.Rows[0]["TABLE_NAME"].ToString();
        }

        private static List<DongMon> ParseDataTable(DataTable dt)
        {
            var result = new List<DongMon>();
            if (dt.Columns.Count == 0)
                return result;

            var headers = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
            var colMap = TaoBanDoCot(headers);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var cells = dt.Rows[i].ItemArray.Select(x => x?.ToString() ?? "").ToArray();
                var row = ParseCells(cells, colMap, i + 2);
                if (row != null)
                    result.Add(row);
            }
            return result;
        }

        private static Dictionary<string, int> TaoBanDoCot(string[] headers)
        {
            var map = new Dictionary<string, int>();
            for (int i = 0; i < headers.Length; i++)
            {
                string key = ChuanHoaTenCot(headers[i]);
                if (!string.IsNullOrEmpty(key) && !map.ContainsKey(key))
                    map[key] = i;
            }
            return map;
        }

        private static string ChuanHoaTenCot(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten))
                return "";
            ten = BoDauTiengViet(ten.Trim().ToLowerInvariant());
            return ten.Replace(" ", "").Replace("_", "");
        }

        private static string BoDauTiengViet(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC)
                .Replace('đ', 'd').Replace('Đ', 'D');
        }

        private static int? TimChiSoCot(Dictionary<string, int> map, params string[] keys)
        {
            foreach (var k in keys)
            {
                string nk = ChuanHoaTenCot(k);
                if (map.ContainsKey(nk))
                    return map[nk];
            }
            return null;
        }

        private static DongMon ParseCells(string[] cells, Dictionary<string, int> colMap, int dongSo)
        {
            int? idxTen = TimChiSoCot(colMap, "tenmon", "tên món", "ten mon");
            int? idxGia = TimChiSoCot(colMap, "gia", "giá", "price", "dongia");
            int? idxDm = TimChiSoCot(colMap, "danhmuc", "danh mục", "danh muc", "category", "loai");

            if (!idxTen.HasValue || !idxGia.HasValue || !idxDm.HasValue)
                throw new Exception($"Dòng {dongSo}: File phải có cột Tên món, Giá, Danh mục.");

            string ten = LayGiaTri(cells, idxTen.Value);
            string giaStr = LayGiaTri(cells, idxGia.Value).Replace(",", "").Replace(".", "").Trim();
            string dm = LayGiaTri(cells, idxDm.Value);

            if (string.IsNullOrWhiteSpace(ten) && string.IsNullOrWhiteSpace(giaStr) && string.IsNullOrWhiteSpace(dm))
                return null;

            if (string.IsNullOrWhiteSpace(ten))
                throw new Exception($"Dòng {dongSo}: Thiếu tên món.");
            if (string.IsNullOrWhiteSpace(dm))
                throw new Exception($"Dòng {dongSo}: Thiếu danh mục.");
            if (!decimal.TryParse(giaStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal gia) || gia < 0)
                throw new Exception($"Dòng {dongSo}: Giá không hợp lệ ({LayGiaTri(cells, idxGia.Value)}).");

            return new DongMon
            {
                TenMon = ten.Trim(),
                Gia = gia,
                DanhMuc = dm.Trim(),
                DongSo = dongSo
            };
        }

        private static string LayGiaTri(string[] cells, int index)
        {
            if (index < 0 || index >= cells.Length)
                return "";
            return cells[index]?.Trim() ?? "";
        }
    }
}
