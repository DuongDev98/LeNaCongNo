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
            grMain.MouseDoubleClick += GrMain_MouseDoubleClick;

            tsbAdd.Click += TsbAdd_Click;
            tsbEdit.Click += TsbEdit_Click;
            tsbDelete.Click += TsbDelete_Click;

            mnuAdd.Click += MnuAdd_Click;
            mnuEdit.Click += MnuEdit_Click;
            mnuDelete.Click += MnuDelete_Click;
            mnuRefresh.Click += MnuRefresh_Click;

            btnTinhTien.Click += BtnTinhTien_Click;
        }

        private void BtnTinhTien_Click(object sender, EventArgs e)
        {
            StringBuilder sbError = new StringBuilder();
            DataTable dtHoaDon = Database.GetTable("select * from tdonhang order by ngay asc", null);
            DataTable dtChiTiet = Database.GetTable("select * from tdonhangchitiet", null);
            DataTable dtBangGia = Database.GetTable("select * from dbanggia", null);
            DataTable dtBangGiaChiTiet = Database.GetTable("select * from dbanggiachitiet", null);

            string error = "";
            try
            {
                foreach (DataRow rHoaDon in dtHoaDon.Rows)
                {
                    TDONHANG dhRow = new TDONHANG(rHoaDon, out error);
                    if (error.Length > 0) goto KetThuc;
                    //tìm bảng giá
                    DBANGGIA bangGiaRow = TimBangGia(dtBangGia, dhRow);
                    if (bangGiaRow == null)
                    {
                        error = "Ngày \"" + dhRow.NGAY.ToString("dd/MM/yyyy") + "\" không thuộc bảng giá nào";
                        goto KetThuc;
                    }

                    int TONGCONG = 0;
                    //lấy đơn giá mặt hàng
                    DataRow[] rowChiTiets = dtChiTiet.Select(string.Format("TDONHANGID='{0}'", dhRow.ID));
                    foreach (DataRow rChiTiet in rowChiTiets)
                    {
                        TDONHANGCHITIET ctRow = new TDONHANGCHITIET(rChiTiet, out error);
                        //lấy đơn giá
                        DataRow[] rDonGias = dtBangGiaChiTiet.Select(string.Format("DBANGGIAID='{0}' AND DMATHANGID='{1}'", bangGiaRow.ID, ctRow.DMATHANG.ID));
                        if (rDonGias.Length > 0)
                        {
                            //cập nhật đơn giá chi tiết
                            string fieldDonGia = "DUOI1KG";
                            if (ctRow.SOLUONG >= 1) fieldDonGia = "TU1KGTROLEN";
                            ctRow.DONGIA = int.Parse(rDonGias[0][fieldDonGia].ToString());
                            ctRow.THANHTIEN = (int)(ctRow.DONGIA * ctRow.SOLUONG);
                            ctRow.Update();
                            TONGCONG += ctRow.THANHTIEN;
                        }
                        else
                        {
                            sbError.AppendLine("Mặt hàng có mã: \"" + ctRow.DMATHANG.CODE + "\" từ ngày \"" + bangGiaRow.TuNgay.ToString("dd/MM/yyyy")
                                + "\" đến \"" + bangGiaRow.DenNgay.ToString("dd/MM/yyyy") + "\" có đơn giá = 0");
                        }
                    }
                    dhRow.TONGCONG = TONGCONG;
                    dhRow.Update();
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            KetThuc:
            if (error.Length > 0)
            {
                Msg.ShowWarning(error);
                return;
            }

            if (sbError.ToString().Length > 0)
            {
                Msg.ShowWarning(sbError.ToString());
                return;
            }

            Msg.ShowInfo("Cập nhật tiền hóa đơn theo bảng giá thành công");
        }
        private DBANGGIA TimBangGia(DataTable dtBangGia, TDONHANG dhRow)
        {
            DBANGGIA bangGiaRow = null;
            foreach (DataRow rBangGia in dtBangGia.Rows)
            {
                DBANGGIA tmp = new DBANGGIA(rBangGia);
                if (dhRow.NGAY >= tmp.TuNgay || dhRow.NGAY <= tmp.DenNgay)
                {
                    bangGiaRow = tmp;
                    break;
                }
            }
            return bangGiaRow;
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
        }
        private void TsbEdit_Click(object sender, EventArgs e)
        {
            if (grMain.SelectedRows != null && grMain.SelectedRows.Count > 0)
            {
                string DBANGGIAID = "";
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    if (DBANGGIAID.Length == 0) DBANGGIAID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
                }

                BangGiaForm editBangGia = new BangGiaForm(DBANGGIAID);
                if (editBangGia.ShowDialog() == DialogResult.OK) LoadData();
            }
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
