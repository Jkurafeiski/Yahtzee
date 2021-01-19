using System.Linq;

namespace Yahtzee
{
    public class YahtzeeRuleChecker
    {
        public YahtzeeRuleChecker()
        {
            
        }

        public YahtzeeRuleChecker(int[] die)
        {
            new YahtzeeMath().YahtzeePointCalculator(AllChecker(die));
        }

        public string AllChecker(int[] die)
        {
            string statusCheck = "";
            if (PairCheck(die))
            {
                statusCheck = "Pair";
            }

            if (DoublePairCheck(die))
            {
                statusCheck = "DoublePair";
            }

            if (ThreeOfAKindCheck(die))
            {
                statusCheck = "ThreeOfAKind";
            }

            if (FourOfAKindCheck(die))
            {
                statusCheck = "FourOfAKind";
            }

            if (YahtzeeCheck(die))
            {
                statusCheck = "Yahtzee";
            }

            if (FullHouseCheck(die))
            {
                statusCheck = "FullHouse";
            }

            if (SmallStreetCheck(die))
            {
                statusCheck = "SmallStreet";
            }

            if (Largestreetcheck(die))
            {
                statusCheck = "LargeStreet";
            }

            return statusCheck;
        }

        public bool PairCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() == 2))
            {
                return true;
            }

            return false;
        }

        public bool DoublePairCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() == 2) && die.GroupBy(x => x).Any(g => g.Count() == 2))
            {
                return true;
            }

            return false;
        }

        public bool ThreeOfAKindCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() == 3))
            {
                return true;
            }

            return false;
        }

        public bool FourOfAKindCheck(int[] die)
        {
            if (die.GroupBy(x => x).Any(g => g.Count() == 4))
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
            if (die[0] == 1 && die[1] == 2 && die[1] == 3 && die[2] == 4 && die[4] == 5)
            {
                return true;
            }

            return false;
        }

        public bool Largestreetcheck(int[] die)
        {
            if (die[0] == 2 && die[1] == 3 && die[1] == 4 && die[2] == 5 && die[4] == 6)
            {
                return true;
            }

            return false;
        }
    }
}