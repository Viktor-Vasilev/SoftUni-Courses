using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            //productShopContext.Database.EnsureDeleted();
            //productShopContext.Database.EnsureCreated();


            // // Query 1. Import Users
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //var result = ImportUsers(productShopContext, inputJson);
            //Console.WriteLine(result);



            // // Query 2. Import Products
            //string usersJson = File.ReadAllText("../../../Datasets/users.json"); // трябва да имаме юзъри за да има продукти !!!
            //string productsJson = File.ReadAllText("../../../Datasets/products.json"); 
            //ImportUsers(productShopContext, usersJson);
            //var result = ImportProducts(productShopContext, productsJson);
            //Console.WriteLine(result);



            //// Query 3.Import Categories
            //string usersJson = File.ReadAllText("../../../Datasets/users.json"); // трябва да имаме юзъри за да има продукти !!!
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");

            //ImportUsers(productShopContext, usersJson);
            //ImportProducts(productShopContext, productsJson);
            //var result = ImportCategories(productShopContext, categoriesJson);

            //Console.WriteLine(result);



            //// Query 4. Import Categories and Products
            //string usersJson = File.ReadAllText("../../../Datasets/users.json"); // трябва да имаме юзъри за да има продукти !!!
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string categoriesProductJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(productShopContext, usersJson);
            //ImportProducts(productShopContext, productsJson);
            //ImportCategories(productShopContext, categoriesJson);
            //var result = ImportCategoryProducts(productShopContext, categoriesProductJson);

            //Console.WriteLine(result);



            //// Query 5. Export Products in Range
            //var result = GetProductsInRange(productShopContext);
            //Console.WriteLine(result);



            //// Query 6. Export Successfully Sold Products
            //var result = GetSoldProducts(productShopContext);
            //Console.WriteLine(result);



            // Query 7. Export Categories by Products Count
            //var result = GetCategoriesByProductsCount(productShopContext);
            //Console.WriteLine(result);



            // Query 8. Export Users and Products
            var result = GetUsersWithProducts(productShopContext);
            Console.WriteLine(result);



        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(x => x.BuyerId != null).Count(),
                        products = u.ProductsSold.Where(x => x.BuyerId != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            // правим нов обект за да включим count 

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsonSerializerSettings = new JsonSerializerSettings // премахваме Null стойностите
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var result = JsonConvert.SerializeObject(resultObject, Formatting.Indented, jsonSerializerSettings);

            return result;
        }


        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            // ако гърми използваме това - първо проверяваме дали не делим на нула !!!
            //var categoriesInfo = context.Categories.Select(category => new
            //{
            //    category = category.Name,
            //    productsCount = category.CategoryProducts.Count,
            //    averagePrice = category.CategoryProducts.Count == 0 ?
            //    0.ToString("F2") : 
            //    category.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
            //    totalRevenue = category.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
            //})
            //        .OrderByDescending(x => x.productsCount)
            //        .ToList();

            var categoriesInfo = context.Categories.Select(category => new
            {
                category = category.Name,
                productsCount = category.CategoryProducts.Count,
                averagePrice = category.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                totalRevenue = category.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
            })
                     .OrderByDescending(x => x.productsCount)
                     .ToList();

            var result = JsonConvert.SerializeObject(categoriesInfo, Formatting.Indented);

            return result;

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .Select(user => new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                soldProducts = user.ProductsSold.Where(p => p.BuyerId != null).Select(b => new
                {
                    name = b.Name,
                    price = b.Price,
                    buyerFirstName = b.Buyer.FirstName,
                    buyerLastName = b.Buyer.LastName
                })
                .ToList()
            })
            .OrderBy(x => x.lastName)
            .ThenBy(x => x.firstName)
            .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(product => new
                {
                    name = product.Name,
                    price = product.Price,
                    seller = product.Seller.FirstName + " " + product.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToArray();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategoriesProduct = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
              

            var categoriesProduct = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProduct);

            context.CategoryProducts.AddRange(categoriesProduct);

            context.SaveChanges();


            return $"Successfully imported {categoriesProduct.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoriesInputModel>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

    }
}