using Cy4.BusinessLogic.Implementations;
using Cy4.BusinessLogic.Interfaces;
using NUnit.Framework;

namespace Cy4.BusinessLogic.Tests.Implementations
{
    [TestFixture]
    public class SimpleCyperTests
    {
        private ICypher _simpleCyper;

        [SetUp]
        public void Setup()
        {
            _simpleCyper = new SimpleCypher();
        }

        [Test]
        public void Encrypt_ShouldShiftAllCapitalLettersByOneByDefault()
        {
            // Data.
            var unencryptedValue = "ABCDEFG";
            var expectedValue = "BCDEFGH";

            // Test
            var actualValue = _simpleCyper.Encrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Encrypt_ShouldShiftAllLowerCaseLettersByOneByDefault()
        {
            // Data.
            var unencryptedValue = "abcdefg";
            var expectedValue = "bcdefgh";

            // Test
            var actualValue = _simpleCyper.Encrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("AbCdEfG", "BcDeFgH")]
        [TestCase("abcDEF", "bcdEFG")]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", "BCDEFGHIJKLMNOPQRSTUVWXYZAbcdefghijklmnopqrstuvwxyza")]
        public void Encrypt_ShouldShiftUpperAndLowerCaseCharactersByOneAndRetainCase(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = _simpleCyper.Encrypt(unencryptedValue);

            // Analysis
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
