using quanlyquancafe.DAO;
using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlyquancafe
{
    public partial class hoadon : Form
    {
        int idtable;
        int idbill;

        public hoadon(int idtable, int idbill)
        {
            InitializeComponent();

            this.idtable = idtable;
            this.idbill = idbill;

            richTextBox1.Multiline = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.WordWrap = true;
            richTextBox1.ReadOnly = true;
            richTextBox1.Dock = DockStyle.Fill;
        }


        void ShowBill(int discount)
        {
            List<showbill> listbill =
                showbilldao.Instance.getlist(idbill, idtable);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("            HÓA ĐƠN THANH TOÁN");
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine(
                $"Bàn: {tabledao.Inststace.selectable(idtable).Name}    " +
                $"Ngày: {DateTime.Now:dd/MM/yyyy}"
            );
            sb.AppendLine("----------------------------------------------");

            decimal total = 0;

            foreach (showbill item in listbill)
            {
                sb.AppendLine(
                    $"{item.Foodname} | SL: {item.Count} | Giá: {item.Price:0,0} | TT: {item.Totalprice:0,0}"
                );

                List<string> extras = new List<string>();

                if (!string.IsNullOrWhiteSpace(item.Note))
                    extras.Add("Ghi chú: " + item.Note);

                if (item.Toppings != null && item.Toppings.Count > 0)
                    extras.Add("Topping: " +
                        string.Join(", ", item.Toppings.Select(t => t.Foodname)));

                if (extras.Count > 0)
                    sb.AppendLine("  → " + string.Join(" | ", extras));

                sb.AppendLine();
                total += item.Totalprice;
            }

            sb.AppendLine("----------------------------------------------");
            sb.AppendLine($"Tổng cộng: {total:0,0} VNĐ");
            sb.AppendLine($"Discount: {discount}%");

            decimal finalTotal = total - (total * discount / 100m);
            sb.AppendLine($"Thành tiền: {finalTotal:0,0} VNĐ");

            sb.AppendLine();
            sb.AppendLine("Cảm ơn quý khách! Hẹn gặp lại!");

           
            richTextBox1.Clear();
            richTextBox1.AppendText(sb.ToString());

            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();
        }

        private void hoadon_Shown_1(object sender, EventArgs e)
        {
            int discount = billdao.Instance.GetDiscountByIdBill(idbill);
            ShowBill(discount);
        }
    }
}
