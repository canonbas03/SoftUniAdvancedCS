namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> bankAccountByNumber = new Dictionary<int, double>();
            string[] bankAccountsData = Console.ReadLine().Split(",");

            foreach (string bankAccountData in bankAccountsData)
            {
                string[] bankTokens = bankAccountData.Split("-");

                int accountNumber = int.Parse(bankTokens[0]);
                double balance = double.Parse(bankTokens[1]);

                bankAccountByNumber[accountNumber] = balance;
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = command.Split();

                    string action = tokens[0];
                    int accNumber = int.Parse(tokens[1]);
                    double amount = double.Parse(tokens[2]);

                    if (action == "Deposit")
                    {
                        bankAccountByNumber[accNumber] += amount;
                    }
                    else if (action == "Withdraw")
                    {
                        if (bankAccountByNumber[accNumber] < amount)
                        {
                            throw new Exception("Insufficient balance!");
                        }

                        bankAccountByNumber[accNumber] -= amount;
                    }
                    else
                    {
                        throw new Exception("Invalid command!");
                    }

                    Console.WriteLine($"Account {accNumber} has new balance: {bankAccountByNumber[accNumber]:f2}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter another command");
            }
        }
    }
}