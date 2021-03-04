using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yahtzee.Categories.SmallSteetTest
{
    [TestClass()]
    public class SmallStreetSmallSteetTest
    {
        [TestMethod()]
        public void SmallStreetScore_isGivenPairAndSmallStreet_returnTrue()
        {
            int[] diceRoll = { 1, 2, 2, 3, 4 };

            var actualResult = new SmallStreet().IsMatch(diceRoll);

            Assert.IsTrue(actualResult);
        }

        [TestMethod()]
        public void SmallStreetScore_WhenCallesWithLargeStreet_ReturnsTrue()
        {
            int[] diceRoll = { 1, 2, 3, 4, 5 };

            var actualResult = new SmallStreet().IsMatch(diceRoll);

            Assert.IsTrue(actualResult);
        }

    }
}