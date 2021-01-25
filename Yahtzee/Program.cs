using System;
using System.Collections.Generic;

namespace Yahtzee
{
    class Program
    {
        private static bool _reRollRun = false;
        private static int[] scoreValue;
        private static readonly Dice Dice = new Dice();
        private static readonly List<int> ScoreList = new List<int>();

        static void Main()
        {
            for (int reRuns = 0; reRuns < 10; reRuns++)
            {
                GameBoardRun(null, false);
            }
        }

        private static void GameBoardRun(int[] initializeDice, bool reRollRun)
        {
            int score = 0;
            
            if (!reRollRun)
            {
                initializeDice = Dice.DiceRandomRoll();
            }

            foreach (var dieRolls in initializeDice)
            {
                Console.Write(dieRolls + " ");
            }

            ShowPossibleInputs();

            var userInput = Console.ReadLine()?.ToUpper();
            Console.Clear();
            if (userInput.StartsWith("R"))
            {
                var convertedRerollDices = DiceReRollConverter(userInput);
                DiceReRollHandler(convertedRerollDices, initializeDice);
            }

            YahtzeeInputRuler convertedInput = YahtzeeInputHandler(userInput);
            var scoreValuesAfterCalc = new YahtzeeMath().YahtzeePointCalculator(initializeDice,convertedInput);
            

            ScoreList.Add(scoreValuesAfterCalc);
            foreach (int number in ScoreList)
            {
                score += number;
            }

            reRollRun = false;
            Console.WriteLine("Deine Punkte sind " + score);
        }

        private static int[] DiceReRollHandler(int[] diceToReRoll, int[] initializeDice)
        {
            foreach (var reRoll in diceToReRoll)
            {
                initializeDice[reRoll - 1] = Dice.DiceRandomReRoll();
            }
            _reRollRun = true;
            GameBoardRun(initializeDice, _reRollRun);
            return initializeDice;
            
        }

        private static int[] DiceReRollConverter(string userInput)
        {
            List<int> reRollDiceList = new List<int>();
            var reRollDie = userInput.Substring(1, userInput.Length-1).ToCharArray();
            foreach (var die in reRollDie)
            {
                var charArrayConvertedToInt = (int) char.GetNumericValue(die);
                if (charArrayConvertedToInt >= 1 && charArrayConvertedToInt <= 5)
                {
                 reRollDiceList.Add(charArrayConvertedToInt);
                }
            }
            int[] reRollDiceArray = reRollDiceList.ToArray();
            return reRollDiceArray;

        }

        private static void ShowPossibleInputs()
        {
            Console.WriteLine();
            Console.WriteLine("Als was möchtest du es jetzt gezählt haben ?");
            Console.WriteLine("1 Summiert");
            Console.WriteLine("2 Paar");
            Console.WriteLine("3 Drei Gleich");
            Console.WriteLine("4 Vier gleich");
            Console.WriteLine("5 Kniffel");
            Console.WriteLine("6 FullHouse");
            Console.WriteLine("7 Kleine Straße");
            Console.WriteLine("8 Große Straße Straße");
            Console.WriteLine("9 Doppeltes Paar");
            Console.WriteLine("Wenn du einen Würfel neu Rollen willst, dann schreibe die Stelle an der der Würfel ist und ein r davor");
        }

        private static YahtzeeInputRuler YahtzeeInputHandler(string input)
        {
            if (int.TryParse(input, out int yahtzeeResult))
            {
                return YahtzeeEnumChecker(yahtzeeResult);
            }

            return 0;

        }

        private static YahtzeeInputRuler YahtzeeEnumChecker(int yahtzeeResult)
        {
            if (Enum.IsDefined(typeof(YahtzeeInputRuler), yahtzeeResult))
            {
                YahtzeeInputRuler myYahtzee = (YahtzeeInputRuler) yahtzeeResult;
                return myYahtzee;
            }

            throw new ArgumentOutOfRangeException("yahtzeeResult", "Das ist keine gültige Nummer");
        }
    }
}
