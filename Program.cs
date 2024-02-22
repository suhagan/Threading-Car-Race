using System;
using System.Threading;

namespace Threading_Car_Race;



class Program
{
    static void Main(string[] args)
    {
        // Create cars
        RaceCar car1 = new RaceCar("AudiTT", 120);
        RaceCar car2 = new RaceCar("NissanSKYLINE", 120);

        // Start the race
        Thread car1Thread = new Thread(car1.Run);
        Thread car2Thread = new Thread(car2.Run);

        car1Thread.Start();
        car2Thread.Start();

        // Allow user to request status updates
        Console.WriteLine("Type 's' to get current race status:");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "s")
            {
                Console.WriteLine($"Status update:");
                Console.WriteLine($"{car1.Name}: Distance: {car1.Distance:F2} km, Speed: {car1.Speed} km/h");
                Console.WriteLine($"{car2.Name}: Distance: {car2.Distance:F2} km, Speed: {car2.Speed} km/h");
            }
            else
            {
                Console.WriteLine("Invalid command. Type 's' to get current race status:");
            }
        }

        // Wait for both cars to finish
        car1Thread.Join();
        car2Thread.Join();

        // Race finished
        Console.WriteLine("Race finished!");
    }

}
