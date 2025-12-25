using Guna.UI2.WinForms;
using quanlyquancafe.DAO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace quanlyquancafe
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            txtsoluong.GotFocus += (s, e) =>
            {
                txtsoluong.SelectionStart = txtsoluong.Text.Length;
                txtsoluong.SelectionLength = 0;
            };
            txtsoluong.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtsoluong.Text))
                    LabelLen(lblsoluong, txtsoluong);
                else
                    LabelXuong(lblsoluong, txtsoluong);
            };

            loadcombobox();
            CapNhatTrangThaiLabel();
        }

        public int idfood { get; set; }

        public void loadcombobox()
        {
            DataTable dt = nguyenlieudao.Instance.getnguyenlieu();
            cboNguyenLieu.DataSource = dt;
            cboNguyenLieu.DisplayMember = "TenNL";
            cboNguyenLieu.ValueMember = "MaNL";
        }

        void LabelLen(Guna2HtmlLabel lbl, Control txt)
        {
            lbl.Location = new Point(lbl.Left, txt.Top - 12);
            lbl.Font = new Font("Segoe UI", 8);
            lbl.ForeColor = Color.Blue;
        }

        void LabelXuong(Guna2HtmlLabel lbl, Control txt)
        {
            lbl.Location = new Point(lbl.Left, txt.Top + 6);
            lbl.Font = new Font("Segoe UI", 10);
            lbl.ForeColor = Color.Gray;
        }

        void CapNhatTrangThaiLabel()
        {
            if (!string.IsNullOrWhiteSpace(txtsoluong.Text))
                LabelLen(lblsoluong, txtsoluong);
            else
                LabelXuong(lblsoluong, txtsoluong);

            if (!string.IsNullOrWhiteSpace(txtdonvi.Text))
                LabelLen(lbldonvi, txtdonvi);
            else
                LabelXuong(lbldonvi, txtdonvi);

            if (cboNguyenLieu.SelectedIndex != -1)
                LabelLen(lblNguyenLieu, cboNguyenLieu);
            else
                LabelXuong(lblNguyenLieu, cboNguyenLieu);
        }

        public decimal SoLuong
        {
            get
            {

                if (string.IsNullOrWhiteSpace(txtsoluong.Text))
                    return -1;
                if (!decimal.TryParse(txtsoluong.Text, out decimal sl))
                    return -1;
                return sl;
            }

            set
            {
                txtsoluong.Text = value.ToString();
                LabelLen(lblsoluong, txtsoluong);
            }
        }

        public int manl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(cboNguyenLieu.Text))
                    return -1;
                return nguyenlieudao.Instance.getidnguyenlieuByname(cboNguyenLieu.Text);
            }
        }

        private void txtsoluong_Enter_1(object sender, EventArgs e)
        {
            LabelLen(lblsoluong, txtsoluong);
        }

        private void txtsoluong_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsoluong.Text))
                LabelXuong(lblsoluong, txtsoluong);
        }

        private void txtdonvi_Enter_1(object sender, EventArgs e)
        {
            LabelLen(lbldonvi, txtdonvi);
        }

        private void txtdonvi_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdonvi.Text))
                LabelXuong(lbldonvi, txtdonvi);
        }

        private void cboNguyenLieu_Enter_1(object sender, EventArgs e)
        {
            LabelLen(lblNguyenLieu, cboNguyenLieu);
        }

        private void cboNguyenLieu_Leave_1(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex == -1)
                LabelXuong(lblNguyenLieu, cboNguyenLieu);
        }

        private void cboNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedItem is DataRowView row)
                txtdonvi.Text = row["DonVi"].ToString();
            else
                txtdonvi.Text = "";

            LabelLen(lblNguyenLieu, cboNguyenLieu);
            LabelLen(lbldonvi, txtdonvi);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int manl = nguyenlieudao.Instance.getidnguyenlieuByname(cboNguyenLieu.Text);
            congthucdao.Instance.deletecongthuc(idfood, manl);

            Control parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(this);
                this.Dispose();
            }
        }
    }
}
