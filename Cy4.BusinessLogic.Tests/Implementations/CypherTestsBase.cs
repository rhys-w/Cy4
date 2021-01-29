using Cy4.BusinessLogic.Interfaces;
using NUnit.Framework;

namespace Cy4.BusinessLogic.Tests.Implementations
{
    [TestFixture]
    public abstract class CypherTestsBase
    {
        protected ICypher Cypher;

        protected virtual void SpecificSetup() { }

        [SetUp]
        public void Setup()
        {
            SpecificSetup();
        }

        #region Other

        [TestCase("A1B2C3")]
        [TestCase("ABCDEF")]
        [TestCase("abcefjgogh")]
        [TestCase("djn1to8yycj0i1e0")]
        [TestCase("h1th089)*H1j01tg")]
        [TestCase("A8A8A8A8A")]
        public void Decrypt_ShouldReturnTheOriginalValueBeforeEncrypt(string original)
        {
            // Test
            var encrypted = Cypher.Encrypt(original);
            var decrypted = Cypher.Decrypt(encrypted);

            // Analysis
            Assert.AreEqual(original, decrypted);
        }

        #endregion
    }
}
