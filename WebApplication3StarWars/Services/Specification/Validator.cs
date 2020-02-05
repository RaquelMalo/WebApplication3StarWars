namespace WebApplication3StarWars.Services.Specification
{
    public class Validator : ISpecification
    {
        public bool IsSatisfiedBy(string name, string planet)
        {
            var result = !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(planet);
            return result;
        }
    }
}