using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //// Query 9. Import Suppliers
            //var json = File.ReadAllText("../../../Datasets/suppliers.json");           
            //Console.WriteLine(ImportSuppliers(context, json));

            //// Query 10. Import Parts
            //// без ДТО - ако бързаме на изпита например!!!
            //var json = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, json));


            //// Query 11. Import Cars
            //var json = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, json));


            //// Query 12. Import Customers
            //var json = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, json));


            //// Query 13. Import Sales
            //var json = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, json));


            //// Query 14. Export Ordered Customers
            // Console.WriteLine(GetOrderedCustomers(context));


            //// Query 15. Export Cars from Make Toyota
            // Console.WriteLine(GetCarsFromMakeToyota(context));


            //// Query 16. Export Local Suppliers
            // Console.WriteLine(GetLocalSuppliers(context));


            //// Query 17. Export Cars with Their List of Parts
            // Console.WriteLine(GetCarsWithTheirListOfParts(context));


            //// Query 18. Export Total Sales by Customer
            // Console.WriteLine(GetTotalSalesByCustomer(context));


            // Query 19. Export Sales with Applied Discount
             Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
            {
                car = new
                     {
                         s.Car.Make,
                         s.Car.Model,
                         s.Car.TravelledDistance
                     },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("F2"),
                price = s.Car.PartCars.Sum(ps => ps.Part.Price).ToString("F2"),
                priceWithDiscount = $"{s.Car.PartCars.Sum(ps => ps.Part.Price) * (1 - s.Discount / 100):F2}",
            }).Take(10)
            .ToList();

            var result = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return result;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new
                     {
                         fullName = c.Sales.Select(s => s.Customer.Name).FirstOrDefault(),
                         boughtCars = c.Sales.Count(),
                         spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(ps => ps.Part.Price))
                     })
                .OrderByDescending(c => c.spentMoney)
                .OrderByDescending(c => c.boughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(x => new
            {
                car = new
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                },
                         parts = x.PartCars.Select(ps => new
                         {
                             ps.Part.Name,
                             Price = ps.Part.Price.ToString("F2")
                         })
            }).ToList();


            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return result;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers.Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return result;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(car => car.Make == "Toyota")
                .OrderBy(car => car.Model)
                .ThenByDescending(car => car.TravelledDistance)
                .Select(car => new
                {
                    //car.Id,     Може и така за по-кратко !!!!
                    //car.Make,
                    //car.Model,
                    //car.TravelledDistance

                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance

                })
                .ToList();

            //var result = JsonConvert.SerializeObject(cars, Formatting.Indented);  по-кратко

            string result = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return result;

        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
               .OrderBy(c => c.BirthDate)
               .ThenBy(c => c.IsYoungDriver)
               .Select(x => new
               {
                   Name = x.Name,
                   //BirthDate = $"{x.BirthDate.Day}/{x.BirthDate.Month}/{x.BirthDate.Year}", дава само 50/100 !!!
                   BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                   IsYoungDriver = x.IsYoungDriver
               })
               .ToList();

            string result = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
            return result;
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";

        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            //var cars = carsDto.Select(c => new Car
            //     {
            //    Make = c.Make,
            //    Model = c.Model,
            //    TravelledDistance = c.TravelledDistance,

            //});

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var partId in car?.PartsId.Distinct()) // може да е nullable !!! Може да има и повтарящи !!!
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers // взимаме съплайърите
                .Select(x => x.Id)
                .ToArray(); 

            var parts = JsonConvert
                .DeserializeObject<IEnumerable<Part>>(inputJson) // !!!!!
                .Where(s => supplierIds.Contains(s.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}."; // !!!!!
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDtos = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

            var suppliers = suppliersDtos.Select(x => new Supplier
                  {
                      Name = x.Name,
                      IsImporter = x.isImporter
                  })
                .ToList();

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

    }
}