using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
       
        private int capacity;

       
        public Robot(string id, int capacity)
            : base(id)
        {
            this.capacity = capacity;
        }

        
        public int Capacity
        {
            get => this.capacity;
            private set => this.capacity = value;
        }

        public int CurrentPower { get; private set; }

        
        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }
    }
}