using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Yahtzee;
using Yahtzee.Categories;

namespace YahtzeeWPF
{
    public class ClickCommandModel
    {
        private MainViewModel _mainViewModel;
        private int reRollTry = 0;
        private DiceModel _dice;
        private List<int> _diceList = new List<int>();
        private ICategory category;

        public ClickCommandModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _dice = new DiceModel(_mainViewModel);
            ClickCommandHandler();
        }

        private void ClickCommandHandler()
        {
            _mainViewModel.ScoreButtonclickCommand = new DelegateCommand<string>(
                (s) => { ScoreClickCommandHandler(); }
            );

            _mainViewModel.RerollButtonClickCommand = new DelegateCommand<string>(
                (s) => { ReRollClickHandler(); }
            );
            _mainViewModel.ResetButtonClickCommand = new DelegateCommand<string>(
                (s) => { ResetClickHandler(); }
            );
            _mainViewModel.ScratchButtonClick = ScratchClickHandler();
            _mainViewModel.DataGridRowClicker = new DelegateCommand<string>(
                (s) => { DataGridRowClickHandler(); }
            );
        }

        private void DataGridRowClickHandler()
        {
            if (_mainViewModel.CellInfoGiver.Column.DisplayIndex == 0)
            {
               //  MessageBox.Show(((YahtzeeModel)_mainViewModel.CellInfoGiver.Item).Category.Name.ToString());
               category = ((YahtzeeModel) _mainViewModel.CellInfoGiver.Item).Category;
            }
           
        }

        private void ScoreClickCommandHandler()
        {
            try
            {
                _mainViewModel._scoreBoard.PutResultToBoard(_mainViewModel.CurrentRoll, category);
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

        private void ReRollClickHandler()
        {
            try
            {
                if (reRollTry < 3)
                {
                    var rerollInput = _mainViewModel.ReRollSwitches();
                    _mainViewModel.CurrentRoll = _dice.CheckReRollTimes(rerollInput, _mainViewModel.CurrentRoll);
                    reRollTry++;
                    _mainViewModel.DiceDataGrid =
                        new ObservableCollection<DiceModel>(_mainViewModel.DiceModels(_mainViewModel.CurrentRoll));
                    _mainViewModel.ImageChanger();
                    _mainViewModel.TextBoxClear();
                    BorderBrushReset();
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
                        _dice.InitializeDice();
                        _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(_mainViewModel.ScoreboardToYahtzeeModel(_mainViewModel._scoreBoard.GetNewScores()));
                        _mainViewModel.DiceDataGrid = new ObservableCollection<DiceModel>(_mainViewModel.DiceModels(_mainViewModel.CurrentRoll));
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

        private void BorderBrushReset()
        {
            _mainViewModel.Dice1ButtonSelected = false;
            _mainViewModel.Dice2ButtonSelected = false;
            _mainViewModel.Dice3ButtonSelected = false;
            _mainViewModel.Dice4ButtonSelected = false;
            _mainViewModel.Dice5ButtonSelected = false;

        }
    }
}