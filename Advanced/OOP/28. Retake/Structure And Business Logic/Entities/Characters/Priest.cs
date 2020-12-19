using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double ClericBaseHealth = 50;
        private const double ClericBaseArmor = 25;
        private const double ClericAbilityPoints = 40;

        public Priest(string name) : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack())
        {
            this.BaseHealth = ClericBaseHealth;
            this.BaseArmor = ClericBaseArmor;
        }

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
