using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;

namespace SoftUni
{
    public class StartUp

    {
        public static void Main(string[] args)
        {
            //        Install Nudget Packages:
            // 1. Microsoft.EntityFrameworkCore.SqlServer
            // 2. Microsoft.EntityFrameworkCore.Design

            // dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models - f - d


            // -o   задава папка в която да постави класовете
            // -f   ако вече имаме направена база във вид на класове и сме променили нещо в базата през SQL, с тази команда му казваме да дръпне пак всичко наново като презапише класовете.
            // -d    тази команда ни прави констрейните на базата като атрибути върху самите пропъртитата


            // 1.	Import the SoftUni Database


            // 2.	Database First


            // 3.	Employees Full Information
            //var softUniContext = new SoftUniContext();
            //var result = GetEmployeesFullInformation(softUniContext);
            //Console.WriteLine(result);

            // 4.	Employees with Salary Over 50 000
            //var softUniContext = new SoftUniContext();
            //var result = GetEmployeesWithSalaryOver50000(softUniContext);
            //Console.WriteLine(result);

            // 5.	Employees from Research and Development
            //var softUniContext = new SoftUniContext();
            //var result = GetEmployeesFromResearchAndDevelopment(softUniContext);
            //Console.WriteLine(result);

            // 6.	Adding a New Address and Updating Employee
            //var softUniContext = new SoftUniContext();
            //var result = AddNewAddressToEmployee(softUniContext);
            //Console.WriteLine(result);

            // 7.	Employees and Projects
            //var softUniContext = new SoftUniContext();
            //var result = GetEmployeesInPeriod(softUniContext);
            //Console.WriteLine(result);

            // 8.	Addresses by Town
            //var softUniContext = new SoftUniContext();
            //var result = GetAddressesByTown(softUniContext);
            //Console.WriteLine(result);

            // 9.	Employee 147
            //var softUniContext = new SoftUniContext();
            //var result = GetEmployee147(softUniContext);
            //Console.WriteLine(result);

            // 10.	Departments with More Than 5 Employees
            //var softUniContext = new SoftUniContext();
            //var result = GetDepartmentsWithMoreThan5Employees(softUniContext);
            //Console.WriteLine(result);

            // 11.	Find Latest 10 Projects
            //var softUniContext = new SoftUniContext();
            //var result = GetLatestProjects(softUniContext);
            //Console.WriteLine(result);

            // 12.	Increase Salaries
            //var softUniContext = new SoftUniContext();
            //var result = IncreaseSalaries(softUniContext);
            //Console.WriteLine(result);

            // 13.	Find Employees by First Name Starting with "Sa"
            //var softUniContext = new SoftUniContext();
            //var result = GetEmployeesByFirstNameStartingWithSa(softUniContext);
            //Console.WriteLine(result);

            // 14.	Delete Project by Id
            //var softUniContext = new SoftUniContext();
            //var result = DeleteProjectById(softUniContext);
            //Console.WriteLine(result);

            // 15.	Remove Town
            var softUniContext = new SoftUniContext();
            var result = RemoveTown(softUniContext);
            Console.WriteLine(result);

        }

        // 3.	Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                { 
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");

            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        // 4.	Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50_000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");

            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        // 5.	Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                  .Where(x => x.Department.Name == "Research and Development")
                  .Select(x => new
                  {
                      x.FirstName,
                      x.LastName,
                      x.Salary,
                      DepartmentName = x.Department.Name,
                  })
                  .OrderBy(x => x.Salary)
                  .ThenByDescending(x => x.FirstName)
                  .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 6.	Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.AddressId = address.AddressId;

            context.SaveChanges();

            var addresses = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var currentAddress in addresses)
            {
                sb.AppendLine($"{currentAddress.AddressText}");
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 7.	Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFirstName = x.FirstName,
                    EmployeeLastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate,
                    })
                }
                )
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.Projects)
                {
                    if (project.EndDate.HasValue)
                    {
                        sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                    }
                    else
                    {
                        sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - not finished");
                    }

                    // с тернарен оператор:
                    //var endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";
                    //sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");

                }
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 8.	Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
          
            var addresses = context.Addresses
                                   .Select(x => new
                                   {
                                       Town = x.Town.Name,
                                       AddressText = x.AddressText,
                                       Employees = x.Employees.Count
                                   })
                                   .ToList()
                                   .OrderByDescending(x => x.Employees)
                                   .ThenBy(x => x.Town)
                                   .ThenBy(x => x.AddressText)
                                   .Take(10)
                                   .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Town} - {address.Employees} employees");
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 9.	Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.OrderBy(x => x.Project.Name).Select(p => new
                       {
                          p.Project.Name
                       })
                })
                .FirstOrDefault(x => x.EmployeeId == 147);


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var projects in employee147.Projects)
            {
                sb.AppendLine($"{projects.Name}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        // 10.	Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                    .Where(x => x.Employees.Count > 5)
                    .OrderBy(x => x.Employees.Count)  // важно е сортировката да е тук, ако е по-долу гърми!!!
                    .ThenBy(x => x.Name)
                    .Select(x => new
                    {
                        x.Name,
                        ManagerFirstName = x.Manager.FirstName,
                        ManagerLastName = x.Manager.LastName,
                        Employees = x.Employees.Select(e => new
                                { 
                                    e.FirstName,
                                    e.LastName,
                                    e.JobTitle,
                                })
                        .OrderBy(x => x.FirstName)
                        .ThenBy(x => x.LastName)
                        .ToList()
                    })
                   
                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.Name} - {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            var result = sb.ToString().TrimEnd();

            return result;





        }

        // 11.	Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
           
            var projects = context.Projects
                                  .OrderByDescending(x => x.StartDate)
                                  .Take(10)
                                  .Select(x => new
                                  {
                                      x.Name,
                                      x.Description,
                                      StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                  })
                                  .OrderBy(x => x.Name)
                                  .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate);
            }

            var result = sb.ToString().TrimEnd();

            return result;


        }

        // 12.	Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] {"Engineering", "Tool Design", "Marketing", "Information Services"};

            var employees = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 13.	Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {

            var employees = context.Employees
                //.Where(x => x.FirstName.StartsWith("Sa", true, CultureInfo.InvariantCulture)) // true - прави case insensitive !!! - не работи !!!
                .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();


            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 14.	Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.First(x => x.ProjectId == 2);

            context.EmployeesProjects  //махаме референциите !!!
                .ToList()
                .ForEach(x => context.EmployeesProjects
                .Remove(x));

            context.Projects.Remove(project);

            context.SaveChanges();

            List<string> projects = context.Projects
                                           .Take(10)
                                           .Select(x => x.Name)
                                           .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (string proj in projects)
            {
                sb.AppendLine(proj);
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        // 15.	Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses) 
                .FirstOrDefault(x => x.Name == "Seattle");

            var allAddressIds = town.Addresses
                .Select(x => x.AddressId).ToList(); // взимаме всички адреси в града

            var employees = context.Employees
                .Where(x => x.AddressId.HasValue && allAddressIds.Contains(x.AddressId.Value)) // взимаме всички служители, слагаме .Value защото някой може да е null !!!
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;  //сетваме ги на null, за да можем да ги изтрием
            }

            

            foreach (var addressId in allAddressIds) // изтриваме адресите
            {
                var address = context.Addresses
                    .FirstOrDefault(x => x.AddressId == addressId); // първо трябва да го заредим

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            var result = $"{allAddressIds.Count} addresses in Seattle were deleted";

            return result;

        }

    }
}
