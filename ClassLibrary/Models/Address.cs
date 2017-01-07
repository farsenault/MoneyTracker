using System;

namespace ClassLibrary.Models
{
    public class Address : ModelBase
    {
        #region fields

        private string _line1;
        private string _line2;
        private string _city;
        private string _state;
        private string _zip;

        #endregion

        #region properties

        public string Line1
        {
            get { return _line1; }
            set
            {
                if (OnPropertyChanging(nameof(Line1), _line1, value))
                {
                    _line1 = value;
                    OnPropertyChanged(nameof(Line1));
                }
            }
        }

        public string Line2
        {
            get { return _line2; }
            set
            {
                if (OnPropertyChanging(nameof(Line2), _line2, value))
                {
                    _line2 = value;
                    OnPropertyChanged(nameof(Line2));
                }
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (OnPropertyChanging(nameof(City), _city, value))
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (OnPropertyChanging(nameof(State), _state, value))
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                if (OnPropertyChanging(nameof(Zip), _zip, value))
                {
                    _zip = value;
                    OnPropertyChanged(nameof(Zip));
                }
            }
        }

        #endregion
    }
}
