using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20200729_Prep___Problem_3
{
    class Hero
    {
        public int HP { get; set; }

        public int MP { get; set; }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string heroName = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                Hero hero = new Hero() { HP = hp, MP = mp };
                heroes.Add(heroName, hero);

            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command.Contains("CastSpell"))
                {
                    string[] splitted = command.Split(" - ");
                    string name = splitted[1];
                    int mpNeeded = int.Parse(splitted[2]);
                    string spellName = splitted[3];

                    if (heroes[name].MP - mpNeeded >= 0)
                    {
                        heroes[name].MP -= mpNeeded; 
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }

                }

                if (command.Contains("TakeDamage"))
                {
                    string[] splitted = command.Split(" - ");
                    string name = splitted[1];
                    int damage = int.Parse(splitted[2]);
                    string attacker = splitted[3];

                    heroes[name].HP -= damage;

                    if (heroes[name].HP > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }

                }

                if (command.Contains("Recharge"))
                {
                    string[] splitted = command.Split(" - ");
                    string name = splitted[1];
                    int recharge = int.Parse(splitted[2]);

                    if (heroes[name].MP + recharge > 200)
                    {
                        recharge = 200 - heroes[name].MP;
                    }

                    heroes[name].MP += recharge;

                    Console.WriteLine($"{name} recharged for {recharge} MP!");

                }

                if (command.Contains("Heal"))
                {
                    string[] splitted = command.Split(" - ");
                    string name = splitted[1];
                    int recharge = int.Parse(splitted[2]);

                    if (heroes[name].HP + recharge > 100)
                    {
                        recharge = 100 - heroes[name].HP;
                    }

                    heroes[name].HP += recharge;

                    Console.WriteLine($"{name} healed for {recharge} HP!");

                }

                command = Console.ReadLine();
            }

            var sortedHeroes = heroes.OrderByDescending(h => h.Value.HP).ThenBy(h => h.Key);

            foreach (var hero in sortedHeroes)
            {
                if (hero.Value.HP > 0)
                {
                    Console.WriteLine(hero.Key);
                    Console.WriteLine($"  HP: {hero.Value.HP}");
                    Console.WriteLine($"  MP: {hero.Value.MP}");
                }
 
            }

            // без клас !!

            //int n = int.Parse(Console.ReadLine());

            //Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            //// heal - 0;
            //// mana - 1;

            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split();

            //    string heroName = input[0];
            //    int healPoints = int.Parse(input[1]);
            //    int manaPoints = int.Parse(input[2]);

            //    heroes.Add(heroName, new List<int> { healPoints, manaPoints });

            //}

            //string command = Console.ReadLine();

            //while (command != "End")
            //{
            //    string[] splitted = command.Split(" - ");

            //    string heroName = splitted[1];

            //    if (command.Contains("CastSpell"))
            //    {
            //        int manaNeeded = int.Parse(splitted[2]);
            //        string spellName = splitted[3];

            //        if (heroes[heroName][1] >= manaNeeded)
            //        {
            //            heroes[heroName][1] -= manaNeeded;
            //            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            //        }


            //    }
            //    else if (command.Contains("TakeDamage"))
            //    {
            //        int damage = int.Parse(splitted[2]);
            //        string attacker = splitted[3];

            //        if (heroes[heroName][0] > damage)
            //        {
            //            heroes[heroName][0] -= damage;

            //            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
            //        }
            //        else
            //        {
            //            heroes.Remove(heroName);
            //            Console.WriteLine($"{heroName} has been killed by {attacker}!");
            //        }


            //    }
            //    else if (command.Contains("Recharge"))
            //    {
            //        int ammount = int.Parse(splitted[2]);

            //        int recovered = ammount;

            //        if (heroes[heroName][1] + ammount > 200)
            //        {
            //            recovered = 200 - heroes[heroName][1];
            //        }

            //        heroes[heroName][1] += recovered;

            //        Console.WriteLine($"{heroName} recharged for {recovered} MP!");

            //    }
            //    else if (command.Contains("Heal"))
            //    {
            //        int ammount = int.Parse(splitted[2]);

            //        int recovered = ammount;

            //        if (heroes[heroName][0] + ammount > 100)
            //        {
            //            recovered = 100 - heroes[heroName][0];
            //        }

            //        heroes[heroName][0] += recovered;

            //        Console.WriteLine($"{heroName} healed for {recovered} HP!");
            //    }

            //    command = Console.ReadLine();
            //}

            //foreach (var hero in heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine(hero.Key);
            //    Console.WriteLine($"  HP: {hero.Value[0]}");
            //    Console.WriteLine($"  MP: {hero.Value[1]}");
            //}





        }
    }
}
