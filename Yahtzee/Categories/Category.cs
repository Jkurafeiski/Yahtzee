using System.Collections.Generic;

namespace Yahtzee.Categories
{
    public abstract class Category
    {
        public abstract string Name { get; }

        public abstract YahtzeeCategory YahtzeeCategory { get; }

        public abstract int GetScore(int[] dice);

        public abstract bool IsMatch(int[] dice);

        public static List<Category> CreateAll()
        {
            return new List<Category>
            {
                new Sum(),
                new Pair(),
                new ThreeOfAKind(), 
                new FourOfAKind(),
                new Yahtzee(),
                new FullHouse(),
                new LargeStreet(),
                new SmallStreet(),
                new DoublePair()
            };
        }
    }
}