using System.Linq;

namespace Yahtzee.Categories
{
    public class Total : Category
    {
        public override string Name
        {
            get
            {
                return "Gesamt";
            }
        }

        public override int GetScore(int[] dice)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsMatch(int[] dice)
        {
            throw new System.NotImplementedException();
        }
    }
}
