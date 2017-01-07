using System.ComponentModel;

namespace ClassLibrary
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged, INotifyOnPropertyChanging
    {
        /// <summary>
        /// Raised before the value of a property is changed
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;
        /// <summary>
        /// Raised after the value of a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called before the value of a property is changed.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns>false if Handled, otherwise true</returns>
        protected virtual bool OnPropertyChanging(string propertyName, object oldValue, object newValue)
        {
            if (((oldValue == null) && (newValue == null))
                || ((oldValue != null) && oldValue.Equals(newValue)))
            {
                return false; // exit early if value does not differ, return false to diallow OnPropertyChanged from being called.
            }

            var args = new PropertyChangingEventArgs(propertyName, oldValue, newValue);
            PropertyChanging?.Invoke(this, args);
            return !args.Handled;
        }

        /// <summary>
        /// Called after the value of a property is changed.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }              

        protected NotifyPropertyChangedBase()
        {

        }
    }
}
