using Guna.UI2.WinForms;
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

    public partial class UserControl2 : UserControl
    {
        BindingSource nguyenlieulist = new BindingSource();
   

        public UserControl2()
        {
 
            InitializeComponent();
            
            

        }
        private int _initialManl = -1;
        public void SetNguyenLieu(int manl)
        {
            _initialManl = manl; // Chỉ lưu giá trị
                                 // Không gán trực tiếp SelectedValue ở đây nữa
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
            if (_initialManl != -1)
            {
                // Kiểm tra xem dữ liệu đã được load chưa, 
                // vì loadcombobox() đã được gọi trong constructor nên ta có thể gán.
                // Để chắc chắn hơn, bạn có thể kiểm tra: if (cboNguyenLieu.DataSource != null)
                cboNguyenLieu.SelectedValue = _initialManl;
            }
        }

        public int idfood
        {
            get; set;
        }
       
        public void loadcombobox()
        {
            DataTable dt = nguyenlieudao.Instance.getnguyenlieu();
            cboNguyenLieu.DataSource = dt;
            cboNguyenLieu.DisplayMember = "TenNL";
            cboNguyenLieu.ValueMember = "MaNL";

        }
        
    

       
     
       

        public decimal SoLuong
        {
            get => Convert.ToDecimal(txtsoluong.Text);
            set => txtsoluong.Text = value.ToString();
        }
       
        public int manl
        {
            get => nguyenlieudao.Instance.getidnguyenlieuByname(cboNguyenLieu.Text);
        }

        private void txtsoluong_Leave_1(object sender, EventArgs e)
        {
            if (txtsoluong.Text == "")
            {
                lblsoluong.Location = new Point(lblsoluong.Left, txtsoluong.Top + 6);
                lblsoluong.Font = new Font("Segoe UI", 10);
                lblsoluong.ForeColor = Color.Gray;
            }
        }

        private void txtsoluong_Enter_1(object sender, EventArgs e)
        {
            if (txtsoluong.Text == "")
                guna2Transition1.SetDecoration(lblsoluong, Guna.UI2.AnimatorNS.DecorationType.None);
            lblsoluong.Location = new Point(lblsoluong.Left, txtsoluong.Top - 12);
            lblsoluong.Font = new Font("Segoe UI", 8);
            lblsoluong.ForeColor = Color.Blue;

        }

        private void txtdonvi_Leave_1(object sender, EventArgs e)
        {
            if (txtdonvi.Text == "")
            {
                lbldonvi.Location = new Point(lbldonvi.Left, txtdonvi.Top + 6);
                lbldonvi.Font = new Font("Segoe UI", 10);
                lbldonvi.ForeColor = Color.Gray;
            }
        }

        private void txtdonvi_Enter_1(object sender, EventArgs e)
        {
            if (txtdonvi.Text == "")
                guna2Transition1.SetDecoration(lbldonvi, Guna.UI2.AnimatorNS.DecorationType.None);
            lbldonvi.Location = new Point(lbldonvi.Left, txtdonvi.Top - 12);
            lbldonvi.Font = new Font("Segoe UI", 8);
            lbldonvi.ForeColor = Color.Blue;
        }

        private void cboNguyenLieu_Enter(object sender, EventArgs e)
        {

            if (cboNguyenLieu.SelectedIndex == -1)
                guna2Transition1.SetDecoration(lblNguyenLieu, Guna.UI2.AnimatorNS.DecorationType.None);

            lblNguyenLieu.Location = new Point(lblNguyenLieu.Left, cboNguyenLieu.Top - 12);
            lblNguyenLieu.Font = new Font("Segoe UI", 8);
            lblNguyenLieu.ForeColor = Color.Blue;

           
        }

        private void cboNguyenLieu_Leave(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex == -1)
            {
                lblNguyenLieu.Location = new Point(lblNguyenLieu.Left, cboNguyenLieu.Top + 6);
                lblNguyenLieu.Font = new Font("Segoe UI", 10);
                lblNguyenLieu.ForeColor = Color.Gray;
            }
        }

        private void cboNguyenLieu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedItem is DataRowView row)
            {
                txtdonvi.Text = row["DonVi"].ToString();
            }
            else
                txtdonvi.Text = "";

            lbldonvi.Location = new Point(lbldonvi.Left, cboNguyenLieu.Top - 12);
            lbldonvi.Font = new Font("Segoe UI", 8);
            lbldonvi.ForeColor = Color.Blue;

        }

        private void btndelete_Click(object sender, EventArgs e)

        {
            int idfood = this.idfood;
                int manl = nguyenlieudao.Instance.getidnguyenlieuByname(cboNguyenLieu.Text);
            congthucdao.Instance.deletecongthuc(idfood, manl);



        }
        public void LoadFull(int manl, decimal soluong)
        {
            loadcombobox();

            // Đặt breakpoint ở đây, xem:
            // 1. cboNguyenLieu.Items có gì?
            // 2. manl có đúng không?
            for (int i = 0; i < cboNguyenLieu.Items.Count; i++)
            {
                if (cboNguyenLieu.Items[i] is DataRowView row)
                {
                    int currentManl = Convert.ToInt32(row["MaNL"]);

                    // Breakpoint: kiểm tra currentManl và manl
                    if (currentManl == manl)
                    {
                        cboNguyenLieu.SelectedIndex = i;

                        // THÊM: Kiểm tra xem đã chọn chưa
                        if (cboNguyenLieu.SelectedIndex == i)
                        {
                            MessageBox.Show($"Đã chọn index {i}: {row["TenNL"]}");
                        }

                        break;
                    }
                }
            }

            txtsoluong.Text = soluong.ToString();
        }
    }
}
