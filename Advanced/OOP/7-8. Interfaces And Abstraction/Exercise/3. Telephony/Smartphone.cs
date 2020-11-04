

using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : IBrowseable, Icallable
    {
        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
