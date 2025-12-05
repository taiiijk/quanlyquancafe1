using Guna.UI2.WinForms;
using quanlyquancafe.DAO;
using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace quanlyquancafe
{
    public partial class tablemanager : Form
    {
        public tablemanager()
        {
            InitializeComponent();
            loadtable();
            loadtablelist();
            loadcategory();
        }

        #region Load dữ liệu
        void loadtable()
        {
            flowLayoutPanel1.Controls.Clear();

            List<table> tablelist = tabledao.Inststace.Loadtablelist();
            foreach (table tb in tablelist)
            {
                Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
                btn.Width = tabledao.tbw;
                btn.Height = tabledao.tbh;
                btn.Tag = tb;

                // Text
                btn.Text = tb.Name + Environment.NewLine + tb.Status;
                btn.TextAlign = HorizontalAlignment.Center;

                // Ảnh bàn ở giữa
                btn.Image = Properties.Resources.side_table;
                btn.ImageAlign = HorizontalAlignment.Center;

                // Icon bill nếu có
               
                  

                // Màu trạng thái
                switch (tb.Status)
                {
                    case "Trống":
                        btn.FillColor = Color.Gray;
                        break;
                    default:
                        btn.FillColor = Color.Brown;
                        break;
                }

                // Hover effect
                btn.HoverState.FillColor = Color.DarkGray;
               

                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }

        }

        public void loadcategory()
        {
            List<category> list = categorydao.Instance.getlistcategory();
            cbxdanhmuc.DataSource = list;
            cbxdanhmuc.DisplayMember = "name";
        }

        void loadfoodbycategory(int id)
        {
            List<food> list = fooddao.Instance.getlistfood(id);
            cbxfood.DataSource = list;
            cbxfood.DisplayMember = "name";
        }
        #endregion

        #region Xử lý hóa đơn
        void showbill(int id,int idbill)
        {
            listView1.Items.Clear();
            int Idbill = billdao.Instance.getbillbyidtable(id);
            List<menu> listbillif = menudao.Instance.getlist(id,idbill);
            float totalprice = 0;

            foreach (menu item in listbillif)
            {
                ListViewItem lsv = new ListViewItem(item.Foodname.ToString());
                lsv.SubItems.Add(item.Count.ToString());
                lsv.SubItems.Add(item.Price.ToString());
                lsv.SubItems.Add(item.Totalprice.ToString());
                totalprice += item.Totalprice;
                listView1.Items.Add(lsv);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            lbltotal.Text = totalprice.ToString("c", culture);
        }

       
        #endregion

        #region Sự kiện điều khiển
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableid = ((sender as Guna2Button).Tag as table).Id;
            listView1.Tag = (sender as Guna2Button).Tag;
            int idbill = billdao.Instance.getbillbyidtable(tableid);
            showbill(tableid,idbill);
        }

        public void ReloadFoodBySelectedCategory()
        {
            if (cbxdanhmuc.SelectedItem != null)
            {
                int id = (cbxdanhmuc.SelectedItem as category).Id;
                loadfoodbycategory(id);
            }
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile f = new profile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin f = new admin(this);
            f.ShowDialog();
        }
        #endregion

        
       
        void loadtablelist()
        {
            cbxtable.DataSource=tabledao.Inststace.Loadtablelist();
            cbxtable.DisplayMember = "Name";
        }
      

     
       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            category selected = cb.SelectedItem as category;
            if (selected != null) loadfoodbycategory(selected.Id);
        }

        private void cbxdanhmuc_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            table table = listView1.Tag as table;

            int idbill = billdao.Instance.getbillbyidtable(table.Id);
            int idfood = (cbxfood.SelectedItem as food).Id;
            int count = (int)guna2NumericUpDown1.Value;

            if (idbill == -1)
            {
                billdao.Instance.insertbill(table.Id);
                billinfodao.Instance.insertbillinfo(billdao.Instance.maxidbill(), idfood, count);
                idbill = billdao.Instance.maxidbill();
            }
            else
            {
                billinfodao.Instance.insertbillinfo(idbill, idfood, count);
            }

            showbill(table.Id, idbill);
            loadtable();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            table table = listView1.Tag as table;

            int idbill = billdao.Instance.getbillbyidtable(table.Id);
            hoadon f = new hoadon(table.Id, idbill);
            f.ShowDialog();

            if (idbill != -1)
            {
                if (MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    billdao.Instance.checkout(idbill);
                showbill(table.Id, idbill);

                loadtable();


            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (listView1.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn nguồn để chuyển!", "Thông báo");
                return;
            }

            if (cbxtable.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn đích để chuyển!", "Thông báo");
                return;
            }

            int id1 = (listView1.Tag as table).Id;
            int id2 = (cbxtable.SelectedItem as table).Id;

            if (id1 == id2)
            {
                MessageBox.Show("Không thể chuyển sang cùng một bàn!", "Thông báo");
                return;
            }

            tabledao.Inststace.switchtable(id1, id2);
            loadtable();
            MessageBox.Show("Chuyển bàn thành công!", "Thông báo");
        }
    }
}
