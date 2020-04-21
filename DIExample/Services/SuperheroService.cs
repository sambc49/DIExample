using System;
using System.Collections.Generic;
using DIExample.Models;
using DIExample.Repositories;

namespace DIExample.Services
{
    public class SuperheroService
    {
        private readonly IAvengerRepository _avengerRepository;
        private readonly ILogger _logger;

        public SuperheroService(IAvengerRepository avengerRepository, ILogger logger)
        {
            _avengerRepository = avengerRepository;
            _logger = logger;
        }
        public IEnumerable<Hero> GetAvengers()
        {
            _logger.Log("Calling SuperheroService.GetAvengers.");
            var avengers = _avengerRepository.FetchAll();

            _logger.Log("SuperheroService.GetAvengers called.");

            return avengers;
        }

        public Hero GetAvenger(string name)
        {
            _logger.Log($"Calling SuperheroService.GetAvenger('{name}').");
            
            var avenger = _avengerRepository.Fetch(name);
            _logger.Log($"SuperheroService.GetAvenger('{name}') called.");

            return avenger;
        }
    }
}
