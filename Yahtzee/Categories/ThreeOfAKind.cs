using System.Linq;

namespace Yahtzee.Categories
{
    public class ThreeOfAKind : Category, ICategory
    {
        public override string Name
        {
            get
            {
                return "Drilling";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.ThreeOfAKind;
            }
        }

        public override int GetScore(int[] dice)
        {
            var sum = 0;
            var duplicates = dice.GroupBy(g => g).Where(w => w.Count() > 2).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum = number * 3;
            }

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            if (dice.GroupBy(x => x).Any(g => g.Count() >= 3))
            {
                return true;
            }

            return false;
        }
    }
}