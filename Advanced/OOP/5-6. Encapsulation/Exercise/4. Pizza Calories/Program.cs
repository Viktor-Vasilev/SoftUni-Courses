using System;

namespace E4PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaArgs[1]);

                string[] DoughArgs = Console.ReadLine().Split();
                Dough dough = new Dough(DoughArgs[1], DoughArgs[2], double.Parse(DoughArgs[3]));

                pizza.Dough = dough;

                string toppingInput = Console.ReadLine();

                while (toppingInput != "END")
                {
                    string[] toppingsArgs = toppingInput.Split();
                    Topping topping = new Topping(toppingsArgs[1], double.Parse(toppingsArgs[2]));

                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
