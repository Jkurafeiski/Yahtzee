using NUnit.Framework;
using Yahtzee;

namespace YahtzeeTest
{
    [TestFixture]
    public class YahtzeeRuleCheckerTest
    {
        private YahtzeeRuleChecker _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new YahtzeeRuleChecker();
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 1, 3, 2, 2)]
        public void ThreeOfAKindCheck_WhenRollDoesNotContainThreeOfAKind_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = {die1, die2, die3, die4, die5};

            var actual = _sut.ThreeOfAKindCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 1, 1, 3, 4)]
        [TestCase(1, 1, 1, 1, 4)]
        [TestCase(1, 1, 3, 3, 3)]
        [TestCase(6, 1, 6, 3, 6)]
        [TestCase(5, 5, 5, 5, 5)]
        public void ThreeOfAKindCheck_WhenRollContainsThreeOfAKind_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.ThreeOfAKindCheck(diceRoll);

            Assert.IsTrue(actual);
        }

        [TestCase(1, 2, 3, 3, 4)]
        [TestCase(1, 5, 6, 6, 4)]
        [TestCase(1, 1, 3, 2, 2)]
        public void SmallStreetCheck_WhenRollDoesNotContainSmallStreet_ReturnsFalse(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.SmallStreetCheck(diceRoll);

            Assert.IsFalse(actual);
        }

        [TestCase(1, 2, 3, 4, 1)]
        [TestCase(2, 5, 3, 2, 4)]
        [TestCase(6, 5, 3, 4, 1)]
        [TestCase(2, 3, 4, 5, 6)]
        public void SmallStreetCheck_WhenRollContainsSmallStreet_ReturnsTrue(int die1, int die2, int die3, int die4, int die5)
        {
            int[] diceRoll = { die1, die2, die3, die4, die5 };

            var actual = _sut.SmallStreetCheck(diceRoll);

            Assert.IsTrue(actual);
        }
    }
}