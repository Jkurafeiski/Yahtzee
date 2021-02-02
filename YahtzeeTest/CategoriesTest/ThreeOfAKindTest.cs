using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class ThreeOfAKindTest
    {
        private ThreeOfAKind _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ThreeOfAKind();
        }

        [Test]
        public void NameShouldReturnDrillinge()
        {
            var expected = "Drilling";

            var actual = _sut.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 6, 3, 3, 3, 9)]
        [TestCase(6, 6, 3, 6, 3, 18)]
        [TestCase(2, 6, 2, 3, 2, 6)]
        public void GetScore_WhenThreeOfAKindIsRolled_ShouldReturnExpectedScore(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 2, 3, 3, 4)]
        [TestCase(1, 6, 2, 2, 3)]
        [TestCase(6, 5, 5, 3, 4)]
        public void GetScore_WhenThreeOfAKindIsNotRolled_ShouldReturnZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 6, 3, 3, 3)]
        [TestCase(6, 6, 3, 6, 3)]
        [TestCase(2, 6, 2, 3, 2)]
        public void IsMatch_WhenThreeOfAKindIsRolled_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(2, 2, 3, 3, 4)]
        [TestCase(1, 6, 2, 2, 3)]
        [TestCase(6, 5, 5, 3, 4)]
        public void IsMatch_WhenThreeOfAKindIsNotRolled_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }
    }
}