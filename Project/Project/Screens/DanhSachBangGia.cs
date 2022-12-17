using Project.Common;
using Project.Forms;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Project.Screens
{
    public partial class DanhSachBangGia : Form
    {
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
                    TDONHANGRow dhRow = new TDONHANGRow(rHoaDon);
                    if (error.Length > 0) goto KetThuc;
                    //tìm bảng giá
                    DBANGGIARow bangGiaRow = TimBangGia(dtBangGia, dhRow);
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
                        TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(rChiTiet);
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
        private DBANGGIARow TimBangGia(DataTable dtBangGia, TDONHANGRow dhRow)
        {
            DBANGGIARow bangGiaRow = null;
            foreach (DataRow rBangGia in dtBangGia.Rows)
            {
                DBANGGIARow tmp = new DBANGGIARow(rBangGia);
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
                    foreach (DataGridViewRow r in grMain.SelectedRows)
                    {
                        DBANGGIARow bangGiaRow = new DBANGGIARow((r.DataBoundItem as DataRowView).Row["ID"].ToString());
                        if (!bangGiaRow.Delete(out error)) break;
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
                string DBANGGIAID = "";
                foreach (DataGridViewRow r in grMain.SelectedRows)
                {
                    if (DBANGGIAID.Length == 0) DBANGGIAID = (r.DataBoundItem as DataRowView).Row["ID"].ToString();
                }

                BangGiaForm editBangGia = new BangGiaForm(DBANGGIAID);
                if (editBangGia.ShowDialog() == DialogResult.OK) TaiDuLieu();
            }
        }

        private void TsbAdd_Click(object sender, EventArgs e)
        {
            BangGiaForm addBangGia = new BangGiaForm("");
            if (addBangGia.ShowDialog() == DialogResult.OK) TaiDuLieu();
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

        private void DanhSachBangGia_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            grMain.DataSource = LoadData();
            GrMain_SelectionChanged(null, null);
        }

        public static DataTable GetCreateDetailTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("DBANGGIAID", typeof(string));
            dt.Columns.Add("DMATHANGID", typeof(string));
            dt.Columns.Add("DMATHANG_CODE", typeof(string));
            dt.Columns.Add("DMATHANG_NAME", typeof(string));
            dt.Columns.Add("DUOI1KG", typeof(int));
            dt.Columns.Add("TU1KGTROLEN", typeof(int));
            return dt;
        }
        public static DataTable LoadData()
        {
            string query = "select * from dbanggia order by name asc";
            DataTable dt = Database.GetTable(query, null);
            return dt;
        }
        public static List<DBANGGIACHITIETRow> LayDuLieuChiTiet(string DBANGGIAID, out string error)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", DBANGGIAID }
            };

            DataTable dtChiTiet = Database.GetTable(@"select dbanggiachitiet.id, dmathang.id as dmathangid, dbanggiaid,
            dmathang.code as dmathang_code, dmathang.name as dmathang_name, coalesce(duoi1kg, 0) as duoi1kg,
            coalesce(tu1kgtrolen, 0) as tu1kgtrolen
            from dmathang left outer join dbanggiachitiet on dmathangid = dmathang.id and dbanggiaid = @id
            order by dmathang.name", dic, out error);

            List<DBANGGIACHITIETRow> details = new List<DBANGGIACHITIETRow>();
            foreach (DataRow rChiTiet in dtChiTiet.Rows)
            {
                DBANGGIACHITIETRow ctRow = new DBANGGIACHITIETRow(rChiTiet);
                if (error.Length == 0)
                {
                    details.Add(ctRow);
                }
            }

            return details;
        }
    }
}
