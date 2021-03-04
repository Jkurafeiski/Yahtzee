

namespace Yahtzee.Categories
{
    public class Sum : Category
    {
        public override string Name
        {
            get
            {
                return "Chance";
            }
        }

        public override int GetScore(int[] dice)
        {
            int sum = 0;
            foreach (var die in dice)
            {
                sum += die;
            }

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            return true;
        }
    }
}