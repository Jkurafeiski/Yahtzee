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

        public override int GetScore(int[] dice)
        {
            var counter = 0;
            if (IsMatch(dice))
            {
                if (counter >= 1)
                {
                    return 100;
                }
                else
                {
                    counter++;
                    return 50;
                }
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