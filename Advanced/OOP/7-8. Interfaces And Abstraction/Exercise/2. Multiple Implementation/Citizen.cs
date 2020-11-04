namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        
        public Citizen(string name, int age, string Id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = Id;
            this.Birthdate = birthdate;
        }

        public string Birthdate { get; }
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }
    }
}
