using Project.Common;
using Project.Model;
using System;
using System.Windows.Forms;

namespace Project.Forms
{
    public partial class KhachHangForm : Form
    {
        string ID;
        public KhachHangForm(string ID, bool hoaDonBanHang = false)
        {
            InitializeComponent();
            this.ID = ID;
            Reload(this.ID);

            btnLuuMoi.Visible = !hoaDonBanHang;

            txtNAME.KeyDown += InputText_KeyDown;
            txtDIENTHOAI.KeyDown += InputText_KeyDown;
            txtDIACHI.KeyDown += InputText_KeyDown;

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
            string DIENTHOAI = txtDIENTHOAI.Text.Trim();
            string DIACHI = txtDIACHI.Text.Trim();

            if (CODE.Length == 0)
            {
                Msg.ShowWarning("Mã khách hàng không được trống");
                return false;
            }

            if (NAME.Length == 0)
            {
                Msg.ShowWarning("Tên khách hàng không được trống");
                return false;
            }

            DKHACHHANGRow khRow = new DKHACHHANGRow();
            khRow.ID = ID;
            khRow.CODE = CODE;
            khRow.NAME = NAME;
            khRow.DIENTHOAI = DIENTHOAI;
            khRow.DIACHI = DIACHI;

            string error;
            bool kq = khRow.Update(out error);
            if (error.Length > 0)
            {
                ID = "";
                Msg.ShowWarning(error);
            }
            else
            {
                Tag = khRow.ID;
            }
            return kq;
        }

        private void Reload(string ID)
        {
            DKHACHHANGRow khRow;
            if (ID.Length == 0)
            {
                Text = "Thêm mới";
                khRow = new DKHACHHANGRow();
            }
            else
            {
                Text = "Chỉnh sửa";
                string error = "";
                khRow = new DKHACHHANGRow(ID);
            }

            this.ID = khRow.ID;
            txtCODE.Text = khRow.CODE;
            txtNAME.Text = khRow.NAME;
            txtNAME.Focus();
            txtDIENTHOAI.Text = khRow.DIENTHOAI;
            txtDIACHI.Text = khRow.DIACHI;
        }
    }
}
