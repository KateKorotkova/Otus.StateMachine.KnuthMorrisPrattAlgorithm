namespace Otus.StateMachine.KnuthMorrisPrattAlgorithm.Logic
{
    public class KnuthMorrisPrattAlgorithm
    {
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
