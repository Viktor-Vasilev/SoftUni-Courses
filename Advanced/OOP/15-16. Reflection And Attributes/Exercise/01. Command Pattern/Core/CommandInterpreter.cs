using System;
using System.Linq;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System.Reflection;


namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = inputTokens[0].ToLower();
            string[] commandArguments = inputTokens
                .Skip(1)      // ако подадат повече аргументи го правим масив
                .ToArray();

            string result = string.Empty;

           // ICommand command = default;

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == $"{commandType}Command"
                .ToLower());

            ICommand instance = (ICommand)Activator.CreateInstance(type);



            //if (commandType == "HelloCommand")
            //{
            //    command = new HelloCommand();               
            //}
            //else if (commandType == "ExitCommand")
            //{
            //    command = new ExitCommand();             
            //}

            result = instance?.Execute(commandArguments); // ? - проверява дали е null, ако е продължава!!

            return result;

        }
    }
}
