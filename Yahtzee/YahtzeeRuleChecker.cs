using System.Collections;
using System.Linq;

namespace Yahtzee
{

    public class YahtzeeRuleChecker : IEnumerable
    {
        public bool PairCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() >= 2))
            {
                return true;
            }

            return false;
        }

        public bool DoublePairCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                var duplicates = die.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key).ToList();
                duplicates.Remove(duplicates[0]);

                if (duplicates.Count != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ThreeOfAKindCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() >= 3))
            {
                return true;
            }

            return false;
        }

        public bool FourOfAKindCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() >= 4))
            {
                return true;
            }

            return false;
        }

        public bool YahtzeeCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() == 5))
            {
                return true;
            }

            return false;
        }

        public bool FullHouseCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() == 2) && die.GroupBy(x => x).Any(g => g.Count() == 3))
            {
                return true;
            }

            return false;
        }

        public bool SmallStreetCheck(int[] die)
        {
            if (die[0] == 1 && die[1] == 2 && die[2] == 3 && die[3] == 4 && die[4] == 5)
            {
                return true;
            }

            return false;
        }

        public bool LargeStreetCheck(int[] die)
        {
            if (die[0] == 2 && die[1] == 3 && die[2] == 4 && die[3] == 5 && die[4] == 6)
            {
                return true;
            }

            return false;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}