using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3StarWars.Domain;
using WebApplication3StarWars.Services.Register;

namespace UnitTestProject.Unit_Testing.Services
{
    [TestClass]
    public class RegisterTest
    {
        private readonly IRegister _register;
        private string _content;

        public RegisterTest()
        {
            _register = new Register();
            _content = string.Empty;
        }

        [TestMethod]
        public void CorrectRegister()
        {
            //Arrange
            var rebelList = new List<Rebel>
            {
                new Rebel("Rachel", "Bad")
            };
            //Act
            _register.RebelRegister(rebelList);
            //Assert
            var pathFile = AppDomain.CurrentDomain.BaseDirectory + "\\Register.txt";
            _content = File.ReadAllText(pathFile);
            var lines = _content.Split(Environment.NewLine);
            //Assert
            Assert.IsTrue(File.Exists(pathFile));

            //var content = string.Empty;

            //if (File.Exists(pathFile))
            //{
            //    content = File.ReadAllText(pathFile);
            //    string[] lines = content.Split(Environment.NewLine);
            //    var lastLine = lines[lines.Length-1];
            //    var data = lastLine.Split("at");
            //    Assert.AreEqual("Rebel Rachel on Bad ", data[0]);
            //}
        }

        //[TestMethod]
        //public void IncorrectRegister()
        //{
        //    //Arrange
        //    List<Rebel> rebelList = null; //Foreach fails when the list is null. If list empty don't fail.
        //    //Act and Assert (NullReferenceException -> error before going into the method
        //    Assert.ThrowsException<RegisterException>(() => _register.RebelRegister(rebelList));
        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    var content = string.Empty;
        //}
    }
}
