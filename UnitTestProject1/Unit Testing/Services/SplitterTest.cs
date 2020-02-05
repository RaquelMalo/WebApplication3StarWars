using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3StarWars.Cross_Structure.Exceptions;
using WebApplication3StarWars.Services.Splitter;

namespace UnitTestProject.Unit_Testing.Services
{
    [TestClass]
    public class SplitterTest
    {
        private ISplitter _split;

        [TestInitialize]
        public void SetupVariables()
        {
           _split = new Splitter();
        }

        [TestMethod]
        public void CorrectSplit()
        {
            //Arrange
            //SetupVariables();
            //Act
            var rebel = _split.Split("Nora, Wan");
            //Assert
            Assert.AreEqual("Nora", rebel[0]);
            Assert.AreEqual("Wan", rebel[1]);
        }

        [TestMethod]
        public void OnlyCommaString()
        {
            //Arrange
            //SetupVariables();
            //Act
            var rebel = _split.Split(",");
            //Assert
            Assert.AreEqual("", rebel[0]);
            Assert.AreEqual("", rebel[1]);
        }

        [TestMethod]
        public void WhiteSpaceAndCommaString()
        {
            //Arrange
            //SetupVariables();
            //Act
            var rebel = _split.Split(" , ");
            //Assert
            Assert.AreEqual("", rebel[0]);
            Assert.AreEqual("", rebel[1]);
        }

        [TestMethod]
        public void IncorrectSplit()
        {
            //Arrange
            //SetupVariables();
            //Act and Assert
            Assert.ThrowsException<SplitterException>(() => _split.Split("Nora - Wan"));
        }

        [TestMethod]
        public void ThreeArguments()
        {
            //Arrange
            //SetupVariables();
            //Act and Assert
            Assert.ThrowsException<SplitterException>(() => _split.Split("Nora, Wan, Andromeda"));
        }
    }
}
