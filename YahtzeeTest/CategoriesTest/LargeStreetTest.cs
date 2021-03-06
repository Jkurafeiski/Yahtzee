using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class LargeStreetTest
    {
        private LargeStreet _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new LargeStreet();
        }


        [TestCase(6, 5, 4, 3, 2)]
        public void LargeStreetScore_ShouldAddLargestreet(int die1, int die2, int die3, int die4, int die5)
        {
            var expectedResult = 20;
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        public void LargeStreet_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4,
            int die5)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 5, 6, 6, 4)]
        [TestCase(1, 1, 3, 2, 2)]
        [TestCase(1, 2, 3, 4, 5)]
        public void LargeStreetCheck_WhenRollContainsLargeStreet_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(2, 3, 4, 5, 6)]
        public void LargeStreetCheck_WhenRollContainsLargeStreet_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }

    }
}