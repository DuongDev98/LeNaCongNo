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

namespace Project.Screens
{
    public partial class QuanLyBanHang : Form
    {
        string TDONHANGID = "";
        DKHACHHANGDAL dKHACHHANGDAL;
        HoaDonBanHang hoaDonBanHangForm;
        public QuanLyBanHang()
        {
            InitializeComponent();

            dKHACHHANGDAL = new DKHACHHANGDAL();

            splitMain.Panel2.Controls.Clear();
            hoaDonBanHangForm = new HoaDonBanHang("");
            hoaDonBanHangForm.TopLevel = false;
            hoaDonBanHangForm.AutoScroll = true;
            hoaDonBanHangForm.FormBorderStyle = FormBorderStyle.None;
            hoaDonBanHangForm.Dock = DockStyle.Fill;
            hoaDonBanHangForm.Show();
            (hoaDonBanHangForm.Controls[0] as SplitContainer).SplitterDistance = 320;
            ((hoaDonBanHangForm.Controls[0] as SplitContainer).Panel2.Controls[0] as SplitContainer).SplitterDistance = 55;
            splitMain.Panel2.Controls.Add(hoaDonBanHangForm);

            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "NAME";
            cbKhachHang.DropDownStyle = ComboBoxStyle.DropDown;
            cbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKhachHang.Cursor = Cursors.Default;

            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            grHoaDon.AutoGenerateColumns = false;

            grHoaDon.SelectionChanged += GrHoaDon_SelectionChanged;

            btnLoc.Click += BtnLoc_Click;
        }

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            string error;
            grHoaDon.DataSource = TDONHANGDAL.Table(dtTuNgay.Value.Date, dtDenNgay.Value.Date,
                cbKhachHang.SelectedValue == null ? "" : cbKhachHang.SelectedValue.ToString(),
                out error);

            if (error.Length > 0) Msg.ShowWarning(error);
        }

        private void GrHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (grHoaDon.SelectedRows != null && grHoaDon.SelectedRows.Count > 0)
            {
                TDONHANGID = (grHoaDon.SelectedRows[0].DataBoundItem as DataRowView).Row["ID"].ToString();
            }
            hoaDonBanHangForm.SetData(TDONHANGID);
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            //Tải dữ liệu khách hàng
            cbKhachHang.DataSource = dKHACHHANGDAL.List("");
            btnLoc.PerformClick();
            hoaDonBanHangForm.SetData(TDONHANGID);
        }
    }
}
