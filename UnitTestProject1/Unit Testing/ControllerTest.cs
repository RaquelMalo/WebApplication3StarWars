using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3StarWars.Controllers;
using WebApplication3StarWars.Cross_Structure.Exceptions;
using WebApplication3StarWars.Services.Factory;
using WebApplication3StarWars.Services.Register;
using WebApplication3StarWars.Services.Repository;
using WebApplication3StarWars.Services.Specification;
using WebApplication3StarWars.Services.Splitter;

namespace UnitTestProject.Unit_Testing
{
    [TestClass]
    public class ControllerTest
    {
        private ILogger _log;
        private IRepository _repository;
        private ISaveRepository _saveRepository;
        private IRegister _register;
        private IRebelFactory _rebelFactory;
        private ISpecification _specification;
        private ISplitter _split;

        [TestInitialize]
        public void SetupVariables()
        {
            _log = new Logger<RegisterController>(new NullLoggerFactory());
            //_repository = new FakeRepository();
            _specification = new Validator();
            _rebelFactory = new RebelFactory(_specification);
            _split = new Splitter();
            _saveRepository = new SaveRepository(_split, _rebelFactory);
            _register = new Register();
        }
        
        [TestMethod]
        public void OkController()
        {
            //Arrange
            _repository = new FakeRepository();
            var controller = new RegisterController(_repository, _saveRepository, _register, _log as ILogger<RegisterController>);
            //Act
            var result = controller.GetRebels();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is IActionResult);
        }

        [TestMethod]
        public void ExceptionController()
        {
            //Arrange
            _repository = new RebelRepository();//Give error because not implemented, return null
            var controller = new RegisterController(_repository, _saveRepository, _register, _log as ILogger<RegisterController>);
            //Act and Assert
            Assert.ThrowsException<ControllerException>(() => controller.GetRebels());
        }
    }
}
