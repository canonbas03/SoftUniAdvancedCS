using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    internal class MyStack
    {
        private const int InitialSize = 4;
        private int[] _arr;
        private int _count;

        public int Count => _count;

        public MyStack() : this(InitialSize) { }

        public MyStack(int size)
        {
            this._arr = new int[size];
        }

        public void Push(int value)
        {
            GrowIfNecessary();
            _arr[_count] = value;
            _count++;
        }

        public int Peek()
        {
            ValidateNotEmpty();
            return _arr[_count - 1];
        }
        public int Pop()
        {
            int elementToRemove = this.Peek();
            this._arr[_count - 1] = default;
            _count--;

            return elementToRemove;
        }

        public int[] ToArray()
        {
            int[] resultArr = new int[this._count];
            Array.Copy(this._arr,resultArr,this._count);
            Array.Reverse(resultArr);
            return resultArr;
        }

        private void Grow()
        {
            int[] newArr = new int[this._arr.Length * 2];
            Array.Copy(this._arr, newArr, this._arr.Length);

            this._arr = newArr;
        }
        private void GrowIfNecessary()
        {
            if (this._arr.Length == this._count)
                this.Grow();
        }

        private void ValidateNotEmpty()
        {
            if (this._count == 0)
                throw new InvalidOperationException("The linked list is empty!!!");
        }
    }
}
