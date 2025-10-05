using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    internal class MyLinkedListNode
    {
        public int Value { get; set; }
        public MyLinkedListNode Prev { get; set; }
        public MyLinkedListNode Next { get; set; }

        public MyLinkedListNode(int value)
        {
            this.Value = value;
        }
    }
}
