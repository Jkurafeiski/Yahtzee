using System.Linq;

namespace Yahtzee.Categories
{
    public class FourOfAKind : Category
    {
        public override string Name
        {
            get
            {
                return "Vierling";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.FourOfAKind;
            }
        }

        public override int GetScore(int[] dice)
        {
            var sum = 0;
            var duplicates = dice.GroupBy(g => g).Where(w => w.Count() > 3).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum = number * 4;
            }

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            if (dice.GroupBy(x => x).Any(g => g.Count() >= 4))
            {
                return true;
            }

            return false;
        }
    }
}