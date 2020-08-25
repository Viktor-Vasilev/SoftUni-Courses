using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            int numCourses = (int)Math.Ceiling((double)numPeople / elevatorCapacity);

            Console.WriteLine(numCourses);



        }
    }
}
