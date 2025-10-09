using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            int result = first.Title.CompareTo(second.Title);
            if(result == 0)
            {
                result = second.Year.CompareTo(first.Year);
                //result = first.Year.CompareTo(second.Year);
            }

            return result;
        }
    }
}
