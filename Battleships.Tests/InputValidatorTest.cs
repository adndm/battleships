using Battleships.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests
{
    [TestClass]
    public class InputValidatorTest
    {
        [TestMethod]
        public void TestValidateSeeGrid_InvalidInput()
        {
            string input = "aaa";

            bool isValid = InputValidator.IsSeeGridValid(input);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestValidateSeeGrid_ValidYesInput()
        {
            string input = "Y";

            bool isValid = InputValidator.IsSeeGridValid(input);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestValidateSeeGrid_ValidNoInput()
        {
            string input = "N";

            bool isValid = InputValidator.IsSeeGridValid(input);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestValidateSeeGrid_NullInput()
        {
            string input = null;

            bool isValid = InputValidator.IsSeeGridValid(input);

            Assert.IsFalse(isValid);
        }
    }
}
