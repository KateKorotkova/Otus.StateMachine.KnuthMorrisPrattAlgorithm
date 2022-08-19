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
    }
}