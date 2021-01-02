using System;
using System.Collections.Generic;
using System.Text;

namespace LazyInitialization
{
    class Cart
    {
        public Cart()
        {
            Console.WriteLine("Initialized");
        }

        public int Balance { get; set; }

    }
}
