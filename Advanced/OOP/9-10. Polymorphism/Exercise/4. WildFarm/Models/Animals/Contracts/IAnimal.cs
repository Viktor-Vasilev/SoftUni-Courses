
using E4WildFarm.Models.Food.Contracts;

namespace E4WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {

        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }


        string ProduceSound();

        void Feed(IFood food);

    }
}
