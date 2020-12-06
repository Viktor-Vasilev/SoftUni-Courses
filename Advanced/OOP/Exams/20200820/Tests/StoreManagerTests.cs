using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]


        public void ConstructorWorksCorrectly()
        {
            Product product = new Product("Lenovo", 100, 1500.50m);

            Assert.AreEqual("Lenovo", product.Name);
            Assert.AreEqual(100, product.Quantity);
            Assert.AreEqual(1500.5m, product.Price);
        }

        [Test]
        public void ManagerConstructorWorksCorrectly()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1500.50m);
            sm.AddProduct(product);

            Assert.AreEqual(1, sm.Count);

        }


        [Test]
        public void AddProductShgouldThrowNullExceptionWhenAddingNullProduct()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1500.50m);
            sm.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() => sm.AddProduct(null));

        }

        [Test]
        public void AddProductShgouldThrowNullExceptionWhenAddingNegativeQuantity()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", -100, 1500.50m);
           

            Assert.Throws<ArgumentException>(() => sm.AddProduct(product));

        }

        [Test]
        public void BuyProductShgouldThrowExcNullName()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1500.50m);
            Product product2 = new Product("Lenovoooooo", 100000, 150000.50m);

            sm.AddProduct(product);
            sm.AddProduct(product2);    

            Assert.Throws<ArgumentNullException>(() => sm.BuyProduct(null, 10));
        }

        [Test]
        public void BuyProductShgouldThrowExcQuantity()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1500.50m);
            Product product2 = new Product("Lenovoooooo", 100000, 150000.50m);

            sm.AddProduct(product);
            sm.AddProduct(product2);

            Assert.Throws<ArgumentException>(() => sm.BuyProduct("Lenovo", 10000000));
        }

        //[Test]
        //public void BuyProductFinalPriceShouldBeCorrect()
        //{
        //    StoreManager sm = new StoreManager();
        //    Product product = new Product("Lenovo", 100, 1500m);
        //    Product product2 = new Product("Lenovoooooo", 100000, 150000.50m);

        //    sm.AddProduct(product);
        //    sm.AddProduct(product2);

        //    sm.BuyProduct("Lenovo", 2);

        //    Assert.AreEqual(3000, ); //?????????????
        //}

        [Test]
        public void BuyProductQuantityBeCorrect()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1500m);
            Product product2 = new Product("Lenovoooooo", 100000, 150000.50m);

            sm.AddProduct(product);
            sm.AddProduct(product2);

            sm.BuyProduct("Lenovo", 50);

            Assert.AreEqual(50, product.Quantity); 
        }

        [Test]
        public void BuyProductShouldReturnCorrectProduct()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1500m);
            Product product2 = new Product("Lenovoooooo", 100000, 150000.50m);

            sm.AddProduct(product);
            sm.AddProduct(product2);

            sm.BuyProduct("Lenovo", 50);

            Assert.AreEqual("Lenovo", product.Name);
        }

        [Test]
        public void GetTMEProductShouldReturnCorrectProduct()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1m);
            Product expected = new Product("Lenovoooooo", 100000, 100m);

            sm.AddProduct(product);
            sm.AddProduct(expected);

            Product actual = sm.GetTheMostExpensiveProduct();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Collection()
        {
            StoreManager sm = new StoreManager();
            Product product = new Product("Lenovo", 100, 1m);
            Product product2 = new Product("Lenovoooooo", 100000, 100m);

            sm.AddProduct(product);
            
            IReadOnlyCollection<Product> exp = new List<Product> {product};
            IReadOnlyCollection<Product> act = sm.Products;

            CollectionAssert.AreEqual(exp, act);

        }

    }
}