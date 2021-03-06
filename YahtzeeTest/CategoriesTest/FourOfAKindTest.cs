using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class FourOfAKindTest
    {
        private FourOfAKind _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new FourOfAKind();
        }
        
        [TestCase(2, 3, 3, 3, 3, 12)]
        [TestCase(2, 5, 5, 5, 5, 20)]
        [TestCase(1, 6, 6, 6, 6, 24)]
        public void FourOfAKindScore_ShouldAddFourOfAKind(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        [TestCase(1, 2, 3, 4, 4)]
        [TestCase(2, 4, 3, 3, 4)]
        public void FourOfAKindScore_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 3)]
        [TestCase(1, 1, 1, 2, 2)]
        public void FourOfAKindCheck_WhenRollDoesNotContainFourOfAKind_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

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

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsTrue(actual);
        }
    }
}