using Cy4.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace Cy4.BusinessLogic.Implementations
{
    public class CypherFactory : ICypherFactory
    {
        private Dictionary<Cypher, ICypher> _cyphers;

        public CypherFactory()
        {
            _cyphers = new Dictionary<Cypher, ICypher>
            {
                { Cypher.Simple, new SimpleCypher() },
                { Cypher.Medium, new MediumCypher() }
            };
        }

        public ICypher CreateCypher(Cypher cypherType)
        {
            return _cyphers[cypherType];
        }
    }
}
