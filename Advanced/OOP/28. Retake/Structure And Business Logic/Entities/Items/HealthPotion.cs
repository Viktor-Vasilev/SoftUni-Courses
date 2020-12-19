using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HPWeight = 5;
        private const int CharacterIncreasingHealthPoints = 20;
        public HealthPotion() : base(HPWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += CharacterIncreasingHealthPoints;
        }
    }
}
