namespace Project.Common
{
    //public class DatabaseSql
    //{
    //    private static FbConnection InitConnection()
    //    {
    //        try
    //        {
    //            string connectionStandard = @"User=SYSDBA;Password=masterkey;Database={0};DataSource={1};Port=3050;Dialect=3;
    //            Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;";
    //            return new FbConnection(string.Format(connectionStandard, Connection.server + ":" + Connection.database, Connection.database));
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }
    //    public static int? GetFirstFieldInt(string query, Dictionary<string, object> attrs)
    //    {
    //        string error;
    //        return GetFirstFieldInt(query, attrs, out error);
    //    }
    //    public static int? GetFirstFieldInt(string query, Dictionary<string, object> attrs, out string error)
    //    {
    //        object data = GetFirstField(query, attrs, out error);
    //        if (data == null) return null;
    //        else return int.Parse(data.ToString());
    //    }
    //    public static string GetFirstFieldString(string query, Dictionary<string, object> attrs)
    //    {
    //        string error;
    //        return GetFirstFieldString(query, attrs, out error);
    //    }
    //    public static string GetFirstFieldString(string query, Dictionary<string, object> attrs, out string error)
    //    {
    //        object data = GetFirstField(query, attrs, out error);
    //        if (data == null) return null;
    //        else return data.ToString();
    //    }
    //    public static object GetFirstField(string query, Dictionary<string, object> attrs)
    //    {
    //        string error;
    //        return GetFirstField(query, attrs, out error);
    //    }
    //    public static object GetFirstField(string query, Dictionary<string, object> attrs, out string error)
    //    {
    //        DataTable dt = GetTable(query, attrs, out error);
    //        if (dt == null || dt.Rows.Count == 0) return null;
    //        else return dt.Rows[0][0];
    //    }

    //    public static DataRow GetFirstRow(string query, Dictionary<string, object> attrs)
    //    {
    //        string error;
    //        return GetFirstRow(query, attrs, out error);
    //    }

    //    public static DataRow GetFirstRow(string query, Dictionary<string, object> attrs, out string error)
    //    {
    //        DataTable dt = GetTable(query, attrs, out error);
    //        if (dt == null || dt.Rows.Count == 0) return null;
    //        else return dt.Rows[0];
    //    }
    //    public static DataTable GetTable(string query, Dictionary<string, object> attrs)
    //    {
    //        string error;
    //        return GetTable(query, attrs, out error);
    //    }

    //    public static DataTable GetTable(string query, Dictionary<string, object> attrs, out string error)
    //    {
    //        error = "";
    //        DataTable dt = new DataTable();
    //        FbConnection conn = InitConnection();
    //        if (conn == null)
    //        {
    //            error = "Không thể kết nối đến dữ liệu";
    //            return dt;
    //        }

    //        try
    //        {
    //            conn.Open();
    //            FbCommand cmd = new FbCommand(query, conn);
    //            BuilderParameter(cmd, attrs);
    //            FbDataAdapter da = new FbDataAdapter(cmd);
    //            da.Fill(dt);
    //            dt.Columns.Add("STT", typeof(string));

    //            int counter = 0;
    //            foreach (DataRow row in dt.Rows)
    //            {
    //                counter++;
    //                row["STT"] = counter.ToString();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            error = ex.ToString();
    //        }
    //        finally
    //        {
    //            if (conn != null && conn.State == ConnectionState.Open)
    //            {
    //                conn.Close();
    //                conn.Dispose();
    //            }
    //        }
    //        return dt;
    //    }
    //    public static bool ExcuteQuery(string query, Dictionary<string, object> attrs)
    //    {
    //        string error;
    //        return ExcuteQuery(query, attrs, out error);
    //    }
    //    public static bool ExcuteQuery(string query, Dictionary<string, object> attrs, out string error)
    //    {
    //        error = "";
    //        FbConnection conn = InitConnection();
    //        if (conn == null)
    //        {
    //            error = "Không thể kết nối đến dữ liệu";
    //            return false;
    //        }

    //        try
    //        {
    //            conn.Open();
    //            FbCommand cmd = new FbCommand(query, conn);
    //            BuilderParameter(cmd, attrs);
    //            cmd.ExecuteNonQuery();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            error = ex.ToString();
    //            return false;
    //        }
    //        finally
    //        {
    //            if (conn != null && conn.State == ConnectionState.Open)
    //            {
    //                conn.Close();
    //                conn.Dispose();
    //            }
    //        }
    //    }
    //    private static void BuilderParameter(FbCommand cmd, Dictionary<string, object> attrs)
    //    {
    //        if (attrs != null && attrs.Count > 0)
    //        {
    //            foreach (string key in attrs.Keys)
    //            {
    //                object value = attrs[key];
    //                if (value == null) continue;
    //                Type typeData = value.GetType();
    //                if (typeData == typeof(int)) cmd.Parameters.Add(key, FbDbType.Integer).Value = attrs[key];
    //                else if (typeData == typeof(decimal)) cmd.Parameters.Add(key, FbDbType.Decimal).Value = attrs[key];
    //                else if (typeData == typeof(string)) cmd.Parameters.Add(key, FbDbType.VarChar).Value = attrs[key];
    //                else if (typeData == typeof(DateTime)) cmd.Parameters.Add(key, FbDbType.Date).Value = attrs[key];
    //            }
    //        }
    //    }

    //    public static string GenCode(string field, string table)
    //    {
    //        int maxLength = 8;
    //        string code = "";
    //        if (table == "DMATHANG") code = "MH";
    //        else if (table == "DKHACHHANG") code = "KH";
    //        else if (table == "TDONHANG") code = "DH";
    //        else if (table == "DBANGGIA") code = "BG";
    //        else if (table == "TTHANHTOAN") code = "TT";

    //        int stt = 0;
    //        string data = GetFirstFieldString(string.Format("SELECT MAX({0}) FROM {1}", field, table), null);
    //        if (data != null && data.Length > 0)
    //        {
    //            data = data.Replace(code, "");
    //            stt = int.Parse(data);
    //        }
    //        stt++;

    //        int length = maxLength - code.Length - stt.ToString().Length;
    //        for (int i = 0; i < length; i++) code += "0";
    //        code += stt.ToString();

    //        return code;
    //    }
    //}
}
