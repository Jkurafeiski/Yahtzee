using System;
using System.Collections.ObjectModel;
using System.Windows;
using Yahtzee;
using Yahtzee.Categories;

namespace YahtzeeWPF
{
    public class ClickCommandModel
    {
        private MainViewModel _mainViewModel;
        private int reRollTry = 0;
        private DiceModel _dice;
        private ICategory category;
        private int _endGame;

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
            _mainViewModel.ScratchButtonClick = new DelegateCommand<string>(
                (s) => { ScratchClickHandler(); }
            );
            _mainViewModel.DataGridRowClicker = new DelegateCommand<string>(
                (s) => { DataGridRowClickHandler(); }
            );
        }

        private void EndGame()
        {
            if (_endGame > 8)
            {
                MessageBox.Show("Du hast " + _mainViewModel._scoreBoard.TotalScore.ToString() + " Punkte");
            }
        }

        private void DataGridRowClickHandler()
        {
            try
            {
                if (_mainViewModel.CellInfoGiver.Column.DisplayIndex == 0)
                {
                    //  MessageBox.Show(((YahtzeeModel)_mainViewModel.CellInfoGiver.Item).Category.Name.ToString());
                    category = ((YahtzeeModel)_mainViewModel.CellInfoGiver.Item).Category;
                    _mainViewModel.SelectedCategoryTextBox = "Ausgewählt: " + category.Name;
                }
            }
            catch (ScoreBoardException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ScoreClickCommandHandler()
        {
            try
            {
                var convertedCategory = _mainViewModel._scoreBoard.CategoryConverter(category);
                _mainViewModel._scoreBoard.PutResultToBoard(_mainViewModel.CurrentRoll, convertedCategory);
                var updatedScoreboard = _mainViewModel._scoreBoard.GetNewScores();
                var scoreboardToYahtzeeModel = _mainViewModel.ScoreboardToYahtzeeModel(updatedScoreboard);
                _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(scoreboardToYahtzeeModel);
                reRollTry = 0;
                _endGame++;
                EndGame();
                _mainViewModel.SelectedCateGoryClearer();
                _dice.InitializeDice();
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (ScoreBoardException e)
            {
                MessageBox.Show(e.Message);
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
                    _mainViewModel.SelectedCateGoryClearer();
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
                    _mainViewModel.SelectedCateGoryClearer();
                    _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(_mainViewModel.ScoreboardToYahtzeeModel(_mainViewModel._scoreBoard.GetNewScores()));
                    reRollTry = 0;
                    break;
                }
                case MessageBoxResult.No:
                {
                    break;
                }
            }
        }

        private void ScratchClickHandler()
        {

            try
            {
                var convertedCategory = _mainViewModel._scoreBoard.CategoryConverter(category);
                _mainViewModel._scoreBoard.ScratchCategory(convertedCategory);
                _dice.InitializeDice();
                _mainViewModel.SelectedCateGoryClearer();
                _mainViewModel.DataGridList = new ObservableCollection<YahtzeeModel>(
                    _mainViewModel.ScoreboardToYahtzeeModel(_mainViewModel._scoreBoard.GetNewScores()));
                _mainViewModel.DiceDataGrid =
                    new ObservableCollection<DiceModel>(_mainViewModel.DiceModels(_mainViewModel.CurrentRoll));
                _endGame++;
                EndGame();
            }
            catch (ScoreBoardException e)
            {
                MessageBox.Show(e.Message);
            }

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