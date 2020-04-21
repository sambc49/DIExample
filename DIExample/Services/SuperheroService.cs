using System;
using System.Collections.Generic;
using DIExample.Models;
using DIExample.Repositories;

namespace DIExample.Services
{
    public class SuperheroService
    {
        public IEnumerable<Hero> GetAvengers()
        {
            var logger = new Logger();
            logger.Log("Calling SuperheroService.GetAvengers.");

            var avengersRepository = new AvengerRepository();
            var avengers = avengersRepository.FetchAll();

            logger.Log("SuperheroService.GetAvengers called.");

            return avengers;
        }

        public Hero GetAvenger(string name)
        {
            var logger = new Logger();
            logger.Log($"Calling SuperheroService.GetAvenger('{name}').");

            var avengersRepository = new AvengerRepository();
            
            var avenger = avengersRepository.Fetch(name);
            logger.Log($"SuperheroService.GetAvenger('{name}') called.");

            return avenger;
        }
    }
}
