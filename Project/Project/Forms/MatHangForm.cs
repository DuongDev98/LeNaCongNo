using Project.Common;
using Project.Model;
using System;
using System.Windows.Forms;

namespace Project.Forms
{
    public partial class MatHangForm : Form
    {
        string ID;
        public MatHangForm(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            Reload(this.ID);

            txtNAME.KeyDown += InputText_KeyDown;
            btnLuuMoi.Click += BtnLuuMoi_Click;
            btnLuuThoat.Click += BtnLuuThoat_Click;
        }

        private void InputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLuuThoat.PerformClick();
            }
        }

        private void BtnLuuThoat_Click(object sender, EventArgs e)
        {
            LuuDuLieu(true);
        }

        private void BtnLuuMoi_Click(object sender, EventArgs e)
        {
            LuuDuLieu(false);
        }

        private void LuuDuLieu(bool thoat)
        {
            if (SaveData())
            {
                if (!thoat)
                {
                    Reload("");
                }
                if (thoat) DialogResult = DialogResult.OK;
            }
        }
        private bool SaveData()
        {
            string CODE = txtCODE.Text.Trim();
            string NAME = txtNAME.Text.Trim();

            if (NAME.Length == 0)
            {
                Msg.ShowWarning("Tên mặt hàng không được trống");
                return false;
            }

            DMATHANGRow mhRow = new DMATHANGRow("");
            mhRow.ID = ID;
            mhRow.CODE = CODE;
            mhRow.NAME = NAME;

            string error;
            if (mhRow.Update(out error))
            {
                ID = "";
                return true;
            }
            else
            {
                Msg.ShowWarning(error);
                return false;
            }
        }

        private void Reload(string ID)
        {
            DMATHANGRow mhRow;
            if (ID.Length == 0)
            {
                Text = "Thêm mới";
                mhRow = new DMATHANGRow("");
            }
            else
            {
                Text = "Chỉnh sửa";
                mhRow = new DMATHANGRow(ID);
            }

            this.ID = mhRow.ID;
            txtCODE.Text = mhRow.CODE;
            txtNAME.Text = mhRow.NAME;
            txtNAME.Focus();
        }
    }
}
