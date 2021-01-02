using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern.Commands
{
    public class PlusCommand : ICommmand
    {
        public PlusCommand(int operand) : base(operand)
        {

        }
        public override int Calculate(int currentValue)
        {
            return currentValue + operand;
        }

        public override int UndoCalculate(int currentValue)
        {
            return currentValue - operand;
        }
    }
}
