namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {

            Employee employee = new Employee("Viktor");

            Robot robot = new Robot("Z3434342", 20);

            employee.Work(8);

            employee.Sleep();

            robot.Recharge();

            robot.Work(16);


        }
    }
}
