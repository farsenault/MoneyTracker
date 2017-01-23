using System;
using System.Collections.ObjectModel;

namespace ClassLibrary.Models
{
    public class ScheduledTransaction : ModelBase
    {
        #region fields

        private string _name;
        private string _memo;
        private Frequency _frequency;
        private Guid _fromAccountId;
        private Guid _toAccountId;
        private ObservableCollection<ScheduledTransactionDetail> _details = new ObservableCollection<ScheduledTransactionDetail>();
        private bool _isEnabled;
        private ObservableCollection<DateTime> _disabledDates = new ObservableCollection<DateTime>();

        #endregion

        #region properties

        public string Name
        {
            get { return _name; }
            set
            {
                if (OnPropertyChanging(nameof(Name), _name, value))
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Memo
        {
            get { return _memo; }
            set
            {
                if (OnPropertyChanging(nameof(Memo), _memo, value))
                {
                    _memo = value;
                    OnPropertyChanged(nameof(Memo));
                }
            }
        }

        public Frequency Frequency
        {
            get { return _frequency; }
            set
            {
                if (OnPropertyChanging(nameof(Frequency), _frequency, value))
                {
                    _frequency = value;
                    OnPropertyChanged(nameof(Frequency));
                }
            }
        }

        public Guid FromAccountId
        {
            get { return _fromAccountId; }
            set
            {
                if (OnPropertyChanging(nameof(FromAccountId), _fromAccountId, value))
                {
                    _fromAccountId = value;
                    OnPropertyChanged(nameof(FromAccountId));
                }
            }
        }

        public Guid ToAccountId
        {
            get { return _toAccountId; }
            set
            {
                if (OnPropertyChanging(nameof(ToAccountId), _toAccountId, value))
                {
                    _toAccountId = value;
                    OnPropertyChanged(nameof(ToAccountId));
                }
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public ObservableCollection<ScheduledTransactionDetail> Details
        {
            get { return _details; }
            set
            {
                if (OnPropertyChanging(nameof(Details), _details, value))
                {
                    _details = value;
                    OnPropertyChanged(nameof(Details));
                }
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                if (OnPropertyChanging(nameof(IsEnabled), _isEnabled, value))
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public ObservableCollection<DateTime> DisabledDates
        {
            get
            {
                return _disabledDates;
            }

            set
            {
                if (OnPropertyChanging(nameof(DisabledDates), _disabledDates, value))
                {
                    _disabledDates = value;
                    OnPropertyChanged(nameof(DisabledDates));
                }
            }
        }

        #endregion
    }
}
