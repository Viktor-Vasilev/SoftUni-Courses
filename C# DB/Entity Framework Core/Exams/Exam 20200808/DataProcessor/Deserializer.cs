namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();
			var games = JsonConvert.DeserializeObject<IEnumerable<GameJsonImportModel>>(jsonString);

			foreach (var jsonGame in games) // проверяваме дали са валидни данните
			{
				if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0)
				{
					output.AppendLine("Invalid Data");
					continue;
				}

				// •	If a developer/genre/tag with that name doesn’t exist, create it. 
				var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre); // ако го намерим
				if (genre == null) // ако не сме го намерили
				{
					genre = new Genre { Name = jsonGame.Genre };
				}

				var developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer);
                if (developer == null)
                {
					developer = new Developer { Name = jsonGame.Developer };
                }

				
				var game = new Game //правим си нова игра
				{
					Name = jsonGame.Name,
					Genre = genre,
					Developer = developer,
				    Price = jsonGame.Price,
					ReleaseDate = jsonGame.ReleaseDate.Value,			    
				};

                foreach (var jsonTag in jsonGame.Tags)  // за таговете на всяка игра
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag); //дали има такъв таг
                    if (tag == null)
                    {
						tag = new Tag { Name = jsonTag };
                    }

					game.GameTags.Add(new GameTag { Tag = tag}); 
                }

				context.Games.Add(game);    // всеки път я запаметяваме

				context.SaveChanges();

				output.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
			}


			
			return output.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();

			var users = JsonConvert.DeserializeObject<IEnumerable<UserJsonInputModel>>(jsonString);

            foreach (var jsonUser in users)
            {
                if (!IsValid(jsonUser) || !jsonUser.Cards.All(IsValid))
                {
					output.AppendLine("Invalid Data");
					continue;
				}

				var user = new User
				{ 
					 Age = jsonUser.Age,
					 Email = jsonUser.Email,
					 FullName = jsonUser.FullName,
					 Username = jsonUser.Username,
					 Cards = jsonUser.Cards.Select(x => new Card
							 {
								Cvc = x.CVC,
								Number = x.Number,
							    Type = x.Type.Value
							 })
					 .ToList()
				
				};

				context.Users.Add(user);

				output.AppendLine($"Imported {jsonUser.Username} with {jsonUser.Cards.Count()} cards");
			}

			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var output = new StringBuilder();

			var xmlSerializer = new XmlSerializer(typeof(PurchaseXmlInputModel[]),
				new XmlRootAttribute("Purchases"));

			var purchases = (PurchaseXmlInputModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlPurchase in purchases)
            {
                if (!IsValid(xmlPurchase))
                {
					output.AppendLine("Invalid Data");
					continue;
                }
				// проверка дали е парснало датата
				bool parsedDate = DateTime.TryParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None,out var date);

                if (!parsedDate)
                {
					output.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase     // за card и Game бъркаме в базата да ги вземем !!!
				{
					Date = date,
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card),
					Game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.GameName)
				};

			
				

				context.Purchases.Add(purchase);

				// взимаме юзъра, който си е купил играта

				var username = context.Users.Where(x => x.Id == purchase.Card.UserId).Select(x => x.Username).FirstOrDefault();

				output.AppendLine($"Imported {xmlPurchase.GameName} for {username}");
            }


			context.SaveChanges();
			return output.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}