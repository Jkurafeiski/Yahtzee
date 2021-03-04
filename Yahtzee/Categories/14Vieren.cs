

namespace Yahtzee.Categories
{
    public class Vieren : Category
    {
        public override string Name
        {
            get
            {
                return "Vieren";
            }
        }


        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                if (die == 4)
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
                if (die == 4)
                {
                    return true;
                }
            }
            return false;
        }
    }
}