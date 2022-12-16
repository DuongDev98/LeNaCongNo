using Project.Common;
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
    public partial class TongHopCongNo : Form
    {
        public TongHopCongNo()
        {
            InitializeComponent();
            detail.AutoGenerateColumns = false;
        }
        private void TongHopCongNo_Load(object sender, EventArgs e)
        {
            mnuLamMoi.PerformClick();
        }
        private void mnuLamMoi_Click(object sender, EventArgs e)
        {
            string query = @"select 0 as stt, t.* from
            (
	            select code, name,
	            (
		            coalesce((select sum(coalesce(tongcong, 0)) from tdonhang where dkhachhangid = dkhachhang.id), 0)
		            -
		            coalesce((select sum(coalesce(tongcong, 0)) from tthanhtoan where dkhachhangid = dkhachhang.id), 0)
	            ) as numcongno, '' as congno
	            from dkhachhang
            )t
            where numcongno <> 0
            order by name asc";
            DataTable dt = Database.GetTable(query, null);
            int stt = 1;
            foreach (DataRow row in dt.Rows)
            {
                row["CONGNO"] = int.Parse(row["NUMCONGNO"].ToString()).ToString("###,###");
                row["stt"] = stt;
                stt++;
            }
            detail.DataSource = dt;
        }
    }
}
