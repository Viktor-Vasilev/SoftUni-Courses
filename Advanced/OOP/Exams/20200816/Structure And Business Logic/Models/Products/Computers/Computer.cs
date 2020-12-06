using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                var sum = (this.components.Sum(c => c.OverallPerformance)) / this.Components.Count;
                return sum + base.OverallPerformance;
            }
        }

        public override decimal Price
        {
            get
            {
                var totalPrice = this.Peripherals.Sum(p => p.Price) + this.Components.Sum(c => c.Price);

                return base.Price + totalPrice;
            }
        }



        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Add(component);

        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                var msg = string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Add(peripheral);

        }

        public IComponent RemoveComponent(string componentType)
        {          

            var component = Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (!components.Contains(component))
            {
                var msg = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Remove(component);

            return component;
        
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {                 

            var peripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (!peripherals.Contains(peripheral))
            {
                var msg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Remove(peripheral);

            return peripheral;

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine("  " + component);
            }

            var averageOverallPerformancePeripherals =
                this.Peripherals.Aggregate(0, (current, peripheral) => (int)(current + peripheral.OverallPerformance));

            averageOverallPerformancePeripherals /= this.Peripherals.Count;

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({averageOverallPerformancePeripherals:F2}):");
            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine("  " + peripheral);
            }
            return sb.ToString().TrimEnd();
        }
    }
    
}
