using System;

using WarCroft.Entities.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            var item = itemName switch
            {
                nameof(HealthPotion) => (Item)new HealthPotion(),
                
                nameof(FirePotion) => new FirePotion(),
                _ => throw new ArgumentException($"Invalid item \"{itemName}\"!")
            };

            return item;
        }
    }
}