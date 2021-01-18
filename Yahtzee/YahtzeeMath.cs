﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Yahtzee
{
    public class YahtzeeMath
    {

        private readonly Dictionary<string, int> yahtzeeDictionary;
        public YahtzeeMath()
        {
            yahtzeeDictionary = new Dictionary<string, int>()
            {
                {"Pair", 1},
                {"DoublePair", 5},
                {"ThreeOfAKind", 10},
                {"FourOfAKind", 50},
                {"Yahtzee", 100},
                {"FullHouse", 500},
                {"SmallStreet", 15},
                {"LargeStreet", 20}
            };

        }
    
        public int YahtzeePointCalculator(string dice)
        {
            Array.Sort(dice);
            
            if (dice[0] == 0)
            {
                throw new ArgumentOutOfRangeException("da stimmt was nicht");
            }
        }
    }
}