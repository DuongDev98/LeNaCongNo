using Project.Common;
using Project.Forms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Windows.Forms;

namespace Project
{
    public partial class DanhSachMatHang : Form
    {
        public DanhSachMatHang()
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
                if (Msg.ShowYesNo(string.Format("Xóa {0} mặt hàng đang chọn", grMain.SelectedRows.Count)) == DialogResult.Yes)
                {
                    string error = "";
                    List<string> ids = new List<string>();
                    foreach (DataGridViewRow r in grMain.SelectedRows)
                    {
                        DMATHANGRow mhRow = new DMATHANGRow((r.DataBoundItem as DataRowView).Row["ID"].ToString());
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
                string DMATHANGID = "";
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    if (DMATHANGID.Length == 0) DMATHANGID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
                }

                MatHangForm addMatHang = new MatHangForm(DMATHANGID);
                if (addMatHang.ShowDialog() == DialogResult.OK) TaiDuLieu();
            }
        }

        private void TsbAdd_Click(object sender, EventArgs e)
        {
            MatHangForm addMatHang = new MatHangForm("");
            if (addMatHang.ShowDialog() == DialogResult.OK) TaiDuLieu();
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

        private void DanhSachMatHang_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            grMain.DataSource = LoadData(txtLoc.Text.Trim());
            GrMain_SelectionChanged(null, null);
        }

        public static DataTable LoadData(string filter)
        {
            string query = "select * from dmathang";
            query += " order by code asc";
            DataTable dt = DatabaseSql.GetTable(query, null);
            if (filter.Length > 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows[i];
                    string code = row["code"].ToString();
                    string name = row["name"].ToString();

                    bool remove = true;
                    if (RemoveUnicode(code).ToLower().Contains(RemoveUnicode(filter).ToLower())) remove = false;
                    else if (RemoveUnicode(name).ToLower().Contains(RemoveUnicode(filter).ToLower())) remove = false;

                    if (remove) dt.Rows.RemoveAt(i);
                }
            }
            return dt;
        }

        private static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
    }
}
