using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern.Commands
{
    public abstract class ICommmand
    {
        protected int operand;

        public ICommmand(int operand)
        {
            this.operand = operand;
        }

        public abstract int Calculate(int currentValue);

        public abstract int UndoCalculate(int currentValue);

    }
}
