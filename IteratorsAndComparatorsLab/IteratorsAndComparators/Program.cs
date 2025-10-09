namespace IteratorsAndComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Hey",1998, "APT.", "Azis");
            var book2 = new Book("Skyfall",1998, "APT.");

            var library = new Library(book1,book2);

            foreach(Book book in library)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
