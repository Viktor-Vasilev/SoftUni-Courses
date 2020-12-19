using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorAbilityPoints = 40;

        public Warrior(string name) : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorAbilityPoints, new Satchel())
        {
            this.BaseHealth = WarriorBaseHealth;
            this.BaseArmor = WarriorBaseArmor;
        }

        public void Attack(Character character)
        {
            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

           

            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
