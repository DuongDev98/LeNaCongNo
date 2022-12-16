using Project.Common;
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
    public class TDONHANG
    {
        public string ID { set; get; }
        public DateTime NGAY { set; get; }
        public string NAME { set; get; }
        public DKHACHHANG DKHACHHANG { set; get; }
        public decimal TONGCONG { set; get; }
        public string NOTE { set; get; }
        public List<TDONHANGCHITIET> details { set; get; }
        public TDONHANG(DataRow row, out string error)
        {
            ID = row["ID"].ToString();
            NGAY = DateTime.Parse(row["NGAY"].ToString());
            NAME = row["NAME"].ToString();
            DKHACHHANG = new DKHACHHANGDAL().Find(row["DKHACHHANGID"].ToString(), out error);
            TONGCONG = int.Parse(row["TONGCONG"].ToString());
            NOTE = row["NOTE"].ToString();
        }        
        public TDONHANG()
        {
            NAME = "Tự động";
            NGAY = DateTime.Now;
            DKHACHHANG = new DKHACHHANG();
            details = new List<TDONHANGCHITIET>();
        }

        public void Update()
        {
            string error;
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", ID },
                { "@ngay", NGAY },
                { "@name", NAME },
                { "@dkhachhangid", DKHACHHANG.ID },
                { "@tongcong", TONGCONG },
                { "@note", NOTE }
            };
            Database.ExcuteQuery(@"update tdonhang set ngay = @ngay, name = @name, dkhachhangid = @dkhachhangid,
            tongcong = @tongcong, note = @note where id = @id", dic, out error);
            if (error.Length > 0) throw new Exception(error);
        }
    }
}
