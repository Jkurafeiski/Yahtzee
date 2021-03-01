using System;
using System.Linq;

namespace Yahtzee.Categories
{
    public class FullHouse : Category
    {
        public override string Name
        {
            get
            {
                return "6. Full House";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.FullHouse;
            }
        }

        public override int GetScore(int[] dice)
        {
            var sum = 25;

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            Array.Sort(dice);
            if (dice.GroupBy(x => x).Any(g => g.Count() == 2) && dice.GroupBy(x => x).Any(g => g.Count() == 3))
            {
                return true;
            }

            return false;
        }
    }
}
