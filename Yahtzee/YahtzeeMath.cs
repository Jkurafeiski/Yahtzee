using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Yahtzee
{
    public class YahtzeeMath
    {
        
        public int YahtzeePointCalculator(int[] dice, YahtzeeInputRuler input)
        {
            var scoreValue = 0;
            Array.Sort(dice);
            if (SwitchInputCheck(dice, input))
            {
                switch (input)
                {
                    case YahtzeeInputRuler.Sum:
                        scoreValue= new ScoreCalculator().SumScore(dice);
                        return scoreValue;
                    case YahtzeeInputRuler.Pair:
                        scoreValue= new ScoreCalculator().PairScore(dice);
                        return scoreValue;
                    case YahtzeeInputRuler.ThreeOfAKind:
                        scoreValue= new ScoreCalculator().ThreeOfAKindScore(dice);
                        return scoreValue;
                    case YahtzeeInputRuler.FourOfAKind:
                        scoreValue= new ScoreCalculator().FourOfAKindScore(dice);
                        return scoreValue;
                    case YahtzeeInputRuler.Yahtzee:
                        return 50;
                    case YahtzeeInputRuler.FullHouse:
                        scoreValue= new ScoreCalculator().FullHouseScore(dice);
                        return scoreValue;
                    case YahtzeeInputRuler.SmallStreet:
                        return 15;
                    case YahtzeeInputRuler.LargeStreet:
                        return 20;
                    case YahtzeeInputRuler.DoublePair:
                        scoreValue= new ScoreCalculator().DoublePairScore(dice);
                        return scoreValue;
                }
            }

            return scoreValue;
        }

        private bool SwitchInputCheck(int[] dice,YahtzeeInputRuler input)
        {
            switch (input)
            {
                case YahtzeeInputRuler.Sum:
                    return true;
                case YahtzeeInputRuler.Pair:
                    if (new YahtzeeRuleChecker().PairCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.ThreeOfAKind:
                    if (new YahtzeeRuleChecker().ThreeOfAKindCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.FourOfAKind:
                    if (new YahtzeeRuleChecker().FourOfAKindCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.Yahtzee:
                    if (new YahtzeeRuleChecker().YahtzeeCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.FullHouse:
                    if (new YahtzeeRuleChecker().FullHouseCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.SmallStreet:
                    if (new YahtzeeRuleChecker().SmallStreetCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.LargeStreet:
                    if (new YahtzeeRuleChecker().LargeStreetCheck(dice)) return true;
                    break;
                case YahtzeeInputRuler.DoublePair:
                    if (new YahtzeeRuleChecker().DoublePairCheck(dice)) return true;
                    break;
            }
            return false;
        }
    }
}