using System;

namespace WebApplication3StarWars.Cross_Structure.Exceptions
{
    public class SplitterException : Exception
    {
        public SplitterException(string message) : base(message)
        {
        }

        public SplitterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}