using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH_POINS = 200;

        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINS)
        {

            this.ToggleAggressiveMode(); // като влезем тук винаги става true!!!!

        }

        public bool AggressiveMode { get; private set; } //трябва да е true, но дефолтната стойност на bool е false !!!

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }           

        }

        public override string ToString()
        {
            string aggresiveOutput = this.AggressiveMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggresiveOutput}";
        }
    }
}
