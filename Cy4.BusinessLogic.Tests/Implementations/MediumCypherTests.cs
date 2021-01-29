using Cy4.BusinessLogic.Implementations;
using NUnit.Framework;

namespace Cy4.BusinessLogic.Tests.Implementations
{
    [TestFixture]
    public class MediumCypherTests : CypherTestsBase
    {
        protected override void SpecificSetup()
        {
            Cypher = new MediumCypher();
        }

        [Test]
        public void Encrypt_ShouldShiftAllCapitalLettersByOneByDefault()
        {
            // Data.
            var unencryptedValue = "ABCDEFG";
            var expectedValue = "BCDEFGH";

            // Test
            var actualValue = Cypher.Encrypt(unencryptedValue);

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
            var actualValue = Cypher.Encrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("AbCdEfG", "BcDeFgH")]
        [TestCase("abcDEF", "bcdEFG")]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", "BCDEFGHIJKLMNOPQRSTUVWXYZAbcdefghijklmnopqrstuvwxyza")]
        public void Encrypt_ShouldShiftUpperAndLowerCaseCharactersByOneAndRetainCase(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = Cypher.Encrypt(unencryptedValue);

            // Analysis
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("ABC1ABC", "BCD2CDE")]
        public void Encrypt_ShouldIncreaseOffsetWhenItReadsANumber(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = Cypher.Encrypt(unencryptedValue);

            // Analysis
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("111111", "234567")]
        [TestCase("A8A8A8A8A", "B9J7R5Z3H")]
        public void Encrypt_ShouldIncreaseWithEVeryNumberItReader(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = Cypher.Encrypt(unencryptedValue);

            // Analysis
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
