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
    public partial class addaccount : Form
    {
        public addaccount()
        {
            InitializeComponent();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            
            if (accountdao.Instance.addaccount(txbusername.Text, txtpass.Text, int.Parse(txttype.Text)))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
