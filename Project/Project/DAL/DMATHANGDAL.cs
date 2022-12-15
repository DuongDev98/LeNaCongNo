using Project.Common;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.DAL
{
    public class DMATHANGDAL : ObjectDataAccessLayer<DMATHANG>
    {
        public override void Delete(IEnumerable<string> ids, out string error)
        {
            error = "";
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", "" }
            };

            foreach (string id in ids)
            {
                dic["@id"] = id;
                Database.ExcuteQuery("delete from dmathang where id = @id", dic, out error);
            }
        }
        public override bool InserOrEdit(DMATHANG data, out string error)
        {
            error = "";
            bool insert = false;
            if (data.ID.Length == 0)
            {
                insert = true;
                data.ID = Guid.NewGuid().ToString();
                data.CODE = Database.GenCode("DMATHANG");
            }
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", data.ID },
                { "@code", data.CODE },
                { "@name", data.NAME }
            };

            if (insert)
            {
                //Kiểm tra tồn tại mặt hàng trong hệ thống
                DataTable tbl = Database.GetTable("select * from dmathang where code=@code or name=@name", dic, out error);
                if (error.Length > 0 || tbl.Rows.Count > 0)
                {
                    if (error.Length == 0)
                    {
                        error = "Mặt hàng đã tồn tại trong hệ thống";
                    }
                    return false;
                }
                return Database.ExcuteQuery("insert into dmathang(id, code, name) values(@id, @code, @name)", dic, out error);
            }
            else
            {
                return Database.ExcuteQuery("update dmathang set name = @name where id = @id", dic, out error);
            }
        }

        public override DMATHANG Find(string id, out string error)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", id }
            };
            DataRow row = Database.GetFirstRow("select * from dmathang where id = @id", dic, out error);
            DMATHANG mhRow = new DMATHANG();
            if (row != null)
            {
                mhRow.ID = row["ID"].ToString();
                mhRow.CODE = row["CODE"].ToString();
                mhRow.NAME = row["NAME"].ToString();
            }
            return mhRow;
        }

        public static DataTable LoadData(string loc)
        {
            string query = "select * from dmathang";
            if (loc.Length > 0)
            {
                query += " where code like N'%" + loc + "%' or name like N'%" + loc + "%'";
            }
            query += " order by name asc";
            Dictionary<string, object> attrs = new Dictionary<string, object>
            {
                { "@loc", loc }
            };
            DataTable dt = Database.GetTable(query, attrs);
            return dt;
        }
    }
}
