namespace WebApplication3StarWars.Services.Specification
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(string name, string planet);
    }
}