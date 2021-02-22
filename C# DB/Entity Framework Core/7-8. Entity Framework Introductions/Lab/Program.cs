using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Install Nudget Packages:
            // 1. Microsoft.EntityFrameworkCore.SqlServer
            // 2. Microsoft.EntityFrameworkCore.Design

            // dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models - f - d


            // -o   задава папка в която да постави класовете
            // -f   ако вече имаме направена база във вид на класове и сме променили нещо в базата през SQL, с тази команда му казваме да дръпне пак всичко наново като презапише класовете.
            // -d    тази команда ни прави констрейните на базата като атрибути върху самите пропъртитата

            var db = new SoftUniContext();

            var employees = db.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .Where(x => x.FirstName.Contains("ro")).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, employees
                .Select(e => e.FirstName + " " + e.LastName)));





        }
    }
}
