using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            // Arrange
            var axe = new Axe(10, 100);
            var dummy = new Dummy(100, 100);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttacked()
        {

            // Arrange
            var axe = new Axe(10, 100);
            var dummy = new Dummy(0, 100);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                axe.Attack(dummy);
            }, "Dummy geberdi bebeim");
        }

        [Test]
        public void DeadDummyShouldGiveXp()
        {
            // Arrange
            var dummy = new Dummy(0, 100);

            // Act
            var result = dummy.GiveExperience();

            // Assert
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void AliveDummyShouldNotGiveXp()
        {
            // Arrange
            var dummy = new Dummy(100, 100);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                dummy.GiveExperience();
            }, "Target is not dead.");
        }
    }
}