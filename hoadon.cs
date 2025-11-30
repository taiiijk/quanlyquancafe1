using quanlyquancafe.DAO;
using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlyquancafe
{
    public partial class hoadon : Form
    {
        int id;
        int idbill;
        public hoadon(int idtable,int idbill)
        {
            InitializeComponent();
         this.id = idtable;
        this.idbill = idbill;
            showbill(id,idbill);
        }
        void showbill(int id, int idbill)

        {
            
            Bill bill = billdao.Instance.selectbill(idbill);
            table table = tabledao.Inststace.selectable(id);
            DateTime datecheckout = bill.DateCheckOut ?? DateTime.Now;

            List<menu> listbillif = menudao.Instance.getlist(id, idbill);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("                 HÓA ĐƠN THANH TOÁN");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"Bàn: {table.Name,-10} Ngày: {datecheckout:dd/MM/yyyy}");
            sb.AppendLine();
            sb.AppendLine("Tên món ăn          SL    Giá        Thành tiền");
            sb.AppendLine("------------------------------------------------");

            double total = 0;
            foreach (menu item in listbillif)
            {
                string ten = item.Foodname;
                if (ten.Length > 18) ten = ten.Substring(0, 18); // Giới hạn 18 ký tự
                else ten = ten.PadRight(18);

                string sl = item.Count.ToString().PadLeft(3);
                string gia = item.Price.ToString("0,0").PadLeft(10);
                string thanhTien = item.Totalprice.ToString("0,0").PadLeft(15);

                sb.AppendLine($"{ten}{sl}{gia}{thanhTien}");
                total += item.Totalprice;
            }

            sb.AppendLine("------------------------------------------------");
            string tong = total.ToString("0,0") + " VNĐ";
            sb.AppendLine("Tổng cộng:".PadRight(48 - tong.Length) + tong);
            sb.AppendLine();
            sb.AppendLine("Cảm ơn quý khách! Hẹn gặp lại!");




            richTextBox1.Text = sb.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void hoadon_Load(object sender, EventArgs e)
        {

        }
    }
}
