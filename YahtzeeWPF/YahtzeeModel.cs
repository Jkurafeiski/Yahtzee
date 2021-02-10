using Yahtzee.Categories;

namespace YahtzeeWPF
{
    public class YahtzeeModel
    {
        public ICategory Category { get; set; }
        public int? ScoreValue { get; set;  }
    }
}