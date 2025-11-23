using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            // Arrange
            var axe = new Axe(10, 100);
            var dummy = new Dummy(100, 100);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(99));
            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]
        public void AxeShouldNotAttackWhenBroken()
        {
            // Arange
            var axe = new Axe(10, -5);
            var dummy = new Dummy(100, 100);


            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                axe.Attack(dummy);
            },"Axe is broken");
        }
    }
}