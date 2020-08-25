using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190809_Retake_03_Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int[]> users = new Dictionary<string, int[]>();

            //string input = Console.ReadLine();

            //// likes = 0; 
            //// comments = 1;

            //// може с два речника, един за like и един за коментари! Като, ако го няма юзъра го дабавяме и в двата речника!

            //while (input != "Log out")
            //{
            //    string[] splitted = input.Split(": ");

            //    string username = splitted[1];

            //    if (splitted.Contains("New follower"))
            //    {
            //        if (!users.ContainsKey(username))
            //        {
            //            users.Add(username, new int[2]);
            //        }

            //    }
            //    else if (splitted.Contains("Like"))
            //    {
            //        int likesCount = int.Parse(splitted[2]);

            //        if (!users.ContainsKey(username))
            //        {
            //            users.Add(username, new int[2] {likesCount, 0 });
            //        }
            //        else
            //        {
            //            users[username][0] += likesCount;
            //        }

            //    }
            //    else if (splitted.Contains("Comment"))
            //    {
            //        if (!users.ContainsKey(username))
            //        {
            //            users.Add(username, new int[2] { 0, 1 });
            //        }
            //        else
            //        {
            //            users[username][1] += 1;
            //        }



            //    }
            //    else if (splitted.Contains("Blocked"))
            //    {
            //        if (!users.ContainsKey(username))
            //        {
            //            Console.WriteLine($"{username} doesn't exist.");
            //        }
            //        else
            //        {
            //            users.Remove(username);
            //        }

                       
            //    }

            //    input = Console.ReadLine();
            //}

            //Console.WriteLine($"{users.Count} followers");

            //foreach (var user in users.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine($"{user.Key}: {user.Value[0] + user.Value[1]}");
            //}

            Dictionary<string, int> likes = new Dictionary<string, int>();
            Dictionary<string, int> comments = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Log out")
            {
                string[] command = input.Split(": ");

                string name = command[1];

                if (command[0] == "New follower")
                {
                    if (!likes.ContainsKey(name))
                    {
                        likes.Add(name, 0);
                        comments.Add(name, 0);
                    }
                }
                else if (command[0] == "Like")
                {
                    int countLikes = int.Parse(command[2]);

                    if (!likes.ContainsKey(name))
                    {
                        likes.Add(name, countLikes);
                        comments.Add(name, 0);
                    }
                    else
                    {
                        likes[name] += countLikes;
                    }
                }
                else if (command[0] == "Comment")
                {
                    if (!likes.ContainsKey(name))
                    {
                        likes.Add(name, 0);
                        comments.Add(name, 1);
                    }
                    else
                    {
                        comments[name] += 1;
                    }
                }
                else if (command[0] == "Blocked")
                {
                    if (!likes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        likes.Remove(name);
                        comments.Remove(name);
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{likes.Count} followers");

            Console.WriteLine(string.Join($"{Environment.NewLine}", likes.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => $"{x.Key}: {x.Value + comments[x.Key]}")));
        }
    }
}
