using System;

namespace WebApplication3StarWars.Domain
{
    public class Rebel
    {
        public Rebel(string name, string planet)
        {
            Name = name;
            Planet = planet;
            Datetime = DateTime.Now;
        }

        public string Name { get; set; }
        public string Planet { get; set; }
        public DateTime Datetime { get; set; }
    }
}