using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private GuildRepository guilds;
        public Controller()
        {
            heroes = new HeroRepository();
            guilds = new GuildRepository();
        }
        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != nameof(Warrior) &&
                heroTypeName != nameof(Sorcerer) &&
                heroTypeName != nameof(Spellblade))
            {
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            }

            if (heroes.GetModel(runeMark) != null)
            {
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
            }

            IHero hero;
            if (heroTypeName == nameof(Warrior))
            {
                hero = new Warrior(heroName, runeMark);
            }
            else if (heroTypeName == nameof(Sorcerer))
            {
                hero = new Sorcerer(heroName, runeMark);
            }
            else
            {
                hero = new Spellblade(heroName, runeMark);
            }

            heroes.AddModel(hero);

            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetModel(guildName) != null)
            {
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);
            }

            Guild guild = new Guild(guildName);
            guilds.AddModel(guild);

            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            IHero hero = heroes.GetModel(runeMark);
            IGuild guild = guilds.GetModel(guildName);

            if (hero == null)
            {
                return string.Format(OutputMessages.HeroNotFound, runeMark);
            }

            if (guild == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            if (hero.GuildName != null)
            {
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
            }

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildIsFallen, guildName);
            }

            if (guild.Wealth < 500)
            {
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guildName);
            }

            bool isCompatible = true;
            string heroType = hero.GetType().Name;

            if (heroType == nameof(Warrior) && guildName != "WarriorGuild" && guildName != "ShadowGuild")
            {
                isCompatible = false;
            }
            else if (heroType == nameof(Sorcerer) && guildName != "SorcererGuild" && guildName != "ShadowGuild")
            {
                isCompatible = false;
            }
            else if (heroType == nameof(Spellblade) && guildName != "WarriorGuild" && guildName != "SorcererGuild")
            {
                isCompatible = false;
            }

            if (!isCompatible)
            {
                return string.Format(OutputMessages.HeroTypeNotCompatible, heroType, guildName);
            }

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);

            return string.Format(OutputMessages.HeroRecruited, hero.Name, guildName);
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            IGuild attackerGuild = guilds.GetModel(attackerGuildName);
            IGuild defenderGuild = guilds.GetModel(defenderGuildName);
            if (attackerGuild == null || defenderGuild == null)
            {
                return OutputMessages.OneOfTheGuildsDoesNotExist;
            }

            if (attackerGuild.IsFallen || defenderGuild.IsFallen)
            {
                return OutputMessages.OneOfTheGuildsIsFallen;
            }

            IHero[] attackerGuildHeroes = heroes.GetAll().Where(h => attackerGuild.Legion.Contains(h.RuneMark)).ToArray();
            IHero[] defenderGuildHeroes = heroes.GetAll().Where(h => defenderGuild.Legion.Contains(h.RuneMark)).ToArray();

            int attackerTotalStrength = attackerGuildHeroes.Sum(h => h.Power + h.Mana + h.Stamina);
            int defenderTotalStrength = defenderGuildHeroes.Sum(h => h.Power + h.Mana + h.Stamina);

            string message;
            if (attackerTotalStrength > defenderTotalStrength)
            {
                int goldAmount = defenderGuild.Wealth;
                attackerGuild.WinWar(goldAmount);
                defenderGuild.LoseWar();

                message = string.Format(OutputMessages.WarWon, attackerGuildName, defenderGuildName, goldAmount);
            }
            else
            {
                int goldAmount = attackerGuild.Wealth;
                defenderGuild.WinWar(goldAmount);
                attackerGuild.LoseWar();

                message = string.Format(OutputMessages.WarLost, defenderGuildName, goldAmount, attackerGuildName);
            }

            return message;
        }

        public string TrainingDay(string guildName)
        {
            IGuild guild = guilds.GetModel(guildName);
            if (guild == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);
            }

            int totalCost = guild.Legion.Count * 200;
            if (guild.Wealth < totalCost)
            {
                return string.Format(OutputMessages.TrainingDayFailed, guildName);
            }

            IHero[] allGuildHeroes = heroes.GetAll().Where(h => guild.Legion.Contains(h.RuneMark)).ToArray();

            guild.TrainLegion(allGuildHeroes);

            return string.Format(OutputMessages.TrainingDayStarted, guildName, allGuildHeroes.Length, totalCost);
        }

        public string ValorState()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Valor State:");

            // maybe the secon is unnecessary
            foreach (IGuild guild in guilds.GetAll().OrderByDescending(g => g.Wealth))
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

                IHero[] allHeroes = heroes.GetAll().Where(h => guild.Legion.Contains(h.RuneMark)).OrderBy(h => h.Name).ToArray();

                foreach (IHero hero in allHeroes)
                {
                    sb.AppendLine($"-Hero: [{hero.Name}] of the Guild '{guild.Name}' - RuneMark: {hero.RuneMark}");
                    sb.AppendLine($"--Essence Revealed - Power [{hero.Power}] Mana [{hero.Mana}] Stamina [{hero.Stamina}]");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
