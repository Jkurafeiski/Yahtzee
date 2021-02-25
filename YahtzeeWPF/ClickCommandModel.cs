using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Yahtzee;

namespace YahtzeeWPF
{
    public class ClickCommandModel
    {
        private MainViewModel _mainViewModel;
        private int reRollTry = 0;
        private DiceModel _dice;

        public ClickCommandModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _dice = new DiceModel(_mainViewModel);
            ClickCommandHandler();
        }

        private void ClickCommandHandler()
        {
            _mainViewModel.ScoreButtonclickCommand = ScoreClickCommandHandler();
            _mainViewModel.RerollButtonClickCommand = new DelegateCommand<string>(
                (s) =>
                {
                    _mainViewModel.CurrentRoll = ReRollClickHandler();
                    _mainViewModel.DiceDataGrid =
                        new ObservableCollection<DiceModel>(_mainViewModel.DiceModels(_mainViewModel.CurrentRoll));
                },
                (s) => { return !string.IsNullOrEmpty(_mainViewModel.TextBox1Input); }
            );
            _mainViewModel.ResetButtonClickCommand = new DelegateCommand<string>(
                (s) => { ResetClickHandler(); }
            );
            _mainViewModel.ScratchButtonClick = ScratchClickHandler();
        }

        private DelegateCommand<string> ScoreClickCommandHandler()
        {
            return new DelegateCommand<string>(
                (s) =>
                {
                    try
                    {
                        var result = CategoryGetter();
                        _mainViewModel._scoreBoard.PutResultToBoard(_mainViewModel.CurrentRoll, result);
                        var updatedScoreboard = _mainViewModel._scoreBoard.GetNewScores();
                        var scoreboardToYahtzeeModel = _mainViewModel.ScoreboardToYahtzeeModel(updatedScoreboard);
                        _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(scoreboardToYahtzeeModel);
                        _mainViewModel.TextBoxClear();
                        reRollTry = 0;
                        _dice.InitializeDice();
                    }
                    catch (ArgumentException e)
                    {
                        MessageBox.Show(e.Message);
                        _mainViewModel.TextBoxClear();
                    }
                    catch (ScoreBoardException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                },
                (s) => { return !string.IsNullOrEmpty(_mainViewModel._textBox1Input); }
            );
        }

        private YahtzeeCategory CategoryGetter()
        {
            if (new InputParser().GetSelectedCategory(_mainViewModel._textBox1Input) != YahtzeeCategory.Empty)
            {
                var result = new InputParser().GetSelectedCategory(_mainViewModel._textBox1Input);
                return result;
            }
            else
            {
                throw new ArgumentException("Falsche eingabe. Geb besser was richtiges ein");
            }


        }

        private int[] ReRollClickHandler()
        {
            try
            {
                if (reRollTry < 3)
                {
                    _mainViewModel.CurrentRoll = _dice.CheckReRollTimes(_mainViewModel._textBox1Input, _mainViewModel.CurrentRoll);
                    reRollTry++;
                    _mainViewModel.ImageChanger();
                    _mainViewModel.TextBoxClear();
                }
                else
                {
                    throw new ScoreBoardException("Du kannst nur drei mal neu rollen");
                }
            }
            
            catch (ScoreBoardException e)
            {
                MessageBox.Show(e.Message);
            }

            return _mainViewModel.CurrentRoll;
        }

        private void ResetClickHandler()
        {
            string msgtext = "Bist du sicher ?";
            string txt = "Sicherheits Box";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(msgtext, txt, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                {
                    _mainViewModel._scoreBoard.Reset();
                    _dice.InitializeDice();
                    _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(_mainViewModel.ScoreboardToYahtzeeModel(_mainViewModel._scoreBoard.GetNewScores()));
                    reRollTry = 0;
                    _mainViewModel.TextBoxClear();
                        break;
                }
                case MessageBoxResult.No:
                {
                    break;
                }
            }
        }

        private DelegateCommand<string> ScratchClickHandler()
        {
            return new DelegateCommand<string>(
                (s) =>
                {
                    try
                    {
                        var result = CategoryGetter();
                        _mainViewModel._scoreBoard.ScratchCategory(result);
                        _mainViewModel.TextBoxClear();
                        _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(_mainViewModel.ScoreboardToYahtzeeModel(_mainViewModel._scoreBoard.GetNewScores()));
                    }
                    catch (ScoreBoardException e)
                    {
                        MessageBox.Show(e.Message);
                        _mainViewModel.TextBoxClear();
                    }
                },
                (s) => { return !string.IsNullOrEmpty(_mainViewModel._textBox1Input); }
            );
        }
    }
}