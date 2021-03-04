using System;
using System.Linq;

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
            var distinctDice = dice.Distinct().ToArray();
            dice = distinctDice;
            if (dice.Length < 4)
            {
                return false;
            }

            int dicePosition1 = dice[0];
            int dicePosition2 = dice[1];
            if (dice[1] == dicePosition1 + 1 && dice[2] == dicePosition1 + 2 && dice[3] == dicePosition1 + 3 ||
                dice[2] == dicePosition2 + 1 && dice[3] == dicePosition2 + 2 && dice[4] == dicePosition2 + 3)
            {
                return true;
            }

            return false;
        }
    }
}