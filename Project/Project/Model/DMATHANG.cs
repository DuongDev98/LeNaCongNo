using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DMATHANG
    {
        public string ID { set; get; }
        public string CODE { set; get; }
        public string NAME { set; get; }

        public DMATHANG() { ID = ""; CODE = "Tự động"; NAME = ""; }
        public DMATHANG(string ID, string CODE, string NAME) { this.ID = ID; this.CODE = CODE; this.NAME = NAME; }
        public DMATHANG(DataRow row)
        {
            ID = row["ID"].ToString();
            CODE = row["CODE"].ToString();
            NAME = row["NAME"].ToString();
        }
    }
}
