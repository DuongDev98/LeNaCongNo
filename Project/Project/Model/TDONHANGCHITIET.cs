using Project.Common;
using Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class TDONHANGCHITIET
    {
        public string ID { set; get; }
        public string TDONHANGID { set; get; }
        public DMATHANG DMATHANG { set; get; }
        public decimal SOLUONG { set; get; }
        public int DONGIA { set; get; }
        public int THANHTIEN { set; get; }

        public TDONHANGCHITIET() {}
        public TDONHANGCHITIET(DataRow row, out string error)
        {
            ID = row["ID"].ToString();
            TDONHANGID = row["TDONHANGID"].ToString();
            ID = row["ID"].ToString();
            DMATHANG = new DMATHANGDAL().Find(row["DMATHANGID"].ToString(), out error);
            SOLUONG = decimal.Parse(row["SOLUONG"].ToString());
            DONGIA = int.Parse(row["DONGIA"].ToString());
            THANHTIEN = int.Parse(row["THANHTIEN"].ToString());
        }

        public void Update()
        {
            if (ID.Length > 0)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "@id", ID },
                    { "@tdonhangid", TDONHANGID},
                    { "@dmathangid", DMATHANG.ID },
                    { "@dongia", DONGIA },
                    { "@soluong", SOLUONG },
                    { "@thanhtien", THANHTIEN }
                };
                string error;
                Database.ExcuteQuery(@"update tdonhangchitiet set tdonhangid=@tdonhangid, dmathangid=@dmathangid,
                dongia=@dongia, soluong=@soluong, thanhtien=@thanhtien where id = @id", dic, out error);
                if (error.Length > 0) throw new Exception(error);
            }
        }
    }
}