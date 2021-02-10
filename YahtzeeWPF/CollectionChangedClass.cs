using System.Collections.Specialized;

namespace YahtzeeWPF
{
    public class CollectionChangedClass : INotifyCollectionChanged
    {
        #region INotifyCollectionChanged

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }

        #endregion INotifyCollectionChanged
    }
}