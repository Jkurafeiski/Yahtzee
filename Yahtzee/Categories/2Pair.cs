using System.Linq;

namespace Yahtzee.Categories
{
    public class Pair : Category
    {
        public override string Name
        {
            get
            {
                return "2. Paar";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.Pair;
            }
        }

        public override int GetScore(int[] dice)
        {
            var sum = 0;
            var duplicates = dice.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum = number * 2;
            }

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            if (dice.GroupBy(x => x).Any(g => g.Count() >= 2))
            {
                return true;
            }

            return false;
        }
    }
}