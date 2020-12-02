namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]

    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectlyAllProperties()
        {
            string name = "Strange";
            int capacity = 10;

            Aquarium aquarium = new Aquarium(name, capacity);

            string expectedName = "Strange";
            int expectedCapacity = 10;

            string actualName = aquarium.Name;
            int actualCapacity = aquarium.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }


        [Test]
        public void SetNameSouldThrowExceptionWhenItIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(String.Empty, 10));
        }

        [Test]
        public void SetCapacityShouldThrowExceptionWhenItIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Strange", -10));

        }

        [Test]
        public void AddFishShouldAddFishInAquariumWhenCapacityIsValid()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddFishShouldThrowExceptionWhenCapacityIsInvalid()
        {
            Fish fish = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Aquarium aquarium = new Aquarium("Strange", 1);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
        }

        [Test]
        public void RemoveFishShouldRemoveFishFromAquariumW()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionWhenNameIsNotFound() // нема нужда да правим риба - виж по-надолу проверката на sell метода
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Nemooooooo"));
        }

        [Test]
        public void SellFishShouldSetAvailablePropertyToFalse()
        {
            Fish fish = new Fish("Nemo");
            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);

            Fish soldfish = aquarium.SellFish("Nemo");

            var expectedAvailability = false;

            Assert.AreEqual(expectedAvailability, soldfish.Available);

        }

        [Test]
        public void SellFishShouldThrowExceptionWhenNameIsNotFound() // тук
        {
            Aquarium aquarium = new Aquarium("Strange", 10);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Nemooooooo"));
        }

        [Test]
        public void ValidateReportMessage()
        {
            Fish fish = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");

            Aquarium aquarium = new Aquarium("Strange", 10);

            aquarium.Add(fish);
            aquarium.Add(fish2);

            string expectedResult = "Fish available at Strange: Nemo, Nemo2";
            string actualResult = aquarium.Report();

            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
