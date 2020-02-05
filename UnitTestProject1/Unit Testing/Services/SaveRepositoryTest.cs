using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3StarWars.Services.Factory;
using WebApplication3StarWars.Services.Repository;
using WebApplication3StarWars.Services.Specification;
using WebApplication3StarWars.Services.Splitter;

namespace UnitTestProject.Unit_Testing.Services
{
    [TestClass]
    public class SaveRepositoryTest
    {
        private IRebelFactory _rebelFactory;
        private ISpecification _specification;
        private ISplitter _split;
        private ISaveRepository _saveRepository;

        [TestInitialize]
        public void SetupVariables()
        {
            _specification = new Validator();
            _rebelFactory = new RebelFactory(_specification);
            _split = new Splitter();
            _saveRepository = new SaveRepository(_split, _rebelFactory);
        }
        
        [TestMethod]
        public void NullStringCollection()
        {
            //Arrange
            var rebelStringCollection = new StringCollection();
            //Act (return an empty list of rebels)
            var rebels = _saveRepository.SaveRebels(rebelStringCollection);
            //Assert
            Assert.AreEqual(0,rebels.Count);
        }
    }
}
