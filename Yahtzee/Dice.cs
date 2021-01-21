using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Yahtzee
{
    public class Dice
    {
        private readonly Random _random;

        public Dice()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }


        public int[] DiceRandomRoll()
        {
            var diceNumber1 = _random.Next(1, 7);
            var diceNumber2 = _random.Next(1, 7);
            var diceNumber3 = _random.Next(1, 7);
            var diceNumber4 = _random.Next(1, 7);
            var diceNumber5 = _random.Next(1, 7);

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

        public int DiceRandomReRoll()
        {
           var diceReRoll = _random.Next(1, 7);
           return diceReRoll;
        }

    }
}
