using Project.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.Model
{
    public class DBANGGIACHITIETRow: ModelRow
    {
        public string ID { set; get; }
        public string DBANGGIAID { set; get; }
        public DMATHANGRow DMATHANG { set; get; }
        public int DUOI1KG { set; get; }
        public int TU1KGTROLEN { set; get; }
        public DBANGGIACHITIETRow()
        {
            ID = "";
            DBANGGIAID = "";
            DMATHANG = new DMATHANGRow("");
            DUOI1KG = 0;
            TU1KGTROLEN = 0;
        }
        public DBANGGIACHITIETRow(string DBANGGIACHITIETID)
        {
            ID = DBANGGIACHITIETID;
            if (ID.Length == 0)
            {
                ID = "";
                DBANGGIAID = "";
                DMATHANG = new DMATHANGRow("");
                DUOI1KG = 0;
                TU1KGTROLEN = 0;
            }
            else
            {
                DataRow row = DatabaseSql.GetFirstRow("select * from dmathang where id = @id", attrs);
                if (row != null)
                {
                    ID = row["ID"].ToString();
                    DBANGGIAID = row["DBANGGIAID"].ToString();
                    DMATHANG = new DMATHANGRow(row["DMATHANGID"].ToString());
                    DUOI1KG = int.Parse(row["DUOI1KG"].ToString());
                    TU1KGTROLEN = int.Parse(row["TU1KGTROLEN"].ToString());
                }
            }

        }
        public DBANGGIACHITIETRow(DataRow row)
        {
            ID = row["ID"].ToString();
            DMATHANG = new DMATHANGRow(row["DMATHANGID"].ToString());
            DUOI1KG = int.Parse(row["DUOI1KG"].ToString());
            TU1KGTROLEN = int.Parse(row["TU1KGTROLEN"].ToString());
        }

        public override bool Update(out string error)
        {
            error = "";
            if (ID == null || ID.Length == 0)
            {
                ID = Guid.NewGuid().ToString();
                DatabaseSql.ExcuteQuery(@"insert into dbanggiachitiet(id, dbanggiaid, dmathangid, duoi1kg, tu1kgtrolen)
                values(@id, @dbanggiaid, @dmathangid, @duoi1kg, @tu1kgtrolen)", attrs);
            }
            else
            {
                DatabaseSql.ExcuteQuery(@"update dbanggiachitiet set dbanggiaid=@dbanggiaid, dmathangid=@dmathangid,
                duoi1kg=@duoi1kg, tu1kgtrolen=@tu1kgtrolen where id = @id", attrs);
            }
            return true;
        }

        public override bool Delete(out string error)
        {
            error = "";
            if (ID.Length == 0) return false;
            DatabaseSql.ExcuteQuery("delete from dbanggiachitiet where id = @id", attrs);
            return true;
        }

        private Dictionary<string, object> attrs
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@id", ID);
                dic.Add("@dbanggiaid", DBANGGIAID);
                dic.Add("@dmathangid", DMATHANG.ID);
                dic.Add("@duoi1kg", DUOI1KG);
                dic.Add("@tu1kgtrolen", TU1KGTROLEN);
                return dic;
            }
        }

        public override DataRow ToRow(DataTable dt)
        {
            DataRow row = dt.NewRow();
            row["ID"] = ID;
            row["DBANGGIAID"] = DBANGGIAID;
            row["DMATHANGID"] = DMATHANG.ID;
            row["DMATHANG_CODE"] = DMATHANG.CODE;
            row["DMATHANG_CODE"] = DMATHANG.NAME;
            row["DUOI1KG"] = DUOI1KG;
            row["TU1KGTROLEN"] = TU1KGTROLEN;
            return row;
        }
    }
}