namespace Project
{
    partial class HoaDonBanHang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitMain1 = new System.Windows.Forms.SplitContainer();
            this.grMatHang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitMain2 = new System.Windows.Forms.SplitContainer();
            this.btnKhachMoi = new System.Windows.Forms.Button();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.txtNOTE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.detail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDatSL = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGiam = new System.Windows.Forms.Button();
            this.btnTang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain1)).BeginInit();
            this.splitMain1.Panel1.SuspendLayout();
            this.splitMain1.Panel2.SuspendLayout();
            this.splitMain1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain2)).BeginInit();
            this.splitMain2.Panel1.SuspendLayout();
            this.splitMain2.Panel2.SuspendLayout();
            this.splitMain2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitMain1
            // 
            this.splitMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain1.Location = new System.Drawing.Point(0, 0);
            this.splitMain1.Name = "splitMain1";
            // 
            // splitMain1.Panel1
            // 
            this.splitMain1.Panel1.Controls.Add(this.grMatHang);
            this.splitMain1.Panel1.Controls.Add(this.btnRefresh);
            this.splitMain1.Panel1.Controls.Add(this.txtLoc);
            this.splitMain1.Panel1.Controls.Add(this.label1);
            // 
            // splitMain1.Panel2
            // 
            this.splitMain1.Panel2.Controls.Add(this.splitMain2);
            this.splitMain1.Size = new System.Drawing.Size(784, 461);
            this.splitMain1.SplitterDistance = 261;
            this.splitMain1.TabIndex = 1;
            // 
            // grMatHang
            // 
            this.grMatHang.AllowUserToAddRows = false;
            this.grMatHang.AllowUserToDeleteRows = false;
            this.grMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.grMatHang.Location = new System.Drawing.Point(3, 33);
            this.grMatHang.Name = "grMatHang";
            this.grMatHang.ReadOnly = true;
            this.grMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMatHang.Size = new System.Drawing.Size(253, 425);
            this.grMatHang.TabIndex = 3;
            this.grMatHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grMatHang_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "CODE";
            this.Column1.HeaderText = "Mã hàng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 74;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "NAME";
            this.Column2.HeaderText = "Mặt hàng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(181, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(46, 6);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(129, 20);
            this.txtLoc.TabIndex = 1;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lọc:";
            // 
            // splitMain2
            // 
            this.splitMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain2.Location = new System.Drawing.Point(0, 0);
            this.splitMain2.Name = "splitMain2";
            this.splitMain2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain2.Panel1
            // 
            this.splitMain2.Panel1.Controls.Add(this.btnKhachMoi);
            this.splitMain2.Panel1.Controls.Add(this.cbKhachHang);
            this.splitMain2.Panel1.Controls.Add(this.txtNOTE);
            this.splitMain2.Panel1.Controls.Add(this.label5);
            this.splitMain2.Panel1.Controls.Add(this.label4);
            this.splitMain2.Panel1.Controls.Add(this.dtNgay);
            this.splitMain2.Panel1.Controls.Add(this.label3);
            this.splitMain2.Panel1.Controls.Add(this.txtNAME);
            this.splitMain2.Panel1.Controls.Add(this.label2);
            // 
            // splitMain2.Panel2
            // 
            this.splitMain2.Panel2.Controls.Add(this.btnLuu);
            this.splitMain2.Panel2.Controls.Add(this.btnHuy);
            this.splitMain2.Panel2.Controls.Add(this.detail);
            this.splitMain2.Panel2.Controls.Add(this.btnDatSL);
            this.splitMain2.Panel2.Controls.Add(this.btnXoa);
            this.splitMain2.Panel2.Controls.Add(this.btnGiam);
            this.splitMain2.Panel2.Controls.Add(this.btnTang);
            this.splitMain2.Size = new System.Drawing.Size(519, 461);
            this.splitMain2.SplitterDistance = 85;
            this.splitMain2.TabIndex = 0;
            // 
            // btnKhachMoi
            // 
            this.btnKhachMoi.Location = new System.Drawing.Point(400, 30);
            this.btnKhachMoi.Name = "btnKhachMoi";
            this.btnKhachMoi.Size = new System.Drawing.Size(107, 23);
            this.btnKhachMoi.TabIndex = 6;
            this.btnKhachMoi.Text = "Khách mới";
            this.btnKhachMoi.UseVisualStyleBackColor = true;
            this.btnKhachMoi.Click += new System.EventHandler(this.btnKhachMoi_Click);
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(101, 31);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(293, 21);
            this.cbKhachHang.TabIndex = 0;
            // 
            // txtNOTE
            // 
            this.txtNOTE.Location = new System.Drawing.Point(101, 58);
            this.txtNOTE.Name = "txtNOTE";
            this.txtNOTE.Size = new System.Drawing.Size(406, 20);
            this.txtNOTE.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ghi chú:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khách hàng:";
            // 
            // dtNgay
            // 
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.Location = new System.Drawing.Point(101, 6);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(102, 20);
            this.dtNgay.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày";
            // 
            // txtNAME
            // 
            this.txtNAME.Enabled = false;
            this.txtNAME.Location = new System.Drawing.Point(400, 6);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(107, 20);
            this.txtNAME.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số HĐ:";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(363, 343);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(69, 26);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu HĐ";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(438, 343);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(69, 26);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy HĐ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // detail
            // 
            this.detail.AllowUserToAddRows = false;
            this.detail.AllowUserToDeleteRows = false;
            this.detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column3});
            this.detail.Location = new System.Drawing.Point(3, 35);
            this.detail.Name = "detail";
            this.detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.detail.Size = new System.Drawing.Size(504, 306);
            this.detail.TabIndex = 4;
            this.detail.SelectionChanged += new System.EventHandler(this.detail_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DMATHANG_CODE";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã hàng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 74;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DMATHANG_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mặt hàng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.DataPropertyName = "SOLUONG";
            this.Column3.HeaderText = "Số lượng";
            this.Column3.Name = "Column3";
            this.Column3.Width = 74;
            // 
            // btnDatSL
            // 
            this.btnDatSL.Location = new System.Drawing.Point(239, 3);
            this.btnDatSL.Name = "btnDatSL";
            this.btnDatSL.Size = new System.Drawing.Size(69, 26);
            this.btnDatSL.TabIndex = 5;
            this.btnDatSL.Text = "Đặt SL";
            this.btnDatSL.UseVisualStyleBackColor = true;
            this.btnDatSL.Click += new System.EventHandler(this.btnDatSL_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(164, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(69, 26);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGiam
            // 
            this.btnGiam.Location = new System.Drawing.Point(89, 3);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(69, 26);
            this.btnGiam.TabIndex = 3;
            this.btnGiam.Text = "Giảm -1";
            this.btnGiam.UseVisualStyleBackColor = true;
            this.btnGiam.Click += new System.EventHandler(this.btnGiam_Click);
            // 
            // btnTang
            // 
            this.btnTang.Location = new System.Drawing.Point(14, 3);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(69, 26);
            this.btnTang.TabIndex = 2;
            this.btnTang.Text = "Tăng +1";
            this.btnTang.UseVisualStyleBackColor = true;
            this.btnTang.Click += new System.EventHandler(this.btnTang_Click);
            // 
            // HoaDonBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitMain1);
            this.Name = "HoaDonBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn bán hàng";
            this.Load += new System.EventHandler(this.HoaDonBanHang_Load);
            this.splitMain1.Panel1.ResumeLayout(false);
            this.splitMain1.Panel1.PerformLayout();
            this.splitMain1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain1)).EndInit();
            this.splitMain1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMatHang)).EndInit();
            this.splitMain2.Panel1.ResumeLayout(false);
            this.splitMain2.Panel1.PerformLayout();
            this.splitMain2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain2)).EndInit();
            this.splitMain2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain1;
        private System.Windows.Forms.SplitContainer splitMain2;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView grMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNOTE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.Button btnDatSL;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGiam;
        private System.Windows.Forms.Button btnTang;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnKhachMoi;
    }
}

