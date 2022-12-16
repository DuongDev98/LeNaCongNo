using Project.DAL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DBANGGIA
    {
        public string ID { set; get; }
        public string NAME { set; get; }
        public DateTime TuNgay { set; get; }
        public DateTime DenNgay { set; get; }
        public List<DBANGGIACHITIET> details { set; get; }
        public DBANGGIA() { ID = ""; NAME = "Tự động"; TuNgay = DateTime.Now; DenNgay = DateTime.Now; details = new List<DBANGGIACHITIET>(); }
        public DBANGGIA(string ID, string NAME, DateTime TuNgay, DateTime DenNgay, List<DBANGGIACHITIET> details) { this.ID = ID; this.NAME = NAME; this.TuNgay = TuNgay; this.DenNgay = DenNgay; this.details = details; }
        public DBANGGIA(DataRow row)
        {
            ID = row["ID"].ToString();
            NAME = row["NAME"].ToString();
            TuNgay = DateTime.Parse(row["TUNGAY"].ToString());
            DenNgay = DateTime.Parse(row["DENNGAY"].ToString());
            details = new List<DBANGGIACHITIET>();
        }
    }
}