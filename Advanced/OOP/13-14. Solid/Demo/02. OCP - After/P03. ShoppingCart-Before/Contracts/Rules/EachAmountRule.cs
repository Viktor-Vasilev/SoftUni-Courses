using P03._ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Contracts.Rules
{
    public class EachAmountRule : IAmountRules
    {
        public decimal Calculate(OrderItem item)
        {
          return item.Quantity * 5m;
        }

        public bool isMatch(OrderItem item)
        {
            return item.Sku.StartsWith("EACH");
        }
    }
}
