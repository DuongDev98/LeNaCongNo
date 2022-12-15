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
    public partial class KhachHangForm : Form
    {
        DKHACHHANGDAL DKHACHHANGDAL = new DKHACHHANGDAL();
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

            DKHACHHANG khRow = new DKHACHHANG();
            khRow.ID = ID;
            khRow.CODE = CODE;
            khRow.NAME = NAME;
            khRow.DIENTHOAI = DIENTHOAI;
            khRow.DIACHI = DIACHI;

            string error;
            bool kq = DKHACHHANGDAL.InserOrEdit(khRow, out error);
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
            DKHACHHANG khRow;
            if (ID.Length == 0)
            {
                Text = "Thêm mới";
                khRow = new DKHACHHANG();
            }
            else
            {
                Text = "Chỉnh sửa";
                string error = "";
                khRow = DKHACHHANGDAL.Find(ID, out error);
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
