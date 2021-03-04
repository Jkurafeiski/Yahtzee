

namespace Yahtzee.Categories
{
    public class Fünfen : Category
    {
        public override string Name
        {
            get
            {
                return "Fünfen";
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