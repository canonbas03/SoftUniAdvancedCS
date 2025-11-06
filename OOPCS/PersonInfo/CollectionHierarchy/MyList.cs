using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class MyList : Collection, IMyList
    {
        public int Used => items.Count;

        public int Add(string item)
        {
            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removed = items.First();
            items.RemoveAt(0);
            return removed;
        }
    }
}
