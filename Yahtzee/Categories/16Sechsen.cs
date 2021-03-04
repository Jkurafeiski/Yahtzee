

namespace Yahtzee.Categories
{
    public class Sechsen : Category
    {
        public override string Name
        {
            get
            {
                return "Sechsen";
            }
        }

        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                if(die == 6)
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
                if (die == 6)
                {
                    return true;
                }
            }

            return false;
        }
    }
}