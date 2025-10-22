using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
    internal class MyLinkedList
    {
        private readonly MyLinkedListNode _start, _end;
        private int _count;
        public int Count => _count;
        public MyLinkedList()
        {
            _start = new MyLinkedListNode(-1);
            _end = new MyLinkedListNode(-1);

            _start.Next = _end;
            _end.Prev = _start;
        }

        public void AddFirst(int value)
        {
            this.InsertBetween(this._start, this._start.Next, value);
        }

        public void AddLast(int value)
        {
            this.InsertBetween(this._end.Prev, this._end, value);
        }

        public int GetFirst()
        {
            this.ValidateNotEmpty();
            return _start.Next.Value;
        }

        public int GetLast()
        {
            this.ValidateNotEmpty();
            return _end.Prev.Value;
        }

        public void RemoveFirst()
        {
            this.ValidateNotEmpty();
            this.RemoveBetween(_start, _start.Next.Next);
        }

        public void RemoveLast()
        {
            this.ValidateNotEmpty();
            this.RemoveBetween(_end.Prev.Prev, _end);
        }
        
        private void ValidateNotEmpty()
        {
            if (this._count == 0)
                throw new InvalidOperationException("The linked list is empty!!!");
        }

        private void InsertBetween(MyLinkedListNode a, MyLinkedListNode b, int value)
        {
            MyLinkedListNode newNode = new MyLinkedListNode(value);
            a.Next = newNode;
            newNode.Next = b;
            b.Prev = newNode;
            newNode.Prev = a;

            _count++;
        }

        private void RemoveBetween(MyLinkedListNode a, MyLinkedListNode b)
        {
            a.Next.Prev = null;
            b.Prev.Next = null;

            a.Next = b;
            b.Prev = a;

            this._count--;
        }
    }
}
