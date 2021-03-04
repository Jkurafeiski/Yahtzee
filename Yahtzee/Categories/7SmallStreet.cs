using System;

namespace Yahtzee.Categories
{
    public class SmallStreet : Category
    {
        public override string Name
        {
            get
            {
                return "Kleine Straße";
            }
        }

        public override int GetScore(int[] dice)
        {
            if (IsMatch(dice))
            {
                return 30;
            }
            return 0;
        }

        public override bool IsMatch(int[] dice)
        {
            Array.Sort(dice);
            if (dice[0] == 1 && dice[1] == 2 && dice[2] == 3 && dice[3] == 4 ||
                dice[0] == 2 && dice[1] == 3 && dice[2] == 4 && dice[3] == 5 ||
                dice[0] == 3 && dice[1] == 4 && dice[2] == 5 && dice[3] == 6)
            {
                return true;
            }
            return false;
        }
    }
}