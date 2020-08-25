using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace _20191102_Group_1_03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allCards = Console.ReadLine().Split(':').ToList();

            List<string> ourCards = new List<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Ready")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    string currentCard = command[1];
                    if (allCards.Contains(currentCard))
                    {
                        ourCards.Add(currentCard);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }

                }
                else if (command[0] == "Insert")
                {
                    string cardName = command[1];
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < ourCards.Count && allCards.Contains(cardName))
                    {
                        ourCards.Insert(index, cardName);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    string cardName = command[1];
                    
                    if (ourCards.Contains(cardName))
                    {
                        ourCards.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Swap")
                {
                    string cardName1 = command[1];
                    string cardName2 = command[2];

                    int cardName1Index = ourCards.IndexOf(cardName1);
                    int cardName2Index = ourCards.IndexOf(cardName2);

                    string temp = ourCards[cardName1Index];
                    ourCards[cardName1Index] = ourCards[cardName2Index];
                    ourCards[cardName2Index] = temp;

                }
                else if (command[0] == "Shuffle")
                {
                    ourCards.Reverse();
                }
            }
            Console.Write(String.Join(" ", ourCards));
        }
    }
}
