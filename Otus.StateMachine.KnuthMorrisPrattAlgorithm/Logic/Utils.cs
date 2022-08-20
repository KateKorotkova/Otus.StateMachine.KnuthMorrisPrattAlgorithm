namespace Otus.StateMachine.KnuthMorrisPrattAlgorithm.Logic
{
    public static class Utils
    {
        public static string GetLeftPart(string pattern, int index)
        {
            return pattern.Length < index ? pattern : pattern.Substring(0, index);
        }

        public static string GetRightPart(string line, int index)
        {
            return line.Length < index ? line : line.Substring(line.Length - index, index);
        }
    }
}
