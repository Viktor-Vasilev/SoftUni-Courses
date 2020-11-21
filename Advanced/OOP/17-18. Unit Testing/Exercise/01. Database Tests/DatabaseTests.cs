using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        //ïğàâèì ñè êîëåêöèÿ, çà äà íå ÿ ïğàâèì ïîñëå íàâñÿêúäå

        //ÍÀÊĞÀß ÈÇÒĞÈÕÌÅ ÏÚÒß ÊÚÌ ÊËÀÑÀ È ÌÀÕÍÀÕÌÅ ÄÅÏÅÍÄÚÍÑÈÒÀÒÀ ÏĞÅÄÈ ÄÀ ÑÚÁÌÈÒÍÅÌ! ÑÒÀÂÀ:
        // private Database database;

        private Database.Database database; // Òóê
        private readonly int[] initialData = new int[] { 1, 2 };


        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialData); // Òóê
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int[] data = new int[] { 1, 2, };
            this.database = new Database.Database(data); // Òóê

            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenBiggerCollectio()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database.Database(data); // Òóê

            });

        }

        [Test]

        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {

            this.database.Add(3);

            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);


        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            // ïúëíèì ñè êîëåêöèÿòà

            Assert.Throws<InvalidOperationException>(() =>
            {

                // try add 17th element
                this.database.Add(17);


            });


        }

        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            int expected = 1;
            
            this.database.Remove();

            int actual = this.database.Count;


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseEmpty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {

                this.database.Remove();
            });

        }

        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database.Database(expectedData); // Òóê


            //returned copy
            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        
        
        }

    }
}