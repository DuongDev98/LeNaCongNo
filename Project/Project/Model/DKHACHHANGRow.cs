using Project.Common;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DKHACHHANGRow:ModelRow
    {
        public string ID { set; get; }
        public string CODE { set; get; }
        public string NAME { set; get; }
        public string DIENTHOAI { set; get; }
        public string DIACHI { set; get; }

        public DKHACHHANGRow()
        {
            ID = "";
            CODE = "";
            NAME = "";
            DIENTHOAI = "";
            DIACHI = "";
        }
        public DKHACHHANGRow(string DKHACHANGID)
        {
            ID = DKHACHANGID;
            if (ID.Length == 0)
            {
                ID = "";
                CODE = "Tự động";
                NAME = "";
                DIENTHOAI = "";
                DIACHI = "";
            }
            else
            {
                DataRow row = Database.GetFirstRow("select * from dkhachhang where id = @id", attrs);
                if (row != null)
                {
                    ID = row["ID"].ToString();
                    CODE = row["CODE"].ToString();
                    NAME = row["NAME"].ToString();
                    DIENTHOAI = row["DIENTHOAI"].ToString();
                    DIACHI = row["DIACHI"].ToString();
                }
            }
        }
        public DKHACHHANGRow(DataRow row)
        {
            ID = row["ID"].ToString();
            CODE = row["CODE"].ToString();
            NAME = row["NAME"].ToString();
            DIENTHOAI = row["DIENTHOAI"].ToString();
            DIACHI = row["DIACHI"].ToString();
        }

        public override bool Update(out string error)
        {
            error = "";
            //kiểm tra trùng tên
            DataTable tbl = Database.GetTable("select * from dkhachhang where (code=@code or name=@name) and id <> @id", attrs);
            if (tbl.Rows.Count > 0)
            {
                error = "Khách hàng đã tồn tại trong hệ thống";
                return false;
            }

            if (ID.Length == 0)
            {
                ID = Guid.NewGuid().ToString();
                CODE = Database.GenCode("CODE", "DKHACHHANG");
                Database.ExcuteQuery("insert into dkhachhang(id, code, name, dienthoai, diachi) values(@id, @code, @name, @dienthoai, @diachi)", attrs);
            }
            else
            {
                Database.ExcuteQuery("update dkhachhang set name = @name, dienthoai = @dienthoai, diachi = @diachi where id = @id", attrs);
            }
            return true;
        }

        public override bool Delete(out string error)
        {
            error = "";
            if (ID.Length == 0) return false;
            Database.ExcuteQuery("delete from dkhachhang where id = @id", attrs);
            return true;
        }
        private Dictionary<string, object> attrs
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ID", ID);
                dic.Add("@CODE", CODE);
                dic.Add("@NAME", NAME);
                dic.Add("@DIENTHOAI", DIENTHOAI);
                dic.Add("@DIACHI", DIACHI);
                return dic;
            }
        }
        public override DataRow ToRow(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["ID"] = ID;
            row["CODE"] = CODE;
            row["NAME"] = NAME;
            row["DIENTHOAI"] = DIENTHOAI;
            row["DIACHI"] = DIACHI;
            return row;
        }
    }
}
