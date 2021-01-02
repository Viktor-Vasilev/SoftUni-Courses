namespace FactoryMethod.Contracts.Factories
{
    class Lion : ICarnivore
    {
        public Lion()
        {
        }

        public string AnimalsThatIEat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}