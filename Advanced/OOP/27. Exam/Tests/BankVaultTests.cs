using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankvolt;

        [SetUp]
        public void Setup()
        {
            this.bankvolt = new BankVault();
        }

        [Test]
        public void AddInvalid1()
        {
            Assert.Throws<ArgumentException>(
                 () => this.bankvolt.AddItem("D1", new Item("", "")));

        }

        [Test]
        public void AddInvalid2()
        {
            this.bankvolt.AddItem("A1", new Item("BMW", "ABC123"));

            Assert.Throws<ArgumentException>(
                () => this.bankvolt.AddItem("A1", new Item("Audi", "DEF456")));
        }

        [Test]
        public void AddInvalid3()
        {
            var item = new Item("BMW", "ABC123");

            this.bankvolt.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(
                () => this.bankvolt.AddItem("B1", item));
        }

        [Test]
        public void AddSuccessfulReturnMessage()
        {
            var itemID = "ABC123";
            var item = new Item("BMW", itemID);

            var actualResult = this.bankvolt.AddItem("A1", item);
            var expectedResult = $"Item:{item.ItemId} saved successfully!";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveInvalid1()
        {
            Assert.Throws<ArgumentException>(
                () => this.bankvolt.RemoveItem("D1", new Item("", "")));
        }

        [Test]
        public void RemoveInvalid2()
        {
            this.bankvolt.AddItem("A1", new Item("sad", "asdasd"));

            Assert.Throws<ArgumentException>(
                () => this.bankvolt.RemoveItem("A1", new Item("", "")));
        }

        [Test]
        public void SuccessfulRemoveMessage()
        {
            var item = new Item("BMW", "ABC123");

            this.bankvolt.AddItem("A1", item);

            var actualResult = this.bankvolt.RemoveItem("A1", item);
            var expectedResult = $"Remove item:{item.ItemId} successfully!";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(bankvolt.VaultCells["A1"], Is.EqualTo(null));
        }


    }
}