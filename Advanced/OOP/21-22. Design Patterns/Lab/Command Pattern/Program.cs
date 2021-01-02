using Command_Pattern.Commands;
using System;
using System.Windows.Input;
using ICommmand = Command_Pattern.Commands.ICommmand;

namespace Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                int value = int.Parse(input[1]);

                ICommmand command = null;

                switch (input[0])
                {
                    case "+":
                        command = new PlusCommand(value);
                        break;
                    case "-":
                        command = new MinusCommand(value);
                        break;
                    case "*":
                        command = new MultiplyCommand(value);
                        break;
                    case "undo":
                        calc.Undo(value);
                        break;
                    case "redo":
                        calc.Redo(value);
                        break;
                }

                if (command != null)
                {
                    calc.AddCommand(command);
                }

                
                Console.WriteLine(calc.Result);
            }

           

        }
    }
}
