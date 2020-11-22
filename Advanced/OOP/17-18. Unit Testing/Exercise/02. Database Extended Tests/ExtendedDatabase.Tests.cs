using NUnit.Framework;
using DatabaseExtended;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorEmptyCollectionShouldReturnCountZero()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void ConstructorShouldThrowException_MoreThan16People()
        {
            Person[] people = new Person[17];
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people));
        }

        [Test]
        public void ConstructorAddOnePersonReturnCountOne()
        {
            ExtendedDatabase database = new ExtendedDatabase(new Person(1, "A"));

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void ConstructorAddOnePersonAddedCorrectly()
        {
            Person expectedResult = new Person(1, "A");
            
            ExtendedDatabase database = new ExtendedDatabase(expectedResult);

            Person actualResult = database.FindById(1);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorAddOnePersonAddedCorrectlyAllProperties()
        {
            Person expectedResult = new Person(1, "A");

            ExtendedDatabase database = new ExtendedDatabase(expectedResult);

            Person actualResult = database.FindById(1);

            Assert.AreEqual(1, actualResult.Id);
            Assert.AreEqual("A", actualResult.UserName);
        }

        [Test]
        public void AddMethodAddMoreThan16PeopleShouldThrowException()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++) //пълним си масива с различни стойности, ако е null гърми
            {
                people[i] = new Person(i + 1, $"A{i}" );
            }

            ExtendedDatabase database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(100, "BBB")));
        }

        [Test]
        public void AddMethodAddExistingPersonUserNameShouldThrowException()
        {
            
            ExtendedDatabase database = new ExtendedDatabase();
            database.Add(new Person(1, "A"));           

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "A")));
        }

        [Test]
        public void AddMethodAddExistingPersonIDShouldThrowException()
        {

            ExtendedDatabase database = new ExtendedDatabase();
            database.Add(new Person(1, "A"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "B")));
        }

        [Test]
        public void AddMethodAddPersonShouldIncreaseCount()
        {           
            ExtendedDatabase database = new ExtendedDatabase();
            Person person = new Person(1, "A");

            database.Add(person);          

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddMethodAddPersonShouldAddCorectly()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person personOne = new Person(1, "A");
            Person personTwo = new Person(2, "B");
            Person personThree = new Person(3, "C");

            database.Add(personOne);
            database.Add(personTwo);
            database.Add(personThree);

            Person actualPerson = database.FindById(2);

            Assert.AreEqual(2, actualPerson.Id);
            Assert.AreEqual("B", actualPerson.UserName);
        }

        [Test]
        public void RemoveMethodEmptyCollectionShouldThrowException()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }


        [Test]
        public void RemoveMethodSuccesfulRemoveShouldCountZero()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            database.Add(new Person(1, "A"));

            database.Remove();

            int expectedResult = 0;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodSuccesfulRemoveShouldRemoveCorrectly()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            database.Add(new Person(1, "A"));

            database.Remove();

            int expectedResult = 0;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        
        [TestCase(null)]
        [TestCase("")]
        public void FindByUserNameEmptyUserNameShouldThrowException(string name) 
        {
            ExtendedDatabase database = new ExtendedDatabase();          

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));

        }

        [Test]
        
        public void FindByUserNameEmptyCollectionShouldThrowException()
        {
            ExtendedDatabase database = new ExtendedDatabase();


            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("A"));

        }

        [Test]
        public void FindByUserNameNonEmptyCollectionWithInvalidUsernameShouldThrowException()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            database.Add(new Person(1, "B"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("A"));

        }

        [Test]
        public void FindByUserNameValidUserNameShouldReturnCorrectPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            database.Add(new Person(1, "A"));

            Person actualPerson =  database.FindByUsername("A");

            Assert.AreEqual(1, actualPerson.Id);
            Assert.AreEqual("A", actualPerson.UserName);

        }

        [Test]
        public void FindByUserIdNegativeIdShouldThrowException()
        {
            ExtendedDatabase database = new ExtendedDatabase();


            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));

        }

        [Test]
        public void FindByIdEmptyCollectionShouldThrowException()
        {
            ExtendedDatabase database = new ExtendedDatabase();


            Assert.Throws<InvalidOperationException>(() => database.FindById(1));

        }


        [Test]
        public void FindByIdNonEmptyCollectionWithInvalidIdShouldThrowException()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            database.Add(new Person(1, "B"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(2));

        }

        [Test]
        public void FindByIdValidUserNameShouldReturnCorrectPerson()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            database.Add(new Person(1, "A"));

            Person actualPerson = database.FindById(1);

            Assert.AreEqual(1, actualPerson.Id);
            Assert.AreEqual("A", actualPerson.UserName);

        }

    }
}