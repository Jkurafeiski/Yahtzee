using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Yahtzee;
using Yahtzee.Categories;

namespace YahtzeeWPF
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private ScoreBoard _scoreBoard = new ScoreBoard();
        private ObservableCollection<YahtzeeModel> _dataGridList;
        private ObservableCollection<DiceModel> _diceDataGrid;
        private string _textBox1Input;
        private readonly DelegateCommand<string> _scoreclickCommand;
        private readonly DelegateCommand<string> _rerollclickCommand;
        private readonly DelegateCommand<string> _resetclickCommand;
        private static readonly Dice Dice = new Dice();


        public string TextBox1Input
        {
            get { return _textBox1Input;}
            set
            {
                if (_textBox1Input != value)
                {
                    _textBox1Input = value;
                    _scoreclickCommand.RaiseCanExecuteChanged();
                    _resetclickCommand.RaiseCanExecuteChanged();
                    _rerollclickCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand<string> ScoreButtonclickCommand
        {
            get { return _scoreclickCommand; }
        }
        public DelegateCommand<string> RerollButtonClickCommand
        {
            get { return _rerollclickCommand; }
        }
        public DelegateCommand<string> ResetButtonClickCommand
        {
            get { return _resetclickCommand; }
        }

        public ObservableCollection<YahtzeeModel> DataGridList
        {
            get { return _dataGridList;}
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
                    OnPropertyChanged(nameof(DataGridList));
                }
            }
        }

        public MainViewModel()
        {
            List<int> total = new List<int>();
            var initializeDice = Dice.DiceRandomRoll();
            Dictionary<ICategory, int?> scoreBoardDic = new ScoreBoard().GetNewScores();
            var foo = scoreBoardDic.Select(d => new YahtzeeModel
            {
                Category = d.Key,
                ScoreValue = d.Value
            });

            var boo = initializeDice.Select(d => new DiceModel()
            {
                Augenzahl = d
            });

            _diceDataGrid = new ObservableCollection<DiceModel>(boo);
            _dataGridList = new ObservableCollection<YahtzeeModel>(foo);

            _scoreclickCommand = new DelegateCommand<string>(
                (s) =>
                { 
                    var result = new InputParser().GetSelectedCategory(_textBox1Input);
                    _scoreBoard.PutResultToBoard(initializeDice, result);
                },
                (s) => { return !string.IsNullOrEmpty(_textBox1Input); }
            );
            _rerollclickCommand = new DelegateCommand<string>(
                (s) =>
                {
                    try
                    {
                        initializeDice = _scoreBoard.CheckReRollTimes(_textBox1Input, initializeDice);
                    }
                    catch (ScoreBoardException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                },
                (s) => { return !string.IsNullOrEmpty(_textBox1Input); }
            );
            _resetclickCommand = new DelegateCommand<string>(
                (s) =>
                {
                    SafetyWindow win2 = new SafetyWindow();
                    win2.Show();
                },
                (s) => { return !string.IsNullOrEmpty(_textBox1Input); }
            );
        }
    }

    public class DiceModel
    {
        public int Augenzahl { get; set; }
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