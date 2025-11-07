using Raiding.Factories;
using Raiding.Models;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            HeroFactory heroFactory = new HeroFactory();
            List<BaseHero> raidGroup = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = heroFactory.Create(type,name);

                if(hero is null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }
                raidGroup.Add(hero);
            }

            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroPower = raidGroup.Sum(h => h.Power);

            if(totalHeroPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
/*
3
Mike
Paladin
Josh
Druid
Scott
Warrior
250

2
Mike
Warrior
Tom
Rogue
200
 */
