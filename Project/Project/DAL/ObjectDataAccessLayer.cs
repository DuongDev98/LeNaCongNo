using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public abstract class ObjectDataAccessLayer<T>
    {
        public abstract T Find(string id, out string error);
        public abstract bool InserOrEdit(T data, out string error);
        public abstract void Delete(IEnumerable<string> ids, out string error);
    }
}
