using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public abstract class ModelRow
    {
        public bool Update()
        {
            string error;
            Update(out error);
            if (error.Length > 0) return false;
            return true;
        }
        public abstract bool Update(out string error);
        public bool Delete()
        {
            string error;
            Delete(out error);
            if (error.Length > 0) return false;
            return true;
        }
        public abstract bool Delete(out string error);
        public abstract DataRow ToRow(DataTable dt);
    }
}
