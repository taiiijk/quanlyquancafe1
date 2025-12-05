    using quanlyquancafe.DAO;
    using quanlyquancafe.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
    using System.Linq;
using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace quanlyquancafe
{
    public partial class admin : Form
    {
        BindingSource tablelist = new BindingSource();
        BindingSource foodlist = new BindingSource();
        BindingSource foodcategorylist = new BindingSource();
        private tablemanager tm;
        public admin(tablemanager tm)
        {

            InitializeComponent();

            this.tm = tm;
            dtgwfood.DataSource = foodlist;
            dtgwct.DataSource = foodcategorylist;
            dtgwtable.DataSource = tablelist;
            load();

        }

        void load()
        {

           
            tm.loadcategory();
            tm.ReloadFoodBySelectedCategory();
            loadcategory();
            loadtablelist();
            loadlistfood();
            loadlistcategory();
            foodbinding();
            tablebinding();
            categorybinding();
            datetu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateden.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            guna2DateTimePicker1checkin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            guna2DateTimePickercheckout.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            loadlistbillbydate(guna2DateTimePicker1checkin.Value, guna2DateTimePickercheckout.Value);
            loadchart();
            loadnguyenlieu();
        }

        void loadlistbillbydate(DateTime checkin, DateTime checkout)
        {
            guna2DataGridView1.DataSource = billdao.Instance.getbillbydate(checkin, checkout);

            guna2DataGridView1.Columns["chitiet"].DisplayIndex = guna2DataGridView1.Columns.Count - 1;

        }

        void foodbinding()
        {
            txtname.DataBindings.Clear();
            txtid.DataBindings.Clear();
            txtprice.DataBindings.Clear();
            comboBox1.DataBindings.Clear();

            txtname.DataBindings.Add(new Binding("Text", foodlist, "name", true, DataSourceUpdateMode.Never));
            txtid.DataBindings.Add(new Binding("Text", foodlist, "id", true, DataSourceUpdateMode.Never));

            txtprice.DataBindings.Add(new Binding("Text", foodlist, "price", true, DataSourceUpdateMode.Never));
            comboBox1.DataBindings.Add(
    "SelectedValue",      // thuộc tính ComboBox cần bind
    foodlist,             // BindingSource chứa danh sách Food
    "idcategory",          // thuộc tính của Food
     true, DataSourceUpdateMode.Never
);
        }
        void categorybinding()
        {
            txtcategory.DataBindings.Clear();

            txtcategory.DataBindings.Add(new Binding("Text", foodcategorylist, "name", true, DataSourceUpdateMode.Never));

        }
        void tablebinding()
        {
            txttable.DataBindings.Clear();
            txttable.DataBindings.Add(new Binding("Text", tablelist, "name", true, DataSourceUpdateMode.Never));
            txtstatus.DataBindings.Clear();
            txtstatus.DataBindings.Add(new Binding("Text", tablelist, "status", true, DataSourceUpdateMode.Never));


        }
        void loadtablelist()
        {
            tablelist.DataSource = tabledao.Inststace.Loadtablelist();
        }
        void loadlistfood()
        {
            foodlist.DataSource = fooddao.Instance.getfood();
        }
        void loadlistcategory()
        {
            foodcategorylist.DataSource = categorydao.Instance.getlistcategory();
        }
        public void loadnguyenlieu()
        {
            dtgwnl.DataSource = nguyenlieudao.Instance.getnguyenlieu();
        }
        void loadcategory()
        {
            comboBox1.DataSource = categorydao.Instance.getlistcategory();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            loadlistfood();
        }





        private void guna2foodmenuButton_Click(object sender, EventArgs e)
        {
            foodmenutransition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.VertSlide;

            // ép transition "ghi nhớ" trạng thái ban đầu
            foodmenutransition.ShowSync(guna2Panelfoodmenu1);

            if (guna2Panelfoodmenu1.Height == 57)
            {
                guna2Panelfoodmenu1.Height = 178;
            }
            else
            {
                guna2Panelfoodmenu1.Height = 57;
            }
        }





        private void admin_Load(object sender, EventArgs e)
        {

        }
        bool expand = true; int targetWidth; int step = 15;
        private void guna2Buttonmenu_Click(object sender, EventArgs e)
        {
            if (expand) targetWidth = 48;
            else
                targetWidth = 200;
            timer1.Start();

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
            panelcontrol.Show();
            panelfoodmenu.Hide();
            paneldanhmucmon.Hide();
            panelthongke.Hide();
            paneltable.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            paneldanhmucmon.Hide();
            panelthongke.Show();
            paneltable.Hide();
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




        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2foodButton4_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Show();
            panelcontrol.Hide();
            panelthongke.Hide();
            paneldanhmucmon.Hide();
            paneltable.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand) { flowLayoutPanel1.Width -= step; if (flowLayoutPanel1.Width <= targetWidth) { flowLayoutPanel1.Width = targetWidth; expand = false; timer1.Stop(); } } else { flowLayoutPanel1.Width += step; if (flowLayoutPanel1.Width >= targetWidth) { flowLayoutPanel1.Width = targetWidth; expand = true; timer1.Stop(); } }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {


        }

        private void btndelete_Click_1(object sender, EventArgs e)
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

        private void btnrepair_Click_1(object sender, EventArgs e)
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
        //void loadchart()
        //{

        //    DataTable dt = billdao.Instance.doanhthu();
        //    chartDoanhthu.Series["Doanh Thu"].Points.Clear();


        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int thang = Convert.ToInt32(row["Thang"]);
        //        double tongthu = Convert.ToDouble(row["Tongthu"]);
        //        chartDoanhthu.Series["Doanh Thu"].Points.AddXY(thang, tongthu);
        //    }






        //}
        void loadchart()
        {
            DateTime date1 = datetu.Value.Date; // 00:00:00
            DateTime date2 = dateden.Value.Date.AddDays(1).AddSeconds(-1); // 23:59:59


            // Lấy dữ liệu từ SP, có thể truyền date1, date2
            DataTable dt = billdao.Instance.doanhthu(date1, date2);

            chartDoanhthu.Series["Doanh Thu"].Points.Clear();

            // Kiểm tra cột trong dt để xác định mốc thời gian
            if (dt.Columns.Contains("Nam") && dt.Columns.Contains("Thang"))
            {
                // Hiển thị theo tháng
                foreach (DataRow row in dt.Rows)
                {
                    string label = row["Thang"].ToString() + "/" + row["Nam"].ToString();
                    double tongthu = Convert.ToDouble(row["TongThu"]);
                    chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                }
            }
            else if (dt.Columns.Contains("Ngay") && dt.Columns.Contains("Gio"))
            {
                // Hiển thị theo giờ trong ngày
                foreach (DataRow row in dt.Rows)
                {
                    string label = row["Gio"].ToString() + ":00";
                    double tongthu = Convert.ToDouble(row["TongThu"]);
                    chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                }
            }
            else if (dt.Columns.Contains("Ngay"))
            {
                // Hiển thị theo ngày
                foreach (DataRow row in dt.Rows)
                {
                    string label = Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy");
                    double tongthu = Convert.ToDouble(row["TongThu"]);
                    chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                }
            }
            else
            {
                // Chỉ 1 cột thời gian (ví dụ năm)
                foreach (DataRow row in dt.Rows)
                {
                    string label = row["Nam"].ToString();
                    double tongthu = Convert.ToDouble(row["TongThu"]);
                    chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                }
            }

            chartDoanhthu.ChartAreas[0].AxisX.Interval = 1;
            DataTable DT = billinfodao.Instance.phantramfood(date1, date2);
            chartPie.Series["TyLeMon"].Points.Clear();
            foreach (DataRow r in DT.Rows)
            {
                chartPie.Series["TyLeMon"].Points.AddXY(
                    r["TenMon"].ToString(),
                    Convert.ToDouble(r["PhanTram"])
                );
            }

            var series = chartPie.Series["TyLeMon"];

            series.IsValueShownAsLabel = true;
            series.Label = "#PERCENT{P0}";          // Chỉ hiện %    
            series.LegendText = "#VALX";            // Tên hiện ở Legend
            series.Font = new Font("Segoe UI", 8);  // Chữ nhỏ để đẹp

            // Làm pie to hơn
            chartPie.ChartAreas[0].InnerPlotPosition.Auto = false;
            chartPie.ChartAreas[0].InnerPlotPosition = new ElementPosition(5, 5, 90, 90);

        }

        private void panelfoodmenu_SizeChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartDoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            loadchart();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            datetu.Value = DateTime.Now;
            dateden.Value = DateTime.Now;
            loadchart();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            datetu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dateden.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                         DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            loadchart();
        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgwfood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnaddct_Click(object sender, EventArgs e)
        {
            string name = txtnewcategory.Text;

            if (categorydao.Instance.insertcategory(name))
                MessageBox.Show("Thông báo ", "Thêm món thành công");
            load();
        }

        private void btnrepairct_Click(object sender, EventArgs e)
        {
            string name = txtcategory.Text;
            int idcategory = Convert.ToInt32(dtgwct.CurrentRow.Cells["id"].Value);
            if (categorydao.Instance.updatecategory(idcategory, name))
                MessageBox.Show("Sửa món thành công");
            load();
        }

        private void btndeletect_Click(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(dtgwct.CurrentRow.Cells["id"].Value);
            if (categorydao.Instance.categoryhavefood(idcategory))
            {
                MessageBox.Show("Danh mục đang có món không thể xóa");
            }
            else
            {
                if (categorydao.Instance.deletecategory(idcategory))
                    MessageBox.Show("Xóa món thành công");
            }
            load();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            panelthongke.Hide();
            paneldanhmucmon.Show();
            paneltable.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btndeletetable_Click(object sender, EventArgs e)


        {
            int id = Convert.ToInt32(dtgwtable.CurrentRow.Cells["id"].Value);
            if (tabledao.Inststace.tablehavebill(id))
            {
                MessageBox.Show("Bàn đang có người không thể xóa");
            }
            else
            {
                if (tabledao.Inststace.deletetable(Convert.ToInt32(dtgwtable.CurrentRow.Cells["id"].Value)))
                    MessageBox.Show("Xóa bàn thành công");
            }
            load();
        }

        private void btnaddtb_Click(object sender, EventArgs e)
        {
            string name = txtnewtable.Text;
            if (tabledao.Inststace.inserttable(name))
                MessageBox.Show("Thêm bàn thành công");
            load();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            panelthongke.Hide();
            paneldanhmucmon.Hide();
            paneltable.Show();
        }

      void insertphieunhap()
        {
            phieunhapkhodao.Instance.insertphieunhapkho();
        }
        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            insertphieunhap();
           Nhaphang f = new Nhaphang(this);
            f.ShowDialog();
        }
    }
}
