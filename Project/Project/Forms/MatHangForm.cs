using Project.Common;
using Project.DAL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms
{
    public partial class MatHangForm : Form
    {
        DMATHANGDAL dMATHANGDAL = new DMATHANGDAL();
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

            DMATHANG mhRow = new DMATHANG();
            mhRow.ID = ID;
            mhRow.CODE = CODE;
            mhRow.NAME = NAME;

            string error;
            bool kq = dMATHANGDAL.InserOrEdit(mhRow, out error);
            if (error.Length > 0)
            {
                ID = "";
                Msg.ShowWarning(error);
            }

            return kq;
        }

        private void Reload(string ID)
        {
            DMATHANG mhRow;
            if (ID.Length == 0)
            {
                Text = "Thêm mới";
                mhRow = new DMATHANG();
            }
            else
            {
                Text = "Chỉnh sửa";
                string error = "";
                mhRow = dMATHANGDAL.Find(ID, out error);
            }

            this.ID = mhRow.ID;
            txtCODE.Text = mhRow.CODE;
            txtNAME.Text = mhRow.NAME;
            txtNAME.Focus();
        }
    }
}
