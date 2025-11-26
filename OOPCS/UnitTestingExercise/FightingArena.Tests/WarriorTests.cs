using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Gosho", 50, 100);
        }

        // ---------- CONSTRUCTOR ----------

        [Test]
        public void Constructor_ShouldSetAllFieldsCorrectly()
        {
            Assert.AreEqual("Gosho", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        // ---------- NAME VALIDATION ----------

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Name_ShouldThrow_WhenInvalid(string invalid)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(invalid, 10, 100));
        }

        // ---------- DAMAGE VALIDATION ----------

        [TestCase(0)]
        [TestCase(-10)]
        public void Damage_ShouldThrow_WhenZeroOrNegative(int dmg)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", dmg, 100));
        }

        // ---------- HP VALIDATION ----------

        [TestCase(-1)]
        [TestCase(-100)]
        public void HP_ShouldThrow_WhenNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 10, hp));
        }

        // ---------- ATTACK VALIDATION ----------

        [Test]
        public void Attack_ShouldThrow_WhenAttackerHpIs30OrLower()
        {
            Warrior attacker = new Warrior("A", 40, 30);
            Warrior defender = new Warrior("D", 20, 80);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrow_WhenDefenderHpIs30OrLower()
        {
            Warrior attacker = new Warrior("A", 40, 50);
            Warrior defender = new Warrior("D", 10, 30);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrow_WhenEnemyIsTooStrong()
        {
            Warrior attacker = new Warrior("A", 10, 40);
            Warrior defender = new Warrior("D", 50, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        // ---------- SUCCESSFUL ATTACK ----------

        [Test]
        public void Attack_ShouldReduceAttackerHpByEnemyDamage()
        {
            Warrior attacker = new Warrior("A", 30, 100);
            Warrior defender = new Warrior("D", 20, 100);

            attacker.Attack(defender);

            Assert.AreEqual(80, attacker.HP);
        }

        [Test]
        public void Attack_ShouldReduceDefenderHpByAttackerDamage()
        {
            Warrior attacker = new Warrior("A", 30, 100);
            Warrior defender = new Warrior("D", 20, 100);

            attacker.Attack(defender);

            Assert.AreEqual(70, defender.HP);
        }

        [Test]
        public void Attack_ShouldSetDefenderHpToZero_WhenDamageIsFatal()
        {
            Warrior attacker = new Warrior("A", 150, 100);
            Warrior defender = new Warrior("D", 20, 80);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }
    }
}
