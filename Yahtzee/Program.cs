using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            var dice = new Dice();
            int[] initializeDice = dice.DiceRandomRoll();

            var dieMath = new YahtzeeRuleChecker(initializeDice);
            Console.WriteLine(dieMath);

            var die = new Die();
            //Console.WriteLine("Neuer Würfel: " + die.Value);
            //Console.WriteLine("Neu würfeln:");
            var rolls = new Dictionary<int, int>();
            for (var i = 1; i <= 6; i++)
            {
                rolls[i] = 0;
            }

            for (var i = 0; i < 60000; i++)
            {
                die.Roll();
                rolls[die.Value]++;
                //Console.WriteLine("Wert nach " + i + ". Wurf: " + die.Value);
            }

            for (var i = 1; i <= 6; i++)
            {
                Console.WriteLine("Zahl " + i + " wurde " + rolls[i] + " mal geworfen.");
            }

        }
    }
}
