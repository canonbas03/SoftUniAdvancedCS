namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2, 3);
        }

        // ---------- Constructor Tests ----------

        [Test]
        public void Constructor_ShouldStoreElementsCorrectly()
        {
            int[] expected = { 1, 2, 3 };
            int[] actual = database.Fetch();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Constructor_ShouldSetCountCorrectly()
        {
            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void Constructor_ShouldThrow_IfMoreThan16ElementsArePassed()
        {
            int[] tooMany = new int[17];

            Assert.Throws<InvalidOperationException>(() =>
            {
                new Database(tooMany);
            });
        }

        // ---------- Add Tests ----------

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            database.Add(4);

            Assert.AreEqual(4, database.Count);
        }

        [Test]
        public void Add_ShouldAddElementToEnd()
        {
            database.Add(4);
            int[] expected = { 1, 2, 3, 4 };

            Assert.AreEqual(expected, database.Fetch());
        }

        [Test]
        public void Add_ShouldThrow_WhenAdding17thElement()
        {
            database = new Database(
                1, 2, 3, 4, 5, 6, 7, 8,
                9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });
        }

        // ---------- Remove Tests ----------

        [Test]
        public void Remove_ShouldDecreaseCount()
        {
            database.Remove();

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void Remove_ShouldRemoveLastElement()
        {
            database.Remove();
            int[] expected = { 1, 2 };

            Assert.AreEqual(expected, database.Fetch());
        }

        [Test]
        public void Remove_ShouldThrow_WhenDatabaseIsEmpty()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        // ---------- Fetch Tests ----------

        [Test]
        public void Fetch_ShouldReturnCopy()
        {
            int[] copy = database.Fetch();
            copy[0] = 99;

            Assert.AreNotEqual(copy, database.Fetch());
        }

        [Test]
        public void Fetch_ShouldReturnSameElements()
        {
            int[] expected = { 1, 2, 3 };

            Assert.AreEqual(expected, database.Fetch());
        }
    }
}
