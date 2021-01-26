using NUnit.Framework;
using Yahtzee;

namespace YahtzeeTest
{
    [TestFixture]
    public class ScoreBoardTest
    {
        private ScoreBoard _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ScoreBoard();
        }

        [Test]
        public void AddScore_ShouldAddScoreToScoreBoard()
        {
            var category = YahtzeeCategory.Pair;
            var points = 8;

            _sut.AddScore(category, points);

            var actualPoints = _sut.GetScoreForCategory(category);
            Assert.AreEqual(points, actualPoints);
        }

        [Test]
        public void AddScore_WhenCategoryAlreadyHasPoints_Throws()
        {
            var category = YahtzeeCategory.Pair;
            _sut.AddScore(category, 8);

            TestDelegate del = () => _sut.AddScore(category, 16);

            Assert.Throws<ScoreBoardException>(del);
        }

        [Test]
        public void ScratchCategory_SetsCategoryPointsToZero()
        {
            var category = YahtzeeCategory.Pair;
            var expectedPointsAfterScratch = 0;

            _sut.ScratchCategory(category);

            var actualPoints = _sut.GetScoreForCategory(category);
            Assert.AreEqual(expectedPointsAfterScratch, actualPoints);
        }

        [Test]
        public void ScratchCategory_WhenCategoryAlreadyHasPoints_Throws()
        {
            var category = YahtzeeCategory.Pair;
            _sut.AddScore(category, 8);

            TestDelegate del = () => _sut.ScratchCategory(category);

            Assert.Throws<ScoreBoardException>(del);
        }
    }
}