namespace Cy4.BusinessLogic.Interfaces
{
    public interface ICypherFactory
    {
        ICypher CreateCypher(Cypher cypherType);
    }
}
