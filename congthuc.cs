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
        public partial class congthuc : Form
        {
            public int idfood;
            public congthuc(int idfood)
            {
                InitializeComponent();
                this.idfood = idfood;
            }

            private void guna2Button1_Click(object sender, EventArgs e)
            {
            
                UserControl2 dong = new UserControl2();
                flowLayoutPanel1.Controls.Add(dong);
                dong.idfood = idfood;
            dong.loadcombobox();
            }

            private void guna2Button3_Click(object sender, EventArgs e)
            {
            int MaPN = phieunhapkhodao.Instance.maxidphieunhapkho();
            MessageBox.Show("Xác nhận lưu công thức?", "Xác nhận", MessageBoxButtons.YesNo);
            
            Close();
            }

            private void guna2Button2_Click(object sender, EventArgs e)
            {
            
                congthucdao.Instance.deletefullcongthuc(idfood);
        
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is UserControl2 item)   
                    {

                    decimal soluong = item.SoLuong;
                    
                    int manl = item.manl;
                    if (soluong <= 0 || item.manl <= 0)
                    {
                        MessageBox.Show("Dữ liệu nhập chưa hợp lệ.", "Lỗi");
                        return;
                    }

                    congthucdao.Instance.insertcongthuc(idfood, manl, soluong);
                    }
                }
                Close();
            }

       
    }
    }
