using System;

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

        public override int GetScore(int[] dice)
        {
            if (IsMatch(dice))
            {
                return 40;
            }

            return 0;
        }

        public override bool IsMatch(int[] dice)
        {
            Array.Sort(dice);
            int n = dice[0];
            if (dice[1] == n + 1 && dice[2] == n + 2 && dice[3] == n + 3 && dice[4] == n+4)
            {
                return true;
            }

            return false;
        }
    }
}
