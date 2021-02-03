using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class FullHouseTest
    {
        private FullHouse _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new FullHouse();
        }

        [TestCase(2, 2, 3, 3, 3, 13)]
        [TestCase(4, 4, 4, 3, 3, 18)]
        [TestCase(5, 5, 6, 6, 6, 28)]
        public void FullHouseScore_ShouldAddFullHouse(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 2, 3, 3, 4)]
        [TestCase(2, 4, 3, 5, 4)]
        [TestCase(2, 5, 3, 6, 2)]
        public void FullHouse_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(6, 6, 6, 6, 6)]
        [TestCase(5, 5, 5, 4, 3)]
        [TestCase(6, 6, 1, 6, 2)]
        [TestCase(3, 5, 5, 4, 3)]
        public void FullHouseCheck_WhenRollDoesNotContainsFullHouse_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(5, 5, 5, 4, 4)]
        [TestCase(5, 4, 5, 4, 5)]
        public void FullHouseCheck_WhenRollContainsFullHouse_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }
    }
}