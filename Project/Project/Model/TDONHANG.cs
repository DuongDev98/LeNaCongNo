using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class TDONHANG
    {
        public string ID { set; get; }
        public DateTime NGAY { set; get; }
        public string NAME { set; get; }
        public DKHACHHANG DKHACHHANG { set; get; }
        public decimal TONGCONG { set; get; }
        public string NOTE { set; get; }
        public List<TDONHANGCHITIET> details { set; get; }

        public TDONHANG()
        {
            NAME = "Tự động";
            NGAY = DateTime.Now;
            DKHACHHANG = new DKHACHHANG();
            details = new List<TDONHANGCHITIET>();
        }
    }
}
