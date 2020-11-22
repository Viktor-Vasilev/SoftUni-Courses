//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {

        private Car car;

        [SetUp]
        public void Setup()
        {
            
        }

        // Constructor

        [Test]
        public void ConstructorShouldInitializeCarMakeCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;

            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;


            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        
        [Test]
        public void TestWithLikeNullName()
        {
            string expectedMake = null;
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);
            });
        }


        [Test]
        public void TestWithLikeEmptyName()
        {
            string expectedMake = String.Empty;
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;


            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);
            });
        }

        // Model
        [Test]
        
        public void ConstructorShouldInitializeCarModelCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;

            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);
            Assert.AreEqual(expectedModel, car.Model);
        }

        [Test]
        [TestCase("Audi", "", 6.5, 60)]
        [TestCase("Audi", null, 6.5, 60)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetModelValueToNullOrEmpty(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        // Fuel Consumption

        [Test]
       
        public void ConstructorShouldInitializeCarFuelConsumptionCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;

            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
        }

        [Test]
        [TestCase("Audi", "A6", 0, 60)]
        [TestCase("Audi", "A6", -100, 60)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetFuelConsumptionValueZeroOrLess(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        // Fuel Capacity

        [Test]
        public void ConstructorShouldInitializeCarFuelCapacityCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;

            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase("Audi", "A6", 6.5, 0)]
        [TestCase("Audi", "A6", 6.5, -100)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetFuelCapacityValueZeroOrLess(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        // METHODS!!!!!!!!!!!!!!!!

        // Refuel
        [Test]
        [TestCase(0)]
        [TestCase(-10.5)]
        public void RefuelOperationShouldThrowArgumentExceptionInAttemptToRefuelWithValueLessThanOrEqualToZero(double fuel)
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuel);
            });
        }

        [Test]
        [TestCase(0.5)]
        [TestCase(11)]
        [TestCase(59.5)]
        public void RefuelOperationShouldSetFuelAmountCorrectly(double fuel)
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            car.Refuel(fuel);
            Assert.AreEqual(fuel, car.FuelAmount);

        }

        [Test]
        [TestCase(60.5)]
        [TestCase(90)]
        public void RefuelOperationShouldSetFuelAmountCorrectlyWhenRefuelingOverflows(double fuel)
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            car.Refuel(fuel);
            double expectedFuelAmount = 60;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        // Drive
        [Test]
        
        public void DriveOperationShouldThrowInvalidOperationExceptionInAttemptToDriveABiggerDistanceWhenFuelIsNotEnough()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            car.Refuel(60);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(5000);
            });
          
        }

        [Test]
        
        public void DriveOperationShouldDecrementFuelAmountCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A6";
            double expectedFuelConsumption = 6.5;
            double expectedFuelCapacity = 60;
            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            car.Refuel(60);

            double distance = 100;

            car.Drive(distance);

            double expectedFuelAmount = 53.5;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

    }
}