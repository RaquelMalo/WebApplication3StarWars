using System;

namespace WebApplication3StarWars.Cross_Structure.Exceptions
{
    public class RebelFactoryException : Exception
    {
        public RebelFactoryException(string message) : base(message)
        {
        }
    }
}