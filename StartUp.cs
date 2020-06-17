using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Car car = new Car();
            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(2000);
            //Console.WriteLine(car.WhoAmI());
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            //Console.WriteLine(firstCar.Make);
            //Console.WriteLine(secondCar.Make);
            //Console.WriteLine(secondCar.FuelQuantity);
            //Console.WriteLine(thirdCar.Make);
            //Console.WriteLine(thirdCar.FuelQuantity);

            //var tires = new Tire[4];
            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3),
            //};
            //Engine engine = new Engine(560, 6300);
            //Car car = new Car("Lamborgini", "Urus", 2010, 250, 9, engine, tires);
            string command = Console.ReadLine();
            List<Tire[]> tires = new List<Tire[]>();
            while(command!="No more tires")
            {
                string[] input = command.Split();
                Tire tire1 = new Tire(int.Parse(input[0]), double.Parse(input[1]));
                Tire tire2 = new Tire(int.Parse(input[2]), double.Parse(input[3]));
                Tire tire3 = new Tire(int.Parse(input[4]), double.Parse(input[5]));
                Tire tire4 = new Tire(int.Parse(input[6]), double.Parse(input[7]));
                tires.Add(new Tire[] { tire1, tire2, tire3, tire4 });
                command = Console.ReadLine();
            }
            List<Engine> engines = new List<Engine>();
            command = Console.ReadLine();
            while(command!="Engines done")
            {
                string[] token = command.Split();
                engines.Add(new Engine ( int.Parse(token[0]), double.Parse(token[1])));
                command = Console.ReadLine();
            }
            List<Car> cars = new List<Car>();
            command = Console.ReadLine();
            while(command!= "Show special")
            {
                string[] input = command.Split();
                string make=input[0];
                string model=input[1];
                int year=int.Parse(input[2]);
                double fuelQuantity=double.Parse(input[3]);
                double fuelConsumption=double.Parse(input[4]);
                var engine= engines[int.Parse(input[5])];
                var tire = tires[int.Parse(input[6])];
                cars.Add(new Car(make,model,year,fuelQuantity,fuelConsumption,engine,tire));
                command = Console.ReadLine();
            }
            cars=cars.Where(c=>c.Year>=2017)
                .Where(c=>c.Engine.HorsePower>330)
                .Where(c=>c.Tires.Sum(y=>y.Pressure)>9)
                .Where( c=>c.Tires.Sum(y => y.Pressure)<10).ToList();
            foreach (Car car in cars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
