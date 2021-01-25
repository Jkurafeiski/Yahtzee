using System.Linq;

namespace Yahtzee
{
    public class ScoreCalculator
    {
        public int SumScore(int[] dieChecked)
        {
            var sum = 0;
            foreach (var t in dieChecked)
            {
                sum += t;
            }
            return sum;
        }

        public int PairScore(int[] dieChecked)
        {
            var sum = 0;
            var duplicates = dieChecked.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum = number * 2;
            }

            return sum;
        }

        public int ThreeOfAKindScore(int[] dieChecked)
        {
            var sum = 0;
            var duplicates = dieChecked.GroupBy(g => g).Where(w => w.Count() > 2).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum = number * 3;
            }

            return sum;
        }

        public int DoublePairScore(int[] dieChecked)
        {
            var sum = 0;
            var duplicates = dieChecked.GroupBy(g => g).Where(w => w.Count() > 1).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum += number * 2;
            }

            return sum;
        }

        public int FourOfAKindScore(int[] dieChecked)
        {
            var sum = 0;
            var duplicates = dieChecked.GroupBy(g => g).Where(w => w.Count() > 3).Select(s => s.Key).ToList();
            foreach (var number in duplicates)
            {
                sum = number * 4;
            }

            return sum;
        }

        public int FullHouseScore(int[] dieChecked)
        {
            var sum = 0;
            if (dieChecked[1] == dieChecked[0] && dieChecked[0] != dieChecked[2])
            {
                sum = (dieChecked[1] + dieChecked[1]) + (dieChecked[3] * 3);
            }

            if (dieChecked[3] == dieChecked[4] && dieChecked[3] != dieChecked[2])
            {
                sum = (dieChecked[3] + dieChecked[3]) + (dieChecked[1] * 3);
            }

            return sum;
        }
    }
}