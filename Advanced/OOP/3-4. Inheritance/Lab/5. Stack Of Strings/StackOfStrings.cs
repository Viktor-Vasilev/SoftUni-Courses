namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        
        public StackOfStrings()
        {

        }

       
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (string element in collection)
            {
                this.Push(element);
            }

            return this;
        }
    }
}
