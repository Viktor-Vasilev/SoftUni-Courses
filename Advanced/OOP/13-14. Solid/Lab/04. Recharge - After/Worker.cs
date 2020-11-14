namespace P04.Recharge
{
    public abstract class Worker : IWorker
    {
        
        private string id;
        private int workingHours;

       
        protected Worker(string id)
        {
            this.id = id;
        }

       
        public int WorkingHours
        {
            get => this.workingHours;
            protected set => this.workingHours = value;
        }
        public string Id => this.id;

       
        public virtual void Work(int hours)
        {
            this.WorkingHours += hours;
        }
    }
}