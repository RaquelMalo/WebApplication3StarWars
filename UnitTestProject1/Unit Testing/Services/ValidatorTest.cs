using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3StarWars.Services.Specification;

namespace UnitTestProject.Unit_Testing.Services
{
    [TestClass]
    public class ValidatorTest
    {
        private readonly ISpecification _validator;

        public ValidatorTest()
        {
           _validator = new Validator();
        }

        [TestMethod]
        public void TrueValidator()
        {
            Assert.IsTrue(_validator.IsSatisfiedBy("Sirius","Black"));
        }

        [TestMethod]
        public void FalseValidator()
        {
            Assert.IsFalse(_validator.IsSatisfiedBy("", null));
        }
    }
}
