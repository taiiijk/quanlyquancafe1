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
            menuStrip1.Visible = Session.isadmin;
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            loadtable();
            
            loadtablelist();
            loadcategory();
        }
        
        #region Load dữ liệu
        private Guna.UI2.WinForms.Guna2Button selectedButton = null;
        bool firstload = true;
        table selectedTable = null;
        void loadtable()
        {
            flowLayoutPanel1.Controls.Clear();

            List<table> tablelist = tabledao.Inststace.Loadtablelist();

            foreach (table tb in tablelist)
            {
                Guna2Button btn = new Guna2Button();
                btn.Width = tabledao.tbw;
                btn.Height = tabledao.tbh;
                btn.Tag = tb;

                btn.Text = tb.Name + Environment.NewLine + tb.Status;
                btn.TextAlign = HorizontalAlignment.Center;

                btn.Image = Properties.Resources.side_table;
                btn.ImageAlign = HorizontalAlignment.Center;

                btn.FillColor = tb.Status == "Trống" ? Color.Gray : Color.Brown;
                btn.HoverState.FillColor = Color.DarkGray;

                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }

           
            if (firstload && tablelist.Count > 0)
            {
                firstload = false;
                Btn_Click(flowLayoutPanel1.Controls[0] as Guna2Button, null);
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
       
        void showbill(int idtable, int idbill)
        {
            DataTable dt = showbilldao.Instance.getlistbillinfo(idbill, idtable);

            fillemptyrows(dt);

            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.DataSource = dt;

            guna2DataGridView1.Columns["realname"].HeaderText = "Tên món";
            guna2DataGridView1.Columns["count"].HeaderText = "Số lượng";
            guna2DataGridView1.Columns["realprice"].HeaderText = "Đơn giá";
            guna2DataGridView1.Columns["totalprice"].HeaderText = "Thành tiền";
            guna2DataGridView1.Columns["note"].HeaderText = "Ghi chú";
          
            guna2DataGridView1.Columns["note"].DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            guna2DataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            decimal totalprice = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r["totalprice"] != DBNull.Value)
                    totalprice += Convert.ToDecimal(r["totalprice"]);
            }

            lbltotal.Text = totalprice.ToString("c", new CultureInfo("vi-VN"));
        }



        #endregion

        #region Sự kiện điều khiển
        private void Btn_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            table tb = btn.Tag as table;
            if (tb == null) return;

            // Lưu bàn đang chọn
            selectedTable = tb;

            guna2DataGridView1.Tag = tb;

            int idbill = billdao.Instance.getbillbyidtable(tb.Id);
            showbill(tb.Id, idbill);

            // Bỏ check bàn cũ
            if (selectedButton != null)
            {
                table tbOld = selectedButton.Tag as table;
                selectedButton.Text = tbOld.Name + Environment.NewLine + tbOld.Status;
            }

            // Check bàn mới
            selectedButton = btn;
            selectedButton.Text = tb.Name + Environment.NewLine + tb.Status + Environment.NewLine + "✓";
        }

        public void ReloadFoodBySelectedCategory()
        {
            if (cbxdanhmuc.SelectedItem != null)
            {
                int id = (cbxdanhmuc.SelectedItem as category).Id;
                loadfoodbycategory(id);
            }
        }


        
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin f = new admin(this);
            f.ShowDialog();
        }
        #endregion



        void loadtablelist()
        {
            cbxtable.DataSource = tabledao.Inststace.Loadtablelist();
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


            table table = guna2DataGridView1.Tag as table;

            int idbill = billdao.Instance.getbillbyidtable(table.Id);
            int idfood = (cbxfood.SelectedItem as food).Id;
            if (!KiemTraNguyenLieu(idfood))
            {
                MessageBox.Show("Không đủ nguyên liệu cho món chính ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // thoát, không thêm món
            }
            tuychon t = new tuychon(idfood);
           
            t.ShowDialog();
            if (idbill == -1)
            {
                billdao.Instance.insertbill(table.Id);
                idbill = billdao.Instance.maxidbill();
            }


            int idBillInfoMain = billinfodao.Instance.insertMainFood(
                idbill,
                idfood,
                t.SoLuong,
                t.Note
               

            );
            decimal price = (decimal)t.TongGia/t.SoLuong;
            updaterealprice(idBillInfoMain, price);

            foreach (food topping in t.ToppingsChon)
            {
                billinfodao.Instance.insertTopping(
                    idbill,
                    topping.Id,
                    t.SoLuong,
                    idBillInfoMain
                );
            }

            showbill(table.Id, idbill);
            loadtable();
        }
        void updaterealprice(int id,decimal price)
        {
           
            billinfodao.Instance.updaterealprice(id,price);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            table table = guna2DataGridView1.Tag as table;

            int idbill = billdao.Instance.getbillbyidtable(table.Id);
            int discount = (int)numgiamgia.Value;
            billdao.Instance.updatediscount(idbill, discount);
            hoadon f = new hoadon(table.Id, idbill);
            f.ShowDialog();

            if (idbill != -1)
            {
                if (MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    billdao.Instance.checkout(idbill);
               

                loadtable();
                showbill(table.Id, idbill);

            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn nguồn để chuyển!", "Thông báo");
                return;
            }

            if (cbxtable.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn đích để chuyển!", "Thông báo");
                return;
            }

            int id1 = (guna2DataGridView1.Tag as table).Id;
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

        void fillemptyrows(DataTable dt)
        {
            int rowHeight = guna2DataGridView1.RowTemplate.Height;
            int headerHeight = guna2DataGridView1.ColumnHeadersHeight;
            int visibleRows =
                (guna2DataGridView1.Height - headerHeight) / rowHeight;
            int need = visibleRows - dt.Rows.Count;
            for (int i = 0; i < need; i++)
            {
                dt.Rows.Add(dt.NewRow());
            }

        }
        private bool KiemTraNguyenLieu(int idfood)
        {
     
           
                int soluong = congthucdao.Instance.getSoluongMonConLai(idfood);

                if (soluong<=0) return false;
            

           

            return true;
        }

        private void btnupdatenl_Click(object sender, EventArgs e)
        {

        }



        private int rightClickRowIndex = -1;

        private void guna2DataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = guna2DataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    rightClickRowIndex = hit.RowIndex;

                    guna2DataGridView1.ClearSelection();
                    guna2DataGridView1.Rows[hit.RowIndex].Selected = true;

                    guna2ContextMenuStrip1.Show(guna2DataGridView1, e.Location);
                }
            }
        }

        

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int idTable = (guna2DataGridView1.Tag as table).Id;
            string Food = (guna2DataGridView1.Rows[rightClickRowIndex].Cells["realname"].Value).ToString();
            string note = guna2DataGridView1.Rows[rightClickRowIndex].Cells["note"].Value.ToString();
            int idBillInfo = billinfodao.Instance.GetIdBillInfo(idTable, Food, note) ?? -1;

            billinfodao.Instance.deletebillinfo(idBillInfo);
            showbill(idTable, billdao.Instance.getbillbyidtable(idTable));

        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int idTable = (guna2DataGridView1.Tag as table).Id;
            string Food = (guna2DataGridView1.Rows[rightClickRowIndex].Cells["realname"].Value).ToString();
            string note = guna2DataGridView1.Rows[rightClickRowIndex].Cells["note"].Value.ToString();
            int idBillInfo = billinfodao.Instance.GetIdBillInfo(idTable, Food, note) ?? -1;
            int idfood = fooddao.Instance.getidfoodbyname(Food);
            tuychon t = new tuychon(idfood, note, Convert.ToInt32(guna2DataGridView1.Rows[rightClickRowIndex].Cells["count"].Value));
            t.ShowDialog();
            billinfodao.Instance.updatebillinfo(
                idBillInfo,
                t.SoLuong,
                t.Note
                );
            showbill(idTable, billdao.Instance.getbillbyidtable(idTable));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public int discount= 0;
        private void numgiamgia_ValueChanged(object sender, EventArgs e)
        {
            discount = (int)numgiamgia.Value;
        }
    }
}

