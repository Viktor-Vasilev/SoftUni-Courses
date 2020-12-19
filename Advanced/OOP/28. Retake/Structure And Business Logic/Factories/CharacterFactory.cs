using System;


using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string characterParam, string name)
        {
            

            var character = characterParam switch
            {
                nameof(Warrior) => (Character)new Warrior(name),
                nameof(Priest) => new Priest(name),
                _ => throw new ArgumentException($"Invalid character type \"{characterParam}\"!")
            };

            return character;
        }
    }
}