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
            var avengersRepository = new AvengerRepository();
            return avengersRepository.FetchAll();
        }

        public Hero GetAvenger(string name)
        {
            var avengersRepository = new AvengerRepository();
            return avengersRepository.Fetch(name);
        }
    }
}
