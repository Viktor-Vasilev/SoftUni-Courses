using Command_Pattern.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Command_Pattern
{
    class Calculator
    {
        private List<ICommmand> commands = new List<ICommmand>();
        private int index = -1;

        public int Result { get; set; }


        public void AddCommand(ICommmand command)
        {
            commands.Insert(++index, command);
            Result = commands[index].Calculate(Result);
        }

        public void Undo(int level) 
        {
            for (int i = 0; i < level; i++)
            {
                if (index >= 0)
                {
                    Result = commands[index].UndoCalculate(Result);
                    index--;
                }
               
            }
        }

        public void Redo(int level)
        {
            for (int i = 0; i < level; i++)
            {
                if (index < commands.Count)
                {
                    Result = commands[index].Calculate(Result);
                    index++;
                }

            }
        }
    }
}
