using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    internal class Library : IEnumerable<Book>
    {
        public List<Book> Books;

        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryIterator(List<Book>books)
            {
                this.books = books;
                Reset();
            }

            public Book Current => this.books[this.index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index++;
                if (this.index >= this.books.Count) return false;

                return true;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
