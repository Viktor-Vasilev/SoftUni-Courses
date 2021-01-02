using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class PaymentSystemDecorator : IPaymentSystem
    {
        private IPaymentSystem paymentSystem;

        public PaymentSystemDecorator(IPaymentSystem system)
        {
            paymentSystem = system;
        }



        public void LoanMoney(string from, string to, int ammount)
        {
            Console.WriteLine("Decorated payment system and logging in our system loans.");
            paymentSystem.LoanMoney(from, to, ammount);
        }

        public void PayMoney(string from, string to, int ammount)
        {
            Console.WriteLine("Decorated payment system and logging in our system payments.");
            paymentSystem.PayMoney(from, to, ammount);
        }
    }
}
