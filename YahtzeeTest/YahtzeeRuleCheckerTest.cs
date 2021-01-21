using System.Collections.Generic;
using NUnit.Framework;
using Yahtzee;

namespace YahtzeeTest
{
    [TestFixture]
    public class YahtzeeRuleCheckerTest
    {
        private YahtzeeRuleChecker _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new YahtzeeRuleChecker();
        }

        [TestCase(1, 2, 3, 5, 4)]
        [TestCase(1, 2, 3, 6, 4)]
        [TestCase(1, 5, 3, 6, 2)]
        public void PairCheck_WhenRollDoesNotContainPair_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.PairCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 1, 1, 3, 4)]
        [TestCase(1, 1, 1, 1, 4)]
        [TestCase(1, 1, 5, 4, 3)]
        [TestCase(6, 1, 6, 3, 6)]
        [TestCase(5, 5, 5, 5, 5)]
        public void PairCheck_WhenRollContainsPair_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.PairCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 5, 4)]
        [TestCase(1, 1, 3, 5, 4)]
        [TestCase(1, 2, 3, 6, 4)]
        [TestCase(1, 5, 3, 6, 2)]
        [TestCase(5, 5, 5, 5, 5)]
        public void DoublePairCheck_WhenRollDoesNotContainDoublePair_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            var actual = _sut.DoublePairCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 1, 3, 3, 4)]
        [TestCase(1, 1, 1, 4, 4)]
        [TestCase(1, 1, 3, 3, 3)]
        public void DoublePairCheck_WhenRollContainsDoublePair_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.DoublePairCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 1, 3, 2, 2)]
        public void ThreeOfAKindCheck_WhenRollDoesNotContainThreeOfAKind_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actual = _sut.ThreeOfAKindCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 1, 1, 3, 4)]
        [TestCase(1, 1, 1, 1, 4)]
        [TestCase(1, 1, 3, 3, 3)]
        [TestCase(6, 1, 6, 3, 6)]
        [TestCase(5, 5, 5, 5, 5)]
        public void ThreeOfAKindCheck_WhenRollContainsThreeOfAKind_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.ThreeOfAKindCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 3)]
        [TestCase(1, 1, 1, 2, 2)]
        public void FourOfAKindCheck_WhenRollDoesNotContainFourOfAKind_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.FourOfAKindCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(3, 3, 3, 3, 4)]
        [TestCase(1, 1, 1, 1, 4)]
        [TestCase(1, 3, 3, 3, 3)]
        [TestCase(6, 1, 6, 6, 6)]
        [TestCase(5, 5, 5, 5, 5)]
        public void FourOfAKindCheck_WhenRollContainsFourOfAKind_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.FourOfAKindCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 3)]
        [TestCase(1, 1, 1, 2, 2)]
        public void YahtzeeCheck_WhenRollDoesNotContainYahtzee_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeeCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(6, 6, 6, 6, 6)]
        [TestCase(5, 5, 5, 4, 3)]
        [TestCase(6, 6, 1, 6, 2)]
        [TestCase(3, 5, 5, 4, 3)]
        public void FullHouseCheck_WhenRollDoesNotContainsFullHouse_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.FullHouseCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(5, 5, 5, 4, 4)]
        [TestCase(5, 4, 5, 4, 5)]
        public void FullHouseCheck_WhenRollContainsFullHouse_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.FullHouseCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 5, 6, 6, 4)]
        [TestCase(1, 1, 3, 2, 2)]
        public void SmallStreetCheck_WhenRollDoesNotContainSmallStreet_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.SmallStreetCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 2, 3, 4, 5)]
        public void SmallStreetCheck_WhenRollContainsSmallStreet_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.SmallStreetCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 5, 6, 6, 4)]
        [TestCase(1, 1, 3, 2, 2)]
        [TestCase(1, 2, 3, 4, 5)]
        public void LargeStreetCheck_WhenRollContainsLargeStreet_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.LargeStreetCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(2, 3, 4, 5, 6)]
        public void LargeStreetCheck_WhenRollContainsLargeStreet_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.LargeStreetCheck(diceRoll);

            Assert.IsTrue(actual);
        }
    }
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

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.Sum);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(5,2,6,1,5,10)]
        [TestCase(2, 2, 5, 4, 6, 4)]
        public void ScoreTestsWithExpectedResults_Pair(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.Pair);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 4, 5, 4, 6, 12)]
        [TestCase(6, 6, 5, 4, 6, 18)]
        public void ScoreTestsWithExpectedResults_ThreeofAKind(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.ThreeOfAKind);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, 3, 3, 3, 12)]
        [TestCase(2, 2, 2, 2, 3, 8)]
        public void ScoreTestsWithExpectedResults_FourOfAKind(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.FourOfAKind);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 5, 5, 5, 5, 50)]
        [TestCase(1, 1, 1, 1, 1, 50)]
        public void ScoreTestsWithExpectedResults_Yahtzee(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.Yahtzee);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 5, 3, 3, 5, 19)]
        [TestCase(3, 3, 3, 5, 5, 19)]
        public void ScoreTestsWithExpectedResults_FullHouse(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.FullHouse);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 4, 5, 15)]
        public void ScoreTestsWithExpectedResults_SmallStreet(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.SmallStreet);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, 4, 5, 6, 20)]
        public void ScoreTestsWithExpectedResults_LargeStreet(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.LargeStreet);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, 4, 5, 5, 1, 18)]
        [TestCase(2, 2, 4, 4, 6, 12)]
        public void ScoreTestsWithExpectedResults_DoublePair(int die1, int die2, int die3, int die4, int die5, int expected)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.YahtzeePointCalculator(diceRoll, YahtzeeInputRuler.DoublePair);

            Assert.AreEqual(expected, actual);
        }

    }
}