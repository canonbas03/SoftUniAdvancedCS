using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior w2;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            w1 = new Warrior("Gosho", 30, 100);
            w2 = new Warrior("Pesho", 20, 100);
        }

        // ---------- CONSTRUCTOR ----------

        [Test]
        public void Constructor_ShouldInitializeWarriorCollection()
        {
            Assert.AreEqual(0, arena.Count);
            Assert.IsNotNull(arena.Warriors);
        }

        // ---------- ENROLL ----------

        [Test]
        public void Enroll_ShouldAddWarrior()
        {
            arena.Enroll(w1);
            Assert.AreEqual(1, arena.Count);
            Assert.IsTrue(arena.Warriors.Contains(w1));
        }

        [Test]
        public void Enroll_ShouldThrow_WhenWarriorWithSameNameExists()
        {
            arena.Enroll(w1);
            Warrior duplicate = new Warrior("Gosho", 10, 50);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(duplicate));
        }

        // ---------- FIGHT ----------

        [Test]
        public void Fight_ShouldThrow_WhenAttackerNotFound()
        {
            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
                arena.Fight("Missing", "Gosho"));
        }

        [Test]
        public void Fight_ShouldThrow_WhenDefenderNotFound()
        {
            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
                arena.Fight("Gosho", "Missing"));
        }

        [Test]
        public void Fight_ShouldCallAttackOnWarriors()
        {
            arena.Enroll(w1);
            arena.Enroll(w2);

            arena.Fight("Gosho", "Pesho");

            Assert.AreEqual(80, w1.HP); // attacker loses defender damage (20)
            Assert.AreEqual(70, w2.HP); // defender loses attacker damage (30)
        }
    }
}
