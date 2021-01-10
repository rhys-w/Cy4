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

        #region Encrypt

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

        [TestCase("1", "2")]
        [TestCase("1234567890", "2345678901")]
        public void Encrypt_ShouldShiftNumbersUpOneValue(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = _simpleCyper.Encrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("10.5", "21.6")]
        [TestCase("ABC!%$&123_3", "BCD!%$&234_4")]
        public void Encrypt_ShouldIgnoreSymbols(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = _simpleCyper.Encrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        #endregion

        #region Decrypt

        [Test]
        public void Decrypt_ShouldShiftAllCapitalLettersBackByOneByDefault()
        {
            // Data.
            var unencryptedValue = "BCDEFGH";
            var expectedValue = "ABCDEFG";

            // Test
            var actualValue = _simpleCyper.Decrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Decrypt_ShouldShiftAllLowerCaseLettersBackByOneByDefault()
        {
            // Data.
            var unencryptedValue = "bcdefgh";
            var expectedValue = "abcdefg";

            // Test
            var actualValue = _simpleCyper.Decrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("BcDeFgH", "AbCdEfG")]
        [TestCase("bcdEFG", "abcDEF")]
        [TestCase("BCDEFGHIJKLMNOPQRSTUVWXYZAbcdefghijklmnopqrstuvwxyza", "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")]
        public void Decrypt_ShouldShiftUpperAndLowerCaseCharactersBackByOneAndRetainCase(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = _simpleCyper.Decrypt(unencryptedValue);

            // Analysis
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("2", "1")]
        [TestCase("2345678901", "1234567890")]
        public void Decrypt_ShouldShiftNumbersDownOneValue(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = _simpleCyper.Decrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase("21.6", "10.5")]
        [TestCase("BCD!%$&234_4", "ABC!%$&123_3")]
        public void Decrypt_ShouldIgnoreSymbols(string unencryptedValue, string expectedValue)
        {
            // Test
            var actualValue = _simpleCyper.Decrypt(unencryptedValue);

            // Analysis.
            Assert.AreEqual(expectedValue, actualValue);
        }

        #endregion

        #region Other

        [TestCase("ABCDEF")]
        [TestCase("abcefjgogh")]
        [TestCase("djn1to8yycj0i1e0")]
        [TestCase("h1th089)*H1j01tg")]
        public void Decrypt_ShouldReturnTheOriginalValueBeforeEncrypt(string original)
        {
            // Test
            var encrypted = _simpleCyper.Encrypt(original);
            var decrypted = _simpleCyper.Decrypt(encrypted);

            // Analysis
            Assert.AreEqual(original, decrypted);
        }

        #endregion
    }
}
