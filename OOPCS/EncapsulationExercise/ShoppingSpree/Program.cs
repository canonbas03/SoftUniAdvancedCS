namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> clients = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (string person in peopleData)
            {
                string[] personData = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string personName = personData[0];
                double personMoney = double.Parse(personData[1]);

                try
                {
                    Person client = new Person(personName, personMoney);
                    clients.Add(client);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (string good in productsData)
            {
                string[] productData = good.Split("=",StringSplitOptions.RemoveEmptyEntries);
                string productName = productData[0];
                double productPrice = double.Parse(productData[1]);

                try
                {
                    Product product = new Product(productName, productPrice);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();

                string clientName = data[0];
                string productName = data[1];

                Person person = clients.FirstOrDefault(c => c.Name == clientName);
                if (person == null)
                {
                    throw new ArgumentException("Client cannot be found");
                }

                Product product = products.FirstOrDefault(p => p.Name == productName);
                if (product == null)
                    throw new ArgumentException("Product cannot be found");



                person.BuyProduct(product);
            }

            foreach (Person client in clients)
            {
                if (client.ProductsBought.Count > 0)
                    Console.WriteLine($"{client.Name} - {string.Join(", ", client.ProductsBought.Select(p => p.Name))}");

                else
                    Console.WriteLine($"{client.Name} - Nothing bought");
            }
        }
    }
}
/*
Peter=11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END

John=-3
Peppers=1;Tomatoes=2;Cheese=3
John Peppers
John Tomatoes
John Cheese
END
 */