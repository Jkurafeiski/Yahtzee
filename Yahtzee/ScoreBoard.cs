using System;
using System.Collections.Generic;

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
            var totalScore = new YahtzeeMath().ScoreCounter(points);
            return totalScore;
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