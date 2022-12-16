using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DKHACHHANG
    {
        public string ID { set; get; }
        public string CODE { set; get; }
        public string NAME { set; get; }
        public string DIENTHOAI { set; get; }
        public string DIACHI { set; get; }

        public DKHACHHANG() { ID = ""; CODE = ""; NAME = ""; DIENTHOAI = ""; DIACHI = ""; }
        public DKHACHHANG(string ID, string CODE, string NAME, string DIENTHOAI, string DIACHI) { this.ID = ID; this.CODE = CODE; this.NAME = NAME; this.DIENTHOAI = DIENTHOAI; this.DIACHI = DIACHI; }
        public DKHACHHANG(DataRow row)
        {
            ID = row["ID"].ToString();
            CODE = row["CODE"].ToString();
            NAME = row["NAME"].ToString();
            DIENTHOAI = row["DIENTHOAI"].ToString();
            DIACHI = row["DIACHI"].ToString();
        }
    }
}
