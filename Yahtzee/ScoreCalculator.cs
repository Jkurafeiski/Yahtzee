using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        private readonly Category _category;

        public ScoreCalculator(Category category)
        {
            _category = category;
        }

        public int GetScore(int[] dice)
        {
            return _category.GetScore(dice);
        }
    }
}