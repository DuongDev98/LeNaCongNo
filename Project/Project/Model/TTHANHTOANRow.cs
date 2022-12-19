using Project.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.Model
{
    public class TTHANHTOANRow:ModelRow
    {
        public string ID { set; get; }
        public DateTime NGAY { set; get; }
        public string NAME { set; get; }
        public DKHACHHANGRow DKHACHHANG { set; get; }
        public decimal TONGCONG { set; get; }
        public string NOTE { set; get; } 
        public TTHANHTOANRow()
        {
            ID = "";
            NAME = "Tự động";
            NGAY = DateTime.Now;
            DKHACHHANG = new DKHACHHANGRow();
            NOTE = "";
        }
        public TTHANHTOANRow(DataRow row)
        {
            ID = row["ID"].ToString();
            NAME = row["NAME"].ToString();
            NGAY = DateTime.Parse(row["NGAY"].ToString());
            DKHACHHANG = new DKHACHHANGRow(row["DKHACHHANGID"].ToString());
            NOTE = row["NOTE"].ToString();
        }
        public TTHANHTOANRow(string TDONHANGID)
        {
            ID = TDONHANGID;
            if (ID.Length == 0)
            {
                ID = "";
                NGAY = DateTime.Now.Date;
                NAME = "Tự động";
                DKHACHHANG = new DKHACHHANGRow();
                TONGCONG = 0;
                NOTE = "";
            }
            else
            {
                DataRow row = Database.GetFirstRow("select * from tthanhtoan where id = @id", attrs);
                if (row != null)
                {
                    ID = row["ID"].ToString();
                    NGAY = DateTime.Parse(row["NGAY"].ToString());
                    NAME = row["NAME"].ToString();
                    DKHACHHANG = new DKHACHHANGRow(row["DKHACHHANGID"].ToString());
                    TONGCONG = int.Parse(row["TONGCONG"].ToString());
                    NOTE = row["NOTE"].ToString();
                }
            }
        }

        public override bool Update(out string error)
        {
            bool kq = true;
            if (ID == null || ID.Length == 0)
            {
                ID = Guid.NewGuid().ToString();
                NAME = Database.GenCode("NAME", "TTHANHTOAN");

                Database.ExcuteQuery(@"insert into tthanhtoan(id, ngay, name, dkhachhangid, tongcong, note)
                    values(@id, @ngay, @name, @dkhachhangid, @tongcong, @note)", attrs, out error);
                if (error.Length > 0) kq = false;
            }
            else
            {
                Database.ExcuteQuery(@"update tthanhtoan set ngay = @ngay, name = @name, dkhachhangid = @dkhachhangid,
                    tongcong = @tongcong, note = @note where id = @id", attrs, out error);
                if (error.Length > 0) kq = false;
            }
            return kq;
        }

        public override bool Delete(out string error)
        {
            Database.ExcuteQuery("delete from tthanhtoan where id = @id", attrs, out error);
            if (error.Length > 0) return false;
            return true;
        }
        private Dictionary<string, object> attrs
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@id", ID);
                dic.Add("@ngay", NGAY);
                dic.Add("@name", NAME);
                if (DKHACHHANG != null) dic.Add("@dkhachhangid", DKHACHHANG.ID);
                dic.Add("@tongcong", TONGCONG);
                dic.Add("@note", NOTE);
                return dic;
            }
        }

        public override DataRow ToRow(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["ID"] = ID;
            row["NGAY"] = NGAY.ToString("dd/MM/yyyy");
            row["NAME"] = NAME;
            row["DKHACHHANG_CODE"] = DKHACHHANG.CODE;
            row["DKHACHHANG_NAME"] = DKHACHHANG.NAME;
            row["TONGCONG"] = TONGCONG;
            row["NOTE"] = NOTE;
            return row;
        }
    }
}
