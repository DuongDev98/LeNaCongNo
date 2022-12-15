namespace Project.Forms
{
    partial class KhachHangForm
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
            this.btnLuuThoat = new System.Windows.Forms.Button();
            this.btnLuuMoi = new System.Windows.Forms.Button();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCODE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDIACHI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDIENTHOAI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLuuThoat
            // 
            this.btnLuuThoat.Location = new System.Drawing.Point(147, 110);
            this.btnLuuThoat.Name = "btnLuuThoat";
            this.btnLuuThoat.Size = new System.Drawing.Size(75, 23);
            this.btnLuuThoat.TabIndex = 5;
            this.btnLuuThoat.Text = "Lưu thoát";
            this.btnLuuThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuuMoi
            // 
            this.btnLuuMoi.Location = new System.Drawing.Point(66, 110);
            this.btnLuuMoi.Name = "btnLuuMoi";
            this.btnLuuMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLuuMoi.TabIndex = 4;
            this.btnLuuMoi.Text = "Lưu mới";
            this.btnLuuMoi.UseVisualStyleBackColor = true;
            // 
            // txtNAME
            // 
            this.txtNAME.Location = new System.Drawing.Point(72, 32);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(150, 20);
            this.txtNAME.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Khách hàng";
            // 
            // txtCODE
            // 
            this.txtCODE.Location = new System.Drawing.Point(72, 6);
            this.txtCODE.Name = "txtCODE";
            this.txtCODE.Size = new System.Drawing.Size(150, 20);
            this.txtCODE.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã khách";
            // 
            // txtDIACHI
            // 
            this.txtDIACHI.Location = new System.Drawing.Point(72, 84);
            this.txtDIACHI.Name = "txtDIACHI";
            this.txtDIACHI.Size = new System.Drawing.Size(150, 20);
            this.txtDIACHI.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Địa chỉ";
            // 
            // txtDIENTHOAI
            // 
            this.txtDIENTHOAI.Location = new System.Drawing.Point(72, 58);
            this.txtDIENTHOAI.Name = "txtDIENTHOAI";
            this.txtDIENTHOAI.Size = new System.Drawing.Size(150, 20);
            this.txtDIENTHOAI.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Điện thoại";
            // 
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 144);
            this.Controls.Add(this.txtDIACHI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDIENTHOAI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLuuThoat);
            this.Controls.Add(this.btnLuuMoi);
            this.Controls.Add(this.txtNAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCODE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KhachHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuuThoat;
        private System.Windows.Forms.Button btnLuuMoi;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCODE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDIACHI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDIENTHOAI;
        private System.Windows.Forms.Label label4;
    }
}