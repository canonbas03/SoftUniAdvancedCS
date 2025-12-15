using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace MythicLegion.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorCorrect()
        {
            Legion legion = new Legion();

            Assert.NotNull(legion);
        }

        [Test]
        public void ConstructorShouldStartWithEmpty()
        {
            Legion legion = new Legion();
            Assert.AreEqual("No heroes in the legion.", legion.GetLegionInfo());
        }

        [Test]
        public void AddHerothrowsWhenNull()
        {
            Legion legion1 = new Legion();
            Hero hero  = null;

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { legion1.AddHero(hero); });

            Assert.AreEqual(ex.Message, $"Hero cannot be null (Parameter 'hero')");
        }

        [Test]
        public void AddHerothrowsWhenAlreadyIn()
        {
            Legion legion1 = new Legion();
            Hero hero = new Hero("a","b");
            legion1.AddHero(hero);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => { legion1.AddHero(hero); });

            Assert.AreEqual(ex.Message, $"Hero with name {hero.Name} already exists in the legion.");
        }

        [Test]
        public void AddHeroShouldIncreaseCount()
        {
            Legion legion = new Legion();
            Hero hero = new Hero("A", "B");

            legion.AddHero(hero);

            string info = legion.GetLegionInfo();
            Assert.IsTrue(info.Contains("A (B)"));
        }

        [Test]
        public void RemoveHeroFalseWhenNotIn()
        {
            Legion legion1 = new Legion();
            //Hero hero = new Hero("a", "b");
            //legion1.AddHero(hero);

            Assert.False(legion1.RemoveHero("abc"));
        }


        [Test]
        public void RemoveHeroTrueWhenIn()
        {
            Legion legion1 = new Legion();
            Hero hero = new Hero("a", "b");
            legion1.AddHero(hero);

            Assert.True(legion1.RemoveHero("a"));
        }

        [Test]
        public void TrainHeroNotFound()
        {
            Legion legion1 = new Legion();

            string result = legion1.TrainHero("a");
            Assert.AreEqual(result, $"Hero with name a not found.");
        }

        [Test]
        public void TrainHeroFound()
        {
            Legion legion1 = new Legion();
            Hero hero = new Hero("a", "b");
            legion1.AddHero(hero);

            string result = legion1.TrainHero("a");
            Assert.AreEqual(result, $"{hero.Name} has been trained.");
        }

        [Test]
        public void TrainHeroShouldUpdateAllStatsAndReturn()
        {
            Legion legion = new Legion();
            Hero hero = new Hero("A", "Warrior");
            legion.AddHero(hero);

            string result = legion.TrainHero("A");

            Assert.AreEqual("A has been trained.", result);
            Assert.AreEqual(30, hero.Power);
            Assert.AreEqual(101, hero.Health);
            Assert.IsTrue(hero.IsTrained);
        }


        [Test]
        public void GetLoginReturnsWhenEmpty()
        {
            Legion legion1 = new Legion();

            string message = legion1.GetLegionInfo();
            Assert.AreEqual(message, "No heroes in the legion.");
        }

        [Test]
        public void GetLoginReturnsWhenNotEmpty()
        {
            Legion legion1 = new Legion();
            Hero hero = new Hero("a", "b");
            legion1.AddHero(hero);

            string expected = $"a (b) - Power: 20, Health: 100, Trained: False";
            string message = legion1.GetLegionInfo();
            Assert.AreEqual(message, expected);
        }
        
    }
}