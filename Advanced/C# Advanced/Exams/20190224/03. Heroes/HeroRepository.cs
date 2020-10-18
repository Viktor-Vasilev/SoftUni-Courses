using System;
using System.Text;

namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository
    {
        private readonly List<Hero> heroList;

        public HeroRepository()
        {
            this.heroList = new List<Hero>();
        }

        public int Count => this.heroList.Count;

        public void Add(Hero hero)
        {
            heroList.Add(hero);
        }

        public void Remove(string name)
        {
            foreach (var hero in this.heroList)
            {
                if (hero.Name == name)
                {
                    this.heroList.Remove(hero);
                }
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            var highestStrength =
                this.heroList
                    .OrderByDescending(x => x.Item.Strength)
                    .First();

            return highestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var highestAbility =
                this.heroList
                    .OrderByDescending(x => x.Item.Ability)
                    .First();

            return highestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var highestIntelligence =
                this.heroList
                    .OrderByDescending(x => x.Item.Intelligence)
                    .First();

            return highestIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb3 = new StringBuilder();

            if (this.heroList.Count >= 0)
            {
                foreach (var hero in this.heroList)
                {
                    sb3.AppendLine($"{hero}");
                }
            }

            return sb3.ToString();
        }
    }
}