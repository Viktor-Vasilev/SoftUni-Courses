using P03._ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Contracts.Rules
{
    public class WeightAmountRule : IAmountRules
    {
        public decimal Calculate(OrderItem item)
        {
            return item.Quantity * 4m / 1000;
        }

        public bool isMatch(OrderItem item)
        {
            return item.Sku.StartsWith("WEIGHT");
        }
    }
}
