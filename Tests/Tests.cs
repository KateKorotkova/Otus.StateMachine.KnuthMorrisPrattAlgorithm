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

        [TestCase("AA", ExpectedResult = 1)]
        [TestCase("AABAA", ExpectedResult = 2)]
        [TestCase("AABAAB", ExpectedResult = 3)]
        [TestCase("AABAABA", ExpectedResult = 4)]
        [TestCase("AABAABAA", ExpectedResult = 5)]
        public int Can_Get_Single_P_Value_Slowly(string pattern)
        {
            return new KnuthMorrisPrattAlgorithm().GetSinglePValueSlowly(pattern);
        }

        [Test]
        public void Cah_Get_P_Function_Slowly()
        {
            var pattern = "AABAABAAABA";

            var result = new KnuthMorrisPrattAlgorithm().GetPFunctionSlowly(pattern);

            Assert.That(result.Length, Is.EqualTo(pattern.Length + 1));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(0));
            Assert.That(result[2], Is.EqualTo(1));
            Assert.That(result[3], Is.EqualTo(0));
            Assert.That(result[4], Is.EqualTo(1));
            Assert.That(result[5], Is.EqualTo(2));
            Assert.That(result[6], Is.EqualTo(3));
            Assert.That(result[7], Is.EqualTo(4));
            Assert.That(result[8], Is.EqualTo(5));
            Assert.That(result[9], Is.EqualTo(2));
            Assert.That(result[10], Is.EqualTo(3));
            Assert.That(result[11], Is.EqualTo(4));
        }

        [Test]
        public void Cah_Get_P_Function_Fast()
        {
            var pattern = "AABAABAAABA";

            var result = new KnuthMorrisPrattAlgorithm().GetPFunctionFast(pattern);

            Assert.That(result.Length, Is.EqualTo(pattern.Length + 1));
            Assert.That(result[0], Is.EqualTo(0));
            Assert.That(result[1], Is.EqualTo(0));
            Assert.That(result[2], Is.EqualTo(1));
            Assert.That(result[3], Is.EqualTo(0));
            Assert.That(result[4], Is.EqualTo(1));
            Assert.That(result[5], Is.EqualTo(2));
            Assert.That(result[6], Is.EqualTo(3));
            Assert.That(result[7], Is.EqualTo(4));
            Assert.That(result[8], Is.EqualTo(5));
            Assert.That(result[9], Is.EqualTo(2));
            Assert.That(result[10], Is.EqualTo(3));
            Assert.That(result[11], Is.EqualTo(4));
        }

        [Test]
        public void Can_Find_Pattern()
        {
            var text = "ABAAABAABAAB";
            var pattern = "AABAAB";

            var result = new KnuthMorrisPrattAlgorithm().Run(text, pattern);

            Assert.That(result, Is.EqualTo(new[] {3, 6}));
        }
    }
}