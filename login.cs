using quanlyquancafe.DAO;
using quanlyquancafe.DTO;
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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            lblPass.Refresh();
            lbllogin.Refresh();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        bool logincheck(string username,string password)
        {
            return accountdao.Instance.Login(username,password);
        }

      

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("xác nhận thoát", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

      

      
        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {


            if (txtPass.Text == "")
                guna2Transition1.SetDecoration(lblPass, Guna.UI2.AnimatorNS.DecorationType.None);
            lblPass.Location = new Point(lblPass.Left, txtPass.Top - 12);
            lblPass.Font = new Font("Segoe UI", 8);
            lblPass.ForeColor = Color.Blue;

        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                lblPass.Location = new Point(lblPass.Left, txtPass.Top + 6);
                lblPass.Font = new Font("Segoe UI", 10);
                lblPass.ForeColor = Color.Gray;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtlogin.Text;
            string password = txtPass.Text;

            if (logincheck(username, password))
            {
                DataTable dt = accountdao.Instance.GetAccountByUsername(username);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    Session.password = r["password"].ToString();
                    Session.username = r["username"].ToString();
                    Session.isadmin = Convert.ToInt32(r["type"]) == 1; // 1 = admin
                }

                tablemanager f = new tablemanager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo");
            }
        }


        private void btnexxit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtlogin_Enter(object sender, EventArgs e)
        {

            if (txtlogin.Text == "")
                guna2Transition1.SetDecoration(lbllogin, Guna.UI2.AnimatorNS.DecorationType.None);
            lbllogin.Location = new Point(lbllogin.Left, txtlogin.Top - 12);
            lbllogin.Font = new Font("Segoe UI", 8);
            lbllogin.ForeColor = Color.Blue;
        }

        private void txtlogin_Leave(object sender, EventArgs e)
        {
            if (txtlogin.Text == "")
            {
                lbllogin.Location = new Point(lbllogin.Left, txtlogin.Top + 6);
                lbllogin.Font = new Font("Segoe UI", 10);
                lbllogin.ForeColor = Color.Gray;
            }
        }
    }
}
