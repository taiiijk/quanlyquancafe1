namespace quanlyquancafe
{
    partial class UserControl2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.AnimatorNS.Animation animation11 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbldonvi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtdonvi = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNguyenLieu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboNguyenLieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblsoluong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtsoluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.btndelete = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btndelete);
            this.guna2Panel1.Controls.Add(this.lbldonvi);
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Controls.Add(this.txtdonvi);
            this.guna2Panel1.Controls.Add(this.lblNguyenLieu);
            this.guna2Panel1.Controls.Add(this.cboNguyenLieu);
            this.guna2Panel1.Controls.Add(this.lblsoluong);
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.txtsoluong);
            this.guna2Transition1.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.Location = new System.Drawing.Point(8, 8);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(464, 65);
            this.guna2Panel1.TabIndex = 1;
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = false;
            this.lbldonvi.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lbldonvi, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbldonvi.Enabled = false;
            this.lbldonvi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldonvi.ForeColor = System.Drawing.Color.Gray;
            this.lbldonvi.Location = new System.Drawing.Point(166, 23);
            this.lbldonvi.Margin = new System.Windows.Forms.Padding(2);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(106, 21);
            this.lbldonvi.TabIndex = 15;
            this.lbldonvi.Text = "Đơn vị";
            this.lbldonvi.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2Transition1.SetDecoration(this.guna2Panel4, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel4.Location = new System.Drawing.Point(166, 49);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(100, 2);
            this.guna2Panel4.TabIndex = 17;
            // 
            // txtdonvi
            // 
            this.txtdonvi.BorderThickness = 0;
            this.txtdonvi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtdonvi, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtdonvi.DefaultText = "";
            this.txtdonvi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdonvi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdonvi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdonvi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdonvi.FillColor = System.Drawing.SystemColors.Control;
            this.txtdonvi.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.txtdonvi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtdonvi.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.txtdonvi.Location = new System.Drawing.Point(156, 18);
            this.txtdonvi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.PlaceholderText = "";
            this.txtdonvi.SelectedText = "";
            this.txtdonvi.Size = new System.Drawing.Size(116, 29);
            this.txtdonvi.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtdonvi.TabIndex = 16;
            this.txtdonvi.Enter += new System.EventHandler(this.txtdonvi_Enter_1);
            this.txtdonvi.Leave += new System.EventHandler(this.txtdonvi_Leave_1);
            // 
            // lblNguyenLieu
            // 
            this.lblNguyenLieu.AutoSize = false;
            this.lblNguyenLieu.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblNguyenLieu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblNguyenLieu.Enabled = false;
            this.lblNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguyenLieu.ForeColor = System.Drawing.Color.Gray;
            this.lblNguyenLieu.Location = new System.Drawing.Point(23, 7);
            this.lblNguyenLieu.Margin = new System.Windows.Forms.Padding(2);
            this.lblNguyenLieu.Name = "lblNguyenLieu";
            this.lblNguyenLieu.Size = new System.Drawing.Size(106, 21);
            this.lblNguyenLieu.TabIndex = 14;
            this.lblNguyenLieu.Text = "Nguyên liệu";
            this.lblNguyenLieu.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // cboNguyenLieu
            // 
            this.cboNguyenLieu.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.cboNguyenLieu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cboNguyenLieu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNguyenLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenLieu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNguyenLieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNguyenLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboNguyenLieu.ItemHeight = 30;
            this.cboNguyenLieu.Location = new System.Drawing.Point(11, 18);
            this.cboNguyenLieu.Name = "cboNguyenLieu";
            this.cboNguyenLieu.Size = new System.Drawing.Size(140, 36);
            this.cboNguyenLieu.TabIndex = 13;
            this.cboNguyenLieu.SelectedIndexChanged += new System.EventHandler(this.cboNguyenLieu_SelectedIndexChanged_1);
            this.cboNguyenLieu.Enter += new System.EventHandler(this.cboNguyenLieu_Enter);
            this.cboNguyenLieu.Leave += new System.EventHandler(this.cboNguyenLieu_Leave);
            // 
            // lblsoluong
            // 
            this.lblsoluong.AutoSize = false;
            this.lblsoluong.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblsoluong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblsoluong.Enabled = false;
            this.lblsoluong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluong.ForeColor = System.Drawing.Color.Gray;
            this.lblsoluong.Location = new System.Drawing.Point(286, 23);
            this.lblsoluong.Margin = new System.Windows.Forms.Padding(2);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(106, 21);
            this.lblsoluong.TabIndex = 10;
            this.lblsoluong.Text = "Số lượng";
            this.lblsoluong.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2Transition1.SetDecoration(this.guna2Panel3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel3.Location = new System.Drawing.Point(286, 49);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(100, 2);
            this.guna2Panel3.TabIndex = 12;
            // 
            // txtsoluong
            // 
            this.txtsoluong.BorderThickness = 0;
            this.txtsoluong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtsoluong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtsoluong.DefaultText = "";
            this.txtsoluong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsoluong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsoluong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsoluong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsoluong.FillColor = System.Drawing.SystemColors.Control;
            this.txtsoluong.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.txtsoluong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsoluong.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.txtsoluong.Location = new System.Drawing.Point(276, 18);
            this.txtsoluong.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.PlaceholderText = "";
            this.txtsoluong.SelectedText = "";
            this.txtsoluong.Size = new System.Drawing.Size(116, 29);
            this.txtsoluong.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtsoluong.TabIndex = 11;
            this.txtsoluong.Enter += new System.EventHandler(this.txtsoluong_Enter_1);
            this.txtsoluong.Leave += new System.EventHandler(this.txtsoluong_Leave_1);
            // 
            // btndelete
            // 
            this.btndelete.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2Transition1.SetDecoration(this.btndelete, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btndelete.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btndelete.Image = global::quanlyquancafe.Properties.Resources.bin;
            this.btndelete.ImageOffset = new System.Drawing.Point(0, 0);
            this.btndelete.ImageRotate = 0F;
            this.btndelete.ImageSize = new System.Drawing.Size(30, 30);
            this.btndelete.Location = new System.Drawing.Point(396, 7);
            this.btndelete.Margin = new System.Windows.Forms.Padding(2);
            this.btndelete.Name = "btndelete";
            this.btndelete.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btndelete.Size = new System.Drawing.Size(48, 44);
            this.btndelete.TabIndex = 18;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.Cursor = null;
            animation11.AnimateOnlyDifferences = true;
            animation11.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.BlindCoeff")));
            animation11.LeafCoeff = 0F;
            animation11.MaxTime = 1F;
            animation11.MinTime = 0F;
            animation11.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.MosaicCoeff")));
            animation11.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation11.MosaicShift")));
            animation11.MosaicSize = 0;
            animation11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation11.RotateCoeff = 0F;
            animation11.RotateLimit = 0F;
            animation11.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.ScaleCoeff")));
            animation11.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation11.SlideCoeff")));
            animation11.TimeCoeff = 0F;
            animation11.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation11;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(477, 80);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton btndelete;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbldonvi;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguyenLieu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblsoluong;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        public Guna.UI2.WinForms.Guna2TextBox txtdonvi;
        public Guna.UI2.WinForms.Guna2ComboBox cboNguyenLieu;
        public Guna.UI2.WinForms.Guna2TextBox txtsoluong;
    }
}
