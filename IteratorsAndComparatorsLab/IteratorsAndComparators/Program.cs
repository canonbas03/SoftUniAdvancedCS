namespace IteratorsAndComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Bey",1998, "APT.", "Azis");
            var book2 = new Book("Skyfall",1997, "APT.");
            var book3 = new Book("Akyfall",1990, "APT.");

            var library = new Library(book1,book2);

            foreach(Book book in library)
            {
                Console.WriteLine(book.Title);
            }

            SortedSet<Book> books = new SortedSet<Book>()
            {
                book1, book2, book3
            };

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
