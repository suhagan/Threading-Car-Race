using System;
namespace Threading_Car_Race
{
	

    class RaceCar
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Speed { get; set; }
        private readonly object _lock = new object(); // Lock object for synchronization

        public RaceCar(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }

        public void Run()
        {
            // Start the race
            Console.WriteLine($"{Name} starts the race!");
            while (Distance < 10)
            {
                // Simulate running
                Thread.Sleep(1000); // Simulate time passing (1 second)

                // Update distance (in km) based on speed
                lock (_lock)
                {
                    Distance += Speed / 360;
                }

                // Check for random events
                CheckForEvent();
            }
            Console.WriteLine($"{Name} finishes the race!");
        }

        private void CheckForEvent()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 51); // Generate a random number between 1 and 50

            if (randomNumber == 1)
            {
                Console.WriteLine($"{Name} ran out of gas and needs to refuel.");
                Thread.Sleep(30000); // Stop for 30 seconds
            }
            else if (randomNumber <= 2)
            {
                Console.WriteLine($"{Name} got a puncture and needs a tire change.");
                Thread.Sleep(20000); // Stop for 20 seconds
            }
            else if (randomNumber <= 5)
            {
                Console.WriteLine($"{Name} encountered a bird on the windshield and needs to wash it.");
                Thread.Sleep(10000); // Stop for 10 seconds
            }
            else if (randomNumber <= 10)
            {
                Console.WriteLine($"{Name}'s engine failed. Speed reduced by 1 km/h.");
                lock (_lock)
                {
                    Speed -= 1;
                }
            }
        }

    }
}

