using Project.Common;
using Project.Forms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class DanhSachKhachHang : Form
    {
        public DanhSachKhachHang()
        {
            InitializeComponent();
            grMain.AutoGenerateColumns = false;
            grMain.SelectionChanged += GrMain_SelectionChanged;
            grMain.MouseDown += GrMain_MouseDown;
            grMain.MouseDoubleClick += GrMain_MouseDoubleClick;

            txtLoc.TextChanged += TxtLoc_TextChanged;

            tsbAdd.Click += TsbAdd_Click;
            tsbEdit.Click += TsbEdit_Click;
            tsbDelete.Click += TsbDelete_Click;

            mnuAdd.Click += MnuAdd_Click;
            mnuEdit.Click += MnuEdit_Click;
            mnuDelete.Click += MnuDelete_Click;
            mnuRefresh.Click += MnuRefresh_Click;
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
                if (Msg.ShowYesNo(string.Format("Xóa {0} khách đang chọn", grMain.SelectedRows.Count)) == DialogResult.Yes)
                {
                    string error = "";
                    List<string> ids = new List<string>();
                    foreach (DataGridViewRow r in grMain.SelectedRows)
                    {
                        DKHACHHANGRow khRow = new DKHACHHANGRow((r.DataBoundItem as DataRowView).Row["ID"].ToString());
                        if (!khRow.Delete(out error)) break;
                    }
                    if (error.Length > 0)
                    {
                        Msg.ShowWarning(error);
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }
        private void TsbEdit_Click(object sender, EventArgs e)
        {
            if (grMain.SelectedRows != null && grMain.SelectedRows.Count > 0)
            {
                string DKHACHHANGID = "";
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    if (DKHACHHANGID.Length == 0) DKHACHHANGID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
                }

                KhachHangForm editKhachHang = new KhachHangForm(DKHACHHANGID);
                if (editKhachHang.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void TsbAdd_Click(object sender, EventArgs e)
        {
            KhachHangForm addKhachHang = new KhachHangForm("");
            if (addKhachHang.ShowDialog() == DialogResult.OK) LoadData();
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
            LoadData();
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
            LoadData();
        }

        private void LoadData()
        {
            string loc = txtLoc.Text.Trim();
            grMain.DataSource = Table(loc);
            GrMain_SelectionChanged(null, null);
        }

        private void DanhSachKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public static DataTable Table(string filter)
        {
            string query = "select * from dkhachhang";
            if (filter.Length > 0)
            {
                query += " where code like N'%" + filter + "%' or name like N'%" + filter + "%' or dienthoai like N'%" + filter + "%' or diachi like N'%" + filter + "%'";
            }
            query += " order by name asc";
            DataTable dt = DatabaseSql.GetTable(query, null);
            return dt;
        }

        public static List<DKHACHHANGRow> List(string filter)
        {
            List<DKHACHHANGRow> lst = new List<DKHACHHANGRow>();
            if (filter.Length == 0)
            {
                DKHACHHANGRow khRow = new DKHACHHANGRow();
                lst.Add(khRow);
            }

            DataTable dt = Table(filter);
            foreach (DataRow row in dt.Rows)
            {
                DKHACHHANGRow khRow = new DKHACHHANGRow(row);
                lst.Add(khRow);
            }
            return lst;
        }
    }
}
