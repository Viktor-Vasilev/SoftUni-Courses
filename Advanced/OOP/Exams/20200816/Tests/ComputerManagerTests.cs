using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Computer computer = new Computer("Lenovo", "A50", 1500.50m );

            Assert.AreEqual("Lenovo", computer.Manufacturer);
            Assert.AreEqual("A50", computer.Model);
            Assert.AreEqual(1500.5m, computer.Price);
        }

        [Test]
        public void ManagerConstructorWorksCorrectlyZero()
        {
            ComputerManager cm = new ComputerManager();
            Assert.AreEqual(0, cm.Count);
        }

        [Test]
        public void ManagerConstructorWorksCorrectly()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            cm.AddComputer(computer);

            Assert.AreEqual(1, cm.Count);

        }

        [Test]
        public void AddSameComputerShouldThrowExc()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            cm.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => cm.AddComputer(computer));

        }

        [Test]
        public void AddComputerWithhNullNameShouldThrowExc()
        {
            ComputerManager cm = new ComputerManager();
           
            Assert.Throws<ArgumentNullException>(() => cm.AddComputer(null));
        }

        [Test]
        public void RemoveComputerShouldWork()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovooo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            cm.RemoveComputer("Lenovo", "A50");

            Assert.AreEqual(1, cm.Count);
        }

        [Test]
        public void RemoveComputerShouldThrowExcNonExistingComputer()
        {
            ComputerManager cm = new ComputerManager();

            Assert.Throws<ArgumentException>(() => cm.RemoveComputer("Lenovo", "A50"));
        }

        [Test]
        public void GetComputerShouldWork()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovooo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            var result = cm.GetComputer("Lenovo", "A50");

            Assert.AreEqual(computer, result);
            
        }
        [Test]
        public void GetComputerShouldThrowExcInavlidData()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovooo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);          

            Assert.Throws<ArgumentException>(() => cm.GetComputer("Lenovo", "A"));

        }

        [Test]
        public void GetComputerShouldThrowExcNullManufacturer()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovooo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => cm.GetComputer(null, "A"));

        }


        [Test]
        public void GetComputerShouldThrowExcNullModel()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovooo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => cm.GetComputer("Lenovo", null));

        }

        [Test]
        public void GetComputerByManufacturerShouldThrowExcNull()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovooo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => cm.GetComputersByManufacturer(null));

        }


        [Test]
        public void GetComputerByManufacturerShouldWork()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            var collection = cm.GetComputersByManufacturer("Lenovo");

            Assert.AreEqual(collection.Count, 2);

        }

        [Test]
        public void GetComputerByManufacturerShouldReturnZero()
        {
            ComputerManager cm = new ComputerManager();
            Computer computer = new Computer("Lenovo", "A50", 1500.50m);
            Computer computer2 = new Computer("Lenovo", "A50000", 15000.50m);

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            var collection = cm.GetComputersByManufacturer("Boza");

            Assert.AreEqual(collection.Count, 0);

        }

    }
}