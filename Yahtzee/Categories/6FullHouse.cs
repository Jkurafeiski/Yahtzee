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
            Array.Sort(dice);
            var sum = 0;
            if (dice[1] == dice[0] && dice[0] != dice[2] && dice[2] == dice[3] && dice[3] == dice[4])
            {
                sum = (dice[1] + dice[1]) + (dice[3] * 3);
            }

            if (dice[3] == dice[4] && dice[3] != dice[2] && dice[0] == dice[1] && dice[1] == dice[2])
            {
                sum = (dice[3] + dice[3]) + (dice[1] * 3);
            }

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
