

namespace Yahtzee.Categories
{
    public class Zweien : Category
    {
        public override string Name
        {
            get
            {
                return "Zweien";
            }
        }


        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                if (die == 2)
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
                if (die == 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}