using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver teamLead = new TeamLeadApprover();
            Approver cto = new CTO();

            teamLead.setNext(cto);

            Console.WriteLine(teamLead.HandleRequest(3));
            Console.WriteLine(teamLead.HandleRequest(50));
            Console.WriteLine(teamLead.HandleRequest(5000));


        }
    }
}
