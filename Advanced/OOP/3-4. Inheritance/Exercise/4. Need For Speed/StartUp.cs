namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Car car = new Car(100, 50);
            car.Drive(10);

            RaceMotorcycle gg = new RaceMotorcycle(20, 10);
            gg.Drive(1);

        }
    }
}
