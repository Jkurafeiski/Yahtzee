using System.Linq;

namespace Yahtzee.Categories
{
    public class Sum : Category
    {
        public override string Name
        {
            get
            {
                return "Summe";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.Sum;
            }
        }

        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                sum += die;
            }

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            if (dice.GroupBy(x => x).Any(g => g.Count() >= 4))
            {
                return true;
            }

            return false;
        }
    }
}