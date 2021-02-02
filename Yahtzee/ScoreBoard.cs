using System;
using System.Collections.Generic;
using System.Linq;
using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly Dictionary<YahtzeeCategory, int?> _scores;
        private readonly Dictionary<Category, int?> _newscores;

        public string PlayerName { get; set; }

        public ScoreBoard()
        {
            _scores = new Dictionary<YahtzeeCategory, int?>();
            foreach (YahtzeeCategory category in Enum.GetValues(typeof(YahtzeeCategory)))
            {
                _scores.Add(category, null);
            }

            _newscores = new Dictionary<Category, int?>();
            foreach (var category in Category.CreateAll())
            {
                _newscores.Add(category, null);
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

        public int SwitchInputCalculator(int[] dice, YahtzeeCategory input)
        {
            var res = (from category in _newscores.Keys
                where category.YahtzeeCategory == input && category.IsMatch(dice)
                select category.GetScore(dice)).FirstOrDefault();

            return res;
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