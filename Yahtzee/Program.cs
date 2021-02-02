using System;
using System.Collections.Generic;

namespace Yahtzee
{
    class Program
    {
        private static bool _reRollRun = false;
        private static readonly Dice Dice = new Dice();
        private static readonly List<int> ScoreList = new List<int>();
        private ScoreBoard scoreBoard = new ScoreBoard();
        private static readonly Program programInitializer = new Program();
        static void Main()
        {
            for (int reRuns = 0; reRuns < 10; reRuns++)
            {
                var wantsToContinue = programInitializer.GameBoardRun(null, false);
                if (!wantsToContinue)
                {
                    break;
                }
            }
        }

        private bool GameBoardRun(int[] initializeDice, bool reRollRun)
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
            var inputParser = new InputParser();
            Console.Clear();
            var selectedOption = inputParser.ParseInput(userInput);
            if (selectedOption == InputParser.Option.ReRoll)
            {
                var convertedRerollDices = inputParser.GetDiceForReroll(userInput);
                DiceReRollHandler(convertedRerollDices, initializeDice);
            }
            else if (selectedOption == InputParser.Option.Quit)
            {
                return false;
            }
            else if (selectedOption == InputParser.Option.Category)
            {
                YahtzeeCategory selectedCategory = inputParser.GetSelectedCategory(userInput);

                var scoreValuesAfterCalc = new YahtzeeMath().YahtzeePointCalculator(initializeDice, selectedCategory);
                scoreBoard.AddScore(selectedCategory, scoreValuesAfterCalc);

                ScoreList.Add(scoreValuesAfterCalc);
                foreach (int number in ScoreList)
                {
                    score += number;
                }
                scoreBoard.PrintScoreBoard(score);
                reRollRun = false;
                //Console.WriteLine("Deine Punkte sind " + score);
            }

            return true;
        }

        private int[] DiceReRollHandler(int[] diceToReRoll, int[] initializeDice)
        {
            foreach (var reRoll in diceToReRoll)
            {
                initializeDice[reRoll - 1] = Dice.DiceRandomReRoll();
            }
            _reRollRun = true;
            programInitializer.GameBoardRun(initializeDice, _reRollRun);
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

        private static YahtzeeCategory YahtzeeInputHandler(string input)
        {
            if (int.TryParse(input, out int yahtzeeResult))
            {
                return YahtzeeEnumChecker(yahtzeeResult);
            }

            return 0;

        }

        private static YahtzeeCategory YahtzeeEnumChecker(int yahtzeeResult)
        {
            if (Enum.IsDefined(typeof(YahtzeeCategory), yahtzeeResult))
            {
                YahtzeeCategory myYahtzee = (YahtzeeCategory) yahtzeeResult;
                return myYahtzee;
            }

            throw new ArgumentOutOfRangeException("yahtzeeResult", "Das ist keine gültige Nummer");
        }
    }
}
