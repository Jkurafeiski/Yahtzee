using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Yahtzee
{
    public class YahtzeeMath
    {
        
        public int YahtzeePointCalculator(int[] dice, YahtzeeCategory input)
        {
            var scoreValue = 0;
            Array.Sort(dice);
            if (SwitchInputCheck(dice, input))
            {
                switch (input)
                {
                    case YahtzeeCategory.Sum:
                        scoreValue= new ScoreCalculator().SumScore(dice);
                        return scoreValue;
                    case YahtzeeCategory.Pair:
                        scoreValue= new ScoreCalculator().PairScore(dice);
                        return scoreValue;
                    case YahtzeeCategory.ThreeOfAKind:
                        scoreValue= new ScoreCalculator().ThreeOfAKindScore(dice);
                        return scoreValue;
                    case YahtzeeCategory.FourOfAKind:
                        scoreValue= new ScoreCalculator().FourOfAKindScore(dice);
                        return scoreValue;
                    case YahtzeeCategory.Yahtzee:
                        return 50;
                    case YahtzeeCategory.FullHouse:
                        scoreValue= new ScoreCalculator().FullHouseScore(dice);
                        return scoreValue;
                    case YahtzeeCategory.SmallStreet:
                        return 15;
                    case YahtzeeCategory.LargeStreet:
                        return 20;
                    case YahtzeeCategory.DoublePair:
                        scoreValue= new ScoreCalculator().DoublePairScore(dice);
                        return scoreValue;
                }
            }

            return scoreValue;
        }

        private bool SwitchInputCheck(int[] dice,YahtzeeCategory input)
        {
            switch (input)
            {
                case YahtzeeCategory.Sum:
                    return true;
                case YahtzeeCategory.Pair:
                    if (new YahtzeeRuleChecker().PairCheck(dice)) return true;
                    break;
                case YahtzeeCategory.ThreeOfAKind:
                    if (new YahtzeeRuleChecker().ThreeOfAKindCheck(dice)) return true;
                    break;
                case YahtzeeCategory.FourOfAKind:
                    if (new YahtzeeRuleChecker().FourOfAKindCheck(dice)) return true;
                    break;
                case YahtzeeCategory.Yahtzee:
                    if (new YahtzeeRuleChecker().YahtzeeCheck(dice)) return true;
                    break;
                case YahtzeeCategory.FullHouse:
                    if (new YahtzeeRuleChecker().FullHouseCheck(dice)) return true;
                    break;
                case YahtzeeCategory.SmallStreet:
                    if (new YahtzeeRuleChecker().SmallStreetCheck(dice)) return true;
                    break;
                case YahtzeeCategory.LargeStreet:
                    if (new YahtzeeRuleChecker().LargeStreetCheck(dice)) return true;
                    break;
                case YahtzeeCategory.DoublePair:
                    if (new YahtzeeRuleChecker().DoublePairCheck(dice)) return true;
                    break;
            }
            return false;
        }
    }
}