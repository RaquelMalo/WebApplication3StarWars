using System.Collections.Specialized;

namespace WebApplication3StarWars.Services.Repository
{
    public class FakeRepository : IRepository
    {
        // Creates and initializes a new StringCollection.
        private readonly StringCollection _rebelString = new StringCollection();

        public FakeRepository()
        {
            for (var c = 1; c < 100; c++) _rebelString.Add("Rebel " + c + ",Planet " + c);
        }

        public StringCollection RebelString()
        {
            return _rebelString;
        }
    }
}