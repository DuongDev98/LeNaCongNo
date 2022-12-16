using Project.Common;
using Project.DAL;
using Project.Forms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project
{
    public partial class HoaDonBanHang : Form
    {
        TDONHANGDAL tDONHANGDAL;
        DKHACHHANGDAL dKHACHHANGDAL;
        DMATHANGDAL dMATHANGDAL;
        string TDONHANGID = "";

        public void SetData(string TDONHANGID)
        {
            this.TDONHANGID = TDONHANGID;
            Enabled = this.TDONHANGID.Length > 0;
            Reload();
        }

        public HoaDonBanHang(string TDONHANGID)
        {
            InitializeComponent();
            this.TDONHANGID = TDONHANGID;

            tDONHANGDAL = new TDONHANGDAL();
            dKHACHHANGDAL = new DKHACHHANGDAL();
            dMATHANGDAL = new DMATHANGDAL();

            splitMain2.SplitterDistance = 100;
            btnHuy.Enabled = TDONHANGID.Length > 0;
            dtNgay.CustomFormat = "dd/MM/yyyy";
            grMatHang.AutoGenerateColumns = false;
            detail.AutoGenerateColumns = false;

            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "NAME";
            cbKhachHang.DropDownStyle = ComboBoxStyle.DropDown;
            cbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKhachHang.Cursor = Cursors.Default;
        }

        private void HoaDonBanHang_Load(object sender, EventArgs e)
        {
            splitMain2.SplitterDistance = 85;
            LoadDanhSachMatHang();
            cbKhachHang.DataSource = dKHACHHANGDAL.List("");
            Reload();
            detail_SelectionChanged(null, null);
        }
        private void Reload()
        {
            //tải thông tin hóa đơn
            TDONHANG dhRow;
            if (TDONHANGID.Length == 0)
            {
                dhRow = new TDONHANG();
            }
            else
            {
                string error = "";
                dhRow = tDONHANGDAL.Find(TDONHANGID, out error);
                if (error.Length > 0)
                {
                    Msg.ShowWarning(error);
                    return;
                }
            }

            //fill data
            dtNgay.Value = dhRow.NGAY;
            txtNAME.Text = dhRow.NAME;
            cbKhachHang.SelectedValue = dhRow.DKHACHHANG.ID;
            txtNOTE.Text = dhRow.NOTE;

            //fill details
            DataTable dtDetails = TDONHANGDAL.GetCreateDetailTable();
            foreach (TDONHANGCHITIET ctRow in dhRow.details)
            {
                DataRow newRow = dtDetails.NewRow();
                newRow["ID"] = ctRow.ID;
                newRow["DMATHANGID"] = ctRow.DMATHANG.ID;
                newRow["DMATHANG_CODE"] = ctRow.DMATHANG.CODE;
                newRow["DMATHANG_NAME"] = ctRow.DMATHANG.NAME;
                newRow["DONGIA"] = ctRow.DONGIA;
                newRow["SOLUONG"] = ctRow.SOLUONG;
                newRow["THANHTIEN"] = ctRow.THANHTIEN;
                dtDetails.Rows.Add(newRow);
            }
            detail.DataSource = dtDetails;

            cbKhachHang.Focus();
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachMatHang();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDanhSachMatHang();
        }

        private void LoadDanhSachMatHang()
        {
            grMatHang.DataSource = DMATHANGDAL.LoadData(txtLoc.Text.Trim());
        }

        private void grMatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grMatHang.SelectedRows == null || grMatHang.SelectedRows.Count == 0) return;
            DataRow row = (grMatHang.SelectedRows[0].DataBoundItem as DataRowView).Row;
            string DMATHANGID = row["ID"].ToString();
            string CODE = row["CODE"].ToString();
            string NAME = row["NAME"].ToString();
            //kiểm tra xem có mặt hàng chưa? chưa có thì thêm, có rồi thì cộng số lượng
            DataTable dt = detail.DataSource as DataTable;
            DataRow[] rows = dt.Select(string.Format("DMATHANGID='{0}'", DMATHANGID));
            if (rows.Length > 0)
            {
                //cộng số lượng
                dt.Rows[dt.Rows.IndexOf(rows[0])]["SOLUONG"] = int.Parse(dt.Rows[dt.Rows.IndexOf(rows[0])]["SOLUONG"].ToString()) + 1;
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["ID"] = "";
                newRow["DMATHANGID"] = DMATHANGID;
                newRow["DMATHANG_CODE"] = CODE;
                newRow["DMATHANG_NAME"] = NAME;
                newRow["DONGIA"] = 0;
                newRow["SOLUONG"] = 1;
                newRow["THANHTIEN"] = 0;
                dt.Rows.Add(newRow);
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            DataRow row = (detail.SelectedRows[0].DataBoundItem as DataRowView).Row;
            int soLuong = int.Parse(row["SOLUONG"].ToString()) + 1;
            row["SOLUONG"] = soLuong;
        }
        private void btnGiam_Click(object sender, EventArgs e)
        {
            DataRow row = (detail.SelectedRows[0].DataBoundItem as DataRowView).Row;
            int soLuong = int.Parse(row["SOLUONG"].ToString());
            if (soLuong > 1)
            {
                soLuong = int.Parse(row["SOLUONG"].ToString()) - 1;
                row["SOLUONG"] = soLuong;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection cols = detail.SelectedRows;
            DataTable dt = detail.DataSource as DataTable;
            for (int i = cols.Count - 1; i >= 0; i--)
            {
                dt.Rows.RemoveAt(dt.Rows.IndexOf((cols[i].DataBoundItem as DataRowView).Row));
            }
        }

        private void btnDatSL_Click(object sender, EventArgs e)
        {
            NhapSoLuong f = new NhapSoLuong();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.Value > 0)
                {
                    DataRow row = (detail.SelectedRows[0].DataBoundItem as DataRowView).Row;
                    row["SOLUONG"] = f.Value;
                }
            }
        }

        private void detail_SelectionChanged(object sender, EventArgs e)
        {
            btnTang.Enabled = btnGiam.Enabled = btnXoa.Enabled = btnDatSL.Enabled = detail.SelectedRows != null && detail.SelectedRows.Count > 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Đơn hàng phải chọn khách hàng
            DKHACHHANG khRow = cbKhachHang.SelectedItem as DKHACHHANG;
            if (khRow == null || khRow.ID.Length == 0)
            {
                Msg.ShowWarning("Khách hàng không được trống");
                return;
            }
            //Đơn phải có mặt hàng
            DataTable dtChiTiet = detail.DataSource as DataTable;
            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
            {
                Msg.ShowWarning("Chi tiết đơn hàng không được trống");
                return;
            }

            //Lưu dữ liệu
            TDONHANG dhRow = new TDONHANG();
            dhRow.ID = TDONHANGID;
            dhRow.NGAY = dtNgay.Value.Date;
            dhRow.NAME = dhRow.NAME;
            dhRow.DKHACHHANG = khRow;
            dhRow.NOTE = txtNOTE.Text.Trim();

            //Lấy dữ liệu chi tiết
            string error;
            List<TDONHANGCHITIET> lst = new List<TDONHANGCHITIET>();
            foreach (DataRow row in dtChiTiet.Rows)
            {
                string DMATHANGID = row["DMATHANGID"].ToString();
                TDONHANGCHITIET ctRow = new TDONHANGCHITIET();
                ctRow.DMATHANG = dMATHANGDAL.Find(DMATHANGID, out error);
                if (error.Length > 0)
                {
                    Msg.ShowWarning(error);
                    return;
                }
                ctRow.SOLUONG = int.Parse(row["SOLUONG"].ToString());
                ctRow.DONGIA = int.Parse(row["DONGIA"].ToString());
                ctRow.THANHTIEN = ctRow.SOLUONG * ctRow.DONGIA;
                lst.Add(ctRow);
            }
            dhRow.details = lst;

            if (tDONHANGDAL.InserOrEdit(dhRow, out error))
            {
                //mở hóa đơn mới nếu không phải quản lý bán hàng
                if (TDONHANGID.Length == 0)
                {
                    Msg.ShowInfo("Lưu hóa đơn thành công");
                    Reload();
                }
            }
            else
            {
                Msg.ShowWarning(error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (Msg.ShowYesNo("Bạn có muốn hủy hóa đơn đang chọn") == DialogResult.Yes)
            {
                string error;
                tDONHANGDAL.Delete(new string[] { TDONHANGID }, out error);
                if (error.Length > 0)
                {
                    Msg.ShowWarning(error);
                }
                else
                {
                    //hủy thành công thì chọn sang hóa đơn đầu tiên
                }
            }
        }

        private void btnKhachMoi_Click(object sender, EventArgs e)
        {
            //tạo khách mới
            KhachHangForm khForm = new KhachHangForm("", true);
            if (khForm.ShowDialog() == DialogResult.OK)
            {
                cbKhachHang.DataSource = dKHACHHANGDAL.List("");
                cbKhachHang.SelectedValue = khForm.Tag;
            }
        }
    }
}