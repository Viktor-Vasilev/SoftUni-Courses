namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]

        public void SetUp()
        {
            this.bag = new Bag();
        }

        [Test]
        public void TestIfPresentCtorWorksCorrectly() // конструктора на Present
        {
            string expName = "Stick";
            double expMagic = 100;

            Present present = new Present(expName, expMagic);

            Assert.AreEqual(expName, present.Name);
            Assert.AreEqual(expMagic, present.Magic);
        }

        [Test]
        public void TestIfBagCtorWorksCorrectly() //проверяваме дали колекцията не е празна
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag.GetPresents());      
        }

        [Test]
        public void CreateShouldThrowExceptionWithNullPresent()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CreateShouldThrowExceptionWithSamePresent()
        {
            Present present = new Present("Stick", 100);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }


        [Test]
        public void CreateShouldAddPresentCorrectly()
        {
            Present present = new Present("Stick", 100);
            Present present2 = new Present("Stickkkk", 10000);

            bag.Create(present);
            bag.Create(present2);

            IReadOnlyCollection<Present> exp = new List<Present>() { present, present2 };
            IReadOnlyCollection<Present> act = bag.GetPresents();

            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void CreateShouldReturnCorrectMessage()
        {
            Present present = new Present("Stick", 100);
           
            string exp = $"Successfully added present {present.Name}.";
            string res = bag.Create(present);

            Assert.AreEqual(exp, res);
        }


        [Test]
        public void RemoveShouldRemovePresent()
        {
            Present present = new Present("Stick", 100);
            Present present2 = new Present("Stickkkk", 10000);

            bag.Create(present);
            bag.Create(present2);

            bool res = bag.Remove(present);

            IReadOnlyCollection<Present> exp = new List<Present> { present2 };

            IReadOnlyCollection<Present> act = bag.GetPresents();

            CollectionAssert.AreEqual(exp, act); 
            Assert.IsTrue(res); //дали е премахнат

        }

        [Test]
        public void TryRemovingNonExistingPresentShouldReturnFalse()
        {
            Present present = new Present("Stick", 100);


            bool result = bag.Remove(present);

            Assert.IsFalse(result);

        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkCorrectly()
        {
            Present present = new Present("Stick", 100);
            Present present2 = new Present("Stickkkk", 10000);
            Present expected = new Present("Stickkkkkkkkkk", 10);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(expected);

            Present act = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expected, act);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldThrowExceptionWhenBagEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => bag.GetPresentWithLeastMagic());          
        }

        [Test]
        public void GetPresentShouldReturnCorrectWhenNoDuplicates()
        {
            string expName = "Stick";
            
            Present exp = new Present(expName, 100);
            Present present2 = new Present("Stickkkk", 10000);


            bag.Create(exp);
            bag.Create(present2);

            Present act = bag.GetPresent(expName);

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void GetPresentShouldReturnFirstPresentWhenDuplicates()
        {
            string name = "Stick";
            double magic = 100;

            Present present = new Present(name, magic);
            Present present2 = new Present(name, magic);

            bag.Create(present);
            bag.Create(present2);

            Present act = bag.GetPresent(name);

            Assert.AreEqual(present, act);
        }

        [Test]
        public void GetPresentShouldReturnNullWhenNameNotExisting()
        {
            string name = "Stick";
            double magic = 100;

            Present present = new Present(name, magic);
            Present present2 = new Present(name, magic);

            bag.Create(present);
            bag.Create(present2);

            string invalidName = "Nema";

            Present act = bag.GetPresent(invalidName);

            Assert.IsNull(act);
        }
    }
}
