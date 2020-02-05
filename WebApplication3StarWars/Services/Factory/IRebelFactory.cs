using WebApplication3StarWars.Domain;

namespace WebApplication3StarWars.Services.Factory
{
    public interface IRebelFactory
    {
        Rebel Create(string name, string planet);
    }
}