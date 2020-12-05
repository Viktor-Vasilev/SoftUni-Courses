namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;
        private const string make = "Samsung";
        private const string model = "S10+";

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(make, model);
        }




        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(make, this.phone.Make);
            Assert.AreEqual(model, this.phone.Model);
        }


        [Test]
        public void TestWithEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => { Phone phone = new Phone(String.Empty, model); });
        }

        [Test]
        public void TestWithEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => { Phone phone = new Phone(make, String.Empty); });
        }

        [Test]
        public void InitialCountShouldBeZero()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.phone.Count);

        }
        [Test]
        public void TestIfAddWorksCorrectly()
        {
            int expectedCount = 2;

            this.phone.AddContact("Pesho", "+359888888");
            this.phone.AddContact("Gosho", "+359999999");

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestIfAddingExistingPersonThrowsException()
        {
            this.phone.AddContact("Pesho", "+359888888");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Pesho", "+359888888"));
        }

        [Test]
        public void AddShouldAddCallableNumber()
        {
           
            string name = "Pesho";
            string number = "+359888888";
            this.phone.AddContact(name, number);

            string expectedOutput = $"Calling {name} - {number}...";

            string actualOutput = this.phone.Call(name);

            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [Test]
        public void TestCallingInexistingPErson()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Pesho"));
        }

    }


}
