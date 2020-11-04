

using System;

namespace Telephony
{
    public class StationaryPhone : Icallable
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
