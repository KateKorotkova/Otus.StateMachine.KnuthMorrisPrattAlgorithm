using NUnit.Framework;
using Otus.StateMachine.KnuthMorrisPrattAlgorithm.Logic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Can_Fine_Substring_Via_State_Machine()
        {
            var text = "ABAAABAABAAB";
            var pattern = "AABAAB";

            var result = new StateMachine().Run(text, pattern);

            Assert.That(result, Is.EqualTo(3));
        }

        [TestCase("AABAA", ExpectedResult = 2)]
        [TestCase("AABAAB", ExpectedResult = 3)]
        [TestCase("AABAABA", ExpectedResult = 4)]
        [TestCase("AABAABAA", ExpectedResult = 5)]
        public int Can_Get_P_Function_Slowly(string pattern)
        {
            return new KnuthMorrisPrattAlgorithm().GetPFunctionSlowly(pattern);
        }
    }
}