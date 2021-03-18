using AutoMapper;
using CarDealer.XMLHelper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using ProductShop.DataTransferObjects.Output;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            //// Query 1.Import Users
            //var usersXml = File.ReadAllText("./Datasets/users.xml");
            //var result = ImportUsers(context, usersXml);
            //Console.WriteLine(result);


            //// Query 2. Import Products
            //var usersXml = File.ReadAllText("./Datasets/users.xml");
            //ImportUsers(context, usersXml);
            //var productsXml = File.ReadAllText("./Datasets/products.xml");
            //string result = ImportProducts(context, productsXml);
            //Console.WriteLine(result);


            //// Query 3. Import Categories
            //var usersXml = File.ReadAllText("./Datasets/users.xml");
            //ImportUsers(context, usersXml);
            //var productsXml = File.ReadAllText("./Datasets/products.xml");
            //ImportProducts(context, productsXml);
            //var categoriesXml = File.ReadAllText("./Datasets/categories.xml");
            //string result = ImportCategories(context, categoriesXml);
            //Console.WriteLine(result);


            //// Query 4. Import Categories and Products
            //var usersXml = File.ReadAllText("./Datasets/users.xml");
            //ImportUsers(context, usersXml);
            //var productsXml = File.ReadAllText("./Datasets/products.xml");
            //ImportProducts(context, productsXml);
            //var categoriesXml = File.ReadAllText("./Datasets/categories.xml");
            //ImportCategories(context, categoriesXml);
            //var categoriesProductsXml = File.ReadAllText("./Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, categoriesProductsXml);
            //Console.WriteLine(result);


            //// Query 5. Products In Range
            //Console.WriteLine(GetProductsInRange(context));


            //// Query 6. Sold Products
            // Console.WriteLine(GetSoldProducts(context));


            //// Query 7. Categories By Products Count
            // Console.WriteLine(GetCategoriesByProductsCount(context));


            // Query 8. Users and Products
             Console.WriteLine(GetUsersWithProducts(context));


        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndProducts = new UsersAllDto
            {
                Count = context.Users.Where(x => x.ProductsSold.Any(p => p.Buyer != null)).Count(),
                Users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserExportDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsExportDto
                    {
                        Count = u.ProductsSold.Where(ps => ps.Buyer != null).Count(),
                        Products = u.ProductsSold.Where(ps => ps.Buyer != null)
                        .Select(p => new UserSoldProductsExportDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToArray()
            };
            var result = XmlConverter.Serialize(usersAndProducts, "Users");

            return result;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
               .Select(c => new CategoriesOutputModel
                           {
                               Name = c.Name,
                               Count = c.CategoryProducts.Count,
                               AveragePrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                               TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                           })
               .OrderByDescending(x => x.Count)
               .ThenBy(x => x.TotalRevenue)
               .ToArray();



            var result = XmlConverter.Serialize(categories, "Categories");

            return result;
        }
            
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                 .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                 .Select(u => new UserWithSoldProducts
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     SoldProducts = u.ProductsSold
                                    .Select(p => new UserSoldProductsExport
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .ToArray()
                 })
                 .OrderBy(x => x.LastName)
                 .ThenBy(x => x.FirstName)
                 .Take(5)
                 .ToArray();

            var result = XmlConverter.Serialize(usersWithProducts, "Users");

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
               .Where(c => c.Price >= 500 && c.Price <= 1000)
               .Select(c => new ProductOutputModel
               {
                   Name = c.Name,
                   Price = c.Price,
                   BuyerFullName = c.Buyer.FirstName + " " + c.Buyer.LastName
               })
               .OrderBy(c => c.Price)
               .Take(10)
               .ToArray();

            var result = XmlConverter.Serialize(products, "Products");

            return result;


        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoriesProductsDto = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, ("CategoryProducts"));

            var categoriesIds = context.Categories
                .Select(x => x.Id)
                .ToList();

            var productsIds = context.Products
                .Select(x => x.Id)
                .ToList();

            var categoryProducts = categoriesProductsDto
                .Where(x => categoriesIds.Contains(x.CategoryId) && productsIds.Contains(x.ProductId))
                .Select(c => new CategoryProduct
                {
                    CategoryId = c.CategoryId,
                    ProductId = c.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDto = XmlConverter.Deserializer<CategoryInputModel>(inputXml, ("Categories"));

            var categories = categoriesDto
               .Where(s => s.Name != null)  // взимаме които не са null
               .Select(x => new Category
               {
                   Name = x.Name,                 
               })
          .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsDto = XmlConverter.Deserializer<ProductInputModel>(inputXml, ("Products"));

            var products = productsDto.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId
            })
           .ToList();

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDto = XmlConverter.Deserializer<UserInputModel>(inputXml, ("Users"));

            var users = usersDto.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            })
            .ToList();

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}"; ;
        }
    }
}