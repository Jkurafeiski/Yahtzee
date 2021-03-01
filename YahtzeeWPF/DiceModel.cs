using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Yahtzee;

namespace YahtzeeWPF
{
    public class DiceModel
    {
        public int Augenzahl { get; set; }
        private MainViewModel _mainViewModel;
        private readonly Dice _dice = new Dice();
        

        public DiceModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public int[] CheckReRollTimes(string userInput, int[] initializeDice)
        {
            if (userInput == null)
            {
                throw new ScoreBoardException("Du musst schon ein würfel auswählen");
            }
            var convertedRerollDices = new InputParser().GetDiceForReroll(userInput);
            var newInitializeDice = DiceReRollHandler(convertedRerollDices, initializeDice);
            return newInitializeDice;
        }

        private int[] DiceReRollHandler(int[] toReRoll, int[] initializeDice)
        {
            foreach (var reRoll in toReRoll)
            {
                initializeDice[reRoll - 1] = _dice.DiceRandomReRoll();
            }
            return initializeDice;
        }
        internal int[] InitializeDice()
        {
            _mainViewModel.CurrentRoll = _dice.DiceRandomRoll();
            //var initializeDice = new int[]{1,2,3,4,5};
            _mainViewModel.DiceDataGrid = new ObservableCollection<DiceModel>(_mainViewModel.DiceModels(_mainViewModel.CurrentRoll));
            return _mainViewModel.CurrentRoll;
        }


        public ImageSource ImageSwitchCase(int dice)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            switch (dice)
            {
                case 1:
                    var _image1 = new BitmapImage(new Uri(Path.Combine(outPutDirectory, "DiceImages/Dice1.png"), UriKind.RelativeOrAbsolute));
                    return _image1;
                case 2:
                    var _image2 = new BitmapImage(new Uri(Path.Combine(outPutDirectory, "DiceImages/Dice2.png"), UriKind.RelativeOrAbsolute));
                    return _image2;
                case 3:
                    var _image3 = new BitmapImage(new Uri(Path.Combine(outPutDirectory, "DiceImages/Dice3.png"), UriKind.RelativeOrAbsolute));
                    return _image3; 
                case 4:
                    var _image4 = new BitmapImage(new Uri(Path.Combine(outPutDirectory, "DiceImages/Dice4.jpg"), UriKind.RelativeOrAbsolute));
                    return _image4; 
                case 5:
                    var _image5 = new BitmapImage(new Uri(Path.Combine(outPutDirectory, "DiceImages/Dice5.png"), UriKind.RelativeOrAbsolute));
                    return _image5; 
                case 6:
                    var _image6 = new BitmapImage(new Uri(Path.Combine(outPutDirectory, "DiceImages/Dice6.png"), UriKind.RelativeOrAbsolute));
                    return _image6; 
                default:
                    return null;
            }
        }
    }
}