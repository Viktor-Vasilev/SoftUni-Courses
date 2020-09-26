using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Exer_08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            SortedDictionary<string, SortedDictionary<string, int>> candidates = new SortedDictionary<string, SortedDictionary<string, int>>();

            string[] contestInfo = Console.ReadLine().Split(':');

            while (contestInfo[0] != "end of contests")
            {
                string contest = contestInfo[0];
                string password = contestInfo[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                contestInfo = Console.ReadLine().Split(':');
            }

            string[] candidatesInfo = Console.ReadLine().Split("=>");

            while (candidatesInfo[0] != "end of submissions")
            {
                string contest = candidatesInfo[0];
                string password = candidatesInfo[1];
                string candidate = candidatesInfo[2];
                int points = int.Parse(candidatesInfo[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(candidate))
                    {
                        candidates.Add(candidate, new SortedDictionary<string, int>());
                    }
                    if (!candidates[candidate].ContainsKey(contest))
                    {
                        candidates[candidate].Add(contest, points);
                    }
                    else if (candidates[candidate][contest] < points)
                    {
                        candidates[candidate][contest] = points;
                    }

                }
                candidatesInfo = Console.ReadLine().Split("=>");
            }

            var topCandidate = candidates.OrderByDescending(candidate => candidate.Value.Sum(points => points.Value)).First();

            Console.WriteLine($"Best candidate is {topCandidate.Key} with total {topCandidate.Value.Sum(s => s.Value)} points.");

            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

            // друго решение с метод за най-добрия:
            //            using System;
            //            using System.Collections.Generic;
            //            using System.Linq;

            //namespace _08._Ranking
            //    {
            //        class Program
            //        {
            //            static void Main(string[] args)
            //            {
            //                var dataOfCourses = new Dictionary<string, string>();

            //                while (true)
            //                {
            //                    string input = Console.ReadLine();

            //                    if (input == "end of contests")
            //                    {
            //                        break;
            //                    }

            //                    string[] toknes = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
            //                    string contest = toknes[0];
            //                    string password = toknes[1];

            //                    dataOfCourses.Add(contest, password); //not cheking key contest
            //                }

            //                var users = new Dictionary<string, Dictionary<string, int>>();
            //                //key=userName, key = contest, value = points

            //                while (true)
            //                {
            //                    string input = Console.ReadLine();

            //                    if (input == "end of submissions")
            //                    {
            //                        break;
            //                    }

            //                    string[] tokens = input.Split("=>"); //"{contest}=>{password}=>{username}=>{points}" 
            //                    string contest = tokens[0];
            //                    string password = tokens[1];
            //                    string userName = tokens[2];
            //                    int points = int.Parse(tokens[3]);

            //                    if (dataOfCourses.ContainsKey(contest))
            //                    {
            //                        if (dataOfCourses[contest] == password)
            //                        {
            //                            if (users.ContainsKey(userName) == false)
            //                            {
            //                                users.Add(userName, new Dictionary<string, int>());
            //                            }

            //                            if (users[userName].ContainsKey(contest) == false)
            //                            {
            //                                users[userName].Add(contest, points);
            //                            }
            //                            else
            //                            {
            //                                if (users[userName][contest] < points)
            //                                {
            //                                    users[userName][contest] = points;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }

            //                KeyValuePair<string, int> bestUser = BestUser(users);
            //                Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value} points.");
            //                Console.WriteLine("Ranking:");

            //                foreach (var kvp in users.OrderBy(x => x.Key))
            //                {
            //                    Console.WriteLine(kvp.Key);

            //                    foreach (var contest in kvp.Value.OrderByDescending(x => x.Value))
            //                    {
            //                        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            //                    }
            //                }
            //            }

            //            private static KeyValuePair<string, int> BestUser(Dictionary<string, Dictionary<string, int>> users)
            //            {
            //                int bestSum = 0;
            //                string userOfBest = string.Empty;

            //                foreach (var kvp in users)
            //                {
            //                    string userName = kvp.Key;
            //                    int sumOfPoints = kvp.Value.Values.Sum();

            //                    if (bestSum < sumOfPoints)
            //                    {
            //                        bestSum = sumOfPoints;
            //                        userOfBest = userName;
            //                    }
            //                }

            //                KeyValuePair<string, int> bestUser = new KeyValuePair<string, int>(userOfBest, bestSum);
            //                return bestUser;
            //            }
            //        }
            //    }
            //}
        }
    }
}
