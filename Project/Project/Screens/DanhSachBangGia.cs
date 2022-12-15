using Project.Common;
using Project.DAL;
using Project.Forms;
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
    public partial class DanhSachBangGia : Form
    {
        DBANGGIADAL dBANGGIADAL = new DBANGGIADAL();
        public DanhSachBangGia()
        {
            InitializeComponent();
            grMain.AutoGenerateColumns = false;
            grMain.SelectionChanged += GrMain_SelectionChanged;
            grMain.MouseDown += GrMain_MouseDown;

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
            if (Msg.ShowYesNo(string.Format("Xóa {0} bảng giá đang chọn", grMain.SelectedRows.Count)) == DialogResult.Yes)
            {
                string error = "";
                List<string> ids = new List<string>();
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    ids.Add((r.DataBoundItem as DataRowView).Row["ID"].ToString());
                }
                dBANGGIADAL.Delete(ids, out error);
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
            string DBANGGIAID = "";
            foreach (DataGridViewRow r in grMain.SelectedRows)
            {
                if (DBANGGIAID.Length == 0) DBANGGIAID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
            }

            BangGiaForm editBangGia = new BangGiaForm(DBANGGIAID);
            if (editBangGia.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void TsbAdd_Click(object sender, EventArgs e)
        {
            BangGiaForm addBangGia = new BangGiaForm("");
            if (addBangGia.ShowDialog() == DialogResult.OK) LoadData();
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

        private void DanhSachBangGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            grMain.DataSource = DBANGGIADAL.LoadData();
            GrMain_SelectionChanged(null, null);
        }
    }
}
