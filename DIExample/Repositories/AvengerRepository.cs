using System;
using System.Collections.Generic;
using System.Linq;
using DIExample.Models;

namespace DIExample.Repositories
{
    public class AvengerRepository
    {
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

            return heroes;
        }

        public Hero Fetch(string name)
        {
            var allHeroes = FetchAll();

            return allHeroes.FirstOrDefault(x => x.SuperheroName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
