
using Moq;

namespace FakeAxeAndDummy.Tests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsXPWhenTargetIsDead()
        {
            // Arrange
            var targetMock = new Mock<ITarget>();

            targetMock
                .Setup(t => t.IsDead())
                .Returns(true);

            targetMock
                .Setup(t => t.GiveExperience())
                .Returns(250);

            var weaponMock = new Mock<IWeapon>();

            var hero = new Hero("testHero", weaponMock.Object);

            // Act 
            hero.Attack(targetMock.Object);

            // Assert
            Assert.That(hero.Experience == 250);
        }
    }
}
