using System.Collections.Generic;
using WebApplication3StarWars.Domain;

namespace WebApplication3StarWars.Services.Register
{
    public interface IRegister
    {
        void RebelRegister(IEnumerable<Rebel> rebelList);
    }
}