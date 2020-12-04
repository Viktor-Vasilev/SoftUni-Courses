using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0 && dwarf.Instruments.Any()) // итерираме между инструментите
            {
                IInstrument currInstrument = dwarf.Instruments.First();

                while (!present.IsDone() && dwarf.Energy > 0 && !currInstrument.IsBroken()) // правим подаръка
                {
                    dwarf.Work(); // намаляме енергията
                    present.GetCrafted(); // намаляме необходимото за правенето на подаръка
                    currInstrument.Use(); // намаляме здравето на инструмента
                }

                if (currInstrument.IsBroken()) //ако заедно с направата на подарък се е счупил и инструмента !!!!
                {
                    dwarf.Instruments.Remove(currInstrument);
                }

                if (present.IsDone()) //подаръка е готов и излизаме
                {
                    break;
                }

            }

        }
    }
}
