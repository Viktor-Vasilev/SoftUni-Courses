using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }


        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            string result = string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);

            return result;

        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {


            IDwarf dwarf = this.dwarfs.FindByName(dwarfName); // първо проверяваме дали има такъв dwarf

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power); //правим си инструмент

            dwarf.AddInstrument(instrument);

            string result = string.Format(OutputMessages.InstrumentAdded, power, dwarfName);

            return result;

        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);

            presents.Add(present);

            string result = string.Format(OutputMessages.PresentAdded, presentName);

            return result;

        }

        public string CraftPresent(string presentName)
        {
            Workshop workshop = new Workshop();

            IPresent present = this.presents.FindByName(presentName); // намираме подаръка

            ICollection<IDwarf> dwarves = this.dwarfs.Models.Where(dw => dw.Energy >= 50).OrderByDescending(dw => dw.Energy).ToList();
            // намираме тези дуорфи, които имат енергия над 50 и ги подреждаме по нея

            if (!dwarves.Any()) // ако е празна колекцията
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            while (dwarves.Any())
            {
                IDwarf currDwarf = dwarves.First();

                workshop.Craft(present, currDwarf);

                if (!currDwarf.Instruments.Any()) // ако му свършат инструментите
                {
                    dwarves.Remove(currDwarf); //махаме го само от локалната колекция !!!
                }

                if (currDwarf.Energy == 0) //ако му свърши енергията
                {
                    dwarves.Remove(currDwarf);
                    this.dwarfs.Remove(currDwarf); // премахваме го от двете колекции
                }

                if (present.IsDone())
                {
                    break;
                }

            }



            //string result;

            //if (present.IsDone())
            //{
            //    result = string.Format(OutputMessages.PresentIsDone, presentName);
            //}
            //else
            //{
            //    result = string.Format(OutputMessages.PresentIsNotDone, presentName);
            //}

            //return result;

            string result = string.Format(present.IsDone() ? OutputMessages.PresentIsDone : OutputMessages.PresentIsNotDone, presentName);

            return result;
        }

        public string Report()
        {

            int countCraftedPresents = this.presents.Models.Count(p => p.IsDone());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countCraftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (IDwarf dwarf in this.dwarfs.Models)
            {
                int countInstruments = dwarf.Instruments.Count(i => !i.IsBroken());


                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {countInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
