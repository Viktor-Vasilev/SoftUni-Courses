using System;
using System.Linq;
using System.Collections.Generic;

namespace _20191102_Group_1_2._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weaponName = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Done")
                {
                    break;
                }
                else if (command[1] == "Left")
                {
                    int index = int.Parse(command[2]);

                    if (index > 0 && index < weaponName.Count) // само > за да не стане отрицателен индекса;
                    {                       
                        string temp = weaponName[index - 1];
                        weaponName[index - 1] = weaponName[index];
                        weaponName[index] = temp;
                    }

                }
                else if (command[1] == "Right")
                {
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < weaponName.Count - 1) // аналогично
                    {                       
                        string temp = weaponName[index + 1];
                        weaponName[index + 1] = weaponName[index];
                        weaponName[index] = temp;
                    }
                    
                }
                else if (command[1] == "Even")
                {
                    List<string> even = new List<string>();

                    for (int i = 0; i < weaponName.Count; i++) // трябва да е до .Count за да обходи цялата колекция!
                    {
                        string currentString = weaponName[i];

                        if (i % 2 == 0)
                        {
                            even.Add(currentString);
                        }
                    }

                    Console.WriteLine(String.Join(" ", even));
                }
                else if (command[1] == "Odd")
                {
                    List<string> odd = new List<string>();

                    for (int i = 0; i < weaponName.Count; i++)
                    {
                        string currentString = weaponName[i];

                        if (i % 2 != 0)
                        {
                            odd.Add(currentString);
                        }
                    }

                    Console.WriteLine(String.Join(" ", odd));
                }

            }

            Console.WriteLine("You crafted " + String.Join("", weaponName) + "!");

        }
    }
}
