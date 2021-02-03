using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class PairTest
    {
        private Pair _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Pair();
        }


        [TestCase(6, 6, 5, 3, 4, 12)]
        [TestCase(3, 6, 5, 3, 4, 6)]
        [TestCase(6, 2, 5, 3, 2, 4)]
        public void LargeStreetScore_ShouldAddLargestreet(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 1, 3, 4)]
        public void DoublePairScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4,
            int die5)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestCase(1, 1, 1, 3, 4)]
        [TestCase(1, 1, 1, 1, 4)]
        [TestCase(1, 1, 5, 4, 3)]
        [TestCase(6, 1, 6, 3, 6)]
        [TestCase(5, 5, 5, 5, 5)]
        public void PairCheck_WhenRollContainsPair_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }
        
        [TestCase(1, 2, 3, 5, 4)]
        [TestCase(1, 2, 3, 6, 4)]
        [TestCase(1, 5, 3, 6, 2)]
        public void PairCheck_WhenRollDoesNotContainPair_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }
    }
}