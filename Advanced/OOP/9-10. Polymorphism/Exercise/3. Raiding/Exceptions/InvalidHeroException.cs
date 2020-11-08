using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Exceptions
{
    public class InvalidHeroException : Exception
    {
        private const 
            string Invalid_Hero_Message = "Invalid hero!";
        public InvalidHeroException()
            :base(Invalid_Hero_Message)
        {

        }


        
    }
}
