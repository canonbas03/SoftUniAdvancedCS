using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        [Test]
        public void ConstructorShouldInitializeWithValidCapacity()
        {
            DealerShop dealerShop = new DealerShop(5);

            Assert.AreEqual(dealerShop.Capacity, 5);
            Assert.IsNotNull(dealerShop);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void SetCapacityShouldThrowIfNegativeOrZero(int capacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new DealerShop(capacity));

            Assert.AreEqual(exception.Message, "Capacity must be a positive value.");
        }

        [Test]
        public void AddVehicleShouldAddWhenIsNotFull()
        {
            DealerShop dealerShop = new DealerShop(5);
            Vehicle vehicle = new Vehicle("make","model",2003);

            string returnMessage = dealerShop.AddVehicle(vehicle);

            Assert.AreEqual(dealerShop.Vehicles.Count,1);

            Assert.AreEqual(returnMessage, $"Added {vehicle}");
        }

        [Test]
        public void AddVehicleShouldThrowWhenIsFull()
        {
            DealerShop dealerShop = new DealerShop(3);

            Vehicle vehicle1 = new Vehicle("make", "model", 2003);
            dealerShop.AddVehicle(vehicle1);
            Vehicle vehicle2 = new Vehicle("make", "model", 2003);
            dealerShop.AddVehicle(vehicle2);
            Vehicle vehicle3 = new Vehicle("make", "model", 2003);
            dealerShop.AddVehicle(vehicle3);

            Vehicle vehicle4 = new Vehicle("make", "model", 2003);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => dealerShop.AddVehicle(vehicle4));

            Assert.AreEqual(exception.Message, "Inventory is full");
        }

        [Test]
        public void SellVehicleReturnsFalseWhenNotContainVehicle()
        {
            DealerShop dealerShop = new(5);
            Vehicle vehicle = new Vehicle("make", "model", 2003);

            Assert.IsFalse(dealerShop.SellVehicle(vehicle));
        }

        [Test]
        public void SellVehicleReturnsTrueWhenContainsVehicle()
        {
            DealerShop dealerShop = new(5);
            Vehicle vehicle = new Vehicle("make", "model", 2003);
            dealerShop.AddVehicle(vehicle);

            Assert.IsTrue(dealerShop.SellVehicle(vehicle));
            Assert.AreEqual(dealerShop.Vehicles.Count, 0);
        }

        [Test]
        public void ToStringReturnsCorrectMessage()
        {
            DealerShop dealerShop = new(5);
            Vehicle vehicle1 = new Vehicle("make", "model", 2003);
            dealerShop.AddVehicle(vehicle1);
            Vehicle vehicle2 = new Vehicle("make", "model", 2004);
            dealerShop.AddVehicle(vehicle2);

            string actualResult = dealerShop.InventoryReport();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report");
            sb.AppendLine($"Capacity: {5}");
            sb.AppendLine($"Vehicles: {2}");
            sb.AppendLine("2003 make model");
            sb.AppendLine("2004 make model");

            string expectedResult = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
