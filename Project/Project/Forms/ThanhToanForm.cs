using Project.Common;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.Forms
{
    public partial class ThanhToanForm : Form
    {
        string ID;
        public ThanhToanForm(string TTHANHTOANID)
        {
            InitializeComponent();
            this.ID = TTHANHTOANID;

            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "NAME";
            cbKhachHang.DropDownStyle = ComboBoxStyle.DropDown;
            cbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKhachHang.Cursor = Cursors.Default;
            cbKhachHang.Click += CbKhachHang_Click;

            numTONGCONG.KeyPress += NumTONGCONG_KeyPress;
            btnLuuMoi.Click += BtnLuuMoi_Click;
            btnLuuThoat.Click += BtnLuuThoat_Click;
        }

        private void CbKhachHang_Click(object sender, EventArgs e)
        {
            if (cbKhachHang.Focused) cbKhachHang.DroppedDown = true;
        }

        private void NumTONGCONG_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

            if (cbKhachHang.SelectedValue == null || cbKhachHang.SelectedValue.ToString().Length == 0)
            {
                Msg.ShowWarning("Khách hàng không được trống");
                return false;
            }

            if (int.Parse(numTONGCONG.Text.Trim()) <= 0)
            {
                Msg.ShowWarning("Số tiền thanh toán phải lớn hơn 0");
                return false;
            }

            TTHANHTOANRow ttRow = new TTHANHTOANRow("");
            ttRow.ID = ID;
            ttRow.NGAY = dtNgay.Value.Date;
            ttRow.TONGCONG = int.Parse(numTONGCONG.Text.Trim());
            ttRow.DKHACHHANG = cbKhachHang.SelectedItem as DKHACHHANGRow;
            ttRow.NOTE = txtNOTE.Text.Trim();

            string error;
            if (ttRow.Update(out error))
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
            TTHANHTOANRow ttRow;
            if (ID.Length == 0)
            {
                Text = "Thêm mới";
                ttRow = new TTHANHTOANRow("");
            }
            else
            {
                Text = "Chỉnh sửa";
                ttRow = new TTHANHTOANRow(ID);
            }

            this.ID = ttRow.ID;
            dtNgay.Value = ttRow.NGAY;
            txtNAME.Text = ttRow.NAME;
            cbKhachHang.SelectedValue = ttRow.DKHACHHANG.ID;
            numTONGCONG.Text = ttRow.TONGCONG.ToString();
            txtNOTE.Text = ttRow.NOTE;
            cbKhachHang.Focus();
        }

        private void ThanhToanForm_Load(object sender, EventArgs e)
        {
            cbKhachHang.DataSource = DanhSachKhachHang.List("");
            Reload(this.ID);
        }
    }
}
