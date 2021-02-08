using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly Dictionary<ICategory, int?> _newscores;
        private int _totalpoints;
        public string PlayerName { get; set; }

        public ScoreBoard()
        {
            var categoryList = InterfaceHandler();
            _newscores = new Dictionary<ICategory, int?>();
            foreach (var category in categoryList)
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

            _totalpoints += points;
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
            foreach (var category in _newscores.Keys.ToList())
            {
                _newscores[category] = null;
            }
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
                    return (Category) category;
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

        public Dictionary<ICategory, int?> GetNewScores()
        {
            return _newscores;
        }

        private List<ICategory> InterfaceHandler()
        {
            List<ICategory> categories = new List<ICategory>();
            var interfaceType = typeof(ICategory);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p));

            foreach (var type in types)
            {
                if (!type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type);
                    //ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int) });
                    //object instance = ctor.Invoke(new object[] { 10 });
                    categories.Add((ICategory) instance);
                }
            }

            return categories;
        }

        public void PrintScoreBoard()
        {
            Console.WriteLine(_totalpoints);
            foreach (KeyValuePair<ICategory, int?> kvp in _newscores)
            {
                Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);
            } 
        }
    }
}