    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using quanlyquancafe.DTO;
    using quanlyquancafe.DAO;
    namespace quanlyquancafe
    {
        public partial class admin : Form
        {
            BindingSource foodlist = new BindingSource();
        private tablemanager tm;
                public admin(tablemanager tm)
                {
           
            InitializeComponent();
            this.tm = tm;
            dtgwfood.DataSource = foodlist;
            load();
           
                }

       void load()
        {
            tm.loadcategory();
            tm.ReloadFoodBySelectedCategory();
            loadcategory();
            loadlistfood();
            foodbinding();
        }
            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }

            
            private void button4_Click(object sender, EventArgs e)
            {

            }

            private void button5_Click(object sender, EventArgs e)
            {

            }

            private void button3_Click(object sender, EventArgs e)
            {

            }

            private void button_Click_1(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
           

            }
            void loadlistbillbydate(DateTime checkin, DateTime checkout)
            {
                guna2DataGridView1.DataSource = billdao.Instance.getbillbydate(checkin, checkout);

                guna2DataGridView1.Columns["chitiet"].DisplayIndex = guna2DataGridView1.Columns.Count - 1;

            }
            private void button7_Click(object sender, EventArgs e)
            {
               
            }

            private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
            {

            }

            private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
            {

               
            }
            void foodbinding()
            {
            txtname.DataBindings.Clear();
            txtid.DataBindings.Clear();
            txtprice.DataBindings.Clear();
            comboBox1.DataBindings.Clear();

            txtname.DataBindings.Add(new Binding("Text", foodlist, "name",true,DataSourceUpdateMode.Never));
            txtid.DataBindings.Add(new Binding("Text", foodlist, "id", true, DataSourceUpdateMode.Never));

            txtprice.DataBindings.Add(new Binding("Text", foodlist, "price", true, DataSourceUpdateMode.Never));
            comboBox1.DataBindings.Add(
    "SelectedValue",      // thuộc tính ComboBox cần bind
    foodlist,             // BindingSource chứa danh sách Food
    "idcategory",          // thuộc tính của Food
     true, DataSourceUpdateMode.Never
);
        }
            void loadlistfood()
            {
                foodlist.DataSource = fooddao.Instance.getfood();
            }
            void loadcategory()
        {
            comboBox1.DataSource = categorydao.Instance.getlistcategory();
            comboBox1.DisplayMember ="name";
            comboBox1.ValueMember = "id";
        }
            private void button5_Click_1(object sender, EventArgs e)
            {
                loadlistfood();
            }

          

      

        private void guna2foodmenuButton_Click(object sender, EventArgs e)

        {
            foodmenutransition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.VertSlide;

            if (guna2Panelfoodmenu1.Height == 70)
            {
                guna2Panelfoodmenu1.Height = 226;
            }
            else
            {
                    guna2Panelfoodmenu1.Height = 70;
            }
        }

      
     
        private void admin_Load(object sender, EventArgs e)
        {

        }
        bool expand = true;
        private void guna2Buttonmenu_Click(object sender, EventArgs e)
        {
            foodmenutransition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.ScaleAndHorizSlide;
           

            if (expand)
            {
                flowLayoutPanel1.Width = 48;
                expand = false;
            }
            else
            {
                flowLayoutPanel1.Width = 271;
                expand = true;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "chitiet")
            {
                var tenCell = guna2DataGridView1.Rows[e.RowIndex].Cells["ten"].Value;
                var idcell = guna2DataGridView1.Rows[e.RowIndex].Cells["id"].Value;

                if (tenCell == null) return; // kiểm tra trước khi Convert
                if (idcell == null) return;  // nếu muốn bỏ qua ô trống
                string tenban = tenCell.ToString();
                int idbill = Convert.ToInt32(idcell);

                int id = tabledao.Inststace.getidtablefromten(tenban);

                hoadon f = new hoadon(id, idbill);
                f.ShowDialog();
            }
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            loadlistbillbydate(guna2DateTimePicker1checkin.Value, guna2DateTimePickercheckout.Value);
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2controlButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Hide();
            panelthongke.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            int id = (comboBox1.SelectedItem as category).Id;
            float price = Convert.ToSingle(txtprice.Text);
            if (fooddao.Instance.insertfood(name, id, price))
                MessageBox.Show("Thông báo ", "Thêm món thành công");
            load();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            int idfood = Convert.ToInt32(txtid.Text);

            if (!billdao.Instance.billhaveidfood(idfood))
            {
                if (fooddao.Instance.deletefood(idfood))
                    MessageBox.Show("Xóa món thành công");
                load();
            }
            else MessageBox.Show("Bill đang có món không thể xóa");
        }

        private void btnrepair_Click(object sender, EventArgs e)
        {

            string name = txtname.Text;
            int id = (comboBox1.SelectedItem as category).Id;
            int idfood = Convert.ToInt32(txtid.Text);
            float price = Convert.ToSingle(txtprice.Text);
            if (!billdao.Instance.billhaveidfood(idfood))
            {
                if (fooddao.Instance.updatefood(name, id, price, idfood))
                    MessageBox.Show("Sửa món thành công");
                loadcategory();
                loadlistfood();
            }
            else MessageBox.Show("Bill đang có món không thể sửa");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2foodButton4_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Show();
            panelthongke.Hide();
        }
    }
    }
