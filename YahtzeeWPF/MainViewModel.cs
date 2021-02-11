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
        private readonly DelegateCommand<string> _clickCommand;
        private static readonly Dice Dice = new Dice();
        public string TextBox1Input
        {
            get { return _textBox1Input;}
            set
            {
                if (_textBox1Input != value)
                {
                    _textBox1Input = value;
                    _clickCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand<string> ButtonClickCommand
        {
            get { return _clickCommand; }
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

            _clickCommand = new DelegateCommand<string>(
                (s) =>
                { 
                    var result = new InputParser().GetSelectedCategory(_textBox1Input);
                    _scoreBoard.PutResultToBoard(initializeDice, result);
                }, //Execute
                (s) => { return !string.IsNullOrEmpty(_textBox1Input); } //CanExecute
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