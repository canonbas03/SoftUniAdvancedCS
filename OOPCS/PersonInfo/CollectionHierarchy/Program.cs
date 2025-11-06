namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split();
            int removeCount = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addResults1 = new();
            List<int> addResults2 = new();
            List<int> addResults3 = new();

            foreach (var item in items)
            {
                addResults1.Add(addCollection.Add(item));
                addResults2.Add(addRemoveCollection.Add(item));
                addResults3.Add(myList.Add(item));
            }

            List<string> removeResults2 = new();
            List<string> removeResults3 = new();

            for (int i = 0; i < removeCount; i++)
            {
                removeResults2.Add(addRemoveCollection.Remove());
                removeResults3.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addResults1));
            Console.WriteLine(string.Join(" ", addResults2));
            Console.WriteLine(string.Join(" ", addResults3));
            Console.WriteLine(string.Join(" ", removeResults2));
            Console.WriteLine(string.Join(" ", removeResults3));

        }
    }
}
