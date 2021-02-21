using Lab.Models;
using System;
using System.Linq;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // NuGet Packages
            // Microsoft.EntityFrameworkCore.SqlServer
            // Microsoft.EntityFrameworkCore.Design

            // dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Integrated Security=true;Database=SoftUni" Microsoft.EntityFrameworkCore.SqlServer -o Models

            var db = new SoftUniContext();

            
            Console.WriteLine(db.Employees.Count());

            var employees = db.Employees.Where(x => x.FirstName.StartsWith("N")).OrderByDescending(x => x.Salary)
                .Select(x => new { x.FirstName, x.LastName, x.Salary }).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} => {employee.Salary}");
            }




        }
    }
}
