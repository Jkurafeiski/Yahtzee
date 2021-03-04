namespace Yahtzee.Categories
{
    public interface ICategory
    {
        string Name { get; }

        int GetScore(int[] dice);

        bool IsMatch(int[] dice);
    }
}