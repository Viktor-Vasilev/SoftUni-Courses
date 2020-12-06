using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            var currentComputer = computerType
                switch
            {
                nameof(Laptop) => (IComputer)new Laptop(id, manufacturer, model, price),
                nameof(DesktopComputer) => new DesktopComputer(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            this.computers.Add(currentComputer);

            var output = string.Format(SuccessMessages.AddedComputer, id);
            return output;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            var computer = FindComputer(computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            var currentPeripheral = peripheralType switch
            {
                nameof(Headset) => (IPeripheral)new Headset(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                nameof(Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            computer.AddPeripheral(currentPeripheral);
            this.peripherals.Add(currentPeripheral);

            var output = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            return output;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = FindComputer(computerId);
            var peripheral = computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            var output = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
            return output;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            var computerToAdd = FindComputer(computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            var currentComponent = componentType switch
            {
                nameof(CentralProcessingUnit) => (IComponent)new CentralProcessingUnit(id, manufacturer, model, price,
                    overallPerformance, generation),
                nameof(Motherboard) => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance,
                    generation),
                nameof(SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance,
                    generation),
                nameof(VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            computerToAdd.AddComponent(currentComponent);
            this.components.Add(currentComponent);

            var output = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            return output;

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = FindComputer(computerId);
            var component = computer.RemoveComponent(componentType);

            this.components.Remove(component);

            var output = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            return output;
        }

        public string BuyComputer(int id)
        {
            var computer = FindComputer(id);

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            foreach (var computer in this.computers.OrderByDescending(c => c.OverallPerformance))
            {
                if (computer.Price <= budget)
                {
                    var info = computer.ToString();
                    computers.Remove(computer);
                    return info;
                }
            }

            var msg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);
            throw new ArgumentException(msg);
        }

        public string GetComputerData(int id)
        {
            var comp = FindComputer(id);
            return comp.ToString();
        }

        private IComputer FindComputer(int computerId)
        {
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer;
        }
    }
}
