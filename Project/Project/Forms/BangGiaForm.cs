using Project.Common;
using Project.DAL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms
{
    public partial class BangGiaForm : Form
    {
        DBANGGIADAL dBANGGIADAL;
        DMATHANGDAL dMATHANGDAL;
        string DBANGGIAID;
        public BangGiaForm(string DBANGGIAID)
        {
            InitializeComponent();
            this.DBANGGIAID = DBANGGIAID;

            dBANGGIADAL = new DBANGGIADAL();
            dMATHANGDAL = new DMATHANGDAL();

            splitMain.SplitterDistance = 100;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            detail.AutoGenerateColumns = false;

            btnLuu.Click += BtnLuu_Click;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            TimeSpan ts = dtDenNgay.Value.Date - dtTuNgay.Value.Date;
            if (ts.TotalDays <= 0)
            {
                Msg.ShowWarning("Từ ngày, đến ngày không hợp lệ");
                return;
            }

            DBANGGIA bangGiaRow = new DBANGGIA();
            bangGiaRow.ID = DBANGGIAID;
            bangGiaRow.TuNgay = dtTuNgay.Value.Date;
            bangGiaRow.DenNgay = dtDenNgay.Value.Date;

            DataTable dt = detail.DataSource as DataTable;

            //StringBuilder sb = new StringBuilder("");
            //foreach (DataRow row in dt.Rows)
            //{
            //    string DMATHANG_CODE = row["DMATHANG_CODE"].ToString();
            //    string DMATHANG_NAME = row["DMATHANG_NAME"].ToString();

            //    string line = "";
            //    int tmp = int.Parse(row["DUOI1KG"].ToString());
            //    if (tmp == 0) line += "dưới 1kg = 0";
            //    if (line.Length > 0) line += ", ";
            //    tmp = int.Parse(row["TU1KGTROLEN"].ToString());
            //    if (tmp == 0) line += "từ 1kg trở lên = 0";

            //    if (line.Length > 0)
            //    {
            //        sb.AppendLine(Environment.NewLine + "Mặt hàng có mã: " + DMATHANG_CODE + " " + line);
            //    }
            //}

            //if (sb.Length > 0)
            //{
            //    Msg.ShowWarning(sb.ToString().Trim());
            //}

            string error;
            List<DBANGGIACHITIET> details = new List<DBANGGIACHITIET>();
            foreach (DataRow row in dt.Rows)
            {
                string DMATHANGID = row["DMATHANGID"].ToString();
                int duoi1kg = int.Parse(row["DUOI1KG"].ToString());
                int tu1kgtrolen = int.Parse(row["TU1KGTROLEN"].ToString());

                if (duoi1kg > 0 || tu1kgtrolen > 0)
                {
                    DBANGGIACHITIET ctRow = new DBANGGIACHITIET();
                    ctRow.DMATHANG = dMATHANGDAL.Find(DMATHANGID, out error);
                    ctRow.DUOI1KG = duoi1kg;
                    ctRow.TU1KGTROLEN = tu1kgtrolen;
                    if (error.Length == 0) details.Add(ctRow);
                }
            }
            bangGiaRow.details = details;

            if (dBANGGIADAL.InserOrEdit(bangGiaRow, out error))
            {

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
            DBANGGIA bangGiaRow;
            if (DBANGGIAID.Length == 0)
            {
                bangGiaRow = new DBANGGIA();
            }
            else
            {
                bangGiaRow = dBANGGIADAL.Find(DBANGGIAID, out error);
                if (error.Length > 0)
                {
                    Msg.ShowWarning(error);
                    return;
                }
            }

            //fill data
            txtNAME.Text = bangGiaRow.NAME;
            dtTuNgay.Value = bangGiaRow.TuNgay;
            dtDenNgay.Value = bangGiaRow.DenNgay;

            //fill details
            DataTable dtDetails = DBANGGIADAL.GetCreateDetailTable();
            bangGiaRow.details = DBANGGIADAL.LayDuLieuChiTiet(bangGiaRow.ID, out error);
            if (error.Length > 0)
            {
                Msg.ShowWarning(error);
                return;
            }
            foreach (DBANGGIACHITIET ctRow in bangGiaRow.details)
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
        }
    }
}
