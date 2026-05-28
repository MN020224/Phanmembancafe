using System.Drawing;
using System.Windows.Forms;

namespace CafeOrder
{
    public static class UiTheme
    {
        public static readonly Color Primary = Color.FromArgb(41, 128, 185);
        public static readonly Color PrimaryDark = Color.FromArgb(44, 62, 80);
        public static readonly Color Sidebar = Color.FromArgb(52, 73, 94);
        public static readonly Color Background = Color.FromArgb(245, 246, 250);
        public static readonly Color Card = Color.White;
        public static readonly Color Success = Color.FromArgb(39, 174, 96);
        public static readonly Color Danger = Color.FromArgb(231, 76, 60);
        public static readonly Color Warning = Color.FromArgb(241, 196, 15);
        public static readonly Color TextDark = Color.FromArgb(44, 62, 80);
        public static readonly Color TextMuted = Color.FromArgb(127, 140, 141);
        public static readonly Font FontTitle = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font FontSection = new Font("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 10F);
        public static readonly Font FontKpi = new Font("Segoe UI", 22F, FontStyle.Bold);

        public static void StyleFlatButton(Button btn, Color back, int height = 36)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = height;
            btn.UseVisualStyleBackColor = false;
        }

        public static void StyleSidebarButton(Button btn, bool selected)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Dock = DockStyle.Top;
            btn.Height = 48;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(16, 0, 0, 0);
            btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
            if (selected)
            {
                btn.BackColor = Primary;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Sidebar;
                btn.ForeColor = Color.FromArgb(236, 240, 241);
            }
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Card;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(4);
            dgv.ColumnHeadersHeight = 40;
            dgv.DefaultCellStyle.Font = FontBody;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            dgv.DefaultCellStyle.SelectionForeColor = TextDark;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgv.RowHeadersVisible = false;
            dgv.GridColor = Color.FromArgb(236, 240, 241);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        public static Panel CreateKpiCard(string title, string value, Color accent, int width = 220)
        {
            var card = new Panel
            {
                BackColor = Card,
                Size = new Size(width, 100),
                Margin = new Padding(8),
                Padding = new Padding(14)
            };
            var lblTitle = new Label
            {
                Text = title,
                ForeColor = TextMuted,
                Font = FontBody,
                Dock = DockStyle.Top,
                Height = 24
            };
            var lblValue = new Label
            {
                Text = value,
                ForeColor = accent,
                Font = FontKpi,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);
            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(accent, 3))
                    e.Graphics.DrawLine(pen, 0, 0, 0, card.Height);
            };
            return card;
        }
    }
}
