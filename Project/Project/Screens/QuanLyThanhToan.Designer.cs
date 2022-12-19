namespace Project.Screens
{
    partial class QuanLyThanhToan
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
            this.components = new System.ComponentModel.Container();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.tsbDelete = new System.Windows.Forms.Button();
            this.tsbEdit = new System.Windows.Forms.Button();
            this.tsbAdd = new System.Windows.Forms.Button();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(128, 22);
            this.mnuRefresh.Text = "Làm mới";
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(128, 22);
            this.mnuEdit.Text = "Chỉnh sửa";
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(128, 22);
            this.mnuAdd.Text = "Thêm mới";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete,
            this.mnuRefresh});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(129, 92);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(128, 22);
            this.mnuDelete.Text = "Xóa";
            // 
            // grMain
            // 
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column1,
            this.Column5});
            this.grMain.Location = new System.Drawing.Point(2, 32);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.Size = new System.Drawing.Size(796, 517);
            this.grMain.TabIndex = 3;
            // 
            // tsbDelete
            // 
            this.tsbDelete.Location = new System.Drawing.Point(431, 3);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(75, 23);
            this.tsbDelete.TabIndex = 11;
            this.tsbDelete.Text = "Xóa";
            this.tsbDelete.UseVisualStyleBackColor = true;
            // 
            // tsbEdit
            // 
            this.tsbEdit.Location = new System.Drawing.Point(350, 3);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(75, 23);
            this.tsbEdit.TabIndex = 10;
            this.tsbEdit.Text = "Chỉnh sửa";
            this.tsbEdit.UseVisualStyleBackColor = true;
            // 
            // tsbAdd
            // 
            this.tsbAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbAdd.Location = new System.Drawing.Point(269, 3);
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(75, 23);
            this.tsbAdd.TabIndex = 9;
            this.tsbAdd.Text = "Thêm mới";
            this.tsbAdd.UseVisualStyleBackColor = true;
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(83, 4);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(180, 21);
            this.cbKhachHang.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Khách hàng";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.DataPropertyName = "STT";
            this.Column3.HeaderText = "STT";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 53;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "NGAY";
            this.Column4.HeaderText = "Ngày";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 57;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "NAME";
            this.Column2.HeaderText = "Số phiếu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 74;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "DKHACHHANG_NAME";
            this.Column1.HeaderText = "Khách hàng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.DataPropertyName = "TONGCONG";
            this.Column5.HeaderText = "Tổng cộng";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 84;
            // 
            // QuanLyThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 551);
            this.Controls.Add(this.tsbDelete);
            this.Controls.Add(this.tsbEdit);
            this.Controls.Add(this.tsbAdd);
            this.Controls.Add(this.cbKhachHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grMain);
            this.Name = "QuanLyThanhToan";
            this.Text = "Quản lý thanh toán";
            this.Load += new System.EventHandler(this.QuanLyThanhToan_Load);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.DataGridView grMain;
        private System.Windows.Forms.Button tsbDelete;
        private System.Windows.Forms.Button tsbEdit;
        private System.Windows.Forms.Button tsbAdd;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}