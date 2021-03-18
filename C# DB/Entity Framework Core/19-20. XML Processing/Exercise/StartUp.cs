using AutoMapper;
using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Output;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
       static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //// Query 9.Import Suppliers
            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //var result = ImportSuppliers(context, supplierXml);
            //System.Console.WriteLine(result);

            //// Query 10. Import Parts
            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //ImportSuppliers(context, supplierXml);
            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //var result = ImportParts(context, partsXml);
            //System.Console.WriteLine(result);


            //// Query 11. Import Cars
            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //ImportSuppliers(context, supplierXml);
            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //ImportParts(context, partsXml);
            //var carsXml = File.ReadAllText("./Datasets/cars.xml");
            //var result = ImportCars(context, carsXml);
            //System.Console.WriteLine(result);


            //// Query 12. Import Customers
            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //ImportSuppliers(context, supplierXml);
            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //ImportParts(context, partsXml);
            //var carsXml = File.ReadAllText("./Datasets/cars.xml");
            //ImportCars(context, carsXml);
            //var customersXml = File.ReadAllText("./Datasets/customers.xml");
            //var result = ImportCustomers(context, customersXml);
            //System.Console.WriteLine(result);


            //// Query 13. Import Sales
            //var supplierXml = File.ReadAllText("./Datasets/suppliers.xml");
            //ImportSuppliers(context, supplierXml);
            //var partsXml = File.ReadAllText("./Datasets/parts.xml");
            //ImportParts(context, partsXml);
            //var carsXml = File.ReadAllText("./Datasets/cars.xml");
            //ImportCars(context, carsXml);
            //var customersXml = File.ReadAllText("./Datasets/customers.xml");
            //ImportCustomers(context, customersXml);
            //var salesXml = File.ReadAllText("./Datasets/sales.xml");
            //var result = ImportSales(context, salesXml);
            //System.Console.WriteLine(result);


            //// Query 14. Cars With Distance
            //System.Console.WriteLine(GetCarsWithDistance(context));

            //// Query 15. Cars from make BMW
            //System.Console.WriteLine(GetCarsFromMakeBmw(context));

            //// Query 16. Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            //// Query 17. Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //// Query 18. Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //// Query 19. Sales with Applied Discount
            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SalesOutputModel
                {
                    Car = new CarSaleOutputModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(x => x.Part.Price) - x.Car.PartCars.Sum(x => x.Part.Price) * x.Discount / 100
                })
                .ToList();

            var result = XmlConverter.Serialize(sales, "sales");
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales
                                .Select(x => x.Car)
                                .SelectMany(x => x.PartCars) // SELECTMANY - за да имаме достъп до колекцията !!!
                                .Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();
                     
            var result = XmlConverter.Serialize(customers, "customers");
            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarPartOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new CarPartsInfoOutputModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            var result = XmlConverter.Serialize(cars, "cars");
            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {

            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Parts.Count
                })
                .ToArray();


            var result = XmlConverter.Serialize(suppliers, "suppliers");
            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BmwOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();


            var result = XmlConverter.Serialize(cars, "cars");


            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray(); // задължително ToArray, Лист гърми!!!!



            // ръчно
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute ("cars")); // масив !!!

            //var textWriter = new StringWriter();

            //var ns = new XmlSerializerNamespaces(); // премахва ненужния неймспей !!!
            //ns.Add("", "");

            //xmlSerializer.Serialize(textWriter, cars, ns); // тук го подаваме ns

            //var result = textWriter.ToString();



            // с хелпъра на Стоян
            var result = XmlConverter.Serialize(cars, "cars");

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            // с хелпъра на Стоян Шопов !!!!
            var salesDto = XmlConverter.Deserializer<SaleInputModel>(inputXml, ("Sales"));

            var carsId = context.Cars.Select(x => x.Id).ToList();

            var sales = salesDto
                .Where(x => carsId.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();


            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            // с хелпъра на Стоян Шопов !!!!
            var customerDto = XmlConverter.Deserializer<CustomerInputModel>(inputXml, ("Customers"));

            // с automapper
            // правим метод за конфигуриране на мапера, правим и статично поле !!!

            var customers = mapper.Map<Customer[]>(customerDto);

            context.Customers.AddRange(customers);

            context.SaveChanges();


            return $"Successfully imported {customers.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            // с хелпъра на Стоян Шопов !!!!

            var cars = new List<Car>();

            var carsDto = XmlConverter.Deserializer<CarInputModel>(inputXml, ("Cars"));

            var allParts = context.Parts.Select(x => x.Id).ToList();

            foreach (var currentCar in carsDto)
            {
                var distinctedParts = currentCar.CarPartsInputModel.Select(x => x.Id).Distinct();

                var parts = distinctedParts.Intersect(allParts);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);

            }

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]),
                new XmlRootAttribute("Parts"));

            var textReader = new StringReader(inputXml);

            var partsDto = xmlSerializer.Deserialize(textReader) as PartInputModel[];

            var supplierIds = context.Suppliers.Select(x => x.Id).ToList(); // взимаме които не са null

            var parts = partsDto
                .Where(s => supplierIds.Contains(s.SupplierId)) //филтрираме ги
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
           .ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            // ръчно
            //var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]),
            //    new XmlRootAttribute("Suppliers"));

            //var textRead = new StringReader(inputXml);

            //var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierInputModel[];


            // с хелпъра на Стоян Шопов !!!!
            var suppliersDto = XmlConverter.Deserializer<SupplierInputModel>(inputXml, ("Suppliers"));

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();

        }


    }
}