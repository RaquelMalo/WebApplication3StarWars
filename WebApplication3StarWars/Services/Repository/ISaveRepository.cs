using System.Collections.Generic;
using System.Collections.Specialized;
using WebApplication3StarWars.Domain;

namespace WebApplication3StarWars.Services.Repository
{
    public interface ISaveRepository
    {
        List<Rebel> SaveRebels(StringCollection rebelStringCollection);
    }
}