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
        BindingSource nguyenlieu = new BindingSource();

        private tablemanager tm;
        public admin(tablemanager tm)
        {

            InitializeComponent();
            ;


            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgwfood.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgwct.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgwnl.CellBorderStyle = DataGridViewCellBorderStyle.Single;



            this.tm = tm;
            dtgwfood.DataSource = foodlist;
            dtgwct.DataSource = foodcategorylist;
            dtgwtable.DataSource = tablelist;
            dtgwnguyenlieu.DataSource = nguyenlieu;
           
            load();

        }

        void load()
        {
            loadslfood();
            loadslcategory();
            tm.loadcategory();
            tm.ReloadFoodBySelectedCategory();
            loadcategory();
            loadtablelist();
            loadlistfood();
            loadlistcategory();
            foodbinding();
            tablebinding();
            categorybinding();
            nguyenlieubinding();
            datetu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateden.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            guna2DateTimePicker1checkin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            guna2DateTimePickercheckout.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            loadlistbillbydate(guna2DateTimePicker1checkin.Value, guna2DateTimePickercheckout.Value);
            loadchart();
            loadnguyenlieu();
            LoadThuChi();
        }

        void loadlistbillbydate(DateTime checkin, DateTime checkout)
        {


            DataTable dt = billdao.Instance.getbillbydate(checkin, checkout);
            FillEmptyRows(dt);
            guna2DataGridView1.DataSource = dt;


            guna2DataGridView1.Columns["id"].HeaderText = "Mã bill";
            guna2DataGridView1.Columns["ten"].HeaderText = "Tên bàn";
            guna2DataGridView1.Columns["datecheckin"].HeaderText = "Date check-in";
            guna2DataGridView1.Columns["datecheckout"].HeaderText = "Date check-out";
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
        void nguyenlieubinding()
        {
            txtnguyenlieu.DataBindings.Clear();

            txtnguyenlieu.DataBindings.Add(new Binding("Text", nguyenlieu, "TenNL", true, DataSourceUpdateMode.Never));
            txtdonvi.DataBindings.Clear();

            txtdonvi.DataBindings.Add(new Binding("Text", nguyenlieu, "DonVi", true, DataSourceUpdateMode.Never));

        }
        void tablebinding()
        {
            txttable.DataBindings.Clear();
            txttable.DataBindings.Add(new Binding("Text", tablelist, "ten", true, DataSourceUpdateMode.Never));
            txtstatus.DataBindings.Clear();
            txtstatus.DataBindings.Add(new Binding("Text", tablelist, "trangthai", true, DataSourceUpdateMode.Never));


        }
        void loadtablelist()
        {
            DataTable dt = tabledao.Inststace.listtable();
            fillemptytablerows(dt);
            tablelist.DataSource = dt;
            dtgwtable.Columns["ten"].HeaderText = "Tên bàn";
            dtgwtable.Columns["trangthai"].HeaderText = "Trạng thái";


        }
        void loadlistfood()
        {
            DataTable dt = fooddao.Instance.getfood();
            fillemptyfoodrows(dt);
            foodlist.DataSource = dt;
            dtgwfood.Columns["id"].HeaderText = "Mã món";
            dtgwfood.Columns["name"].HeaderText = "Tên món";
            dtgwfood.Columns["idcategory"].HeaderText = "Danh mục";
            dtgwfood.Columns["price"].HeaderText = "Giá";
        }
        void loadlistcategory()
        {
            DataTable dt = categorydao.Instance.getlistcate();

            foodcategorylist.DataSource = dt;
            fillrowemptyctrows(dt);
            dtgwct.Columns["id"].HeaderText = "Mã danh mục";
            dtgwct.Columns["name"].HeaderText = "Tên danh mục";


        }
        public void loadnguyenlieu()
        {
            DataTable dt = nguyenlieudao.Instance.getnguyenlieu();
            fillemptynlrows(dt);
       
            dtgwnl.DataSource = dt;
            nguyenlieu.DataSource = dt;
                dtgwnguyenlieu.Columns["MaNL"].HeaderText = "Mã nguyên liệu";
            dtgwnguyenlieu.Columns["TenNL"].HeaderText = "Tên nguyên liệu";
            dtgwnguyenlieu.Columns["DonVi"].HeaderText = "Đơn vị";

        }
        void loadcategory()
        {
            comboBox1.DataSource = categorydao.Instance.getlistcategory2();

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

                if (tenCell == null || tenCell == DBNull.Value ||
          idcell == null || idcell == DBNull.Value)
                {
                    return;
                }
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
            panelnguyenlieu.Hide();
            Panelkho.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            paneldanhmucmon.Hide();
            panelthongke.Show();
            paneltable.Hide();
            panelnguyenlieu.Hide();
            Panelkho.Hide();
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
            panelnguyenlieu.Hide();
            Panelkho.Hide();

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

            int idfood = dtgwfood.CurrentCell == null ? 0 : Convert.ToInt32(dtgwfood.CurrentRow.Cells["id"].Value);

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
            int idfood = dtgwfood.CurrentCell == null ? 0 : Convert.ToInt32(dtgwfood.CurrentRow.Cells["id"].Value);
            float price = Convert.ToSingle(txtprice.Text);

            if (!billdao.Instance.billhaveidfood(idfood))
            {
                if (fooddao.Instance.updatefood(name, id, price, idfood))
                {
                    DataTable dt = congthucdao.Instance.getcongthucbyidfood(idfood);
                    congthuc c = new congthuc(idfood);
                    c.flowLayoutPanel1.Controls.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        UserControl2 uc = new UserControl2();

                        uc.idfood = idfood;

                        uc.cboNguyenLieu.SelectedValue = row["MaNL"];
                        uc.txtsoluong.Text = row["SoLuongCan"].ToString();
                       


                        c.flowLayoutPanel1.Controls.Add(uc);
                    }

                    c.ShowDialog();
                    MessageBox.Show("Sửa món thành công");
                }
                loadcategory();
                loadlistfood();
            }
            else
            {
                MessageBox.Show("Bill đang có món không thể sửa");
            }
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
            DateTime date1 = datetu.Value.Date;
            DateTime date2 = dateden.Value.Date.AddDays(1).AddSeconds(-1);

            // ===== BIỂU ĐỒ DOANH THU =====
            DataTable dt = billdao.Instance.doanhthu(date1, date2);

            chartDoanhthu.Series["Doanh Thu"].Points.Clear();

            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Columns.Contains("Nam") && dt.Columns.Contains("Thang"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string label = row["Thang"].ToString() + "/" + row["Nam"].ToString();

                        double tongthu = row["TongThu"] == DBNull.Value
                            ? 0
                            : Convert.ToDouble(row["TongThu"]);

                        chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                    }
                }
                else if (dt.Columns.Contains("Ngay") && dt.Columns.Contains("Gio"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string label = row["Gio"].ToString() + ":00";

                        double tongthu = row["TongThu"] == DBNull.Value
                            ? 0
                            : Convert.ToDouble(row["TongThu"]);

                        chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                    }
                }
                else if (dt.Columns.Contains("Ngay"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string label = Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy");

                        decimal tongthu = row["TongThu"] == DBNull.Value
                            ? 0
                            : Convert.ToDecimal(row["TongThu"]);

                        chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                    }
                }
                else if (dt.Columns.Contains("Nam"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string label = row["Nam"].ToString();

                        double tongthu = row["TongThu"] == DBNull.Value
                            ? 0
                            : Convert.ToDouble(row["TongThu"]);

                        chartDoanhthu.Series["Doanh Thu"].Points.AddXY(label, tongthu);
                    }
                }
            }

            chartDoanhthu.ChartAreas[0].AxisX.Interval = 1;

            // ===== BIỂU ĐỒ PIE TỶ LỆ MÓN =====
            DataTable DT = billinfodao.Instance.phantramfood(date1, date2);

            chartPie.Series["TyLeMon"].Points.Clear();

            if (DT != null && DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    string tenmon = r["TenMon"].ToString();

                    double phantram = r["PhanTram"] == DBNull.Value
                        ? 0
                        : Convert.ToDouble(r["PhanTram"]);

                    if (phantram > 0) // tránh vẽ lát 0%
                    {
                        chartPie.Series["TyLeMon"].Points.AddXY(tenmon, phantram);
                    }
                }
            }

            var series = chartPie.Series["TyLeMon"];
            series.IsValueShownAsLabel = true;
            series.Label = "#PERCENT{P0}";
            series.LegendText = "#VALX";
            series.Font = new Font("Segoe UI", 8);

            chartPie.ChartAreas[0].InnerPlotPosition.Auto = false;
            chartPie.ChartAreas[0].InnerPlotPosition = new ElementPosition(5, 5, 90, 90);
        }

        void loadslfood()
        {
            int sl=fooddao.Instance.soluongfood();
            buttonslmon.Text= $"MÓN ĂN"+ Environment.NewLine + sl.ToString();

        }
        void loadslcategory()
        {
            int sl = categorydao.Instance.soluongcategory();
            Buttonslcategory.Text=$"DANH MỤC"+ Environment.NewLine + sl.ToString();
        }
        void LoadThuChi()
        {
            DateTime tu = datetu.Value.Date;
            DateTime den = dateden.Value.Date.AddDays(1).AddSeconds(-1);

            decimal doanhThu = billdao.Instance.GetTongDoanhThu(tu, den);
            decimal tienChi = phieunhapkhodao.Instance.GetTongTienChi(tu, den);

            buttomndoanhthu.Text = $"DOANH THU\n{doanhThu:N0} đ";
            Buttonchi.Text = $"TIỀN CHI\n{tienChi:N0} đ";
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

      

     
      

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            panelthongke.Hide();
            paneldanhmucmon.Show();
            paneltable.Hide();
            Panelkho.Hide();
            panelnguyenlieu.Hide();
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
            panelnguyenlieu.Hide();
            Panelkho.Hide();
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

        private void guna2Panel14_Paint(object sender, PaintEventArgs e)
        {

        }


 
   

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            string name = txtname.Text;
            int id = (comboBox1.SelectedItem as category).Id;
            float price = Convert.ToSingle(txtprice.Text);
            
            if (fooddao.Instance.insertfood(name, id, price))
            {
                int idfood = fooddao.Instance.maxidfood();
                congthuc congthuc = new congthuc(idfood);
                UserControl2 dong = new UserControl2();
                congthuc.flowLayoutPanel1.Controls.Add(dong);


                congthuc.ShowDialog();
                MessageBox.Show("Thông báo ", "Thêm món thành công");
            }
            load();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            Panelkho.Show();
            panelthongke.Hide();
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            paneldanhmucmon.Hide();
            paneltable.Hide();
            panelnguyenlieu.Hide();

        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "chitiet")
            {
                var row = guna2DataGridView1.Rows[e.RowIndex];


                if (row.Cells["id"].Value != null && row.Cells["id"].Value != DBNull.Value)
                {
                    e.Value = "Xem chi tiết";
                }
                else
                {
                    e.Value = "";
                }

                e.FormattingApplied = true;
            }
        }


        void FillEmptyRows(DataTable dt)
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
        void fillemptyfoodrows(DataTable dt)
        {
            int rowHeight = dtgwfood.RowTemplate.Height;
            int headerHeight = dtgwfood.ColumnHeadersHeight;
            int visibleRows =
                (dtgwfood.Height - headerHeight) / rowHeight;
            int need = visibleRows - dt.Rows.Count;
            for (int i = 0; i < need; i++)
            {
                dt.Rows.Add(dt.NewRow());
            }
        }



        void fillrowemptyctrows(DataTable dt)
        {

            int rowHeight = dtgwct.RowTemplate.Height;
            int headerHeight = dtgwct.ColumnHeadersHeight;
            int visibleRows =
                (dtgwct.Height - headerHeight) / rowHeight;
            int need = visibleRows - dt.Rows.Count;
            for (int i = 0; i < need; i++)
            {
                dt.Rows.Add(dt.NewRow());
            }
        }


        void fillemptynlrows(DataTable dt)
        {
            int rowHeight = dtgwnl.RowTemplate.Height;
            int headerHeight = dtgwnl.ColumnHeadersHeight;
            int visibleRows =
                (dtgwnl.Height - headerHeight) / rowHeight;
            int need = visibleRows - dt.Rows.Count;
            for (int i = 0; i < need; i++)
            {
                dt.Rows.Add(dt.NewRow());
            }
        }

        void fillemptytablerows(DataTable dt)
        {
            int rowHeight = dtgwtable.RowTemplate.Height;
            int headerHeight = dtgwtable.ColumnHeadersHeight;
            int visibleRows =
                (dtgwtable.Height - headerHeight) / rowHeight;
            int need = visibleRows - dt.Rows.Count;
            for (int i = 0; i < need; i++)
            {
                dt.Rows.Add(dt.NewRow());
            }
        }

        private void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {
            datetu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dateden.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                         DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            loadchart();
            LoadThuChi();
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            datetu.Value = DateTime.Now;
            dateden.Value = DateTime.Now;
            loadchart();
            LoadThuChi();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);

            datetu.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);

            dateden.Value = new DateTime(
                lastMonth.Year,
                lastMonth.Month,
                DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month)
            );

            loadchart();
            LoadThuChi();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            loadchart();
            LoadThuChi();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelnguyenlieu.Show();
            Panelkho.Hide();
            panelthongke.Hide();
            panelfoodmenu.Hide();
            panelcontrol.Hide();
            paneldanhmucmon.Hide();
            paneltable.Hide();


        }

        private void btnrepairct_Click_1(object sender, EventArgs e)
        {
            string name = txtcategory.Text;
            int idcategory = Convert.ToInt32(dtgwct.CurrentRow.Cells["id"].Value);
            
            if (categorydao.Instance.updatecategory(idcategory, name))
                MessageBox.Show("Sửa món thành công");
            load();
        }

        private void btnaddct_Click_1(object sender, EventArgs e)
        {
            string name = txtnewcategory.Text;

            if (categorydao.Instance.insertcategory(name))
                MessageBox.Show("Thông báo ", "Thêm món thành công");
            load();
        }

        private void btndeletect_Click_1(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(dtgwct.CurrentRow.Cells["id"].Value);
            
            if (categorydao.Instance.categoryhavefood(idcategory))
            {
                MessageBox.Show("Danh mục đang có món không thể xóa");
            }
            else if (idcategory == 9)
            {
                MessageBox.Show("Không thể xóa topping");
            }
            else
            {
                if (categorydao.Instance.deletecategory(idcategory))
                    MessageBox.Show("Xóa món thành công");
            }
            load();
        }

        private void btnaddnl_Click_1(object sender, EventArgs e)
        {
            string tennl = txtnguyenlieu.Text;
            string donvi = txtdonvi.Text;
            int tonkho = 0;
            if (nguyenlieudao.Instance.insertnguyenlieu(tennl, donvi, tonkho))
            {
                MessageBox.Show("Thêm nguyên liệu thành công");
                loadnguyenlieu();

            }
        }

        private void btnupdatenl_Click_1(object sender, EventArgs e)
        {
          int manl = Convert.ToInt32(dtgwnguyenlieu.CurrentRow.Cells["MaNL"].Value);

            string tennl = txtnguyenlieu.Text;
            string donvi = txtdonvi.Text;
            if (nguyenlieudao.Instance.updatenguyenlieu(manl, tennl, donvi))
            {
                MessageBox.Show("Sửa nguyên liệu thành công");
                loadnguyenlieu();
            }
        }

        private void btndeletenl_Click_1(object sender, EventArgs e)
        {
            if (dtgwnguyenlieu.CurrentRow == null) return;

           int manl = Convert.ToInt32(dtgwnguyenlieu.CurrentRow.Cells["MaNL"].Value);

        

            if (congthucdao.Instance.congthuchaveidNguyenLieu(manl))
            {
                MessageBox.Show("Nguyên liệu đang có trong công thức món không thể xóa");
                return;
            }

            if (nguyenlieudao.Instance.deletenguyenlieu(manl))
            {
                MessageBox.Show("Xóa nguyên liệu thành công");
                loadnguyenlieu();
            }
            else
            {
                MessageBox.Show("Xóa nguyên liệu thất bại");
            }
        }

        string BoDau(string input)
        {
            string s = input.ToLower();
            s = s.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                    != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string key = txttimkiem.Text.Trim();

            if (key == "")
            {
                loadlistfood();
                return;
            }

            DataTable dt = fooddao.Instance.getfood();
            DataTable result = dt.Clone();

            string keyKhongDau = BoDau(key);

            foreach (DataRow row in dt.Rows)
            {
                string tenMon = BoDau(row["name"].ToString());

                if (tenMon.Contains(keyKhongDau))
                    result.ImportRow(row);
            }
            fillemptyfoodrows(result);
            foodlist.DataSource = result;   
           
        }

        private void txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
                guna2Transition1.SetDecoration(lbltimkiem, Guna.UI2.AnimatorNS.DecorationType.None);
            lbltimkiem.Location = new Point(lbltimkiem.Left, txttimkiem.Top - 12);
                lbltimkiem.Font = new Font("Segoe UI", 8);
            lbltimkiem.ForeColor = Color.Blue;
        }

        private void txttimkiem_Leave(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                lbltimkiem.Location = new Point(lbltimkiem.Left, txttimkiem.Top + 6);
                lbltimkiem.Font = new Font("Segoe UI", 10);
                lbltimkiem.ForeColor = Color.Gray;
            }
        }

        private void buttonslmon_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(guna2Button6, new Point(0, guna2Button6.Height));
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile profile = new profile();
            profile.txbusername.Text = Session.username.ToString();
            profile.txtpass.Text = Session.password.ToString();
            profile.ActiveControl = null;


            profile.ShowDialog();
        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addaccount addaccount = new addaccount();
            addaccount.ShowDialog();
        }
    }
}



