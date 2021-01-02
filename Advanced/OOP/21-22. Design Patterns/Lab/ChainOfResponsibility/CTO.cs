using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public class CTO : Approver
    {

        public override bool HandleRequest(int ammount)
        {
            if (ammount < 500)
            {
                Console.WriteLine("Eto vzemi si ot firmata");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
