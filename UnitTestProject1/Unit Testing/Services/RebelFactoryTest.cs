using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3StarWars.Cross_Structure.Exceptions;
using WebApplication3StarWars.Services.Factory;
using WebApplication3StarWars.Services.Specification;

namespace UnitTestProject.Unit_Testing.Services
{
    [TestClass]
    public class RebelFactoryTest
    {
        private IRebelFactory _rebelFactory;
        private ISpecification _specification;

        [TestInitialize]
        public void SetupVariables()
        {
            _specification = new Validator();
            _rebelFactory = new RebelFactory(_specification);
        }

        [TestMethod]
        public void CorrectFactory()
        {
            //Arrange
            const string name = "Sirius";
            const string planet = "Black";
            //Act
            var rebel = _rebelFactory.Create(name,planet);
            //Assert
            Assert.IsNotNull(rebel);
        }

        [TestMethod]
        public void IncorrectFactory()
        {
            //Arrange
            //Act and Assert
            Assert.ThrowsException<RebelFactoryException>(() => _rebelFactory.Create("", null));
        }

        [TestMethod]
        public void IncorrectFactory2()
        {
            //Arrange
            //Act and Assert
            Assert.ThrowsException<RebelFactoryException>(() => _rebelFactory.Create(null, ""));
        }
    }
}
