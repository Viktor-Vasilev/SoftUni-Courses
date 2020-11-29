namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorSetCorrectName()
        {
            Computer computer = new Computer("a");

            Assert.AreEqual("a", computer.Name);
        }

        [Test]
        public void ConstructorPartsCollectionIsEmpty()
        {
            Computer computer = new Computer("a");

            Assert.IsEmpty(computer.Parts);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NameEmptyValueShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void PartsAddTwoPartsShoulsAddTwoParts()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("b", 1));
            computer.AddPart(new Part("e", 1));

            Assert.AreEqual(2, computer.Parts.Count);
        }

        [Test]
        public void TotalPriceShouldReturnCorrectResult()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("b", 1));
            computer.AddPart(new Part("e", 2));
            computer.AddPart(new Part("t", 3));

            Assert.AreEqual(6, computer.TotalPrice);
        }

        [Test]
        public void AddPartMethodNullPartShouldThrowWxception()
        {
            Computer computer = new Computer("a");

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }



        [Test]
        public void AddPArtMethodShouldAddPart()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("b", 1));
            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        public void AddPArtMethodShouldAddCorrectPart()
        {
            Computer computer = new Computer("a");
            computer.AddPart(new Part("b", 1));

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "b");

            Assert.IsNotNull(actualPart);
            Assert.AreEqual("b", actualPart.Name);
        }

        [Test]
        public void RemovePArtMethodShouldRemovePartSuccessfully()
        {
            Computer computer = new Computer("a");

            Part part = new Part("b", 1);

            computer.AddPart(part);

            computer.RemovePart(part);

            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void RemovePArtMethodValidPartShouldReturnTrue()
        {
            Computer computer = new Computer("a");

            Part part = new Part("b", 1);

            computer.AddPart(part);

            bool actualRes = computer.RemovePart(part);

            Assert.IsTrue(actualRes);
        }

        [Test]
        public void RemovePArtMethodInValidPartShouldReturnTrue()
        {
            Computer computer = new Computer("a");

            Part part = new Part("b", 1);
            Part partTwo = new Part("q", 1);

            computer.AddPart(part);

            bool actualRes = computer.RemovePart(partTwo);

            Assert.IsFalse(actualRes);
        }

        [Test]
        public void RemovePArtMethodShouldRemoveCorrectPart()
        {
            Computer computer = new Computer("a");

            Part part = new Part("b", 1);

            computer.AddPart(part);

            computer.RemovePart(part);

            Part actualPart = computer.Parts.FirstOrDefault(p => p.Name == "b");

            Assert.IsNull(actualPart);
            
        }

        [Test]
        public void GetPartMethodValidPartShouldRemoveCorrectPart()
        {
            Computer computer = new Computer("a");

            Part part = new Part("b", 1);

            computer.AddPart(part);

            Part actualPart = computer.GetPart("b");

            Assert.AreEqual("b", actualPart.Name);
            Assert.AreEqual(1, actualPart.Price);
        }

        [Test]
        public void GetPartMethodInValidPartShouldReturnNull()
        {
            Computer computer = new Computer("a");

            Part part = new Part("b", 1);

            computer.AddPart(part);

            Part actualPart = computer.GetPart("q");

            Assert.IsNull(actualPart);
        }

    }
}
