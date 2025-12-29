using Guna.UI2.WinForms;
using quanlyquancafe.DAO;
using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyquancafe
{
    public partial class tuychon : Form
    {
        public List<food> ToppingsChon = new List<food>();
        public string Note { get; private set; } = "";
        public float TongGia { get; private set; }
        public int idfood;
        float giaMonChinh = 0;
        public int SoLuong { get; private set; }

        public tuychon(int idfood)
        {
            InitializeComponent();
            this.idfood = idfood;
        }
        public tuychon(int idfood, string note = null, int soLuong = 1)
        {
            InitializeComponent();
            this.idfood = idfood;
            this.Load += tuychon_Load;

            // nếu sửa từ billinfo thì truyền note và số lượng
            if (!string.IsNullOrEmpty(note))
            {
                LoadTuyChonFromNote(note);
                this.guna2NumericUpDown1.Value = soLuong;
              
            }
        }
        private void tuychon_Load(object sender, EventArgs e)
        {
            loadfood();
            loadtopping();
        }

        void loadfood()
        {
            food f = fooddao.Instance.getfoodbyid(idfood);
            lbltenmon.Text = f.Name;
            lblgia.Text = f.Price.ToString("N0") + " đ";
            giaMonChinh = f.Price;
            UpdateTongGia();
        }

        void loadtopping()
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = fooddao.Instance.gettopping();

            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["id"]);
                string ten = r["name"].ToString();
                int soluong = congthucdao.Instance.getSoluongMonConLai(id);

                if (soluong <= 0) continue;

                Guna2CheckBox cb = new Guna2CheckBox();
                cb.Text = $"{ten} (+{Convert.ToInt32(r["price"]):N0} đ)";
                cb.Tag = r;
                cb.AutoSize = true;
                cb.CheckedChanged += Topping_CheckedChanged;

                // tick topping nếu có trong note
                string tenTopping = ten;
                if (toppingNamesFromNote.Contains(tenTopping))
                    cb.Checked = true;

                flowLayoutPanel1.Controls.Add(cb);
            }

            // tick đá
            if (!string.IsNullOrEmpty(iceFromNote))
            {
                switch (iceFromNote)
                {
                    case "Không đá": rb0da.Checked = true; break;
                    case "Ít đá": rbit.Checked = true; break;
                    case "Nhiều đá": rbnhieu.Checked = true; break;
                }
            }

            // tick đường
            if (!string.IsNullOrEmpty(sugarFromNote))
            {
                switch (sugarFromNote)
                {
                    case "0% đường": rb0.Checked = true; break;
                    case "30% đường": rb30.Checked = true; break;
                    case "50% đường": rb50.Checked = true; break;
                    case "70% đường": rb70.Checked = true; break;
                    case "100% đường": rb100.Checked = true; break;
                }
            }
        }

        
        private bool isAdjusting = false;


        


        private void Topping_CheckedChanged(object sender, EventArgs e)
        {
            if (isAdjusting) return;

            int soLuong = (int)guna2NumericUpDown1.Value;
            int max = congthucdao.Instance.getSoluongConLai(
                idfood,
                GetToppingDangChon()
            );

            if (soLuong > max)
            {
                isAdjusting = true;
                ((Guna2CheckBox)sender).Checked = false;
                MessageBox.Show("Không đủ nguyên liệu cho topping này!");
                isAdjusting = false;
                return;
            }

            UpdateTongGia();
        }

        List<int> GetToppingDangChon()
        {
            List<int> ids = new List<int>();
            foreach (Control c in flowLayoutPanel1.Controls)
                if (c is Guna2CheckBox cb && cb.Checked)
                    ids.Add(Convert.ToInt32(((DataRow)cb.Tag)["id"]));
            return ids;
        }

        void UpdateTongGia()
        {
            int soLuong = (int)guna2NumericUpDown1.Value;
            float tong = giaMonChinh;

            foreach (Control c in flowLayoutPanel1.Controls)
                if (c is Guna2CheckBox cb && cb.Checked)
                    tong += Convert.ToInt32(((DataRow)cb.Tag)["price"]);

            TongGia = tong * soLuong;
            lblTongTien.Text = TongGia.ToString("N0") + " đ";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            SoLuong = (int)guna2NumericUpDown1.Value;

            int max = congthucdao.Instance.getSoluongConLai(
                idfood,
                GetToppingDangChon()
            );

            if (SoLuong > max)
            {
                MessageBox.Show("Nguyên liệu không đủ!");
                return;
            }
            SoLuong = (int)guna2NumericUpDown1.Value;

            string da = rb0da.Checked ? "Không đá" :
                        rbit.Checked ? "Ít đá" : "Nhiều đá";

            string duong = rb0.Checked ? "0%" :
                           rb30.Checked ? "30%" :
                           rb50.Checked ? "50%" :
                           rb70.Checked ? "70%" : "100%";

            duong = duong + " đường";

            StringBuilder sb = new StringBuilder();
            sb.Append(da + " | " + duong);

            ToppingsChon.Clear();

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Guna2CheckBox cb && cb.Checked)
                {
                    DataRow r = (DataRow)cb.Tag;
                    int id = Convert.ToInt32(r["id"]);
                    int soLuongTopping = congthucdao.Instance.getSoluongMonConLai(id);

                    if ((int)guna2NumericUpDown1.Value > soLuongTopping)
                    {
                        MessageBox.Show($"Topping {r["name"]} không đủ tồn kho!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    ToppingsChon.Add(
                        new food(id, r["name"].ToString(), 9, Convert.ToInt32(r["price"]))
                    );

                    sb.AppendLine();
                    sb.Append("+ " + r["name"]);
                }
            }

            Note = sb.ToString();

            TongGia = giaMonChinh * (int)guna2NumericUpDown1.Value;
            foreach (var t in ToppingsChon)
                TongGia += t.Price * (int)guna2NumericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void guna2NumericUpDown1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int max = congthucdao.Instance.getSoluongConLai(idfood, GetToppingDangChon());
            int currentValue = (int)guna2NumericUpDown1.Value;

            if (currentValue > max)
            {
                // Thông báo
                MessageBox.Show($"Chỉ còn {max} phần!", "Cảnh báo");

                // Reset giá trị về max
                guna2NumericUpDown1.Value = max;
            }
        }

        private void guna2NumericUpDown1_Validated(object sender, EventArgs e)
        {
            // Cập nhật tổng giá tiền
            UpdateTongGia();
        }
        List<string> toppingNamesFromNote = new List<string>();
        string iceFromNote = null;
        string sugarFromNote = null;

        // load note để tick lại topping và đá/đường
        void LoadTuyChonFromNote(string note)
        {
            string[] lines = note.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0) return;

            // đá và đường
            string[] parts = lines[0].Split('|');
            if (parts.Length >= 2)
            {
                iceFromNote = parts[0].Trim();
                sugarFromNote = parts[1].Trim();
            }

            // topping
            toppingNamesFromNote.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.StartsWith("+"))
                    toppingNamesFromNote.Add(line.Substring(1).Trim());
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tuychon_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
    }
}
