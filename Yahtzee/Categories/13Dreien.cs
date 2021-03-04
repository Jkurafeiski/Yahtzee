

namespace Yahtzee.Categories
{
    public class Dreien : Category
    {
        public override string Name
        {
            get
            {
                return "Dreien";
            }
        }

        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                if (die == 3)
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
                if (die == 3)
                {
                    return true;
                }
            }
            return false;
        }
    }
}