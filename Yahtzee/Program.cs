using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            var die = new Die();
            int[] initializeDice = die.DiceRandomRoll();

            var dieMath = new MathChecker(initializeDice);

            Console.WriteLine(dieMath);

        }
    }
}
