using System.ComponentModel;

namespace ClassLibrary
{
    public class PropertyChangingEventArgs : PropertyChangedEventArgs
    {
        public object OldValue { get; private set; }

        public object NewValue { get; private set; }

        public bool Handled { get; set; }

        public PropertyChangingEventArgs(string propertyName, object oldValue, object newValue)
            : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
