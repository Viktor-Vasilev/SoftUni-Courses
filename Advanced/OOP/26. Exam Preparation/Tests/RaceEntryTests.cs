using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverExcWithInvalidData()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

        }

        [Test]
        public void AddDriverExcWithExistingDriver()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);

            var unidDriver = new UnitDriver("Gosho", unitCar);

            raceEntry.AddDriver(unidDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unidDriver));

        }

        [Test]
        public void AddDriverShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);

            var unidDriver = new UnitDriver("Gosho", unitCar);

            var result = raceEntry.AddDriver(unidDriver);

            Assert.AreEqual("Driver Gosho added in race.", result);
            Assert.AreEqual(1, raceEntry.Counter);

        }


        [Test]
        public void CalcExcWhenPartNotEnough()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);

            var unidDriver = new UnitDriver("Gosho", unitCar);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());



        }

        [Test]
        
        public void CalcShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("Vw", 100, 15670);
            var unidDriver = new UnitDriver("Gosho", unitCar);

            var unitCar2 = new UnitCar("BMW", 100, 156760);
            var unidDriver2 = new UnitDriver("Ivan", unitCar);

            var unitCar3 = new UnitCar("Lada", 100, 1890);
            var unidDriver3 = new UnitDriver("Stoyan", unitCar);

            raceEntry.AddDriver(unidDriver);
            raceEntry.AddDriver(unidDriver2);
            raceEntry.AddDriver(unidDriver3);

            var result = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(100, result);
        }

    }
}