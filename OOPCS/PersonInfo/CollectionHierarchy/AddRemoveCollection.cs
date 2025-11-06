using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public int Add(string item)
        {
            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removed = items.Last();
            items.RemoveAt(items.Count - 1);
            return removed;
        }
    }
}
