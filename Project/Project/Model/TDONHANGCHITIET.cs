using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class TDONHANGCHITIET
    {
        public string ID { set; get; }
        public string TDONHANGID { set; get; }
        public DMATHANG DMATHANG { set; get; }
        public int SOLUONG { set; get; }
        public int DONGIA { set; get; }
        public int THANHTIEN { set; get; }
    }
}