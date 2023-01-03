using Project.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.Model
{
    public class TDONHANGCHITIETRow:ModelRow
    {
        public string ID { set; get; }
        public string TDONHANGID { set; get; }
        public DMATHANGRow DMATHANG { set; get; }
        public decimal SOLUONG { set; get; }
        public int DONGIA { set; get; }
        public int THANHTIEN { set; get; }

        public TDONHANGCHITIETRow() {}
        public TDONHANGCHITIETRow(DataRow row)
        {
            ID = row["ID"].ToString();
            TDONHANGID = row["TDONHANGID"].ToString();
            ID = row["ID"].ToString();
            DMATHANG = new DMATHANGRow(row["DMATHANGID"].ToString());
            SOLUONG = decimal.Parse(row["SOLUONG"].ToString());
            DONGIA = int.Parse(row["DONGIA"].ToString());
            THANHTIEN = int.Parse(row["THANHTIEN"].ToString());
        }
        public override bool Update(out string error)
        {
            error = "";
            if (ID == null || ID.Length == 0)
            {
                ID = Guid.NewGuid().ToString();
                DatabaseSql.ExcuteQuery(@"insert into tdonhangchitiet(id, tdonhangid, dmathangid, dongia, soluong, thanhtien)
                values(@id, @tdonhangid, @dmathangid, @dongia, @soluong, @thanhtien)", attrs);
            }
            else
            {
                DatabaseSql.ExcuteQuery(@"update tdonhangchitiet set tdonhangid=@tdonhangid, dmathangid=@dmathangid,
                dongia=@dongia, soluong=@soluong, thanhtien=@thanhtien where id = @id", attrs);
            }
            return true;
        }

        public override bool Delete(out string error)
        {
            error = "";
            if (ID.Length == 0) return false;
            DatabaseSql.ExcuteQuery("delete from tdonhangchitiet where id = @id", attrs);
            return true;
        }
        private Dictionary<string, object> attrs
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ID", ID);
                dic.Add("@TDONHANGID", TDONHANGID);
                dic.Add("@DMATHANGID", DMATHANG.ID);
                dic.Add("@DONGIA", DONGIA);
                dic.Add("@SOLUONG", SOLUONG);
                dic.Add("@THANHTIEN", THANHTIEN);
                return dic;
            }
        }
        public override DataRow ToRow(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}