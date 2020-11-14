using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {

            List<IEmployee> employees = new List<IEmployee>();

            IEmployee employee = new Employee("Viktor");

            IEmployee manager = new Manager("Dakov", new string[] { "Boza 1", "Boza 2" });

            employees.Add(employee);

            employees.Add(manager);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);

            detailsPrinter.PrintDetails();

        }
    }
}
