using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Project.DAL;

namespace Project.Model
{
    public class DBANGGIACHITIET
    {
        public string ID { set; get; }
        public string DBANGGIAID { set; get; }
        public DMATHANG DMATHANG { set; get; }
        public int DUOI1KG { set; get; }
        public int TU1KGTROLEN { set; get; }

        public DBANGGIACHITIET(DataRow row, out string error)
        {
            ID = row["ID"].ToString();
            DBANGGIAID = row["DBANGGIAID"].ToString();
            DMATHANG = new DMATHANGDAL().Find(row["DMATHANGID"].ToString(), out error);
            DUOI1KG = int.Parse(row["DUOI1KG"].ToString());
            TU1KGTROLEN = int.Parse(row["TU1KGTROLEN"].ToString());
        }
    }
}