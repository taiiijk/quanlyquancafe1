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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlyquancafe
{
    public partial class UserControl1 : UserControl
    {
        BindingSource nguyenlieulist = new BindingSource();
        public UserControl1()
        {
            InitializeComponent();
            nguyenlieulist.DataSource = nguyenlieudao.Instance.getnguyenlieu();
            loadcombobox();
            nguyenlieubinding();
            this.ActiveControl = cboNguyenLieu;
        }
        void nguyenlieubinding()
        {

            txtdonvi.DataBindings.Clear();
            txtdonvi.DataBindings.Add(new Binding("Text", nguyenlieulist, "DonVi", true, DataSourceUpdateMode.Never));
        }
        public void loadcombobox()
        {
            DataTable dt = nguyenlieudao.Instance.getnguyenlieu();
            cboNguyenLieu.DataSource = dt;
            cboNguyenLieu.DisplayMember = "TenNL";

        }
        private void txtdonvi_Leave(object sender, EventArgs e)
        {
            if (txtdonvi.Text == "")
            {
                lbldonvi.Location = new Point(lbldonvi.Left, txtdonvi.Top + 6);
                lbldonvi.Font = new Font("Segoe UI", 10);
                lbldonvi.ForeColor = Color.Gray;
            }
        }
        private void txtdonvi_Enter(object sender, EventArgs e)
        {
            if (txtdonvi.Text == "")
                guna2Transition1.SetDecoration(lbldonvi, Guna.UI2.AnimatorNS.DecorationType.None);
            lbldonvi.Location = new Point(lbldonvi.Left, txtdonvi.Top - 12);
            lbldonvi.Font = new Font("Segoe UI", 8);
            lbldonvi.ForeColor = Color.Blue;
        }
        private void txtdongia_Leave(object sender, EventArgs e)
        {
            if (txtdongia.Text == "")
            {
                lbldongia.Location = new Point(lbldongia.Left, txtdongia.Top + 6);
                lbldongia.Font = new Font("Segoe UI", 10);
                lbldongia.ForeColor = Color.Gray;
            }
        }

        private void txtdongia_Enter(object sender, EventArgs e)
        {

            if (txtdongia.Text == "")
                guna2Transition1.SetDecoration(lbldongia, Guna.UI2.AnimatorNS.DecorationType.None);
            lbldongia.Location = new Point(lbldongia.Left, txtdongia.Top - 12);
            lbldongia.Font = new Font("Segoe UI", 8);
            lbldongia.ForeColor = Color.Blue;
        }

        private void txtsoluong_Enter(object sender, EventArgs e)
        {
            if (txtsoluong.Text == "")
                guna2Transition1.SetDecoration(lblsoluong, Guna.UI2.AnimatorNS.DecorationType.None);
            lblsoluong.Location = new Point(lblsoluong.Left, txtsoluong.Top - 12);
            lblsoluong.Font = new Font("Segoe UI", 8);
            lblsoluong.ForeColor = Color.Blue;

        }

        private void txtsoluong_Leave(object sender, EventArgs e)
        {
            if (txtsoluong.Text == "")
            {
                lblsoluong.Location = new Point(lblsoluong.Left, txtsoluong.Top + 6);
                lblsoluong.Font = new Font("Segoe UI", 10);
                lblsoluong.ForeColor = Color.Gray;
            }
        }

        private void cbxnl_Enter(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex == -1)
                guna2Transition1.SetDecoration(lblNguyenLieu, Guna.UI2.AnimatorNS.DecorationType.None);

            lblNguyenLieu.Location = new Point(lblNguyenLieu.Left, cboNguyenLieu.Top - 12);
            lblNguyenLieu.Font = new Font("Segoe UI", 8);
            lblNguyenLieu.ForeColor = Color.Blue;
        }

        private void cbxnl_Leave(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex == -1)
            {
                lblNguyenLieu.Location = new Point(lblNguyenLieu.Left, cboNguyenLieu.Top + 6);
                lblNguyenLieu.Font = new Font("Segoe UI", 10);
                lblNguyenLieu.ForeColor = Color.Gray;
            }
        }

        private void cboNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
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
        public int SoLuong
        {
            get => Convert.ToInt32(txtsoluong.Text);
            set => txtsoluong.Text = value.ToString();
        }
        public decimal dongia
        {
            get => decimal.Parse(txtdongia.Text);
            set => txtdongia.Text = value.ToString();


        }
        public int manl
        {
            get => nguyenlieudao.Instance.getidnguyenlieuByname(cboNguyenLieu.Text);
        }
    }
}
