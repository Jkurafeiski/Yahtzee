using System;
using System.Collections.Generic;

namespace Yahtzee
{
    public class InputParser
    {
        public Option ParseInput(string userInput)
        {
            userInput = userInput.ToUpper();
            if (userInput.Length == 0)
            {
                return Option.Unknown;
            }

            if (userInput.StartsWith("R"))
            {
                return Option.ReRoll;
            }
            
            if (userInput.StartsWith("Z"))
            {
                return Option.Restart;
            }

            if (userInput.StartsWith("Q"))
            {
                return Option.Quit;
            }

            if (char.IsDigit(userInput[0]))
            {
                return Option.Category;
            }

            return Option.Unknown;
        }

        public int[] GetDiceForReroll(string userInput)
        {
            if (userInput.StartsWith("R"))
            {
                userInput = userInput.Substring(1);
            }
            List<int> reRollDiceList = new List<int>();
            var reRollDie = userInput.ToCharArray();
            foreach (var die in reRollDie)
            {
                var charArrayConvertedToInt = (int)char.GetNumericValue(die);
                if (charArrayConvertedToInt >= 1 && charArrayConvertedToInt <= 5)
                {
                    reRollDiceList.Add(charArrayConvertedToInt);
                }
            }
            int[] reRollDiceArray = reRollDiceList.ToArray();
            return reRollDiceArray;
        }

        public YahtzeeCategory GetSelectedCategory(string userInput)
        {
            if (userInput.Length > 0 && int.TryParse(userInput, out var input))
            {
                if (Enum.IsDefined(typeof(YahtzeeCategory), input))
                {
                    return (YahtzeeCategory) input;
                }
            }

            throw new ArgumentException("input not valid");
        }
        public bool AskForSafetyInput(string safetyInput)
        {
            
            if (safetyInput == "J")
            {
                return true;
            }
            else if (safetyInput == "N")
            {
                
                return false;
            }
            else
            {
                throw new ScoreBoardException("Du musst schon richtig bestätigen!");
            }
        }

        public enum Option
        {
            Unknown,
            Category,
            ReRoll,
            Quit,
            Restart
        }
    }
}