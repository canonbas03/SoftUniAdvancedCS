using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddCollection : Collection, IAddCollection
    {
        public int Add(string item)
        {
            items.Add(item);
            return items.Count - 1;
        }
    }
}
