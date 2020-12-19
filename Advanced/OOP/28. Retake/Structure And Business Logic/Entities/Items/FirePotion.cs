using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int FPWeight = 5;
        private const int CharacterDecreasingHealthPoints = 20;
        public FirePotion() : base(FPWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= CharacterDecreasingHealthPoints;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
