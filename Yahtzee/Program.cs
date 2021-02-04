using System;

namespace Yahtzee
{
    class Program
    {
        private static bool _reRollRun;
        private static readonly Dice Dice = new Dice();
        private static readonly ScoreBoard ScoreBoardGiver = new ScoreBoard();
        private static readonly Program ProgramInitializer = new Program();
        private static int _reRollTry;
        private static readonly InputParser InputParser = new InputParser();
        static void Main()
        {
            for (int reRuns = 0; reRuns < 10; reRuns++)
            {
                var wantsToContinue = ProgramInitializer.GameBoardRun(null, false);
                if (!wantsToContinue)
                {
                    break;
                }
            }
        }

        private bool GameBoardRun(int[] initializeDice, bool reRollRun)
        {
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
            var selectedOption = InputParser.ParseInput(userInput);
            if (selectedOption == InputParser.Option.ReRoll)
            {
                try
                {
                    CheckReRollTimes(userInput, initializeDice);
                }
                catch (ScoreBoardException e)
                {
                    Console.WriteLine(e.Message);
                    ProgramInitializer.GameBoardRun(initializeDice, true);
                }
                
            }
            else if (selectedOption == InputParser.Option.Quit)
            {
                try
                {
                    Console.WriteLine("Bist du sicher ? J / N");
                    var safetyInput = Console.ReadLine();
                    safetyInput = safetyInput.ToUpper();
                    if (InputParser.AskForSafetyInput(safetyInput))
                    {
                        return false;
                    }
                    else
                    {
                        throw new ScoreBoardException("Muss schon eine Richtige eingabe sein");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    ProgramInitializer.GameBoardRun(initializeDice, true);
                }
                
            }
            else if (selectedOption == InputParser.Option.Restart)
            {
                try
                {
                    Console.WriteLine("Bist du sicher ? J / N");
                    var safetyInput = Console.ReadLine();
                    safetyInput = safetyInput.ToUpper();
                    if (InputParser.AskForSafetyInput(safetyInput))
                    {
                        Console.WriteLine("Dann mach eine neue Eingabe");
                        ProgramInitializer.GameBoardRun(initializeDice, true);
                    }
                    
                }
                catch (ScoreBoardException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    ProgramInitializer.GameBoardRun(initializeDice, true);
                }
            }
            else if (selectedOption == InputParser.Option.Category)
            {
                YahtzeeCategory selectedCategory = InputParser.GetSelectedCategory(userInput);
                ScoreBoardGiver.PutResultToBoard(initializeDice, selectedCategory);
                _reRollTry = 0;
                ScoreBoardGiver.PrintScoreBoard();
            }

            return true;
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
            Console.WriteLine("Wenn du einen Würfel neu Rollen willst, dann schreibe die Stelle an der der Würfel ist und ein 'r' davor");
            Console.WriteLine("Aber nur drei mal!");
            Console.WriteLine("Du kannst du das Spiel auch mit 'z' zurücksetzten oder mit 'q' die Anwendung verlassen");
        }

        private void CheckReRollTimes(string userInput, int[] initializeDice)
        {
            
            if (_reRollTry < 3)
            {
                var convertedRerollDices = InputParser.GetDiceForReroll(userInput);
                _reRollTry ++;
                DiceReRollHandler(convertedRerollDices, initializeDice);
            }
            else
            {
                throw new ScoreBoardException("Zu oft neu gerollt"); 
            }
        }
        private void DiceReRollHandler(int[] toReRoll, int[] initializeDice)
        {
            foreach (var reRoll in toReRoll)
            {
                initializeDice[reRoll - 1] = Dice.DiceRandomReRoll();
            }
            _reRollRun = true;
            ProgramInitializer.GameBoardRun(initializeDice, _reRollRun);
        }
    }
}
