using Cy4.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace Cy4.BusinessLogic.Implementations
{
    public class SimpleCypher : ICypher
    {
        private IDictionary<char, char> _characterParings;
        private int _defaultOffset;
        private List<char> _lowerCaseChars;
        private List<char> _upperCaseChars;
        private List<char> _digitChars;

        public SimpleCypher()
        {
            _defaultOffset = 1;
            _lowerCaseChars = new List<char>
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z'
            };
            _upperCaseChars = new List<char>
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            _digitChars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        }

        public string Encrypt(string value)
        {
            var newValue = "";
            ResetDict();
            CreateEncryptionDict();

            foreach(var character in value)
            {
                if (char.IsLetterOrDigit(character))
                    newValue += _characterParings[character];
                else
                    newValue += character;
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
            CreatePairingsFor(_lowerCaseChars, _defaultOffset);
            CreatePairingsFor(_upperCaseChars, _defaultOffset);
            CreatePairingsFor(_digitChars, _defaultOffset);
        }

        private void CreatePairingsFor(List<char> characterSet, int offset)
        {
            var maxIndex = characterSet.Count - 1;

            for (int i = 0; i < characterSet.Count; i++)
            {
                var pairIndex = GetPairIndex(i, offset, maxIndex);
                _characterParings.Add(characterSet[i], characterSet[pairIndex]);
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