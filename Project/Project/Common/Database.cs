using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class Database
    {
        private const string server = "NGOC-DUONG\\SQLSERVER";
        //private const string server = "DESKTOP-B13JTK3\\SQLSERVER";
        private const string user = "sa";
        private const string password = "1433";
        private const string data = "doino";
        private static SqlConnection InitConnection()
        {
            return new SqlConnection(string.Format("Server={0};Database={1};User Id={2};Password={3};", server, data, user, password));
        }
        public static int? GetFirstFieldInt(string query, Dictionary<string, object> attrs)
        {
            string error;
            return GetFirstFieldInt(query, attrs, out error);
        }
        public static int? GetFirstFieldInt(string query, Dictionary<string, object> attrs, out string error)
        {
            object data = GetFirstField(query, attrs, out error);
            if (data == null) return null;
            else return int.Parse(data.ToString());
        }
        public static string GetFirstFieldString(string query, Dictionary<string, object> attrs)
        {
            string error;
            return GetFirstFieldString(query, attrs, out error);
        }
        public static string GetFirstFieldString(string query, Dictionary<string, object> attrs, out string error)
        {
            object data = GetFirstField(query, attrs, out error);
            if (data == null) return null;
            else return data.ToString();
        }
        public static object GetFirstField(string query, Dictionary<string, object> attrs)
        {
            string error;
            return GetFirstField(query, attrs, out error);
        }
        public static object GetFirstField(string query, Dictionary<string, object> attrs, out string error)
        {
            DataTable dt = GetTable(query, attrs, out error);
            if (dt == null || dt.Rows.Count == 0) return null;
            else return dt.Rows[0][0];
        }

        public static DataRow GetFirstRow(string query, Dictionary<string, object> attrs)
        {
            string error;
            return GetFirstRow(query, attrs, out error);
        }

        public static DataRow GetFirstRow(string query, Dictionary<string, object> attrs, out string error)
        {
            DataTable dt = GetTable(query, attrs, out error);
            if (dt == null || dt.Rows.Count == 0) return null;
            else return dt.Rows[0];
        }
        public static DataTable GetTable(string query, Dictionary<string, object> attrs)
        {
            string error;
            return GetTable(query, attrs, out error);
        }

        public static DataTable GetTable(string query, Dictionary<string, object> attrs, out string error)
        {
            error = "";
            DataTable dt = new DataTable();
            SqlConnection conn = InitConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                BuilderParameter(cmd, attrs);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dt.Columns.Add("STT", typeof(string));

                int counter = 0;
                foreach (DataRow row in dt.Rows)
                {
                    counter++;
                    row["STT"] = counter.ToString();
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }
        public static bool ExcuteQuery(string query, Dictionary<string, object> attrs)
        {
            string error;
            return ExcuteQuery(query, attrs, out error);
        }
        public static bool ExcuteQuery(string query, Dictionary<string, object> attrs, out string error)
        {
            error = "";
            SqlConnection conn = InitConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                BuilderParameter(cmd, attrs);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        private static void BuilderParameter(SqlCommand cmd, Dictionary<string, object> attrs)
        {
            if (attrs != null && attrs.Count > 0)
            {
                foreach (string key in attrs.Keys)
                {
                    object value = attrs[key];
                    if (value == null) continue;
                    Type typeData = value.GetType();
                    if (typeData == typeof(int)) cmd.Parameters.Add(key, SqlDbType.Int).Value = attrs[key];
                    else if (typeData == typeof(decimal)) cmd.Parameters.Add(key, SqlDbType.Decimal).Value = attrs[key];
                    else if (typeData == typeof(string)) cmd.Parameters.Add(key, SqlDbType.NVarChar).Value = attrs[key];
                    else if (typeData == typeof(DateTime)) cmd.Parameters.Add(key, SqlDbType.Date).Value = attrs[key];
                }
            }
        }

        public static string GenCode(string field, string table)
        {
            int maxLength = 8;
            string code = "";
            if (table == "DMATHANG") code = "MH";
            else if (table == "DKHACHHANG") code = "KH";
            else if (table == "TDONHANG") code = "DH";
            else if (table == "DBANGGIA") code = "BG";
            else if (table == "TTHANHTOAN") code = "TT";

            int stt = 0;
            string data = GetFirstFieldString(string.Format("SELECT MAX({0}) FROM {1}", field, table), null);
            if (data != null && data.Length > 0)
            {
                data = data.Replace(code, "");
                stt = int.Parse(data);
            }
            stt++;

            int length = maxLength - code.Length - stt.ToString().Length;
            for (int i = 0; i < length; i++) code += "0";
            code += stt.ToString();

            return code;
        }
    }
}
