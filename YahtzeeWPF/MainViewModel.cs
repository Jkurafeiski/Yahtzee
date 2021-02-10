using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Yahtzee;
using Yahtzee.Categories;

namespace YahtzeeWPF
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<YahtzeeModel> _dataGridList;

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

        public MainViewModel()
        {
            Dictionary<ICategory, int?> scoreBoardDic = new ScoreBoard().GetNewScores();
            var foo = scoreBoardDic.Select(d => new YahtzeeModel
            {
                Category = d.Key,
                ScoreValue = d.Value
            });
            
            _dataGridList = new ObservableCollection<YahtzeeModel>(foo);
        }
    }
}