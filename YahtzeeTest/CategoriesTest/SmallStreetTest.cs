using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class SmallStreetTest
    {
        private SmallStreet _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SmallStreet();
        }


        [TestCase(1, 2, 3, 5, 4)]
        public void SmallStreetScore_ShouldAddSmallStreet(int die1, int die2, int die3, int die4, int die5)
        {
            var expectedResult = 15;
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        public void SmallStreetScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4,
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
        public void SmallStreetCheck_WhenRollDoesNotContainSmallStreet_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 2, 3, 4, 5)]
        public void SmallStreetCheck_WhenRollContainsSmallStreet_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }
    }
}