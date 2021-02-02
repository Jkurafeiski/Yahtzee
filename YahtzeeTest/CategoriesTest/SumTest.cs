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
        public void SumScore_ShouldAddSum(int die1, int die2, int die3, int die4, int die5, int expectedResult)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actualResult = _sut.GetScore(diceRoll);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}