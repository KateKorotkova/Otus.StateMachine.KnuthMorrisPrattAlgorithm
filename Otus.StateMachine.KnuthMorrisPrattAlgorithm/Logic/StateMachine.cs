using System.Security.Cryptography.X509Certificates;

namespace Otus.StateMachine.KnuthMorrisPrattAlgorithm.Logic
{
    public class StateMachine
    {
        //private string _alphabet = "ABC";
        private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public int Run(string text, string pattern)
        {
            var qTable = GetQTable(pattern);

            return GetIndex(text, pattern, qTable);
        }


        #region Support Methods

        private int[,] GetQTable(string pattern)
        {
            var qTable = new int[pattern.Length + 1, _alphabet.Length];

            for (var i = 0; i < pattern.Length + 1; i++)
            {
                var subPattern = pattern.Substring(0, i);

                foreach (var el in _alphabet)
                {
                    var line = subPattern + el;
                    var nextPatternSize = i + 1;

                    while (nextPatternSize != 0 && Utils.GetLeftPart(pattern, nextPatternSize) != Utils.GetRightPart(line, nextPatternSize))
                    {
                        nextPatternSize--;
                    }

                    qTable[i, GetCharacterIndex(el)] = nextPatternSize;
                }
            }

            return qTable;
        }

        private int GetIndex(string text, string pattern, int[,] qTable)
        {
            var q = 0;
            for(var i = 0; i < text.Length; i++)
            {
                q = qTable[q, GetCharacterIndex(text[i])];
                if (q == pattern.Length)
                    return i - pattern.Length + 1;
            }

            return -1;
        }

        private int GetCharacterIndex(char el)
        {
            return el - _alphabet[0];
        }

        #endregion
    }
}
