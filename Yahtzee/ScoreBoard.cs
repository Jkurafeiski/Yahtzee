using System;
using System.Collections.Generic;
using System.Linq;
using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly Dictionary<YahtzeeCategory, int?> _scores;
        public readonly Dictionary<Category, int?> _newscores;

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

        

        public void AddScore(Category category, int points)
        {
            if (_newscores[category] != null)
            {
                throw new ScoreBoardException("Hast du schon ausgewählt");
            }
            
            _newscores[category] = points;
        }

        public void ScratchCategory(Category category)
        {
            if (_newscores[category] != null)
            {
                throw new ScoreBoardException("Du kannst nicht etwas Streichen was schon eine Nummer hat");
            }
            _newscores[category] = 0;
        }

        public void Reset()
        {

        }

        public int? GetScoreForCategory(Category category)
        {
            return _newscores[category];
        }

        public int TotalScore(int points)
        {
            var totalScore = points;
            return totalScore;
        }

        public int SwitchInputCalculator(int[] dice, Category input)
        {
            var res = 0;
            foreach (var category in _newscores.Keys)
            {
                if (Category.CreateAll == input && category.IsMatch(dice))
                {
                    res = category.GetScore(dice);
                    break;
                }
            }

            return res;
        }

        public void PrintScoreBoard(int points)
        {
            Console.WriteLine(points);
            foreach (KeyValuePair<Category, int?> kvp in _newscores)
            {
                Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);
            } 
        }
    }
}