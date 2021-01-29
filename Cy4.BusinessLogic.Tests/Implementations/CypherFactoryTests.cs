using Cy4.BusinessLogic.Implementations;
using Cy4.BusinessLogic.Interfaces;
using NUnit.Framework;
using System;

namespace Cy4.BusinessLogic.Tests.Implementations
{
    [TestFixture]
    public class CypherFactoryTests
    {
        [TestCase(typeof(MediumCypher), Cypher.Medium)]
        [TestCase(typeof(SimpleCypher), Cypher.Simple)]
        public void CreateCypher_ReturnsCorrectCypherType(Type expectedCypherType, Cypher cypherType)
        {
            // Setup.
            ICypherFactory fact = new CypherFactory();

            // Testing.
            var createdCypher = fact.CreateCypher(cypherType);

            // Analysis.
            Assert.AreEqual(createdCypher.GetType(), expectedCypherType);
        }
    }
}
