namespace _08.SoftuniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vipGuests = new HashSet<string>();
            var regularGuests = new HashSet<string>();
            bool isParty = false;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    isParty = true;
                    continue;
                }
                else if(isParty)
                {
                    vipGuests.Remove(input);
                    regularGuests.Remove(input);
                }
                else
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                }
            }
            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
