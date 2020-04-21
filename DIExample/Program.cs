using System;
using DIExample.Services;

namespace DIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1 - Get all Avengers");
                Console.WriteLine("2 - Get a single Avenger");
                Console.WriteLine("\n0 - Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            var superheroService = new SuperheroService();

                            var avengers = superheroService.GetAvengers();
                            foreach (var avenger in avengers)
                            {
                                Console.WriteLine($"{avenger.SuperheroName}, who is really {avenger.RealName}, and has {avenger.Power}. \n");
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Enter Avenger name: ");
                            string name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                var superheroService = new SuperheroService();
                                var avenger = superheroService.GetAvenger(name);
                                if (avenger != null)
                                {
                                    Console.WriteLine($"{avenger.SuperheroName}, who is really {avenger.RealName}, and has {avenger.Power}. \n");
                                }
                                Console.WriteLine($"Cannot find Avenger with the name '{name}' \n");
                            }
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
        }
    }
}
