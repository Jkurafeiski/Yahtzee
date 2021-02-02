using System.Collections;
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
                new ThreeOfAKind(), 
                new FourOfAKind()
            };
        }
    }
}