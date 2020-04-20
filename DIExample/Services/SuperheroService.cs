using System;
using System.Collections.Generic;
using DIExample.Models;

namespace DIExample.Services
{
    public class SuperheroService
    {
        public IEnumerable<Hero> GetAvengers()
        {
            //here call the avengerRepository to get all avengers
            return null;
        }

        public Hero GetAvenger(string name)
        {
            //here call the avengerRepository to get single avenger by name
            return null;
        }
    }
}
