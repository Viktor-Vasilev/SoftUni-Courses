using System;

namespace Farm

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog sharo = new Dog();
            sharo.Bark();
            sharo.Eat();

            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();


        }
    }
}
