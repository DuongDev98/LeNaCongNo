using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class Connection
    {
        public static string server = "localhost";
        public static string database = Directory.GetCurrentDirectory() + @"\data.fdb";
    }
}