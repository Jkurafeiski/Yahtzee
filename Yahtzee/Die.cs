using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Yahtzee
{
    public class Die
    {
        private Random Randy;

        public Die()
        {
        }

        public Die(Random randy)
        {
            Randy = randy;
        }

        public int[] DiceRandomRoll()
        {
            var diceNumber1 = Randy.Next(1, 6);
            var diceNumber2 = Randy.Next(1, 6);
            var diceNumber3 = Randy.Next(1, 6);
            var diceNumber4 = Randy.Next(1, 6);
            var diceNumber5 = Randy.Next(1, 6);

            int[] diceValues = new int[5]
            {
                diceNumber1,
                diceNumber2,
                diceNumber3,
                diceNumber4,
                diceNumber5
            };

            return diceValues;
        }

    }
}
