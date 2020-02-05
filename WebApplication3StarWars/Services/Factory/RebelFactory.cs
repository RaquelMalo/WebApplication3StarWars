using WebApplication3StarWars.Cross_Structure.Exceptions;
using WebApplication3StarWars.Domain;
using WebApplication3StarWars.Services.Specification;

namespace WebApplication3StarWars.Services.Factory
{
    public class RebelFactory : IRebelFactory
    {

        private readonly ISpecification _specification;

        public RebelFactory(ISpecification specification)
        {
            _specification = specification;
        }

        public Rebel Create(string name, string planet)
        {
            if (_specification.IsSatisfiedBy(name, planet))
            {
                return new Rebel(name, planet);
            }
            else
            {
                throw new RebelFactoryException("Error to create a rebel.");
            }
        }
    }
}