﻿using System;

namespace Stealer
{
    class StartUp
    {
        static void Main(string[] args)
        {

           Spy spy = new Spy();

            Console.WriteLine(spy.StealFieldInfo("Hacker", "password", "username"));



        }
    }
}
