using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private const int MinHealth = 0;
        private const int MinArmor = 0;

        private string name;
        private double health;
        private double armor;

        // TODO: Implement the rest of the class.

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

       
       
        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; set; }

        public double Health
        {
            get 
            {
                return this.health;
            }
             set
            {
                if (value < MinHealth)
                {
                    value = MinHealth;
                }

                if (value > this.BaseHealth && this.BaseHealth > MinHealth)
                {
                    value = this.BaseHealth;
                }

                this.health = value;
            }
        }

        public double BaseArmor { get; set; }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < MinArmor)
                {
                    value = MinArmor;
                }

                if (value > this.BaseArmor && this.BaseArmor > MinArmor)
                {
                    value = this.BaseArmor;
                }

                this.armor = value;
            }
        }

        public double AbilityPoints { get;}

        public Bag Bag { get; }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                var additional = hitPoints - this.Armor;

                this.Armor -= hitPoints;
                if (this.Armor == MinArmor && additional > MinArmor)
                {
                    this.Health -= additional;
                }

                if (this.Health <= MinHealth)
                {
                    this.IsAlive = false;
                }
            }
        
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
            
        }
    }
}