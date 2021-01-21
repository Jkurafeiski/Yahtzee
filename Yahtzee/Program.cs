using System;
using System.Collections.Generic;

namespace Yahtzee
{
    class Program
    {
        private static int[] _initializeDice;
        private static bool reRollRun = false;
        private static int[] scoreValue;
        private static readonly Dice Dice = new Dice();
        private static readonly List<int> ScoreList = new List<int>();

        static void Main()
        {
            for (int reRuns = 0; reRuns < 10; reRuns++)
            {
                GameBoardRun(null, false);
            }
            


            /*var die = new Die();
            Console.WriteLine("Neuer Würfel: " + die.Value);
            Console.WriteLine("Neu würfeln:");
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
            }*/
        }

        private static void GameBoardRun(int[] _initializeDice, bool reRollRun)
        {
            int score = 0;
            
            if (!reRollRun)
            {
                _initializeDice = Dice.DiceRandomRoll();
            }

            foreach (var dieRolls in _initializeDice)
            {
                Console.Write(dieRolls + " ");
            }

            ShowPossibleInputs();

            var userInput = Console.ReadLine();
            Console.Clear();
            int convertedInput = YahtzeeInputHandler(userInput);
            if (convertedInput == 0)
            {
                DiceReRollChecker(userInput, _initializeDice);
            }



            ScoreList.Add(convertedInput);
            foreach (int number in ScoreList)
            {
                score += number;
            }

            reRollRun = false;
            Console.WriteLine("Deine Punkte sind " + score);
        }

        private static void DiceReRollChecker(string userInput, int[] _initializeDice)
        {
            if (DiceReRollHandler(userInput, _initializeDice) == null)
            {
                Console.WriteLine("Schreib schon was richtiges!");
            }

            var reRolledDices = DiceReRollHandler(userInput, _initializeDice);
            _initializeDice = reRolledDices;
            Console.WriteLine(_initializeDice);
            GameBoardRun(_initializeDice, true);
            
        }

        private static int[] DiceReRollHandler(string input, int[] oldRoles)
        {
            if (input == "r1")
            {
                var newRoll = Dice.DiceRandomReRoll();
                oldRoles[0] = newRoll;
                return oldRoles;
            }
            else if (input == "r2")
            {
                var newRoll = Dice.DiceRandomReRoll();
                oldRoles[1] = newRoll;
                return oldRoles;
            }
            else if (input == "r3")
            {
                var newRoll = Dice.DiceRandomReRoll();
                oldRoles[2] = newRoll;
                return oldRoles;
            }
            else if (input == "r4")
            {
                var newRoll = Dice.DiceRandomReRoll();
                oldRoles[3] = newRoll;
                return oldRoles;
            }
            else if (input == "r5")
            {
                var newRoll = Dice.DiceRandomReRoll();
                oldRoles[4] = newRoll;
                return oldRoles;
            }
            else
            {
                return null;
            }
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

        private static int YahtzeeInputHandler(string input)
        {
            if (int.TryParse(input, out int yahtzeeResult))
            {
                return YahtzeeEnumChecker(yahtzeeResult);
            }
            else
            {
                return 0;
            }

        }

        private static int YahtzeeEnumChecker(int yahtzeeResult)
        {
            if (Enum.IsDefined(typeof(YahtzeeInputRuler), yahtzeeResult))
            {
                YahtzeeInputRuler myYahtzee = (YahtzeeInputRuler) yahtzeeResult;
                return yahtzeeResult;
            }
            else
            {
                throw new ArgumentOutOfRangeException("NotTheNumber", "Das ist keine gültige Nummer");
            }
        }
    }
}
