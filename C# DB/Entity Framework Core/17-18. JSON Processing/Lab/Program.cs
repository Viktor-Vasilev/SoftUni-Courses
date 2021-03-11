using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Lab
{
    partial class Program
    {

        static void Main(string[] args)
        {
            // System.Text.Json;

            //var car = new Car
            //{
            //    Extras = new List<string> { "Klimatronik", "4X4", "Farove" },
            //    ManufacturedOn = DateTime.Now,
            //    Model = "Golf",
            //    Vendor = "VW",
            //    Price = 12345.67m,
            //    Engine = new Engine { Volume = 1.6f, HorsePower = 80 },
            //};

            // // 1. From Code to Json

            // File.WriteAllText("myCar.Json", JsonSerializer.Serialize(car)); // -- във файл

            // може да се използват опции:
            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true, //по пригледно изглежда
            //};

            //Console.WriteLine(JsonSerializer.Serialize(car, options));


            // // 2. From Json to Code

            //var options = new JsonSerializerOptions // може и с опции
            //{

            //};

            //var json = File.ReadAllText("myCar.Json");

            //Car car = JsonSerializer.Deserialize<Car>(json, options);




            // Newtonsoft.Json - друга библиотека

            // работи с анонимни типове
            // Console.WriteLine(JsonConvert.SerializeObject(new { Name = "Niki", Course = "EF Core"}));

            //var json = File.ReadAllText("myCar.json");
            //var car = JsonConvert.DeserializeObject<Car>(json);




            // Ако трябва да генерираме много пропъртита от json файл - правим нов клас/файл и пействаме като json!!!

            //var car = new Car
            //{
            //    Extras = new List<string> { "Klimatronik", "4X4", "Farove" },
            //    ManufacturedOn = DateTime.Now,
            //    Model = "Golf",
            //    Vendor = "VW",
            //    Price = 12345.67m,
            //    Engine = new Engine { Volume = 1.6f, HorsePower = 80 },
            //};

            //var settings = new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    ContractResolver = new DefaultContractResolver
            //    {
            //        //NamingStrategy = new SnakeCaseNamingStrategy() // с долни черти
            //        NamingStrategy = new DefaultNamingStrategy() // Pascal Naming                                                       // ...
            //    },
            //    DateFormatString = "yyyy-MM-dd" // настройка на дата
            //};

            //Console.WriteLine(JsonConvert.SerializeObject(car, settings));

            //var json = File.ReadAllText("myCar.json");

            //var a = new
            //{
            //    Model = "",
            //    Vendor = "",
            //    Price = 0.0M,
            //};

            //Console.WriteLine((JsonConvert.DeserializeAnonymousType(json, a, settings)));

            //Могат да се слагат атрибути на пропъртитата - например:
            // [JsonIgnore] - премахва ненужните ни пропъртита - сетва им дефолтната стойност
            // [JsonProperty()] - много допълнителни настройки



            // LINQ to Json

            var json = File.ReadAllText("myCar.json");
            var jObject = JObject.Parse(json); // обработваме го едно по едно
            // jObject.Children().Where(x => x.....)

            //foreach (var item in jObject.Children())
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine(new string('-', 60));
            //}

            foreach (var item in jObject.Children().Where(x => x.Children().First().Children().Count() > 1))
            {
                Console.WriteLine(item);
                Console.WriteLine(new string('-', 60));
            }
        }
    }
}
