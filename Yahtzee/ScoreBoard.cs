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

        }

        public void ScratchCategory(YahtzeeCategory category)
        {

        }

        public void Reset()
        {

        }

        public int? GetScoreForCategory(YahtzeeCategory category)
        {
            return _scores[category];
        }

        public int TotalScore()
        {
            return 0;
        }
    }
}