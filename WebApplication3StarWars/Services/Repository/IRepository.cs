using System.Collections.Specialized;

namespace WebApplication3StarWars.Services.Repository
{
    public interface IRepository
    {
        /// <summary>
        ///     IN Data of the application
        /// </summary>
        /// <returns>A string collection with name and planet separated with comma</returns>
        StringCollection RebelString();
    }
}