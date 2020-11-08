

namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int powerStrenght = 100;

        public Paladin(string name) : base(name, powerStrenght)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";

        }
    }
}
