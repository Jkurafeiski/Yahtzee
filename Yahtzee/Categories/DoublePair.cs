using System.Linq;

namespace Yahtzee.Categories
{
    public class DoublePair : Category
    {
        public override string Name
        {
            get
            {
                return "Zwei Paare";
            }
        }

        public override YahtzeeCategory YahtzeeCategory
        {
            get
            {
                return YahtzeeCategory.DoublePair;
            }
        }

        public override int GetScore(int[] dice)
        {
            var sum = 0;
            var duplicates = dice.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key).ToList();
            if (duplicates.Count == 1)
            {
                return 0;
            }
            foreach (var number in duplicates)
            {
                sum += number * 2;
            }

            return sum;
        }

        public override bool IsMatch(int[] dice)
        {
            if (dice.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                var duplicates = dice.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key).ToList();
                duplicates.Remove(duplicates[0]);

                if (duplicates.Count != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
