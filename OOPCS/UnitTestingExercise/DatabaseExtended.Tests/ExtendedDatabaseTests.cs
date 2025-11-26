namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person p1;
        private Person p2;

        [SetUp]
        public void Setup()
        {
            p1 = new Person(1, "Gosho");
            p2 = new Person(2, "Pesho");
            db = new Database(p1, p2);
        }

        // ---------------- Constructor Tests ----------------

        [Test]
        public void Constructor_ShouldAddInitialPeople()
        {
            Assert.AreEqual(2, db.Count);

            Person found = db.FindById(1);
            Assert.AreEqual(p1.UserName, found.UserName);
        }

        [Test]
        public void Constructor_ShouldThrow_WhenMoreThan16People()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(i, "User" + i);
            }

            Assert.Throws<ArgumentException>(() =>
            {
                new ExtendedDatabase.Database(persons);
            });
        }

        // ---------------- Add Tests ----------------

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            Person p3 = new Person(3, "Stoyan");
            db.Add(p3);

            Assert.AreEqual(3, db.Count);
        }

        [Test]
        public void Add_ShouldThrow_WhenFull()
        {
            // Fill it to 16
            for (int i = 3; i <= 16; i++)
            {
                db.Add(new Person(i, "User" + i));
            }

            // Now full
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(999, "Overflow"));
            });
        }

        [Test]
        public void Add_ShouldThrow_IfUsernameExists()
        {
            var duplicate = new Person(10, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(duplicate);
            });
        }

        [Test]
        public void Add_ShouldThrow_IfIdExists()
        {
            var duplicate = new Person(1, "NewUser");

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(duplicate);
            });
        }

        // ---------------- Remove Tests ----------------

        [Test]
        public void Remove_ShouldDecreaseCount()
        {
            db.Remove();

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void Remove_ShouldThrow_WhenEmpty()
        {
            db.Remove();
            db.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        // ---------------- FindByUsername Tests ----------------

        [Test]
        public void FindByUsername_ShouldReturnCorrectPerson()
        {
            Person found = db.FindByUsername("Gosho");

            Assert.AreEqual(p1.UserName, found.UserName);
            Assert.AreEqual(p1.Id, found.Id);
        }

        [Test]
        public void FindByUsername_ShouldThrow_IfUsernameNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsername_ShouldThrow_IfUserNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("NonExisting");
            });
        }

        [Test]
        public void FindByUsername_ShouldBeCaseSensitive()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("gosho"); // lowercase, should fail
            });
        }

        // ---------------- FindById Tests ----------------

        [Test]
        public void FindById_ShouldReturnCorrectPerson()
        {
            Person found = db.FindById(2);

            Assert.AreEqual(p2.UserName, found.UserName);
        }

        [Test]
        public void FindById_ShouldThrow_IfNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-1);
            });
        }

        [Test]
        public void FindById_ShouldThrow_IfNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(9999);
            });
        }
    }
}
