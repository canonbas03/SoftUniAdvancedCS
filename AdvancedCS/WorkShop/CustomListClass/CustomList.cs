using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    internal class CustomList
    {
        private int[] _arr;
        private const int InitialCapacity = 2;
        private int _count;
        public int Count => this._count;

        public CustomList() : this(InitialCapacity)
        {
        }

        public CustomList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than 0!!!");
            }
            this._arr = new int[size];
        }

        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._arr[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._arr[index] = value;
            }
        }

        public void Add(int element)
        {
            this.GrowIfNecessary();

            this._arr[_count] = element;
            this._count++;
        }
        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this._count - 1; i++)
            {
                this._arr[i] = this._arr[i + 1];
            }
            this._arr[this._count - 1] = default;
            this._count--;
        }

        public void InsertAt(int index, int value)
        {
            if (index == this._count) Add(value);
            else
            {
                this.ValidateIndex(index);
                this.GrowIfNecessary();

                for (int i = this._count - 1; i >= index; i--)
                {
                    this._arr[i + 1] = this._arr[i];
                }
                this._arr[index] = value;
                this._count++;
            }
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

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this._count)
                throw new IndexOutOfRangeException($"Index must be in [0, {this._count - 1}]!!!");
        }
    }
}
