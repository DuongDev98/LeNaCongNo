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
    public class TDONHANGDAL : ObjectDataAccessLayer<TDONHANG>
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
                Database.ExcuteQuery("delete from tdonhang where id = @id", dic, out error);
                if (error.Length > 0) break;
                Database.ExcuteQuery("delete from tdonhangchitiet where tdonhangid = @id", dic, out error);
                if (error.Length > 0) break;
            }
        }
        public override bool InserOrEdit(TDONHANG data, out string error)
        {
            error = "";
            bool insert = false;
            if (data.ID.Length == 0)
            {
                insert = true;
                data.ID = Guid.NewGuid().ToString();
                data.NAME = Database.GenCode("TDONHANG");
            }
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", data.ID },
                { "@ngay", data.NGAY },
                { "@name", data.NAME },
                { "@dkhachhangid", data.DKHACHHANG.ID },
                { "@tongcong", data.TONGCONG },
                { "@note", data.NOTE }
            };

            bool kq = true;
            if (insert)
            {
                Database.ExcuteQuery(@"insert into tdonhang(id, ngay, name, dkhachhangid, tongcong, note)
                values(@id, @ngay, @name, @dkhachhangid, @tongcong, @note)", dic, out error);
                if (error.Length > 0) kq = false;
                else
                {
                    AddDetail(data, out error);
                    if (error.Length > 0) kq = false;
                }
            }
            else
            {
                Database.ExcuteQuery(@"update tdonhang set ngay = @ngay, name = @name, dkhachhangid = @dkhachhangid,
                tongcong = @tongcong, note = @note where id = @id", dic, out error);
                if (error.Length > 0) kq = false;
                else
                {
                    Database.ExcuteQuery(@"delete from tdonhangchitiet where tdonhangid = @id", dic, out error);
                    if (error.Length > 0) kq = false;
                    else
                    {
                        AddDetail(data, out error);
                        if (error.Length > 0) kq = false;
                    }
                }
            }
            return kq;
        }

        private void AddDetail(TDONHANG data, out string error)
        {
            error = "";

            if (data.details == null || data.details.Count == 0)
                error = "Đơn hàng trống";

            foreach (TDONHANGCHITIET ctRow in data.details)
            {
                ctRow.ID = Guid.NewGuid().ToString();
                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "@id", ctRow.ID },
                    { "@tdonhangid", data.ID},
                    { "@dmathangid", ctRow.DMATHANG.ID },
                    { "@dongia", ctRow.DONGIA },
                    { "@soluong", ctRow.SOLUONG },
                    { "@thanhtien", ctRow.THANHTIEN }
                };

                Database.ExcuteQuery(@"insert into tdonhangchitiet(id, tdonhangid, dmathangid, dongia, soluong, thanhtien)
                values(@id, @tdonhangid, @dmathangid, @dongia, @soluong, @thanhtien)", dic, out error);

                if (error.Length > 0) break;
            }
        }

        public override TDONHANG Find(string id, out string error)
        {
            DMATHANGDAL dMATHANGDAL = new DMATHANGDAL();
            DKHACHHANGDAL dKHACHHANGDAL = new DKHACHHANGDAL();
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", id }
            };
            DataRow row = Database.GetFirstRow("select * from dkhachhang where id = @id", dic, out error);
            TDONHANG dhRow = new TDONHANG();
            if (row != null)
            {
                dhRow.ID = row["ID"].ToString();
                dhRow.NGAY = DateTime.Parse(row["NGAY"].ToString());
                dhRow.NAME = row["NAME"].ToString();
                dhRow.DKHACHHANG = dKHACHHANGDAL.Find(row["DKHACHHANGID"].ToString(), out error);
                dhRow.TONGCONG = int.Parse(row["TONGCONG"].ToString());
                dhRow.NOTE = row["NOTE"].ToString();

                //lấy danh sách mặt hàng chi tiết
                List<TDONHANGCHITIET> details = new List<TDONHANGCHITIET>();
                DataTable dtChiTiet = Database.GetTable(@"select * from tdonhangchitiet inner join dmathang on dmathangid = dmathang.id
                where tdonhangid = @id", dic, out error);
                foreach (DataRow rChiTiet in dtChiTiet.Rows)
                {
                    TDONHANGCHITIET ctRow = new TDONHANGCHITIET();
                    ctRow.ID = rChiTiet["ID"].ToString();
                    ctRow.DMATHANG = dMATHANGDAL.Find(rChiTiet["DMATHANGID"].ToString(), out error);
                    ctRow.DONGIA = int.Parse(rChiTiet["DONGIA"].ToString());
                    ctRow.SOLUONG = int.Parse(rChiTiet["SOLUONG"].ToString());
                    ctRow.THANHTIEN = int.Parse(rChiTiet["THANHTIEN"].ToString());
                    ctRow.TDONHANGID = dhRow.ID;
                    if (error.Length == 0)
                    {
                        details.Add(ctRow);
                    }
                }
                dhRow.details = details;
            }
            return dhRow;
        }

        public static DataTable GetCreateDetailTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("DMATHANGID", typeof(string));
            dt.Columns.Add("DMATHANG_CODE", typeof(string));
            dt.Columns.Add("DMATHANG_NAME", typeof(string));
            dt.Columns.Add("SOLUONG", typeof(int));
            dt.Columns.Add("DONGIA", typeof(int));
            dt.Columns.Add("THANHTIEN", typeof(int));
            return dt;
        }
    }
}
