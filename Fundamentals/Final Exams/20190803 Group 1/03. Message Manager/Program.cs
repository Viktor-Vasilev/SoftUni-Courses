using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _20190803_Group_1_03_Message_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();

            // sent - 0;
            // received - 1;

            while (command != "Statistics")
            {
                string[] splitted = command.Split('=');

                if (command.Contains("Add"))
                {
                    string username = splitted[1];
                    int sent = int.Parse(splitted[2]);
                    int received = int.Parse(splitted[3]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new List<int> { sent, received });
                    }

                }
                else if (command.Contains("Message"))
                {
                    string sender = splitted[1];
                    string receiver = splitted[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender][0] += 1;

                        if (users[sender][0] + users[sender][1] >= limit)
                        {
                            users.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        users[receiver][1] += 1;
                        if (users[receiver][1] + users[receiver][0] >= 10)
                        {
                            users.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }

                    }

                }
                else if (command.Contains("Empty"))
                {
                    string username = splitted[1];

                    if (username == "All")
                    {
                        users.Clear();
                    }
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value.Sum()}");
            }

            //int capacity = int.Parse(Console.ReadLine());

            //Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();

            //string input = Console.ReadLine();

            //// sent = 0; 
            //// received = 1;

            //while (input != "Statistics")
            //{
            //    string[] command = input.Split("=");

            //    if (command.Contains("Add"))
            //    {
            //        string username = command[1];
            //        int sent = int.Parse(command[2]);
            //        int received = int.Parse(command[3]);

            //        if (!users.ContainsKey(username))
            //        {
            //            users.Add(username, new List<int> { sent, received });
            //        }

            //    }
            //    else if (command.Contains("Message"))
            //    {
            //        string sender = command[1];
            //        string receiver = command[2];

            //        if (users.ContainsKey(sender) && users.ContainsKey(receiver))
            //        {
            //            users[sender][0] += 1;
            //            users[receiver][1] += 1;

            //            if (users[sender][0] + users[sender][1] >= capacity)
            //            {
            //                Console.WriteLine($"{sender} reached the capacity!");
            //                users.Remove(sender);
            //            }
            //            if (users[receiver][0] + users[receiver][1] >= capacity)
            //            {
            //                Console.WriteLine($"{receiver} reached the capacity!");
            //                users.Remove(receiver);
            //            }
            //        }

            //    }
            //    else if (command.Contains("Empty"))
            //    {
            //        string username = command[1];

            //        if (users.ContainsKey(username))
            //        {
            //            users.Remove(username);
            //        }
            //        else
            //        {
            //            users.Clear();
            //        }
            //    }

            //    input = Console.ReadLine();
            //}

            //Console.WriteLine($"Users count: {users.Count}");

            //// така се пълни речник, като се вземат различни стойности от листа - в случая знам, че са само две!!

            ////Dictionary<string, int> sorted = new Dictionary<string, int>();

            ////foreach (string key in users.Keys)
            ////{
            ////    sorted.Add(key, users[key][0] + users[key][1]);
            ////}



            //Dictionary<string, int> receivedd = new Dictionary<string, int>();

            //foreach (string key in users.Keys)
            //{
            //    receivedd.Add(key, users[key][1]);
            //}

            //Dictionary<string, int> sentt = new Dictionary<string, int>();

            //foreach (string key in users.Keys)
            //{
            //    sentt.Add(key, users[key][0]);
            //}

            //foreach (var kvp in receivedd.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            //{
            //    string user = kvp.Key;
            //    int receivedMessagesPerUser = kvp.Value;
            //    int sentMessagesPerUser = sentt[user];
            //    int sum = receivedMessagesPerUser + sentMessagesPerUser;

            //    Console.WriteLine($"{user} - {sum}");
            //}




            // по-лесно е с два речника, ама като започнах така се заинатих ...

            //Dictionary<string, int> sentMessages = new Dictionary<string, int>();
            //Dictionary<string, int> receivedMessages = new Dictionary<string, int>();

            //int maxCapacity = int.Parse(Console.ReadLine());

            //string command;
            //while ((command = Console.ReadLine()) != "Statistics")
            //{
            //    string[] commandArgs = command.Split("=").ToArray();
            //    string commandType = commandArgs[0];

            //    if (commandType == "Add")
            //    {
            //        string username = commandArgs[1];
            //        int sent = int.Parse(commandArgs[2]);
            //        int received = int.Parse(commandArgs[3]);

            //        if (!sentMessages.ContainsKey(username))
            //        {
            //            sentMessages.Add(username, sent);
            //            receivedMessages.Add(username, received);
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //    else if (commandType == "Message")
            //    {
            //        string sender = commandArgs[1];
            //        string receiver = commandArgs[2];

            //        if (sentMessages.ContainsKey(sender) && sentMessages.ContainsKey(receiver))
            //        {
            //            sentMessages[sender] += 1;
            //            receivedMessages[receiver] += 1;

            //            if ((sentMessages[sender] + receivedMessages[sender]) >= maxCapacity)
            //            {
            //                Console.WriteLine($"{sender} reached the capacity!");
            //                sentMessages.Remove(sender);
            //                receivedMessages.Remove(sender);
            //            }
            //            if ((receivedMessages[receiver] + sentMessages[receiver]) >= maxCapacity)
            //            {
            //                Console.WriteLine($"{receiver} reached the capacity!");
            //                sentMessages.Remove(receiver);
            //                receivedMessages.Remove(receiver);
            //            }
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //    else if (commandType == "Empty")
            //    {
            //        string username = commandArgs[1];

            //        if (username == "All")
            //        {
            //            sentMessages.Clear();
            //            receivedMessages.Clear();
            //        }
            //        else
            //        {
            //            if (sentMessages.ContainsKey(username))
            //            {
            //                sentMessages.Remove(username);
            //                receivedMessages.Remove(username);
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine($"Users count: {sentMessages.Count}");

            //foreach (var kvp in receivedMessages.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            //{
            //    string user = kvp.Key;
            //    int receivedMessagesPerUser = kvp.Value;
            //    int sentMessagesPerUser = sentMessages[user];
            //    int sum = sentMessagesPerUser + receivedMessagesPerUser;
            //    Console.WriteLine($"{user} - {sum}");
            //}

        }
    }
}
