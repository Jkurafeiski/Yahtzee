

namespace Yahtzee.Categories
{
    public class Einsen : Category
    {
        public override string Name
        {
            get
            {
                return "Einsen";
            }
        }

        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                if (die == 1)
                {
                    sum += die;
                }
            }
            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            foreach (var die in dice)
            {
                if (die == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}