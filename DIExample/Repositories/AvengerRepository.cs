using System;
using System.Collections.Generic;
using System.Linq;
using DIExample.Models;
using DIExample.Services;

namespace DIExample.Repositories
{
    public interface IAvengerRepository
    {
        IEnumerable<Hero> FetchAll();
        Hero Fetch(string name);
    }
    public class AvengerRepository : IAvengerRepository
    {
        private readonly ILogger _logger;
        public AvengerRepository(ILogger logger)
        {
            _logger = logger;
        }
        public IEnumerable<Hero> FetchAll()
        {
            //simulates db operation to go and get list of heroes from a database
            var heroes = new List<Hero>()
            {
                new Hero("Ironman", "Tony Stark", "Extreme Geek Suit"),
                new Hero("Thor", "Thor Johnson", "Craftsman Professional Hammer"),
                new Hero("Captain America", "Steve Rogers", "Steroid Tolerance & Big Frisbee"),
                new Hero("Hulk", "Bruce Banner", "Chlorofill Induced Epidermis"),
                new Hero("Black Widow", "Natasha Romanov", "Mixed-Martial Arts & Bad Temper"),
                new Hero("Spiderman", "Peter Parker", "Tarzan-like Swinging Abilities")
            };

            _logger.Log("AvengerRepository.FetchAll called - Database hit.");

            return heroes;
        }

        public Hero Fetch(string name)
        {
            var allHeroes = FetchAll();

            _logger.Log("AvengerRepository.Fetch('{0}') called - Database hit.", name);

            return allHeroes.FirstOrDefault(x => x.SuperheroName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
