using Project.Common;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class DKHACHHANGDAL : ObjectDataAccessLayer<DKHACHHANG>
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
                Database.ExcuteQuery("delete from dkhachhang where id = @id", dic, out error);
            }
        }
        public override bool InserOrEdit(DKHACHHANG data, out string error)
        {
            error = "";
            bool insert = false;
            if (data.ID.Length == 0)
            {
                insert = true;
                data.ID = Guid.NewGuid().ToString();
            }
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", data.ID },
                { "@code", data.CODE },
                { "@name", data.NAME },
                { "@dienthoai", data.DIENTHOAI },
                { "@diachi", data.DIACHI }
            };

            if (insert)
            {
                //Kiểm tra tồn tại mặt hàng trong hệ thống
                DataTable tbl = Database.GetTable("select * from dkhachhang where code=@code", dic, out error);
                if (error.Length > 0 || tbl.Rows.Count > 0)
                {
                    if (error.Length == 0)
                    {
                        error = "Mã khách hàng đã tồn tại trong hệ thống";
                    }
                    return false;
                }
                return Database.ExcuteQuery("insert into dkhachhang(id, code, name, dienthoai, diachi) values(@id, @code, @name, @dienthoai, @diachi)", dic, out error);
            }
            else
            {
                return Database.ExcuteQuery("update dkhachhang set name = @name, dienthoai = @dienthoai, diachi = @diachi where id = @id", dic, out error);
            }
        }

        public override DKHACHHANG Find(string id, out string error)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", id }
            };
            DataRow row = Database.GetFirstRow("select * from dkhachhang where id = @id", dic, out error);
            DKHACHHANG khRow = new DKHACHHANG();
            if (row != null)
            {
                CopyData(khRow, row);
            }
            return khRow;
        }

        private void CopyData(DKHACHHANG khRow, DataRow row)
        {
            khRow.ID = row["ID"].ToString();
            khRow.CODE = row["CODE"].ToString();
            khRow.NAME = row["NAME"].ToString();
            khRow.DIENTHOAI = row["DIENTHOAI"].ToString();
            khRow.DIACHI = row["DIACHI"].ToString();
        }

        public DataTable Table(string loc)
        {
            string query = "select * from dkhachhang";
            if (loc.Length > 0)
            {
                query += " where code like N'%" + loc + "%' or name like N'%" + loc + "%' or dienthoai like N'%" + loc + "%' or diachi like N'%" + loc + "%'";
            }
            query += " order by name asc";
            Dictionary<string, object> attrs = new Dictionary<string, object>
            {
                { "@loc", loc }
            };
            DataTable dt = Database.GetTable(query, attrs);
            return dt;
        }

        public List<DKHACHHANG> List(string filter)
        {
            List<DKHACHHANG> lst = new List<DKHACHHANG>();
            if (filter.Length == 0)
            {
                DKHACHHANG khRow = new DKHACHHANG();
                lst.Add(khRow);
            }

            DataTable dt = Table(filter);
            foreach (DataRow row in dt.Rows)
            {
                DKHACHHANG khRow = new DKHACHHANG();
                CopyData(khRow, row);
                lst.Add(khRow);
            }
            return lst;
        }
    }
}
