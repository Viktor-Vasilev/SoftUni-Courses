

namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int powerStrenght = 80;

        public Rogue(string name) : base(name, powerStrenght)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";

        }
    }
}
