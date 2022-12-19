namespace Project.Forms
{
    partial class ThanhToanForm
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
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numTONGCONG = new System.Windows.Forms.TextBox();
            this.txtNOTE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLuuMoi = new System.Windows.Forms.Button();
            this.btnLuuThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtNgay
            // 
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.Location = new System.Drawing.Point(89, 12);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(102, 20);
            this.dtNgay.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày";
            // 
            // txtNAME
            // 
            this.txtNAME.Enabled = false;
            this.txtNAME.Location = new System.Drawing.Point(229, 12);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(107, 20);
            this.txtNAME.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Số :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Khách hàng";
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(89, 38);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(247, 21);
            this.cbKhachHang.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Số tiền";
            // 
            // numTONGCONG
            // 
            this.numTONGCONG.Location = new System.Drawing.Point(89, 65);
            this.numTONGCONG.Name = "numTONGCONG";
            this.numTONGCONG.Size = new System.Drawing.Size(102, 20);
            this.numTONGCONG.TabIndex = 1;
            // 
            // txtNOTE
            // 
            this.txtNOTE.Location = new System.Drawing.Point(89, 91);
            this.txtNOTE.Name = "txtNOTE";
            this.txtNOTE.Size = new System.Drawing.Size(247, 20);
            this.txtNOTE.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ghi chú";
            // 
            // btnLuuMoi
            // 
            this.btnLuuMoi.Location = new System.Drawing.Point(180, 117);
            this.btnLuuMoi.Name = "btnLuuMoi";
            this.btnLuuMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLuuMoi.TabIndex = 16;
            this.btnLuuMoi.Text = "Lưu mới";
            this.btnLuuMoi.UseVisualStyleBackColor = true;
            // 
            // btnLuuThoat
            // 
            this.btnLuuThoat.Location = new System.Drawing.Point(261, 117);
            this.btnLuuThoat.Name = "btnLuuThoat";
            this.btnLuuThoat.Size = new System.Drawing.Size(75, 23);
            this.btnLuuThoat.TabIndex = 17;
            this.btnLuuThoat.Text = "Lưu thoát";
            this.btnLuuThoat.UseVisualStyleBackColor = true;
            // 
            // ThanhToanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 147);
            this.Controls.Add(this.btnLuuThoat);
            this.Controls.Add(this.btnLuuMoi);
            this.Controls.Add(this.txtNOTE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numTONGCONG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbKhachHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNAME);
            this.Controls.Add(this.label2);
            this.Name = "ThanhToanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.ThanhToanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numTONGCONG;
        private System.Windows.Forms.TextBox txtNOTE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLuuMoi;
        private System.Windows.Forms.Button btnLuuThoat;
    }
}