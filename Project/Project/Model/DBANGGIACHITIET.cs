using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DBANGGIACHITIET
    {
        public string ID { set; get; }
        public string DBANGGIAID { set; get; }
        public DMATHANG DMATHANG { set; get; }
        public int DUOI1KG { set; get; }
        public int TU1KGTROLEN { set; get; }
    }
}