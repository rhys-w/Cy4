using Cy4.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace Cy4.BusinessLogic.Implementations
{
    public class SimpleCypher : ICypher
    {
        private IDictionary<char, char> _characterParings;
        private int _defaultOffset;

        public SimpleCypher()
        {
            _defaultOffset = 1;
        }

        public string Encrypt(string value)
        {
            var newValue = "";
            ResetDict();
            CreateEncryptionDict();

            foreach(var character in value)
            {
                newValue += _characterParings[character];
            }

            return newValue;
        }

        public string Decrypt(string value)
        {
            throw new System.NotImplementedException();
        }

        private void ResetDict()
        {
            _characterParings?.Clear();
            _characterParings = new Dictionary<char, char>();
        }

        private void CreateEncryptionDict()
        {
            CreateUpperCasePairings();
            CreateLowerCasePairings();
        }

        private void CreateLowerCasePairings()
        {
            var lowerCaseChars = new List<char>
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z'
            };

            for (int i = 0; i < 26; i++)
            {
                var pairIndex = GetPairIndex(i, 1, 25);
                _characterParings.Add(lowerCaseChars[i], lowerCaseChars[pairIndex]);
            }
        }

        private void CreateUpperCasePairings()
        {
            var upperCaseChars = new List<char>
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };

            for (int i = 0; i < 26; i++)
            {
                var pairIndex = GetPairIndex(i, 1, 25);
                _characterParings.Add(upperCaseChars[i], upperCaseChars[pairIndex]);
            }
        }

        private int GetPairIndex(int currentIndex, int offset, int maxIndex)
        {
            var pairIndex = currentIndex + offset;

            while (pairIndex > maxIndex)
            {
                pairIndex -= maxIndex + 1;
            }

            return pairIndex;
        }
    }
}
