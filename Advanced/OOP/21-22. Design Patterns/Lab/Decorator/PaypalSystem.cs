using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class PaypalSystem : IPaymentSystem
    {
        public void LoanMoney(string from, string to, int ammount)
        {
            Console.WriteLine($"Loaned {ammount} money from {from} to {to}.");
        }

        public void PayMoney(string from, string to, int ammount)
        {
            Console.WriteLine($"Paid {ammount} money from {from} to {to}.");
        }
    }
}
