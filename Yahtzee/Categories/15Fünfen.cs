

namespace Yahtzee.Categories
{
    public class F�nfen : Category
    {
        public override string Name
        {
            get
            {
                return "F�nfen";
            }
        }

        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                if(die == 5)
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
                if (die == 5)
                {
                    return true;
                }
            }
            return false;
        }
    }
}