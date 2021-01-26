using NUnit.Framework;
using Yahtzee;

namespace YahtzeeTest
{
    [TestFixture]
    public class YahtzeeRuleScoreCheckerTest
    {
        private YahtzeeMath _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new YahtzeeMath();
        }

        [TestCase(5, 3, 4, 2, 6, 20)]
        [TestCase(2, 2, 4, 4, 6, 18)]
        public void ScoreTestsWithExpectedResults_Sum(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.Sum);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(5,2,6,1,5,10)]
        [TestCase(2, 2, 5, 4, 6, 4)]
        public void ScoreTestsWithExpectedResults_Pair(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.Pair);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 4, 5, 4, 6, 12)]
        [TestCase(6, 6, 5, 4, 6, 18)]
        public void ScoreTestsWithExpectedResults_ThreeofAKind(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.ThreeOfAKind);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, 3, 3, 3, 12)]
        [TestCase(2, 2, 2, 2, 3, 8)]
        public void ScoreTestsWithExpectedResults_FourOfAKind(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.FourOfAKind);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 5, 5, 5, 5, 50)]
        [TestCase(1, 1, 1, 1, 1, 50)]
        public void ScoreTestsWithExpectedResults_Yahtzee(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.Yahtzee);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 5, 3, 3, 5, 19)]
        [TestCase(3, 3, 3, 5, 5, 19)]
        public void ScoreTestsWithExpectedResults_FullHouse(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.FullHouse);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 4, 5, 15)]
        public void ScoreTestsWithExpectedResults_SmallStreet(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.SmallStreet);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, 4, 5, 6, 20)]
        public void ScoreTestsWithExpectedResults_LargeStreet(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.LargeStreet);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 4, 5, 5, 1, 18)]
        [TestCase(2, 2, 4, 4, 6, 12)]
        public void ScoreTestsWithExpectedResults_DoublePair(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeCategory.DoublePair);

            Assert.AreEqual(expected, actual);
        }

    }
}