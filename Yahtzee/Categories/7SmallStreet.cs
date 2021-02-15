using System;

namespace Yahtzee.Categories
{
    public class SmallStreet : Category
    {
        public override string Name
        {
            get
            {
                return "7. Kleine Straße";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.SmallStreet;
            }
        }

        public override int GetScore(int[] dice)
        {
            if (IsMatch(dice))
            {
                return 15;
            }
            return 0;
        }

        public override bool IsMatch(int[] dice)
        {
            Array.Sort(dice);
            if (dice[0] == 1 && dice[1] == 2 && dice[2] == 3 && dice[3] == 4 && dice[4] == 5)
            {
                return true;
            }
            return false;
        }
    }
}