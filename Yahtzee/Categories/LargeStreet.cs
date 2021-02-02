using System;
using System.Linq;

namespace Yahtzee.Categories
{
    public class LargeStreet : Category
    {
        public override string Name
        {
            get
            {
                return "Große Straße";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.LargeStreet;
            }
        }

        public override int GetScore(int[] dice)
        {
            if (IsMatch(dice))
            {
                return 20;
            }

            return 0;
        }

        public override bool IsMatch(int[] dice)
        {
            Array.Sort(dice);
            if (dice[0] == 2 && dice[1] == 3 && dice[2] == 4 && dice[3] == 5 && dice[4] == 6)
            {
                return true;
            }

            return false;
        }
    }
}
