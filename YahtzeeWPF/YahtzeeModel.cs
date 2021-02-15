using System.ComponentModel;
using Yahtzee.Categories;

namespace YahtzeeWPF
{
    public class YahtzeeModel
    {
        private int? _scoreValue;
        private ICategory _category;

        public ICategory Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }

        public int? ScoreValue
        {
            get => _scoreValue;
            set
            {
                _scoreValue = value;
            }
        }
    }
}