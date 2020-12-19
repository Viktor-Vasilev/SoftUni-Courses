using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int BIC = 100;

        public Backpack() : base(BIC)
        {
        }
    }
}
