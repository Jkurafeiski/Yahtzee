using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Yahtzee.Categories;

namespace Yahtzee
{
    public class ScoreBoard
    {
        private readonly Dictionary<ICategory, int?> _scores;
        public string PlayerName { get; set; }
        public int TotalScore = 0;

        public ScoreBoard()
        {
            var categoryList = InterfaceHandler();
            _scores = new Dictionary<ICategory, int?>();
            foreach (var category in categoryList)
            {
                _scores.Add(category, null);
            }
        }

        public ICategory CategoryConverter(ICategory category)
        {
            try
            {
                var categoryValue = _scores.First(x => x.Key.Name == category.Name);
                return categoryValue.Key;
            }
            catch (KeyNotFoundException e)
            {
                throw new ScoreBoardException("Du musst etwas anklicken");
            }
            
        }

        public void ScratchCategory(ICategory category)
        {
            
            if (_scores[category] == null)
            {
                _scores[category] = 0;
            }
            else
            {
                throw new ScoreBoardException("Du kannst nicht etwas Streichen was schon eine Nummer hat");
            }
            
        }

        public void Reset()
        {
            foreach (var category in _scores.Keys.ToList())
            {
                _scores[category] = null;
            }
        }

        public void PutResultToBoard(int[] dice, ICategory category)
        {
            if (category.IsMatch(dice) && _scores[category] == null)
            {
                _scores[category] = category.GetScore(dice);
                var keyValuePair = _scores.First(x => x.Key.GetType() == typeof(Total));
                //_scores[keyValuePair.Key] = 0;
                //_scores[keyValuePair.Key] = TotalPoints;
                var newTotalPoints = keyValuePair.Value.GetValueOrDefault(0) + category.GetScore(dice);
                _scores[keyValuePair.Key] = newTotalPoints;
                TotalScore = newTotalPoints;
            }
            else if (!category.IsMatch(dice))
            {
                throw new ScoreBoardException("Du kriegst keine Punkte für diese Kategorie. Wenn du sie Streichen willst bitte benutzt den 'Streichen' Knopf");
            }
            else if (_scores[category] != null)
            { 
                throw new ScoreBoardException("Du hast diese Kategorie schon ausgewählt");
            }
        }
        
        public Dictionary<ICategory, int?> GetNewScores()
        {
            return _scores;
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
    }
}