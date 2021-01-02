using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class LoggerSingleton
    {
        private static LoggerSingleton instance;
        private static object someLock = new object();
        private LoggerSingleton() { }

        public void LogToFile()
        {
            Console.WriteLine("Logged to file");
        }

        public static LoggerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (someLock)
                    {
                        if (instance == null)
                        {
                            Console.WriteLine("Creating instance only once");
                            instance = new LoggerSingleton();
                        }
                       
                    }
                }
                return instance;
            }
        }
    }
}
