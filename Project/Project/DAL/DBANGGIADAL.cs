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
    public class DBANGGIADAL : ObjectDataAccessLayer<DBANGGIA>
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
                Database.ExcuteQuery("delete from dbanggia where id = @id", dic, out error);
                if (error.Length > 0) break;
                Database.ExcuteQuery("delete from dbanggiachitiet where dbanggiaid = @id", dic, out error);
                if (error.Length > 0) break;
            }
        }
        public override bool InserOrEdit(DBANGGIA data, out string error)
        {
            error = "";
            bool insert = false;
            if (data.ID.Length == 0)
            {
                insert = true;
                data.ID = Guid.NewGuid().ToString();
                data.NAME = Database.GenCode("DBANGGIA");
            }
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", data.ID },
                { "@name", data.NAME },
                { "@tungay", data.TuNgay },
                { "@denngay", data.DenNgay }
            };

            bool kq = true;
            if (insert)
            {
                Database.ExcuteQuery(@"insert into dbanggia(id, name, tungay, denngay)
                values(@id, @name, @tungay, @denngay)", dic, out error);
                if (error.Length > 0) kq = false;
                else
                {
                    AddDetail(data, out error);
                    if (error.Length > 0) kq = false;
                }
            }
            else
            {
                Database.ExcuteQuery(@"update dbanggia set tungay = @tungay, denngay = @denngay where id = @id", dic, out error);
                if (error.Length > 0) kq = false;
                else
                {
                    Database.ExcuteQuery(@"delete from dbanggiachitiet where dbanggiaid = @id", dic, out error);
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

        private void AddDetail(DBANGGIA data, out string error)
        {
            error = "";

            if (data.details == null || data.details.Count == 0)
                error = "Bảng giá chi tiết trống";

            foreach (DBANGGIACHITIET ctRow in data.details)
            {
                ctRow.ID = Guid.NewGuid().ToString();
                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                    { "@id", ctRow.ID },
                    { "@dbanggiaid", data.ID},
                    { "@dmathangid", ctRow.DMATHANG.ID },
                    { "@duoi1kg", ctRow.DUOI1KG },
                    { "@tu1kgtrolen", ctRow.TU1KGTROLEN }
                };

                Database.ExcuteQuery(@"insert into dbanggiachitiet(id, dbanggiaid, dmathangid, duoi1kg, tu1kgtrolen)
                values(@id, @dbanggiaid, @dmathangid, @duoi1kg, @tu1kgtrolen)", dic, out error);

                if (error.Length > 0) break;
            }
        }

        public override DBANGGIA Find(string id, out string error)
        {
            //DMATHANGDAL dMATHANGDAL = new DMATHANGDAL();
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", id }
            };
            DataRow row = Database.GetFirstRow("select * from dbanggia where id = @id", dic, out error);
            DBANGGIA bangGiaRow = new DBANGGIA();
            if (row != null)
            {
                bangGiaRow.ID = row["ID"].ToString();
                bangGiaRow.NAME = row["NAME"].ToString();
                bangGiaRow.TuNgay = DateTime.Parse(row["TUNGAY"].ToString());
                bangGiaRow.DenNgay = DateTime.Parse(row["DENNGAY"].ToString());

                //lấy danh sách mặt hàng chi tiết
                //List<DBANGGIACHITIET> details = new List<DBANGGIACHITIET>();
                //DataTable dtChiTiet = Database.GetTable(@"select * from dbanggiachitiet where dbanggiaid = @id", dic, out error);
                //foreach (DataRow rChiTiet in dtChiTiet.Rows)
                //{
                //    DBANGGIACHITIET ctRow = new DBANGGIACHITIET();
                //    ctRow.ID = rChiTiet["ID"].ToString();
                //    ctRow.DBANGGIAID = bangGiaRow.ID;
                //    ctRow.DMATHANG = dMATHANGDAL.Find(rChiTiet["DMATHANGID"].ToString(), out error);
                //    ctRow.DUOI1KG = int.Parse(rChiTiet["DUOI1KG"].ToString());
                //    ctRow.TU1KGTROLEN = int.Parse(rChiTiet["TU1KGTROLEN"].ToString());

                //    if (error.Length == 0)
                //    {
                //        details.Add(ctRow);
                //    }
                //}
                //bangGiaRow.details = details;
            }
            return bangGiaRow;
        }

        public static DataTable GetCreateDetailTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("DMATHANGID", typeof(string));
            dt.Columns.Add("DMATHANG_CODE", typeof(string));
            dt.Columns.Add("DMATHANG_NAME", typeof(string));
            dt.Columns.Add("DUOI1KG", typeof(int));
            dt.Columns.Add("TU1KGTROLEN", typeof(int));
            return dt;
        }
        public static DataTable LoadData()
        {
            string query = "select * from dbanggia order by name asc";
            DataTable dt = Database.GetTable(query, null);
            return dt;
        }

        public static List<DBANGGIACHITIET> LayDuLieuChiTiet(string DBANGGIAID, out string error)
        {
            DMATHANGDAL dMATHANGDAL = new DMATHANGDAL();

            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "@id", DBANGGIAID }
            };

            DataTable dtChiTiet = Database.GetTable(@"select dbanggiachitiet.id, dmathang.id as dmathangid, dmathang.code as dmathang_code, dmathang.name as dmathang_name,
            coalesce(duoi1kg, 0) as duoi1kg, coalesce(tu1kgtrolen, 0) as tu1kgtrolen
            from dmathang left outer join dbanggiachitiet on dmathangid = dmathang.id and dbanggiaid = @id
            order by dmathang.name", dic, out error);

            List<DBANGGIACHITIET> details = new List<DBANGGIACHITIET>();
            foreach (DataRow rChiTiet in dtChiTiet.Rows)
            {
                DBANGGIACHITIET ctRow = new DBANGGIACHITIET();
                ctRow.ID = rChiTiet["ID"].ToString();
                ctRow.DBANGGIAID = DBANGGIAID;
                ctRow.DMATHANG = dMATHANGDAL.Find(rChiTiet["DMATHANGID"].ToString(), out error);
                ctRow.DUOI1KG = int.Parse(rChiTiet["DUOI1KG"].ToString());
                ctRow.TU1KGTROLEN = int.Parse(rChiTiet["TU1KGTROLEN"].ToString());

                if (error.Length == 0)
                {
                    details.Add(ctRow);
                }
            }

            return details;
        }
    }
}
