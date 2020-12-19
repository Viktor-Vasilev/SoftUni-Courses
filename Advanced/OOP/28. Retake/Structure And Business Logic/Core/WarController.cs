using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly ICollection<Character> characterParty;
		private readonly ICollection<Item> itemPool;
		
		private ICollection<Item> itemsToPick;

		public WarController()
		{
			this.characterParty = new List<Character>();
			this.itemPool = new List<Item>();
			this.itemsToPick = this.itemPool;
		}

		public string JoinParty(string[] args)
		{
			
			var characterParam = args[0];
			var name = args[1];

			var characterFactory = new CharacterFactory();
			var character = characterFactory.CreateCharacter(characterParam, name);

			this.characterParty.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			var itemName = args[0];
			var itemFactory = new ItemFactory();

			var item = itemFactory.CreateItem(itemName);

			this.itemPool.Add(item);

			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			var characterName = args[0];

			this.CheckForInvalidCharacter(characterName);

			this.CheckForEmptyItemPool();

			var character = this.characterParty.First(ch => ch.Name == characterName);


			var itemToPick = this.itemsToPick.Last();
			this.itemsToPick.Remove(itemToPick);
			character.Bag.AddItem(itemToPick);

			return $"{characterName} picked up {itemToPick.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			var characterName = args[0];
			var itemName = args[1];

			this.CheckForInvalidCharacter(characterName);

			var character = this.characterParty.First(ch => ch.Name == characterName);
			var item = character.Bag.Items.FirstOrDefault(it => it.GetType().Name == itemName);

			if (!character.Bag.Items.Any())
			{
				throw new InvalidOperationException("Bag is empty!");
			}
			if (item == null)
			{
				throw new ArgumentException($"No item with name {itemName} in bag!");
			}

			character.UseItem(item);
			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			var orderedCharacters =
			   this.characterParty.OrderByDescending(ch => ch.IsAlive)
				   .ThenByDescending(ch => ch.Health);

			var sb = new StringBuilder();

			foreach (var character in orderedCharacters)
			{
				var status = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			var attackerName = args[0];
			var defenderName = args[1];

			this.CheckForInvalidCharacter(attackerName);
			this.CheckForInvalidCharacter(defenderName);

			var attacker = (Warrior)this.characterParty.FirstOrDefault(ch => ch.Name == attackerName
			&& ch.GetType().Name == "Warrior");

            if (!attacker.IsAlive) // ????????
			{
				throw new InvalidOperationException("Must be alive to perform this action!");
            }

			if (attacker == null)
			{
				throw new ArgumentException($"{attackerName} cannot attack!");
			}

			var defender = this.characterParty.First(ch => ch.Name == defenderName);

            if (!defender.IsAlive) // ????????
            {
				throw new InvalidOperationException("Must be alive to perform this action!");
			}
            

			attacker.Attack(defender);

			var sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {defenderName} for {attacker.AbilityPoints} hit points! {defenderName} has {defender.Health}/{defender.BaseHealth} HP and {defender.Armor}/{defender.BaseArmor} AP left!");

			if (!defender.IsAlive)
			{
				sb.AppendLine($"{defender.Name} is dead!");
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			var healerName = args[0];
			var receiverName = args[1];

			this.CheckForInvalidCharacter(healerName);
			this.CheckForInvalidCharacter(receiverName);

			var healer = (Priest)this.characterParty.FirstOrDefault(ch => ch.Name == healerName
			&& ch.GetType().Name == "Priest");

			if (healer == null)
			{
				throw new ArgumentException($"{healerName} cannot heal!");
			}

			var receiver = this.characterParty.First(ch => ch.Name == receiverName);

			healer.Heal(receiver);

			return
				$"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}

		private void CheckForInvalidCharacter(string characterName)
		{
			if (this.characterParty.All(ch => ch.Name != characterName))
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}
		}

		private void CheckForEmptyItemPool()
		{
			if (!this.itemPool.Any())
			{
				throw new InvalidOperationException("No items left in pool!");
			}
		}
	}
}
