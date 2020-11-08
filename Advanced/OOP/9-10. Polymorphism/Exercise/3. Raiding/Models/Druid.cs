

namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int powerStrenght = 80;
        
        public Druid(string name) : base(name, powerStrenght)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}"; ;

        }
    }
}
