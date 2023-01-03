using Project.Common;
using Project.Forms;
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
    public partial class QuanLyThanhToan : Form
    {
        public QuanLyThanhToan()
        {
            InitializeComponent();

            grMain.AutoGenerateColumns = false;
            grMain.SelectionChanged += GrMain_SelectionChanged;
            grMain.MouseDown += GrMain_MouseDown;
            grMain.MouseDoubleClick += GrMain_MouseDoubleClick;

            tsbAdd.Click += TsbAdd_Click;
            tsbEdit.Click += TsbEdit_Click;
            tsbDelete.Click += TsbDelete_Click;

            mnuAdd.Click += MnuAdd_Click;
            mnuEdit.Click += MnuEdit_Click;
            mnuDelete.Click += MnuDelete_Click;
            mnuRefresh.Click += MnuRefresh_Click;

            cbKhachHang.SelectedIndexChanged += CbKhachHang_SelectedIndexChanged;
        }

        private void CbKhachHang_SelectedValueChanged(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void CbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void GrMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsbEdit.PerformClick();
        }

        private void GrMain_SelectionChanged(object sender, EventArgs e)
        {
            tsbEdit.Enabled = tsbDelete.Enabled = grMain.SelectedRows != null && grMain.SelectedRows.Count > 0;
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            if (grMain.SelectedRows != null && grMain.SelectedRows.Count > 0)
            {
                if (Msg.ShowYesNo(string.Format("Xóa {0} phiếu thanh toán đang chọn", grMain.SelectedRows.Count)) == DialogResult.Yes)
                {
                    string error = "";
                    List<string> ids = new List<string>();
                    foreach (DataGridViewRow r in grMain.SelectedRows)
                    {
                        TTHANHTOANRow mhRow = new TTHANHTOANRow((r.DataBoundItem as DataRowView).Row["ID"].ToString());
                        if (!mhRow.Delete(out error)) break;
                    }

                    if (error.Length > 0)
                    {
                        Msg.ShowWarning(error);
                    }
                    else
                    {
                        TaiDuLieu();
                    }
                }
            }
        }
        private void TsbEdit_Click(object sender, EventArgs e)
        {
            if (grMain.SelectedRows != null && grMain.SelectedRows.Count > 0)
            {
                string TTHANHTOANID = "";
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    if (TTHANHTOANID.Length == 0) TTHANHTOANID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
                }

                ThanhToanForm addThanhToan = new ThanhToanForm(TTHANHTOANID);
                if (addThanhToan.ShowDialog() == DialogResult.OK) TaiDuLieu();
            }
        }

        private void TsbAdd_Click(object sender, EventArgs e)
        {
            ThanhToanForm editThanhToan = new ThanhToanForm("");
            if (editThanhToan.ShowDialog() == DialogResult.OK) TaiDuLieu();
        }

        private void GrMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (ToolStripItem mnuItem in contextMenu.Items)
                {
                    if (mnuItem.Text == "Chỉnh sửa" || mnuItem.Text == "Xóa")
                    {
                        mnuItem.Enabled = grMain.SelectedRows != null && grMain.SelectedRows.Count > 0;
                    }
                }
                contextMenu.Show(grMain, e.X, e.Y);
            }
        }

        private void MnuRefresh_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            tsbDelete.PerformClick();
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            tsbEdit.PerformClick();
        }

        private void MnuAdd_Click(object sender, EventArgs e)
        {
            tsbAdd.PerformClick();
        }

        private void TxtLoc_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void QuanLyThanhToan_Load(object sender, EventArgs e)
        {
            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "NAME";
            cbKhachHang.DropDownStyle = ComboBoxStyle.DropDown;
            cbKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbKhachHang.Cursor = Cursors.Default;
            cbKhachHang.DataSource = DanhSachKhachHang.List("");
            cbKhachHang.Click += CbKhachHang_Click;
            TaiDuLieu();
        }

        private void CbKhachHang_Click(object sender, EventArgs e)
        {
            if (cbKhachHang.Focused) cbKhachHang.DroppedDown = true;
        }

        private void TaiDuLieu()
        {
            string DKHACHHANGID = "";
            if (cbKhachHang.SelectedItem != null)
            {
                DKHACHHANGID = (cbKhachHang.SelectedItem as DKHACHHANGRow).ID;
            }
            grMain.DataSource = LoadData("", DKHACHHANGID);
            GrMain_SelectionChanged(null, null);
        }

        public static DataTable LoadData(string filter, string DKHACHHANGID)
        {
            string query = @"select tthanhtoan.*, (select name from dkhachhang where id = dkhachhangid) as dkhachhang_name
            from tthanhtoan where (dkhachhangid = @dkhachhangid or cast(@dkhachhangid as varchar(36))='')";
            if (filter.Length > 0)
            {
                query += " and name like N'%" + filter + "%'";
            }
            query += " order by name asc";
            Dictionary<string, object> attrs = new Dictionary<string, object>();
            attrs.Add("@dkhachhangid", DKHACHHANGID);
            DataTable dt = DatabaseSql.GetTable(query, attrs);
            return dt;
        }
    }
}
