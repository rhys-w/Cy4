using Cy4.BusinessLogic;
using Cy4.BusinessLogic.Implementations;
using Cy4.BusinessLogic.Interfaces;
using System;

namespace Cy4.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                PrintHelpText();
                return;
            }

            var cypherType = args[0];
            var encyptOrDecrypt = args[1];

            var cypherEnum = (Cypher)Enum.Parse(typeof(Cypher), cypherType);

            ICypherFactory factory = new CypherFactory();

            var cypher = factory.CreateCypher(cypherEnum);

            var textToOperateOn = ArrayHelpers.SubArray(args, 2, args.Length - 2);

            var allText = string.Join(' ', textToOperateOn);

            if (encyptOrDecrypt == "Encrypt")
                Console.WriteLine(cypher.Encrypt(allText));
            else
                Console.WriteLine(cypher.Decrypt(allText));
        }

        private static void PrintHelpText()
        {
            Console.WriteLine("Cy4 Encryption / Decryption");
            Console.WriteLine("Enter the following:");
            Console.WriteLine("1      - Cypher type");
            Console.WriteLine("2      - Encrypt / Decrypt");
            Console.WriteLine("Then any text you want to operate on");
        }
    }

    public static class ArrayHelpers
    {
        public static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }

}
