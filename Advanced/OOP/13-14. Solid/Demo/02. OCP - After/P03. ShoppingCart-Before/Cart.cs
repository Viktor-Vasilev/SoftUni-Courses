namespace P03._ShoppingCart
{
    using P03._ShoppingCart_Before.Contracts;
    using P03._ShoppingCart_Before.Contracts.Rules;
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        private readonly List<OrderItem> items;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustmerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;

            List<IAmountRules> rules = new List<IAmountRules>()
            {
            new EachAmountRule(),
            new WeightAmountRule(),
            new SpecialAmountRule()
            };

            foreach (var item in this.items)
            {
                total += rules.First(r => r.isMatch(item)).Calculate(item);

                // more rules are coming!
            }

            return total; 
        }
    }
}
