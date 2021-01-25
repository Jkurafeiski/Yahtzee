using NUnit.Framework;
using Yahtzee;

namespace YahtzeeTest
{
    [TestFixture]
    public class ScoreCalculatorTest
    {
        private ScoreCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ScoreCalculator();
        }

        [TestCase(2, 6, 3, 3, 3, 9)]
        public void ThreeOfAKindScore_ShouldAddThreeOfAKind(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            
            var actualResult = _sut.ThreeOfAKindScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 2, 3, 3,4)]
        public void ThreeOfAKindScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.ThreeOfAKindScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 3, 3, 3, 3, 12)]
        public void FourOfAKindScore_ShouldAddFourOfAKind(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actualResult = _sut.FourOfAKindScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        public void FourOfAKindScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.FourOfAKindScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(6, 6, 5, 5, 4, 22)]
        public void DoublePairScore_ShouldAddDoublePair(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actualResult = _sut.DoublePairScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        public void DoublePairScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.DoublePairScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 2, 3, 3, 3, 13)]
        public void FullHouseScore_ShouldAddFullHouse(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actualResult = _sut.FullHouseScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 2, 3, 3, 4)]
        public void FullHouse_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.FullHouseScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}