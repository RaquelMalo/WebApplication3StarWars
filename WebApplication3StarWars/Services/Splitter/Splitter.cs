using System;
using WebApplication3StarWars.Cross_Structure.Exceptions;

namespace WebApplication3StarWars.Services.Splitter
{
    public class Splitter : ISplitter
    {
        public string[] Split(string rebelString)
        {
            string[] data;
            try
            {
                data = rebelString.Split(',');
                data[0] = data[0].Trim();
                data[1] = data[1].Trim();
                if (data.Length > 2)
                {
                    throw new SplitterException("Error to split the string collection. Expected less arguments.");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new SplitterException("Error to split the string collection. Separator no found.", ex);
            }
            catch (Exception ex)
            {
                throw new SplitterException("Unexpected error to split the string collection received.", ex);
            }

            return data;
        }
    }
}