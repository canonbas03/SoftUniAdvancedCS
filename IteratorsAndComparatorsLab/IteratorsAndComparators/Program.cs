namespace IteratorsAndComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("ABook",1998, "APT.", "Azis");
            var book2 = new Book("BBook",1997, "APT.");
            var book3 = new Book("BBook",1990, "APT.");
            var book4 = new Book("BBook",1993, "APT.");

            var library = new Library(book1,book2,book3,book4);

            foreach(Book book in library)
            {
                Console.WriteLine(book);
            }

           
        }
    }
}
