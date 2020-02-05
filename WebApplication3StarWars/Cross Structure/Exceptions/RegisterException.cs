using System;

namespace WebApplication3StarWars.Cross_Structure.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}