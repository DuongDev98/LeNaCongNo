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
    public class DMATHANGRow : ModelRow
    {
        public string ID { set; get; }
        public string CODE { set; get; }
        public string NAME { set; get; }
        public DMATHANGRow(string DMATHANGID)
        {
            ID = DMATHANGID;
            if (ID.Length == 0)
            {
                ID = "";
                CODE = "Tự động";
                NAME = "";
            }
            else
            {
                DataRow row = Database.GetFirstRow("select * from dmathang where id = @id", attrs);
                if (row != null)
                {
                    ID = row["ID"].ToString();
                    CODE = row["CODE"].ToString();
                    NAME = row["NAME"].ToString();
                }
            }
        }

        public DMATHANGRow(DataRow row)
        {
            ID = row["ID"].ToString();
            CODE = row["CODE"].ToString();
            NAME = row["NAME"].ToString();
        }

        public override bool Update(out string error)
        {
            error = "";
            //kiểm tra trùng tên
            DataTable tbl = Database.GetTable("select * from dmathang where (code=@code or name=@name) and id <> @id", attrs);
            if (tbl.Rows.Count > 0)
            {
                error = "Mặt hàng đã tồn tại trong hệ thống";
                return false;
            }

            if (ID.Length == 0)
            {
                ID = Guid.NewGuid().ToString();
                CODE = Database.GenCode("CODE", "DMATHANG");
                Database.ExcuteQuery("insert into dmathang(id, code, name) values(@id, @code, @name)", attrs);
            }
            else
            {
                Database.ExcuteQuery("update dmathang set name = @name where id = @id", attrs);
            }
            return true;
        }

        public override bool Delete(out string error)
        {
            error = "";
            if (ID.Length == 0) return false;
            Database.ExcuteQuery("delete from dmathang where id = @id", attrs);
            return true;
        }
        private Dictionary<string, object> attrs
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@id", ID);
                dic.Add("@code", CODE);
                dic.Add("@name", NAME);
                return dic;
            }
        }
        public override DataRow ToRow(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["ID"] = ID;
            row["CODE"] = CODE;
            row["NAME"] = NAME;
            return row;
        }
    }
}
