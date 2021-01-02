using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public class TeamLeadApprover : Approver
    {
       

        public override bool HandleRequest(int ammount)
        {
            if (ammount < 5)
            {
                Console.WriteLine("Eto ti ot moite lichni");
                return true;
            }
            else
            {
               return Next.HandleRequest(ammount);
            }
        }
    }
}
