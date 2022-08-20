using System.Collections.Generic;

namespace Otus.StateMachine.KnuthMorrisPrattAlgorithm.Logic
{
    public class KnuthMorrisPrattAlgorithm
    {
        public int[] Run(string text, string pattern)
        {
            var fakeBeginning = $"{pattern}#";
            var fakePattern = $"{fakeBeginning}{text}";
            var p = GetPFunctionSlowly(fakePattern);

            var result = new List<int>();
            for (var i = 0; i < p.Length; i++)
            {
                if (p[i] == pattern.Length)
                    result.Add(i - fakeBeginning.Length - pattern.Length);
            }

            return result.ToArray();
        }

        public int[] GetPFunctionSlowly(string pattern)
        {
            var p = new int[pattern.Length + 1];

            for (var i = 0; i < pattern.Length + 1; i++)
            {
                var patternPart = Utils.GetLeftPart(pattern, i);
                
                p[i] = GetSinglePValueSlowly(patternPart);
            }

            return p;
        }

        public int[] GetPFunctionFast(string pattern)
        {
            var pi = new int[pattern.Length + 1];
            pi[1] = 0;

            for (var q = 1; q < pattern.Length; q++)
            {
                var len = pi[q];
                while (len > 0 && pattern[len] != pattern[q])
                    len = pi[len];
                if (pattern[len] == pattern[q])
                    len++;

                pi[q + 1] = len;
            }

            return pi;
        }

        public int GetSinglePValueSlowly(string pattern)
        {
            var maxCounter = 0;

            for (var i = 0; i < pattern.Length; i++)
            {
                var counter = 0;
                var patternBeginning = Utils.GetLeftPart(pattern, i);

                for (var j = 0; j < patternBeginning.Length; j++)
                {
                    var indexInPatterFromRight = pattern.Length - patternBeginning.Length + j;

                    if (pattern[indexInPatterFromRight] == patternBeginning[j])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }

                if (counter > maxCounter)
                    maxCounter = counter;
            }

            return maxCounter;
        }
    }
}
