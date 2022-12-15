using Project.Common;
using Project.DAL;
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

namespace Project
{
    public partial class DanhSachKhachHang : Form
    {
        DKHACHHANGDAL dKHACHHANGDAL = new DKHACHHANGDAL();
        public DanhSachKhachHang()
        {
            InitializeComponent();
            grMain.AutoGenerateColumns = false;
            grMain.SelectionChanged += GrMain_SelectionChanged;
            grMain.MouseDown += GrMain_MouseDown;
            txtLoc.TextChanged += TxtLoc_TextChanged;

            tsbAdd.Click += TsbAdd_Click;
            tsbEdit.Click += TsbEdit_Click;
            tsbDelete.Click += TsbDelete_Click;

            mnuAdd.Click += MnuAdd_Click;
            mnuEdit.Click += MnuEdit_Click;
            mnuDelete.Click += MnuDelete_Click;
            mnuRefresh.Click += MnuRefresh_Click;
        }

        private void GrMain_SelectionChanged(object sender, EventArgs e)
        {
            tsbEdit.Enabled = tsbDelete.Enabled = grMain.SelectedRows != null && grMain.SelectedRows.Count > 0;
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            if (Msg.ShowYesNo(string.Format("Xóa {0} khách đang chọn", grMain.SelectedRows.Count)) == DialogResult.Yes)
            {
                string error = "";
                List<string> ids = new List<string>();
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    ids.Add((r.DataBoundItem as DataRowView).Row["ID"].ToString());
                }
                dKHACHHANGDAL.Delete(ids, out error);
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
        private void TsbEdit_Click(object sender, EventArgs e)
        {
            string DKHACHHANGID = "";
            foreach (DataGridViewRow r in grMain.SelectedRows)
            {
                if (DKHACHHANGID.Length == 0) DKHACHHANGID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
            }

            KhachHangForm editKhachHang = new KhachHangForm(DKHACHHANGID);
            if (editKhachHang.ShowDialog() == DialogResult.OK) LoadData();
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
            grMain.DataSource = dKHACHHANGDAL.Table(loc);
            GrMain_SelectionChanged(null, null);
        }

        private void DanhSachKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
