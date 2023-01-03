using Project.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Project.Screens
{
    public partial class QuanLyBanHang : Form
    {
        string TDONHANGID = "";
        HoaDonBanHang hoaDonBanHangForm;
        public QuanLyBanHang()
        {
            InitializeComponent();

            splitMain.Panel2.Controls.Clear();
            hoaDonBanHangForm = new HoaDonBanHang("");
            hoaDonBanHangForm.TopLevel = false;
            hoaDonBanHangForm.AutoScroll = true;
            hoaDonBanHangForm.FormBorderStyle = FormBorderStyle.None;
            hoaDonBanHangForm.Dock = DockStyle.Fill;
            hoaDonBanHangForm.Show();
            hoaDonBanHangForm.SplitMain1.SplitterDistance = 320;
            hoaDonBanHangForm.SplitMain2.SplitterDistance = 55;
            hoaDonBanHangForm.DeleteSuccess = new Action(()=>btnLoc.PerformClick());
            AddColumnDetail(hoaDonBanHangForm.Detail);
            splitMain.Panel2.Controls.Add(hoaDonBanHangForm);

            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "NAME";
            cbKhachHang.DropDownStyle = ComboBoxStyle.DropDown;
            cbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKhachHang.Cursor = Cursors.Default;
            cbKhachHang.Click += CbKhachHang_Click;

            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            grHoaDon.AutoGenerateColumns = false;

            grHoaDon.SelectionChanged += GrHoaDon_SelectionChanged;
            btnLoc.Click += BtnLoc_Click;
        }

        private void CbKhachHang_Click(object sender, EventArgs e)
        {
            if (cbKhachHang.Focused) cbKhachHang.DroppedDown = true;
        }

        private void AddColumnDetail(DataGridView detail)
        {
            DataGridViewColumn colDonGia = new DataGridViewColumn();
            colDonGia.HeaderText= "Đơn giá";
            colDonGia.DataPropertyName = "DONGIA";
            colDonGia.CellTemplate = new DataGridViewTextBoxCell();
            colDonGia.ReadOnly = true;
            detail.Columns.Add(colDonGia);
            DataGridViewColumn colThanhTien = new DataGridViewColumn();
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.DataPropertyName = "THANHTIEN";
            colThanhTien.CellTemplate = new DataGridViewTextBoxCell();
            colThanhTien.ReadOnly = true;
            detail.Columns.Add(colThanhTien);
        }

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            string error;
            grHoaDon.DataSource = LayDanhSachDonHang(dtTuNgay.Value.Date, dtDenNgay.Value.Date,
                cbKhachHang.SelectedValue == null ? "" : cbKhachHang.SelectedValue.ToString(),
                out error);

            if (error.Length > 0) Msg.ShowWarning(error);
        }

        private object LayDanhSachDonHang(DateTime fromDate, DateTime toDate, string DKHACHHANGID, out string error)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@tungay", fromDate);
            dic.Add("@denngay", toDate);
            dic.Add("@dkhachhangid", DKHACHHANGID);
            DataTable dt = DatabaseSql.GetTable(@"select tdonhang.*, (select name from dkhachhang where id = dkhachhangid) as dkhachhang_name
            from tdonhang where ngay between @tungay and @denngay
            and (dkhachhangid = @dkhachhangid or cast(@dkhachhangid as varchar(36))='')
            order by tdonhang.ngay, tdonhang.name asc", dic, out error);
            return dt;
        }

        private void GrHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            TDONHANGID = "";
            if (grHoaDon.SelectedRows != null && grHoaDon.SelectedRows.Count > 0)
            {
                TDONHANGID = (grHoaDon.SelectedRows[0].DataBoundItem as DataRowView).Row["ID"].ToString();
            }
            hoaDonBanHangForm.SetData(TDONHANGID);
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            //Tải dữ liệu khách hàng
            cbKhachHang.DataSource = DanhSachKhachHang.List("");
            btnLoc.PerformClick();
            hoaDonBanHangForm.SetData(TDONHANGID);
        }
    }
}
