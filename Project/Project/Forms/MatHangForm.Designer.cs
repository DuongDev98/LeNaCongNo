namespace Project.Forms
{
    partial class MatHangForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCODE = new System.Windows.Forms.TextBox();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLuuMoi = new System.Windows.Forms.Button();
            this.btnLuuThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hàng";
            // 
            // txtCODE
            // 
            this.txtCODE.Enabled = false;
            this.txtCODE.Location = new System.Drawing.Point(82, 6);
            this.txtCODE.Name = "txtCODE";
            this.txtCODE.Size = new System.Drawing.Size(150, 20);
            this.txtCODE.TabIndex = 1;
            // 
            // txtNAME
            // 
            this.txtNAME.Location = new System.Drawing.Point(82, 32);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(150, 20);
            this.txtNAME.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mặt hàng";
            // 
            // btnLuuMoi
            // 
            this.btnLuuMoi.Location = new System.Drawing.Point(76, 58);
            this.btnLuuMoi.Name = "btnLuuMoi";
            this.btnLuuMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLuuMoi.TabIndex = 4;
            this.btnLuuMoi.Text = "Lưu mới";
            this.btnLuuMoi.UseVisualStyleBackColor = true;
            // 
            // btnLuuThoat
            // 
            this.btnLuuThoat.Location = new System.Drawing.Point(157, 58);
            this.btnLuuThoat.Name = "btnLuuThoat";
            this.btnLuuThoat.Size = new System.Drawing.Size(75, 23);
            this.btnLuuThoat.TabIndex = 5;
            this.btnLuuThoat.Text = "Lưu thoát";
            this.btnLuuThoat.UseVisualStyleBackColor = true;
            // 
            // MatHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 86);
            this.Controls.Add(this.btnLuuThoat);
            this.Controls.Add(this.btnLuuMoi);
            this.Controls.Add(this.txtNAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCODE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mặt hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCODE;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLuuMoi;
        private System.Windows.Forms.Button btnLuuThoat;
    }
}