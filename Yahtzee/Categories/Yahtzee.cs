using System.Linq;

namespace Yahtzee.Categories
{
    public class Yahtzee : Category
    {
        public override string Name
        {
            get
            {
                return "Kniffel";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.FourOfAKind;
            }
        }

        public override int GetScore(int[] dice)
        {
            if (IsMatch(dice))
            {
                return 50;
            }

            return 0;
        }

        public override bool IsMatch(int[] dice)
        {
            if (dice.GroupBy(x => x).Any(g => g.Count() == 5))
            {
                return true;
            }

            return false;
        }
    }
}