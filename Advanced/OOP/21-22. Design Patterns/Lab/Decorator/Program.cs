using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {

            IPaymentSystem payment = new PaymentSystemDecorator(new PaypalSystem());


            payment.LoanMoney("Gosho", "Pesho", 2);
            payment.PayMoney("Viktor", "Stefan", 3);
            payment.LoanMoney("Ivan", "Stoyan", 2);


        }
    }
}
