using NUnit.Framework;
using System;

namespace CarManager.Tests
{
    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("BMW", "M3", 10, 60);
        }

        // ---------- CONSTRUCTOR TESTS ----------

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("M3", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(60, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount); // private parameterless ctor sets this
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ShouldThrow_WhenMakeInvalid(string invalidMake)
        {
            Assert.Throws<ArgumentException>(() => new Car(invalidMake, "M3", 10, 60));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ShouldThrow_WhenModelInvalid(string invalidModel)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", invalidModel, 10, 60));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Constructor_ShouldThrow_WhenFuelConsumptionInvalid(double fc)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M3", fc, 60));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Constructor_ShouldThrow_WhenFuelCapacityInvalid(double cap)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M3", 10, cap));
        }

        // ---------- REFUEL TESTS ----------

        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_ShouldThrow_WhenFuelIsZeroOrNegative(double amount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(amount));
        }

        [Test]
        public void Refuel_ShouldIncreaseFuelAmount()
        {
            car.Refuel(30);
            Assert.AreEqual(30, car.FuelAmount);
        }

        [Test]
        public void Refuel_ShouldNotExceedFuelCapacity()
        {
            car.Refuel(100);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        // ---------- DRIVE TESTS ----------

        [Test]
        public void Drive_ShouldThrow_WhenFuelNotEnough()
        {
            // fuel needed = (distance/100)*consumption = 100km => 10 litres needed
            car.Refuel(5); // less than needed
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void Drive_ShouldReduceFuelCorrectly()
        {
            car.Refuel(50);   // enough fuel
            car.Drive(100);   // uses 10 litres
            Assert.AreEqual(40, car.FuelAmount);
        }

        [Test]
        public void Drive_ExactFuelAmount_ShouldWork()
        {
            car.Refuel(10); // exactly enough for 100 km
            car.Drive(100);
            Assert.AreEqual(0, car.FuelAmount);
        }
    }
}
