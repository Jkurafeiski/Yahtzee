using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Yahtzee;
using Yahtzee.Categories;

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
        public void PutToResultsToBoard_WhenCategoryAlreadyHasPoints_Throws()
        {
            var category = YahtzeeCategory.Pair;
            int[] diceRolls = new int[5];
            diceRolls = new[] {1, 2, 3, 4, 5};
            _sut.PutResultToBoard(diceRolls,category);
            TestDelegate del = () => _sut.PutResultToBoard(diceRolls, category);
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
        
        [Test]
        public void Reset_TestWithScoreBoardInitialize_Equals()
        {
            var categoryPair = YahtzeeCategory.Pair;
            var categoryFullHouse = YahtzeeCategory.FullHouse;
            var points = 8;
            _sut.AddScore(categoryPair, points);
            _sut.AddScore(categoryFullHouse, points);
            _sut.Reset();
            var resettedScores = _sut.GetNewScores();

            foreach (KeyValuePair<ICategory, int?> score in resettedScores)
            {
                Assert.IsNull(score.Value);
            }
        }
       
    }
}