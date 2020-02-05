using System;
using System.Collections.Generic;
using System.IO;
using WebApplication3StarWars.Cross_Structure.Exceptions;
using WebApplication3StarWars.Domain;

namespace WebApplication3StarWars.Services.Register
{
    public class Register : IRegister
    {
        /// <summary>
        ///     Text file with the information of all valid rebels received
        /// </summary>
        /// <param name="rebelList">List of rebel objects after the conversion of the original string list</param>
        public void RebelRegister(IEnumerable<Rebel> rebelList)
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;

            var fileName = Path.Combine(directoryPath, "Register.txt");
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            try
            {
                using (var w = File.AppendText(fileName))
                {//using open and close the connection automatically
                    foreach (var rebel in rebelList)
                    {
                        AppendLog($"Rebel {rebel.Name} on {rebel.Planet} at {rebel.Datetime}", w);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new RegisterException("Unexpected error opening and writing register file. ", ex);
            }
        }

        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"{logMessage}");
                txtWriter.Flush();
            }
            catch (Exception ex)
            {
                throw new RegisterException("Write error in the register file. ", ex);
            }
        }
    }
}