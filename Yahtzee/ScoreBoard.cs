using System;
using System.Collections.Generic;
using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly Dictionary<YahtzeeCategory, int?> _scores;

        public string PlayerName { get; set; }

        public ScoreBoard()
        {
            _scores = new Dictionary<YahtzeeCategory, int?>();
            foreach (YahtzeeCategory category in Enum.GetValues(typeof(YahtzeeCategory)))
            {
                _scores.Add(category, null);
            }
        }

        

        public void AddScore(YahtzeeCategory category, int points)
        {
            if (_scores[category] != null)
            {
                throw new ScoreBoardException("Hast du schon ausgewählt");
            }
            
            _scores[category] = points;
        }

        public void ScratchCategory(YahtzeeCategory category)
        {
            if (_scores[category] != null)
            {
                throw new ScoreBoardException("Du kannst nicht etwas Streichen was schon eine Nummer hat");
            }
            _scores[category] = 0;
        }

        public void Reset()
        {

        }

        public int? GetScoreForCategory(YahtzeeCategory category)
        {
            return _scores[category];
        }

        public int TotalScore(int points)
        {
            var totalScore = points;
            return totalScore;
        }
        public int SwitchInputCalculator(int[] dice,YahtzeeCategory input)
        {
            switch (input)
            {
                case YahtzeeCategory.Sum:
                    return new Sum().GetScore(dice);
                case YahtzeeCategory.Pair:
                    if (new Pair().IsMatch(dice)) return new Pair().GetScore(dice);
                    break;
                case YahtzeeCategory.ThreeOfAKind:
                    if (new ThreeOfAKind().IsMatch(dice)) return new ThreeOfAKind().GetScore(dice);
                    break;
                case YahtzeeCategory.FourOfAKind:
                    if (new FourOfAKind().IsMatch(dice)) return new FourOfAKind().GetScore(dice);
                    break;
                case YahtzeeCategory.Yahtzee:
                    if (new Categories.Yahtzee().IsMatch(dice)) return new Categories.Yahtzee().GetScore(dice);
                    break;
                case YahtzeeCategory.FullHouse:
                    if (new FullHouse().IsMatch(dice)) return new FullHouse().GetScore(dice);
                    break;
                case YahtzeeCategory.SmallStreet:
                    if (new SmallStreet().IsMatch(dice)) return new SmallStreet().GetScore(dice);
                    break;
                case YahtzeeCategory.LargeStreet:
                    if (new LargeStreet().IsMatch(dice)) return new LargeStreet().GetScore(dice);
                    break;
                case YahtzeeCategory.DoublePair:
                    if (new DoublePair().IsMatch(dice)) return new DoublePair().GetScore(dice);
                    break;
            }

            throw new ScoreBoardException("Das ist keine Richtige Eingabe");
        }
        public void PrintScoreBoard(int points)
        {
            Console.WriteLine(TotalScore(points));
            foreach (KeyValuePair<YahtzeeCategory, int?> kvp in _scores)
            {
                Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);
            } 
        }
    }
}