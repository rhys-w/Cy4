namespace Cy4.BusinessLogic.Interfaces
{
    public interface ICypher
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}
