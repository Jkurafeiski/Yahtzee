using NUnit.Framework;
using Yahtzee.Categories;

namespace YahtzeeTest.CategoriesTest
{
    [TestFixture]
    public class SumTest
    {
        private Sum _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Sum();
        }


        [TestCase(6, 6, 5, 5, 4, 26)]
        [TestCase(3, 6, 5, 2, 4, 20)]
        [TestCase(1, 6, 4, 5, 4, 20)]
        [TestCase(5, 1, 5, 5, 3, 19)]
        public void SumScore_ShouldAddSum(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}