using quanlyquancafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyquancafe
{
    public partial class Nhaphang : Form
    {
        private admin ad;
        public Nhaphang(admin ad)
        {
            this.ad = ad;
            InitializeComponent();
            UserControl1 dong = new UserControl1();

            flowLayoutPanel1.Controls.Add(dong);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserControl1 dong = new UserControl1();

            flowLayoutPanel1.Controls.Add(dong);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            int MaPN = phieunhapkhodao.Instance.maxidphieunhapkho();
            bool result = MessageBox.Show("Xác nhận Xóa phiếu hiện tại ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (result)
            {
                phieunhapkhodao.Instance.deletephieunhapkho(MaPN);
            }
           
            Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int MaPN = phieunhapkhodao.Instance.maxidphieunhapkho();
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UserControl1 item)   // chỉ xử lý UserControl1
                {
                    int soluong = item.SoLuong;
                    decimal dongia = item.dongia;
                    int manl = item.manl;
                    if (soluong <= 0 || dongia <= 0 || item.manl <= 0)
                    {
                        MessageBox.Show("Dữ liệu nhập chưa hợp lệ.", "Lỗi");
                        return;
                    }

                    phieunhapkhodao.Instance.insertchitietphieunhapkho(MaPN, manl, soluong, dongia);
                }

            }
            Close();
            ad.loadnguyenlieu();
        }

        

        }
    }

