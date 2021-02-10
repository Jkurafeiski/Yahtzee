using System.ComponentModel;

namespace YahtzeeWPF
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
    }
}