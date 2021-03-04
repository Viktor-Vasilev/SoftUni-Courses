using System;
using System.Linq;
using Lab.Models;
using Lab.SoftUni;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Install Nudget Packages:
            // 1. Microsoft.EntityFrameworkCore.SqlServer
            // 2. Microsoft.EntityFrameworkCore.Design

            // dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=MusicX;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models - f - d


            // -o   задава папка в която да постави класовете
            // -f   ако вече имаме направена база във вид на класове и сме променили нещо в базата през SQL, с тази команда му казваме да дръпне пак всичко наново като презапише класовете.
            // -d    тази команда ни прави констрейните на базата като атрибути върху самите пропъртитата





            //// Executing Native SQL Queries
            
            //var db = new MusicXContext();

            //var maxId = Console.ReadLine();

            //var songs = db.Songs
            //    .FromSqlInterpolated($"SELECT * FROM Songs WHERE Id <= {0}")
            //    .ToList();

            //foreach (var song in songs)
            //{
            //    Console.WriteLine(song.Id + "=>" + song.Name);
            //}

            // db.Database.ExecuteSqlRaw("UPDATE Songs SET SourceItemId = '----' WHERE Id <= 10");

            ////Executing Stored Procedures
            //var db = new SoftUniContext();

            //var emploeeId = 59;
            //var projectId = 12;

            //db.Database.ExecuteSqlInterpolated($"EXEC sp.AddToProject {emploeeId}, {projectId}");




            //Object State Tracking

            // Когато нямаме проекция обектите авоматично се тракват!
            // Ако го направим анонимно или през нов клас - не се тракват!

            // .AsNoTracking() - изрично му казваме да не го следи - подобрява малко перформанса

            // db.Entry() - имаме достъп до метаданни на обекта





            // Bulk Operations

            // трябва да се инсталира:
            // Z.EntityFramework.Plus.EFCore


            // DELETE:
            //var db = new SoftUniContext();
            //db.Employees.Where(x => x.FirstName.StartsWith("_")).Delete();

            // UPDATE:
            //var db = new MusicXContext();

            //db.Songs
            //    .Where(x => x.Id < 10)
            //    .Update(oldSong => new Song {SourceItemId = oldSong.Id.ToString()});

            // и при двете НЕ ВИКАМЕ SaveChanges() !!!!



            // Types Of Loading

            // Lazy Loading

            // nav prop не се зареждат по подразбиране !!
            // N+1 problem
            // 3 условия да се актвира:
            //    1. Microsoft.EntityFrameworkCore.Proxies
            //    2. Virtual propertys
            //    3. Да го активираме в option.Builder : .UseLazyLoadingProxies()



            // Concurency Check


        }
    }
}
