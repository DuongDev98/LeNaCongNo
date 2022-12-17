using Project.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.Model
{
    public class DBANGGIARow:ModelRow
    {
        public string ID { set; get; }
        public string NAME { set; get; }
        public DateTime TuNgay { set; get; }
        public DateTime DenNgay { set; get; }
        public List<DBANGGIACHITIETRow> details { set; get; }
        public DBANGGIARow() {
            ID = "";
            NAME = "Tự động";
            TuNgay = DateTime.Now;
            DenNgay = DateTime.Now;
            details = new List<DBANGGIACHITIETRow>();
        }
        public DBANGGIARow(string DBANGGIAID)
        {
            ID = DBANGGIAID;
            if (ID.Length == 0)
            {
                ID = "";
                NAME = "Tự động";
                TuNgay = DateTime.Now;
                DenNgay = DateTime.Now;
                details = new List<DBANGGIACHITIETRow>();
            }
            else
            {
                DataRow row = Database.GetFirstRow("select * from dbanggia where id = @id", attrs);
                if (row != null)
                {
                    ID = row["ID"].ToString();
                    NAME = row["NAME"].ToString();
                    TuNgay = DateTime.Parse(row["TUNGAY"].ToString());
                    DenNgay = DateTime.Parse(row["DENNGAY"].ToString());
                    //Lấy chi tiết hóa đơn
                    List<DBANGGIACHITIETRow> lst = new List<DBANGGIACHITIETRow>();
                    DataTable dtChiTiet = Database.GetTable("select * from dbanggiachitiet where dbanggiaid = @id", attrs);
                    foreach (DataRow rChiTiet in dtChiTiet.Rows)
                    {
                        DBANGGIACHITIETRow ctRow = new DBANGGIACHITIETRow(rChiTiet);
                        lst.Add(ctRow);
                    }
                    details = lst;
                }
            }
        }
        public DBANGGIARow(DataRow row)
        {
            ID = row["ID"].ToString();
            NAME = row["NAME"].ToString();
            TuNgay = DateTime.Parse(row["TUNGAY"].ToString());
            DenNgay = DateTime.Parse(row["DENNGAY"].ToString());
            details = new List<DBANGGIACHITIETRow>();
        }
        public override bool Update(out string error)
        {
            error = "";

            bool kq = true;
            if (ID.Length == 0)
            {
                ID = Guid.NewGuid().ToString();
                NAME = Database.GenCode("NAME", "DBANGGIA");

                Database.ExcuteQuery(@"insert into dbanggia(id, name, tungay, denngay)
                values(@id, @name, @tungay, @denngay)", attrs, out error);
                if (error.Length > 0) kq = false;
                else
                {
                    AddDetail(out error);
                    if (error.Length > 0) kq = false;
                }
            }
            else
            {
                Database.ExcuteQuery(@"update dbanggia set tungay = @tungay, denngay = @denngay where id = @id", attrs, out error);
                if (error.Length > 0) kq = false;
                else
                {
                    Database.ExcuteQuery(@"delete from dbanggiachitiet where dbanggiaid = @id", attrs, out error);
                    if (error.Length > 0) kq = false;
                    else
                    {
                        AddDetail(out error);
                        if (error.Length > 0) kq = false;
                    }
                }
            }
            return kq;
        }

        private void AddDetail(out string error)
        {
            error = "";
            foreach (Dictionary<string, object> dic in attrsDetails)
            {
                dic["@id"] = Guid.NewGuid().ToString();
                Database.ExcuteQuery(@"insert into dbanggiachitiet(id, dbanggiaid, dmathangid, duoi1kg, tu1kgtrolen)
                values(@id, @dbanggiaid, @dmathangid, @duoi1kg, @tu1kgtrolen)", dic, out error);
                if (error.Length > 0) break;
            }
        }

        public override bool Delete(out string error)
        {
            Database.ExcuteQuery("delete from dbanggia where id = @id", attrs, out error);
            if (error.Length > 0) return false;
            Database.ExcuteQuery("delete from dbanggiachitiet where dbanggiaid = @id", attrs, out error);
            if (error.Length > 0) return false;
            return true;
        }
        private Dictionary<string, object> attrs
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@id", ID);
                dic.Add("@name", NAME);
                dic.Add("@tungay", TuNgay);
                dic.Add("@denngay", DenNgay);
                return dic;
            }
        }
        private List<Dictionary<string, object>> attrsDetails
        {
            get
            {
                List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
                foreach (DBANGGIACHITIETRow ctRow in details)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@id", ctRow.ID);
                    dic.Add("@dbanggiaid", ID);
                    dic.Add("@dmathangid", ctRow.DMATHANG.ID);
                    dic.Add("@duoi1kg", ctRow.DUOI1KG);
                    dic.Add("@tu1kgtrolen", ctRow.TU1KGTROLEN);
                    lst.Add(dic);
                }
                return lst;
            }
        }
        public override DataRow ToRow(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["ID"] = ID;
            row["NAME"] = NAME;
            row["TuNgay"] = TuNgay.ToString("dd/MM/yyyy");
            row["DenNgay"] = DenNgay.ToString("dd/MM/yyyy");
            return row;
        }
    }
}