using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Yahtzee;
using Yahtzee.Categories;

namespace YahtzeeWPF
{


    public class MainViewModel : NotifyPropertyChangedBase
    {
        public ScoreBoard _scoreBoard = new ScoreBoard();
        public ObservableCollection<YahtzeeModel> _dataGridList;
        private ObservableCollection<DiceModel> _diceDataGrid;
        internal string _textBox1Input;
        private DelegateCommand<string> _scoreclickCommand;
        private DelegateCommand<string> _rerollclickCommand;
        private DelegateCommand<string> _resetclickCommand;
        private DelegateCommand<string> _scratchCommand;
        private int[] _currentRoll;
        private readonly ClickCommandModel _clickCommandModel;
        public DiceModel _diceModel;
        private ImageSource _image1;
        private ImageSource _image2;
        private ImageSource _image3;
        private ImageSource _image4;
        private ImageSource _image5;


        public string TextBox1Input
        {
            get { return _textBox1Input; }
            set
            {
                if (_textBox1Input != value)
                {
                    _textBox1Input = value;
                    _scoreclickCommand.RaiseCanExecuteChanged();
                    _rerollclickCommand.RaiseCanExecuteChanged();
                    _resetclickCommand.RaiseCanExecuteChanged();
                    _scratchCommand.RaiseCanExecuteChanged();
                }

                OnPropertyChanged(nameof(TextBox1Input));
            }
        }

        public DelegateCommand<string> ScoreButtonclickCommand
        {
            get { return _scoreclickCommand; }
            set => _scoreclickCommand = value;
        }
        public DelegateCommand<string> RerollButtonClickCommand
        {
            get { return _rerollclickCommand; }
        }
        public DelegateCommand<string> ResetButtonClickCommand
        {
            get { return _resetclickCommand; }
        }

        public DelegateCommand<string> RerollButtonClickCommand
        {
            get { return _rerollclickCommand; }
            set => _rerollclickCommand = value;
        }

        public DelegateCommand<string> ResetButtonClickCommand
        {
            get { return _resetclickCommand; }
            set => _resetclickCommand = value;
        }

        public DelegateCommand<string> ScratchButtonClick
        {
            get { return _scratchCommand; }
            set => _scratchCommand = value;
        }

        public ObservableCollection<YahtzeeModel> DataGridList
        {
            get { return _dataGridList; }
            set
            {
                if (_dataGridList != value)
                {
                    _dataGridList = value;
                    OnPropertyChanged(nameof(DataGridList));
                }
            }
        }

        public ObservableCollection<DiceModel> DiceDataGrid
        {
            get => _diceDataGrid;
            set
            {
                if (_diceDataGrid != value)
                {
                    _diceDataGrid = value;
                    OnPropertyChanged(nameof(DiceDataGrid));
                }
            }
        }
        public ImageSource ImageSource1
        {

            get => _image1;
            set
            {
                if (ImageSource1 != value)
                {
                    _image1 = value;
                    OnPropertyChanged(nameof(ImageSource1));
                }
            }
        }

        public ImageSource ImageSource2
        {

            get => _image2;
            set
            {
                if (ImageSource2 != value)
                {
                    _image2 = value;
                    OnPropertyChanged(nameof(ImageSource2));
                }
            }
        }
        public ImageSource ImageSource3
        {

            get => _image3;
            set
            {
                if (ImageSource3 != value)
                {
                    _image3 = value;
                    OnPropertyChanged(nameof(ImageSource3));
                }
            }
        }
        public ImageSource ImageSource4
        {

            get => _image4;
            set
            {
                if (ImageSource4 != value)
                {
                    _image4 = value;
                    OnPropertyChanged(nameof(ImageSource4));
                }
            }
        }
        public ImageSource ImageSource5
        {

            get => _image5;
            set
            {
                if (ImageSource5 != value)
                {
                    _image5 = value;
                    OnPropertyChanged(nameof(ImageSource5));
                }
            }
        }

        public void ImageChanger()
        {
            ImageSource1 = _diceModel.ImageSwitchCase(_currentRoll[0]);
            ImageSource2 = _diceModel.ImageSwitchCase(_currentRoll[1]);
            ImageSource3 = _diceModel.ImageSwitchCase(_currentRoll[2]);
            ImageSource4 = _diceModel.ImageSwitchCase(_currentRoll[3]);
            ImageSource5 = _diceModel.ImageSwitchCase(_currentRoll[4]);
        }

        public int[] CurrentRoll
        {
            get => _currentRoll;
            set 
            {
                if (CurrentRoll != value)
                {
                    _currentRoll = value;
                    OnPropertyChanged(nameof(CurrentRoll));
                    ImageChanger();
                }
            }
        }

        public MainViewModel()
        {

            _clickCommandModel = new ClickCommandModel(this);
            _diceModel = new DiceModel(this);

            List<int> total = new List<int>();
            CurrentRoll = _diceModel.InitializeDice();
            Dictionary<ICategory, int?> scoreBoardDic = new ScoreBoard().GetNewScores();
            var scoreboardToYahtzeeModel = ScoreboardToYahtzeeModel(scoreBoardDic);

            var diceModels = DiceModels(_currentRoll);
            _diceDataGrid = new ObservableCollection<DiceModel>(diceModels);
            _dataGridList = new ObservableCollection<YahtzeeModel>(scoreboardToYahtzeeModel);
        }


        public IEnumerable<DiceModel> DiceModels(int[] initializeDice)
        {
            var diceModels = initializeDice.Select(d => new DiceModel(this)
            {
                Augenzahl = d
            });
            return diceModels;
        }

        

        public IEnumerable<YahtzeeModel> ScoreboardToYahtzeeModel(Dictionary<ICategory, int?> scoreBoardDic)
        {
            var scoreboardToYahtzeeModel = scoreBoardDic.Select(d => new YahtzeeModel
            {
                Category = d.Key,
                ScoreValue = d.Value
            });
            return scoreboardToYahtzeeModel;
        }

        public void TextBoxClear()
        {
            TextBox1Input = string.Empty;
        }

    }

    

    public class DelegateCommand<T> : System.Windows.Input.ICommand where T : class
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}