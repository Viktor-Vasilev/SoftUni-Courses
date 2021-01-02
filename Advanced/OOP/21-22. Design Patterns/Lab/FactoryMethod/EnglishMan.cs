namespace FactoryMethod.Contracts.Factories
{
     class EnglishMan : ICarnivore
    {
        public EnglishMan()
        {
        }

        public string AnimalsThatIEat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}