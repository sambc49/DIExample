using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DIExample.Repositories;
using DIExample.Services;
using Microsoft.Extensions.DependencyInjection;

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
                            ContainerBuilder builder = new ContainerBuilder();

                            builder.RegisterType<AvengerRepository>().As<IAvengerRepository>();
                            builder.RegisterType<Logger>().As<ILogger>();
                            builder.RegisterType<SuperheroService>();

                            IContainer container = builder.Build();

                            var superheroService = container.Resolve<SuperheroService>();

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
                                ContainerBuilder builder = new ContainerBuilder();

                                builder.RegisterType<AvengerRepository>().As<IAvengerRepository>();
                                builder.RegisterType<Logger>().As<ILogger>();
                                builder.RegisterType<SuperheroService>();

                                IContainer container = builder.Build();

                                SuperheroService superheroService = container.Resolve<SuperheroService>();

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

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           
            // setup the Autofac container
            var builder = new ContainerBuilder();
            builder.Populate(services);
            services.AddTransient<ILogger, Logger>();
            services.AddTransient<IAvengerRepository, AvengerRepository>();
            services.AddTransient<SuperheroService>();
            var container = builder.Build();
            
            // return the IServiceProvider implementation
            return new AutofacServiceProvider(container);
        }
    }
}
