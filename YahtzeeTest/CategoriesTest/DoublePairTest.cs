using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class DoublePairTest
    {
        private DoublePair _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DoublePair();
        }


        [TestCase(6, 6, 5, 5, 4, 22)]
        [TestCase(3, 3, 5, 5, 4, 16)]
        [TestCase(2, 2, 1, 1, 4, 6)]
        public void DoublePairScore_ShouldAddDoublePair(int die1, int die2, int die3, int die4, int die5,
            int expectedResult)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        [TestCase(1, 2, 4, 3, 4)]
        [TestCase(5, 5, 2, 1, 4)]
        public void DoublePairScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4,
            int die5)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(1, 2, 3, 5, 4)]
        [TestCase(1, 1, 3, 5, 4)]
        [TestCase(1, 2, 3, 6, 4)]
        [TestCase(1, 5, 3, 6, 2)]
        [TestCase(5, 5, 5, 5, 5)]
        public void DoublePairCheck_WhenRollDoesNotContainDoublePair_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 1, 3, 3, 4)]
        [TestCase(1, 1, 1, 4, 4)]
        [TestCase(1, 1, 3, 3, 3)]
        public void DoublePairCheck_WhenRollContainsDoublePair_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }
    }
}