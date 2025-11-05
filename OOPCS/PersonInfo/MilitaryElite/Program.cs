using MilitaryElite.Models;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class Program
    {
        private static Dictionary<int, ISoldier> soldiers =
            new Dictionary<int, ISoldier>();

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(ProcessInput(tokens));
                }
                catch
                {
                    // ignore invalid entries
                }
            }
        }

        private static string ProcessInput(string[] tokens)
        {
            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];

            ISoldier soldier = soldierType switch
            {
                "Private" => GetPrivate(id, firstName, lastName, decimal.Parse(tokens[4])),
                "LieutenantGeneral" => GetLieutenantGeneral(id, firstName, lastName, tokens),
                "Engineer" => GetEngineer(id, firstName, lastName, tokens),
                "Commando" => GetCommando(id, firstName, lastName, tokens),
                "Spy" => GetSpy(id, firstName, lastName, int.Parse(tokens[4])),
                _ => null
            };

            if (soldier != null)
                soldiers.Add(id, soldier);

            return soldier?.ToString();
        }

        private static ISoldier GetPrivate(int id, string firstName, string lastName, decimal salary)
            => new Private(id, firstName, lastName, salary);

        private static ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, string[] tokens)
        {
            decimal salary = decimal.Parse(tokens[4]);
            List<IPrivate> privates = new();

            for (int i = 5; i < tokens.Length; i++)
            {
                int privateId = int.Parse(tokens[i]);
                if (soldiers.ContainsKey(privateId))
                    privates.Add((IPrivate)soldiers[privateId]);
            }

            return new LieutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private static ISoldier GetEngineer(int id, string firstName, string lastName, string[] tokens)
        {
            decimal salary = decimal.Parse(tokens[4]);

            if (!Enum.TryParse(tokens[5], out Corps corps))
                throw new Exception();

            List<IRepair> repairs = new();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                repairs.Add(new Repair(tokens[i], int.Parse(tokens[i + 1])));
            }

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private static ISoldier GetCommando(int id, string firstName, string lastName, string[] tokens)
        {
            decimal salary = decimal.Parse(tokens[4]);

            if (!Enum.TryParse(tokens[5], out Corps corps))
                throw new Exception();

             List<IMission> missions = new();

            for (int i = 6; i < tokens.Length; i += 2)
            {
                if (Enum.TryParse(tokens[i + 1], out State state))
                    missions.Add(new Mission(tokens[i], state));
            }

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }

        private static ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
            => new Spy(id, firstName, lastName, codeNumber);
    }
}
/*
Private 1 Peter Johnson 22,22
Commando 13 Sam Peterson 13,1 Airforces
Private 222 Tony Samthon 80,08
LieutenantGeneral 3 George Stevenson 100 222 1
End
 */