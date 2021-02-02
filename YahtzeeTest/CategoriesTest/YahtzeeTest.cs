using NUnit.Framework;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class YahtzeeTest
    {
        private Yahtzee.Categories.Yahtzee _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Yahtzee.Categories.Yahtzee();
        }


        [TestCase(6, 6, 6, 6, 6)]
        public void Yahtzee_ShouldAddYahtzee(int die1, int die2, int die3, int die4, int die5)
        {
            var expectedResult = 50;
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, 5, 3, 3, 4)]
        public void Yahtzee_WhenCalledWithIllegalRoll_ReturnsZero(int die1, int die2, int die3, int die4,
            int die5)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};
            int expectedResult = 0;

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 3)]
        [TestCase(1, 1, 1, 2, 2)]
        public void YahtzeeCheck_WhenRollDoesNotContainYahtzee_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.IsMatch(diceRoll);

            Assert.IsFalse(actual);
        }
    }
}