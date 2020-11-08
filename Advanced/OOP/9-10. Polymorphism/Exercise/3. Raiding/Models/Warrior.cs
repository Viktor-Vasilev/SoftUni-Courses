
namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int powerStrenght = 100;

        public Warrior(string name) : base(name, powerStrenght)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";

        }
    }
}
