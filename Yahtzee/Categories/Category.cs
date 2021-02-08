using System.Collections.Generic;

namespace Yahtzee.Categories
{
    public abstract class Category : ICategory
    {
        public abstract string Name { get; }

        public abstract YahtzeeCategory YahtzeeCategory { get; }

        public abstract int GetScore(int[] dice);

        public abstract bool IsMatch(int[] dice);
    }
}