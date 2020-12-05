using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }
        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }
        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                this.attackPoints = value;
            }
        }
        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            protected set
            {
                this.defensePoints = value;
            }
        }
        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double hpDecreasment = this.attackPoints - target.DefensePoints;

            target.HealthPoints -= hpDecreasment;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);

            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetsOutput = this.targets.Count > 0 ? String.Join(",", this.targets) : "None";

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.healthPoints:f2}");
            sb.AppendLine($" *Attack: {this.attackPoints:f2}");
            sb.AppendLine($" *Defense: {this.defensePoints:f2}");
            sb.AppendLine($"{targetsOutput}")


            return sb.ToString().TrimEnd();
        }
    }
}
