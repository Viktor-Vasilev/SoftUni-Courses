﻿using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{

    public class Tank : BaseMachine, ITank
    {

        private const double INITIAL_HEALTH_POINTS = 100;

        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINTS)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string defenceOutput = this.DefenseMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {defenceOutput}";
        }
    }
}
