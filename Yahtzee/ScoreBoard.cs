using System;
using System.Collections.Generic;
using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly Dictionary<Category, int?> _newscores;

        public string PlayerName { get; set; }

        public ScoreBoard()
        {
            _newscores = new Dictionary<Category, int?>();
            foreach (var category in Category.CreateAll())
            {
                _newscores.Add(category, null);
            }
        }
        
        public void AddScore(YahtzeeCategory category, int points)
        {
            var convertedCategory = GetCategory(category);
            if (_newscores[convertedCategory] != null)
            {
                throw new ScoreBoardException("Hast du schon ausgewählt");
            }
            
            _newscores[convertedCategory] = points;
        }

        public void ScratchCategory(YahtzeeCategory category)
        {
            var convertedCategory = GetCategory(category);
            if (_newscores[convertedCategory] != null)
            {
                throw new ScoreBoardException("Du kannst nicht etwas Streichen was schon eine Nummer hat");
            }
            _newscores[convertedCategory] = 0;
        }

        public void Reset()
        {

        }

        public int? GetScoreForCategory(YahtzeeCategory yahtzeeCategory)
        {
            var category = GetCategory(yahtzeeCategory);
            return _newscores[category];
        }

        public Category GetCategory(YahtzeeCategory yahtzeeCategory)
        {
            foreach (var category in _newscores.Keys)
            {
                if (category.YahtzeeCategory == yahtzeeCategory)
                {
                    return category;
                }
            }

            return null;
        }

        public void PutResultToBoard(int[] dice, YahtzeeCategory input)
        {
            var category = GetCategory(input);
            if (category.IsMatch(dice))
            {
                _newscores[category] = category.GetScore(dice);
            }
            else
            {
                ScratchCategory(input);
            }
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