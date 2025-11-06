using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public abstract class Collection
    {
        protected List<string> items;
        protected Collection()
        {
            items = new List<string>(100);
        }
    }
}
