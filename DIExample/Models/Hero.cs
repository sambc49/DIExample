using System;
namespace DIExample.Models
{
    public class Hero
    {
        public Hero(string superheroName, string realName, string power)
        {
            SuperheroName = superheroName;
            RealName = realName;
            Power = power;
        }
        public string SuperheroName { get; set; }
        public string RealName { get; set; }
        public string Power { get; set; }
    }
}
