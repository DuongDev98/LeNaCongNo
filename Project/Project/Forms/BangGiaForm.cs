using Project.Common;
using Project.Model;
using Project.Screens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project.Forms
{
    public partial class BangGiaForm : Form
    {
        string DBANGGIAID;
        public BangGiaForm(string DBANGGIAID)
        {
            InitializeComponent();
            this.DBANGGIAID = DBANGGIAID;
            splitMain.SplitterDistance = 100;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            detail.AutoGenerateColumns = false;

            txtLoc.TextChanged += TxtLoc_TextChanged;
            btnLuu.Click += BtnLuu_Click;
        }

        private void TxtLoc_TextChanged(object sender, EventArgs e)
        {
            if (detail.DataSource != null)
            {
                (detail.DataSource as DataTable).DefaultView.RowFilter = string.Format("DMATHANG_CODE LIKE '%{0}%' OR DMATHANG_NAME LIKE '%{0}%'", txtLoc.Text.Trim());
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            TimeSpan ts = dtDenNgay.Value.Date - dtTuNgay.Value.Date;
            if (ts.TotalDays <= 0)
            {
                Msg.ShowWarning("Từ ngày, đến ngày không hợp lệ");
                return;
            }

            DBANGGIARow bangGiaRow = new DBANGGIARow();
            bangGiaRow.ID = DBANGGIAID;
            bangGiaRow.TuNgay = dtTuNgay.Value.Date;
            bangGiaRow.DenNgay = dtDenNgay.Value.Date;

            DataTable dt = detail.DataSource as DataTable;
            string error;
            if (bangGiaRow.Update(out error))
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@dbanggiaid", bangGiaRow.ID);
                DatabaseSql.ExcuteQuery(@"delete from dbanggiachitiet where dbanggiaid = @dbanggiaid", dic, out error);

                foreach (DataRow row in dt.Rows)
                {
                    string DMATHANGID = row["DMATHANGID"].ToString();
                    int duoi1kg = int.Parse(row["DUOI1KG"].ToString());
                    int tu1kgtrolen = int.Parse(row["TU1KGTROLEN"].ToString());

                    if (duoi1kg > 0 || tu1kgtrolen > 0)
                    {
                        row["ID"] = "";
                        DBANGGIACHITIETRow ctRow = new DBANGGIACHITIETRow(row);
                        ctRow.DBANGGIAID = bangGiaRow.ID;
                        ctRow.Update();
                    }
                }

                Msg.ShowInfo("Lưu thành công bảng giá");
                DBANGGIAID = bangGiaRow.ID;
                Reload();
            }
            else
            {
                Msg.ShowWarning(error);
            }
        }

        private void BangGiaForm_Load(object sender, EventArgs e)
        {
            splitMain.SplitterDistance = 30;
            Reload();
        }
        private void Reload()
        {
            string error;
            //tải thông tin hóa đơn
            DBANGGIARow bangGiaRow;
            if (DBANGGIAID.Length == 0)
            {
                bangGiaRow = new DBANGGIARow();
            }
            else
            {
                bangGiaRow = new DBANGGIARow(DBANGGIAID);
            }

            //fill data
            txtNAME.Text = bangGiaRow.NAME;
            dtTuNgay.Value = bangGiaRow.TuNgay;
            dtDenNgay.Value = bangGiaRow.DenNgay;

            //fill details
            DataTable dtDetails = DanhSachBangGia.GetCreateDetailTable();
            bangGiaRow.details = DanhSachBangGia.LayDuLieuChiTiet(bangGiaRow.ID, out error);
            if (error.Length > 0)
            {
                Msg.ShowWarning(error);
                return;
            }
            foreach (DBANGGIACHITIETRow ctRow in bangGiaRow.details)
            {
                DataRow newRow = dtDetails.NewRow();
                newRow["ID"] = ctRow.ID;
                newRow["DMATHANGID"] = ctRow.DMATHANG.ID;
                newRow["DMATHANG_CODE"] = ctRow.DMATHANG.CODE;
                newRow["DMATHANG_NAME"] = ctRow.DMATHANG.NAME;
                newRow["DUOI1KG"] = ctRow.DUOI1KG;
                newRow["TU1KGTROLEN"] = ctRow.TU1KGTROLEN;
                dtDetails.Rows.Add(newRow);
            }
            detail.DataSource = dtDetails;
            if (txtLoc.Text.Trim().Length > 0) TxtLoc_TextChanged(null, null);
        }
    }
}
