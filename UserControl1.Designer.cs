namespace quanlyquancafe
{
    partial class UserControl1
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
            Guna.UI2.AnimatorNS.Animation animation5 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btndelete = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lbldonvi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtdonvi = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNguyenLieu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboNguyenLieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblsoluong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtsoluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbldongia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtdongia = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.guna2Panel1.Controls.Add(this.lbldongia);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.txtdongia);
            this.guna2Transition1.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(739, 92);
            this.guna2Panel1.TabIndex = 0;
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
            this.btndelete.Location = new System.Drawing.Point(675, 22);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndelete.Name = "btndelete";
            this.btndelete.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btndelete.Size = new System.Drawing.Size(64, 54);
            this.btndelete.TabIndex = 18;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = false;
            this.lbldonvi.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lbldonvi, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbldonvi.Enabled = false;
            this.lbldonvi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldonvi.ForeColor = System.Drawing.Color.Gray;
            this.lbldonvi.Location = new System.Drawing.Point(221, 28);
            this.lbldonvi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(141, 26);
            this.lbldonvi.TabIndex = 15;
            this.lbldonvi.Text = "Đơn vị";
            this.lbldonvi.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2Transition1.SetDecoration(this.guna2Panel4, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel4.Location = new System.Drawing.Point(221, 60);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(133, 2);
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
            this.txtdonvi.Location = new System.Drawing.Point(208, 22);
            this.txtdonvi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.PlaceholderText = "";
            this.txtdonvi.SelectedText = "";
            this.txtdonvi.Size = new System.Drawing.Size(155, 36);
            this.txtdonvi.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtdonvi.TabIndex = 16;
            this.txtdonvi.Enter += new System.EventHandler(this.txtdonvi_Enter);
            this.txtdonvi.Leave += new System.EventHandler(this.txtdonvi_Leave);
            // 
            // lblNguyenLieu
            // 
            this.lblNguyenLieu.AutoSize = false;
            this.lblNguyenLieu.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblNguyenLieu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblNguyenLieu.Enabled = false;
            this.lblNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguyenLieu.ForeColor = System.Drawing.Color.Gray;
            this.lblNguyenLieu.Location = new System.Drawing.Point(27, 28);
            this.lblNguyenLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblNguyenLieu.Name = "lblNguyenLieu";
            this.lblNguyenLieu.Size = new System.Drawing.Size(141, 26);
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
            this.cboNguyenLieu.FillColor = System.Drawing.SystemColors.Control;
            this.cboNguyenLieu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNguyenLieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNguyenLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboNguyenLieu.ItemHeight = 30;
            this.cboNguyenLieu.Location = new System.Drawing.Point(15, 22);
            this.cboNguyenLieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboNguyenLieu.Name = "cboNguyenLieu";
            this.cboNguyenLieu.Size = new System.Drawing.Size(185, 36);
            this.cboNguyenLieu.TabIndex = 2;
            this.cboNguyenLieu.SelectedIndexChanged += new System.EventHandler(this.cboNguyenLieu_SelectedIndexChanged);
            this.cboNguyenLieu.Enter += new System.EventHandler(this.cbxnl_Enter);
            this.cboNguyenLieu.Leave += new System.EventHandler(this.cbxnl_Leave);
            // 
            // lblsoluong
            // 
            this.lblsoluong.AutoSize = false;
            this.lblsoluong.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblsoluong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblsoluong.Enabled = false;
            this.lblsoluong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluong.ForeColor = System.Drawing.Color.Gray;
            this.lblsoluong.Location = new System.Drawing.Point(541, 28);
            this.lblsoluong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(141, 26);
            this.lblsoluong.TabIndex = 10;
            this.lblsoluong.Text = "Số lượng";
            this.lblsoluong.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2Transition1.SetDecoration(this.guna2Panel3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel3.Location = new System.Drawing.Point(541, 60);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(133, 2);
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
            this.txtsoluong.Location = new System.Drawing.Point(528, 22);
            this.txtsoluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.PlaceholderText = "";
            this.txtsoluong.SelectedText = "";
            this.txtsoluong.Size = new System.Drawing.Size(155, 36);
            this.txtsoluong.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtsoluong.TabIndex = 11;
            this.txtsoluong.Enter += new System.EventHandler(this.txtsoluong_Enter);
            this.txtsoluong.Leave += new System.EventHandler(this.txtsoluong_Leave);
            // 
            // lbldongia
            // 
            this.lbldongia.AutoSize = false;
            this.lbldongia.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lbldongia, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbldongia.Enabled = false;
            this.lbldongia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldongia.ForeColor = System.Drawing.Color.Gray;
            this.lbldongia.Location = new System.Drawing.Point(381, 28);
            this.lbldongia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbldongia.Name = "lbldongia";
            this.lbldongia.Size = new System.Drawing.Size(141, 26);
            this.lbldongia.TabIndex = 7;
            this.lbldongia.Text = "Đơn giá";
            this.lbldongia.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2Transition1.SetDecoration(this.guna2Panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel2.Location = new System.Drawing.Point(381, 60);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(133, 2);
            this.guna2Panel2.TabIndex = 9;
            // 
            // txtdongia
            // 
            this.txtdongia.BorderThickness = 0;
            this.txtdongia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtdongia, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtdongia.DefaultText = "";
            this.txtdongia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdongia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdongia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdongia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdongia.FillColor = System.Drawing.SystemColors.Control;
            this.txtdongia.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.txtdongia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtdongia.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.txtdongia.Location = new System.Drawing.Point(368, 22);
            this.txtdongia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.PlaceholderText = "";
            this.txtdongia.SelectedText = "";
            this.txtdongia.Size = new System.Drawing.Size(155, 36);
            this.txtdongia.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtdongia.TabIndex = 8;
            this.txtdongia.Enter += new System.EventHandler(this.txtdongia_Enter);
            this.txtdongia.Leave += new System.EventHandler(this.txtdongia_Leave);
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.Cursor = null;
            animation5.AnimateOnlyDifferences = true;
            animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
            animation5.LeafCoeff = 0F;
            animation5.MaxTime = 1F;
            animation5.MinTime = 0F;
            animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
            animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
            animation5.MosaicSize = 0;
            animation5.Padding = new System.Windows.Forms.Padding(0);
            animation5.RotateCoeff = 0F;
            animation5.RotateLimit = 0F;
            animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
            animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
            animation5.TimeCoeff = 0F;
            animation5.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation5;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(739, 92);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbldongia;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2TextBox txtdongia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblsoluong;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox txtsoluong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbldonvi;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2TextBox txtdonvi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguyenLieu;
        private Guna.UI2.WinForms.Guna2ComboBox cboNguyenLieu;
        private Guna.UI2.WinForms.Guna2ImageButton btndelete;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
    }
}
